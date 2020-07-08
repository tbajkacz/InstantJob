using InstantJob.Domain.Jobs.Constants;
using MediatR;
using System;

namespace InstantJob.Core.Jobs.Commands.PostJob
{
    public class PostJobCommand : IRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime? Deadline { get; set; }

        public Difficulty Difficulty { get; set; }

        public int CategoryId { get; set; }
    }
}
