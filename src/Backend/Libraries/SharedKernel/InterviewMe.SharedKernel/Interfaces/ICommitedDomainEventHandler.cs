namespace InterviewMe.SharedKernel.Interfaces
{
    public interface ICommitedDomainEventHandler<T> : IHandler<T>
        where T : IDomainEvent
    {
    }
}
