using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewMe.SharedKernel.Interfaces
{
    public interface IDomainEvent
    {
        DateTime DateTimeEventOccurred { get; }
    }
}
