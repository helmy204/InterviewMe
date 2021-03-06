﻿namespace InterviewMe.SharedKernel
{
    public abstract class Entity<TId>
    {
        public TId Id { get; protected set; }

        // EF requires an empty constructor
        protected Entity() { }
    }
}
