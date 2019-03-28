namespace InterviewMe.SharedKernel.Interfaces
{
    public interface IDomainEventHandler<T> : IHandler<T>
        where T : IDomainEvent
    {
    }
}
