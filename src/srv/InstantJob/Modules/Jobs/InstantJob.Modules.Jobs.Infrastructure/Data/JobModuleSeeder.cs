using InstantJob.BuildingBlocks.Application.Interfaces;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Jobs.Application.Categories.Abstractions;
using InstantJob.Modules.Jobs.Application.Categories.Commands.SeedCategories;
using InstantJob.Modules.Jobs.Application.Contractors.Abstractions;
using InstantJob.Modules.Jobs.Application.Jobs.Commands.SeedJobs;
using InstantJob.Modules.Jobs.Application.Mandators.Abstractions;
using InstantJob.Modules.Jobs.Domain.Categories;
using InstantJob.Modules.Jobs.Domain.Jobs.Constants;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstantJob.Modules.Jobs.Infrastructure.Data
{
    public class JobModuleSeeder : IDataSeeder
    {
        private readonly IMediator mediator;
        private readonly IContractorRepository contractorRepository;
        private readonly IMandatorRepository mandatorRepository;
        private readonly ICategoryRepository categoryRepository;

        public JobModuleSeeder(
            IMediator mediator,
            IContractorRepository contractorRepository,
            IMandatorRepository mandatorRepository,
            ICategoryRepository categoryRepository)
        {
            this.mediator = mediator;
            this.contractorRepository = contractorRepository;
            this.mandatorRepository = mandatorRepository;
            this.categoryRepository = categoryRepository;
        }

        public async Task SeedAsync()
        {
            await SeedCategoriesAsync();

            await SeedJobsAsync();
        }

        private async Task SeedJobsAsync()
        {
            var mandators = mandatorRepository.Get().ToList();
            var contractors = contractorRepository.Get().ToList();
            var categories = categoryRepository.Get().ToList();

#pragma warning disable SecurityIntelliSenseCS // MS Security rules violation
            var random = new Random(Environment.TickCount);
#pragma warning restore SecurityIntelliSenseCS // MS Security rules violation

            var jobs = new []
            {
                new Job(
                    Guid.NewGuid(),
                    "Web job management application",
                    @"Hello,
I need a simple application which will allow its users to post and apply for job offers.

The application should have the following functionalities:
- login
- registration
- viewing and filtering job offers
- posting and editing job offers
- applying for job offers

If you are interested, please apply for this job offer.",
                    random.Next(100, 1253),
                    DateTime.Now.AddDays(random.Next(5, 60)),
                    Difficulty.Intermediate,
                    categories[13],
                    mandators[1]
                ),
                new Job(
                    Guid.NewGuid(),
                    "Google drive integration",
                    @"Hello

I need someone to create a backend google drive module for my application

It should allow to use a predefined google account which will access user accounts by using dropbox auth tokens.

The app should allow to connect/disconnect users from their dropbox account and upload large files. If you need more information, please email me and we can discuss details. The price is adjustable.

Greetings",
                    random.Next(100, 1253),
                    DateTime.Now.AddDays(random.Next(5, 60)),
                    Difficulty.Beginner,
                    categories[13],
                    mandators[0]
                ),
                new Job(
                    Guid.NewGuid(),
                    "Mobile job management application",
                    @"Hello,
I need a simple application which will allow its users to post and apply for job offers.

The application should have the following functionalities:
- login
- registration
- viewing and filtering job offers
- posting and editing job offers
- applying for job offers

If you are interested, please apply for this job offer.",
                    random.Next(100, 1253),
                    DateTime.Now.AddDays(random.Next(5, 60)),
                    Difficulty.Intermediate,
                    categories[13],
                    mandators[1]
                ),
                new Job(
                    Guid.NewGuid(),
                    "Desktop job management application",
                    @"Hello,
I need a simple application which will allow its users to post and apply for job offers.

The application should have the following functionalities:
- login
- registration
- viewing and filtering job offers
- posting and editing job offers
- applying for job offers

If you are interested, please apply for this job offer.",
                    random.Next(100, 1253),
                    DateTime.Now.AddDays(random.Next(5, 60)),
                    Difficulty.Intermediate,
                    categories[13],
                    mandators[1]
                ),
                new Job(
                    Guid.NewGuid(),
                    "Google drive integration",
                    @"Hello

I need someone to create a backend google drive module for my application

It should allow to use a predefined google account which will access user accounts by using dropbox auth tokens.

The app should allow to connect/disconnect users from their dropbox account and upload large files. If you need more information, please email me and we can discuss details. The price is adjustable.

Greetings",
                    random.Next(100, 1253),
                    DateTime.Now.AddDays(random.Next(5, 60)),
                    Difficulty.Beginner,
                    categories[13],
                    mandators[0]
                ),
                new Job(
                    Guid.NewGuid(),
                    "Quick HTML/CSS/Javascript job",
                    @"Hello

I need an addition on my website

The website has a few forms which should allow to generate pdf files off them. You can choose to work with a partner who knows React/Angular.

Fresh developers who can learn quick are welcome, there are several experienced developers can assist you.",
                    random.Next(100, 1253),
                    DateTime.Now.AddDays(random.Next(5, 60)),
                    Difficulty.Beginner,
                    categories[13],
                    mandators[0]
                ),
                new Job(
                    Guid.NewGuid(),
                    "Update Debian 7.11 to 10",
                    @"Welcome,

We need to upgrade Debian version 7.11 to version 10.

It should be a really simple task, so if you are willing to perform it, please apply.",
                    random.Next(100, 1253),
                    DateTime.Now.AddDays(random.Next(5, 60)),
                    Difficulty.Intermediate,
                    categories[12],
                    mandators[1]
                ),
                new Job(
                    Guid.NewGuid(),
                    "Use Paypal API to collect product payment",
                    @"Hey,
we have an online store which we would want to integrate with paypal payments.

We are looking for an experienced developer, with prior experience in similar tasks.",
                    random.Next(100, 1253),
                    DateTime.Now.AddDays(random.Next(5, 60)),
                    Difficulty.Expert,
                    categories[0],
                    mandators[0]
                ),
                new Job(
                    Guid.NewGuid(),
                    "Unity3D Mobile development",
                    @"Hello, I'm looking for an senior Unity Game Developer. An ideal candidate should have prior experience with such games, please send your portfiolio.",
                    random.Next(100, 1253),
                    DateTime.Now.AddDays(random.Next(5, 60)),
                    Difficulty.Expert,
                    categories[10],
                    mandators[1]
                ),
                new Job(
                    Guid.NewGuid(),
                    "Copywriter job",
                    @"Hi,

We need a freelance copywriter, who has experience in SEO.

Please send some examples of your work (preferably online preview).

Thanks.",
                    random.Next(100, 1253),
                    DateTime.Now.AddDays(random.Next(5, 60)),
                    Difficulty.Intermediate,
                    categories[11],
                    mandators[0]
                ),
                new Job(
                    Guid.NewGuid(),
                    "Need Game Dev for C# MMO Game",
                    @"Looking an experienced C# unity developer for a new mmo project",
                    random.Next(100, 1253),
                    DateTime.Now.AddDays(random.Next(5, 60)),
                    Difficulty.Expert,
                    categories[0],
                    mandators[0]
                ),
                new Job(
                    Guid.NewGuid(),
                    "PHP web development",
                    @"We have detailed project requirements and we need a new developer to extend our application.

The job should take no more than 2-3 months of full-time work.

Please send your applications.",
                    random.Next(100, 1253),
                    DateTime.Now.AddDays(random.Next(5, 60)),
                    Difficulty.Expert,
                    categories[13],
                    mandators[1]
                ),
                new Job(
                    Guid.NewGuid(),
                    "Mobile + web app development",
                    @"I need a new application which will work both on web browsers and mobile devices.
Please email me.",
                    random.Next(100, 1253),
                    DateTime.Now.AddDays(random.Next(5, 60)),
                    Difficulty.Intermediate,
                    categories[14],
                    mandators[0]
                ),
                new Job(
                    Guid.NewGuid(),
                    "Wechat backend developer",
                    @"I'm in the process of building a WeChat solution for my e-commerce project and I need a new backend developer.

Example tasks: order and payment handling, user login or registration.",
                    random.Next(100, 1253),
                    DateTime.Now.AddDays(random.Next(5, 60)),
                    Difficulty.Expert,
                    categories[2],
                    mandators[1]
                ),
                new Job(
                    Guid.NewGuid(),
                    "Server migration",
                    @"I need someone to perform a server migration. Please make sure that there will be a data backup in case of a failure.",
                    random.Next(100, 1253),
                    DateTime.Now.AddDays(random.Next(5, 60)),
                    Difficulty.Expert,
                    categories[6],
                    mandators[1]
                ),
            };

            foreach (var job in jobs[4..12])
            {
                foreach (var contractor in contractors)
                {
                    if (random.Next(1, 3) == 1 || contractor.JobUser.Name == "Tomasz")
                    {
                        job.ApplyForJob(contractor);
                    }
                }
            }

            foreach (var contractor in contractors)
            {
                jobs[0].ApplyForJob(contractor);
                jobs[1].ApplyForJob(contractor);
                jobs[2].ApplyForJob(contractor);
                jobs[3].ApplyForJob(contractor);
            }

            jobs[0].AssignContractor(contractors[0], jobs[0].Mandator.Id);
            jobs[1].AssignContractor(contractors[0], jobs[1].Mandator.Id);
            jobs[2].AssignContractor(contractors[0], jobs[2].Mandator.Id);
            jobs[3].AssignContractor(contractors[0], jobs[3].Mandator.Id);

            jobs[0].AcceptJobAssignment(contractors[0].Id);
            jobs[1].AcceptJobAssignment(contractors[0].Id);
            jobs[2].AcceptJobAssignment(contractors[0].Id);

            jobs[0].CompleteJob(jobs[0].Mandator.Id);
            jobs[1].CompleteJob(jobs[1].Mandator.Id);

            await mediator.Send(new SeedJobsCommand { Jobs = jobs.ToList() });
        }

        private async Task SeedCategoriesAsync()
        {
            var categories = new List<Category>
            {
                new Category(Guid.NewGuid(), "C#", ""),
                new Category(Guid.NewGuid(), "Javascript", ""),
                new Category(Guid.NewGuid(), "C++", ""),
                new Category(Guid.NewGuid(), "QA", ""),
                new Category(Guid.NewGuid(), "Ruby", ""),
                new Category(Guid.NewGuid(), "Python", ""),
                new Category(Guid.NewGuid(), "Databases", ""),
                new Category(Guid.NewGuid(), "Docker", ""),
                new Category(Guid.NewGuid(), "CI/CD", ""),
                new Category(Guid.NewGuid(), "Hardware", ""),
                new Category(Guid.NewGuid(), "Unity", ""),
                new Category(Guid.NewGuid(), "Article writing", ""),
                new Category(Guid.NewGuid(), "Linux", ""),
                new Category(Guid.NewGuid(), "Web development", ""),
                new Category(Guid.NewGuid(), "Mobile", ""),
            };

            await mediator.Send(new SeedCategoriesCommand { Categories = categories });
        }
    }
}
