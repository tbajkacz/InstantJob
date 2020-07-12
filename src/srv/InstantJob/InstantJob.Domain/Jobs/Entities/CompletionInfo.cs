﻿using InstantJob.Domain.Common;
using System;

namespace InstantJob.Domain.Jobs.Entities
{
    public class CompletionInfo : BaseEntity<int>
    {
        public virtual DateTime? CompletionDate { get; set; }

        public virtual string Comment { get; set; }

        public virtual int? Rating { get; set; }
    }
}