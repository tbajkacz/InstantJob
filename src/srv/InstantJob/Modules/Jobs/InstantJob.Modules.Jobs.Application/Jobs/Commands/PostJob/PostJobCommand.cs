using System;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Jobs.Commands.PostJob
{
    public class PostJobCommand : IRequest<Guid>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime? Deadline { get; set; }

        public int DifficultyId { get; set; }

        public string CategoryId { get; set; }
    }
}
