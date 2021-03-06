﻿using System;

namespace InterviewMe.SharedKernel
{
    public abstract class AuditableEntity<TId> : Entity<TId>
    {
        public DateTime InsertedOn { get; set; }
        public long InsertedBy { get; set; }

        public DateTime UpdatedOn { get; set; }
        public long UpdatedBy { get; set; }
    }
}
