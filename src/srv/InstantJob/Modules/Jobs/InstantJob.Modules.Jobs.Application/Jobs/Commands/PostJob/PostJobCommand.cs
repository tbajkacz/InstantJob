﻿using System;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Jobs.Commands.PostJob
{
    public class PostJobCommand : IRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime? Deadline { get; set; }

        public int DifficultyId { get; set; }

        public Guid CategoryId { get; set; }
    }
}