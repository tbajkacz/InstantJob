using MediatR;
using System;

namespace InstantJob.Core.Jobs.Commands.UpdateJobDetails
{
    public class UpdateJobDetailsCommand : IRequest
    {
        public Guid JobId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime? Deadline { get; set; }

        public int DifficultyId { get; set; }
    }
}
