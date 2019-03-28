using InterviewMe.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace InterviewMe.SharedKernel
{
    public static class DomainEvents
    {
        private static List<Type> staticEventHandlers;
        private static List<Type> staticCommitedEventHandlers;

        [ThreadStatic] //each thread has its own callbacks
        private static List<Delegate> dynamicEventHandlers;

        [ThreadStatic] //each thread has its own callbacks
        private static List<Delegate> dynamicCommitedEventHandlers;

        [ThreadStatic] //each thread has its own callbacks
        private static Queue<IDomainEvent> commitedEvents;

        static DomainEvents()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();

            staticEventHandlers = types
                .Where(x => x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IDomainEventHandler<>)))
                .ToList();

            staticCommitedEventHandlers = types
                .Where(x => x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(ICommitedDomainEventHandler<>)))
                .ToList();
        }


        /// <summary>
        /// Registers a callback for the given domain event
        /// </summary>
        /// <typeparam name="T">The IDomainEvent to Register handler for</typeparam>
        /// <param name="eventHandler">The IDomainEventHandler for the domain event</param>
        public static void Register<T>(Action<T> eventHandler) where T : IDomainEvent
        {
            if (dynamicEventHandlers == null)
            {
                dynamicEventHandlers = new List<Delegate>();
            }

            dynamicEventHandlers.Add(eventHandler);
        }

        /// <summary>
        /// Registers a callback for the given domain event as commited event handler
        /// </summary>
        /// <typeparam name="T">The IDomainEvent to Register handler for</typeparam>
        /// <param name="eventHandler">The IDomainEventHandler for the domain event</param>
        public static void RegisterCommited<T>(Action<T> eventHandler) where T : IDomainEvent
        {
            if (dynamicCommitedEventHandlers == null)
            {
                dynamicCommitedEventHandlers = new List<Delegate>();
            }

            dynamicCommitedEventHandlers.Add(eventHandler);
        }

        /// <summary>
        /// Delete all dynamic registered handlers
        /// </summary>
        public static void ClearHandlers()
        {
            dynamicEventHandlers = null;
            commitedEvents = null;
        }

        /// <summary>
        /// Raise a DomainEvent
        /// </summary>
        /// <typeparam name="T">The IDomainEvent Type</typeparam>
        /// <param name="domainEvent">The domain event</param>
        public static void Raise<T>(T domainEvent) where T : IDomainEvent
        {
            //Raise static Handlers first
            foreach (var handler in staticEventHandlers)
            {
                if (typeof(IDomainEventHandler<T>).IsAssignableFrom(handler))
                {
                    IDomainEventHandler<T> instance = (IDomainEventHandler<T>)Activator.CreateInstance(handler);
                    instance.Handle(domainEvent);
                }
            }

            //Raise dynamic handlers
            if (dynamicEventHandlers != null)
            {
                foreach (var handler in dynamicEventHandlers)
                {
                    if (handler is Action<T>)
                    {
                        ((Action<T>)handler)(domainEvent);
                    }
                }
            }

            CommitEvent(domainEvent);
        }

        /// <summary>
        /// Execute all queued domain events using Commited Handlers if any
        /// </summary>
        public static void DispatchCommitedEvents()
        {
            if (commitedEvents != null)
            {
                while (commitedEvents.Count > 0)
                {
                    var domainEvent = commitedEvents.Dequeue();
                    var domainEventType = domainEvent.GetType();

                    //Raise static Handlers first
                    if (staticCommitedEventHandlers != null)
                    {
                        foreach (var handlerType in staticCommitedEventHandlers)
                        {
                            bool canHandleEvent = handlerType.GetInterfaces()
                                .Any(x => x.GenericTypeArguments[0] == domainEventType);

                            if (canHandleEvent)
                            {
                                dynamic handler = Activator.CreateInstance(handlerType);
                                handler.Handle((dynamic)domainEvent);
                            }
                        }
                    }

                    //Raise dynamic handlers
                    if (dynamicCommitedEventHandlers != null)
                    {
                        foreach (var handler in dynamicCommitedEventHandlers)
                        {
                            if (handler.Method.GetParameters()[0].ParameterType == domainEventType)
                            {
                                handler.DynamicInvoke(domainEvent);
                            }
                        }
                    }
                }
            }
        }

        private static void CommitEvent(IDomainEvent domainEvent)
        {
            if (commitedEvents == null)
            {
                commitedEvents = new Queue<IDomainEvent>();
            }
            commitedEvents.Enqueue(domainEvent);
        }

    }
}
