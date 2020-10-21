using FluentValidation;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Jobs.Application.Categories.Abstractions;
using InstantJob.Modules.Jobs.Domain.Jobs.Constants;
using System;

namespace InstantJob.Modules.Jobs.Application.Jobs.Commands.PostJob
{
    public class PostJobCommandValidator : BaseJobValidator<PostJobCommand>
    {
        public PostJobCommandValidator(ICategoryRepository categoryRepository)
        {
            RuleForTitle(x => x.Title);
            RuleForDescription(x => x.Description);
            RuleForPrice(x => x.Price);
            RuleForDeadline(x => x.Deadline);

            RuleFor(x => x.CategoryId)
                .MustAsync(async (c, g, ctx) => Guid.TryParse(g, out Guid guid) && (await categoryRepository.GetByIdOrDefaultAsync(guid)) != null);

            RuleFor(x => x.DifficultyId)
                .Must(x => Enumeration.ContainsId<Difficulty>(x));
        }
    }
}
