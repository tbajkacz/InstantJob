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
                    "Quick HTML/CSS/Liquid/Javascript job",
                    @"Hello

I need some code putting on my site

From my website developers...

If you are wanting to add additional pages or make custom changes to pages not supported in the code editor, the developers below understand Uscreen and can help you. You may also use any other developer you choose as long as they understand HTML/CSS/Liquid as well as Javascript.

We recommend limiting custom changes to the home page and additional HTML pages. The catalog, content, author, category, checkout, and login pages are not intended to be customized with code. We do not guarantee that customizations will continue to work in the future as new features or versions of the platform are released. If you decide to customize pages outside of the home page or additional HTML pages, please be prepared to hire a developer in the future to resolve issues that may arise.",
                    random.Next(100, 1253),
                    DateTime.Now.AddDays(random.Next(5, 60)),
                    Difficulty.Beginner,
                    categories[13],
                    mandators[0]
                ),
                new Job(
                    Guid.NewGuid(),
                    "Update Debian 7.11 to Debian 10",
                    @"Dear Sirs and Madames,

one of our customers runs a web portal on a server with Debian 7.11 and Plesk. We would like you to give us the appropriate steps / commands to upgrade to Debian 10 via SSH (e.g. Putty).

sudo apt-get update & upgrade doesn't work because the Debian sources have changed.

All in all a matter of a few minutes - but we don't have the time to read it all up at the moment.",
                    random.Next(100, 1253),
                    DateTime.Now.AddDays(random.Next(5, 60)),
                    Difficulty.Intermediate,
                    categories[12],
                    mandators[1]
                ),
                new Job(
                    Guid.NewGuid(),
                    "Use Stripe API to collect Credit Card Payment",
                    @" - input credit card details for Stripe API
- display whether payment is successful or not",
                    random.Next(100, 1253),
                    DateTime.Now.AddDays(random.Next(5, 60)),
                    Difficulty.Expert,
                    categories[0],
                    mandators[0]
                ),
                new Job(
                    Guid.NewGuid(),
                    "Unity3D Mobile Game",
                    @"Hello, I'm looking for an experienced Unity3D Game Developer to create casual mobile games. Send your 3D Games portfolio made with Unity for mobile.",
                    random.Next(100, 1253),
                    DateTime.Now.AddDays(random.Next(5, 60)),
                    Difficulty.Expert,
                    categories[10],
                    mandators[1]
                ),
                new Job(
                    Guid.NewGuid(),
                    "CONTENT WRITING JOB",
                    @"Hi,

We are looking for freelance copy- and content writers to write several blogs and articles on a range of different topics. I need someone who is willing to accept a rate of $20 per 1000words. Are you reliable and doing a great job, then I may have bigger opportunities awaiting for you soon, as I am looking to build a team of trusted copywriters for my business.

Do you have experience in SEO and writing affiliate blogs, then please let me know, as this is a big advantage.

Big plus if you are able to adapt your writing style. Please let me know in your cover letter what your strengths are regarding writing (blog, product descriptions, emails, landing pages etc.)

Please do provide examples of content you've written (Google Docs link, Word links will not be opened).

Look forward to hearing from you.

Thanks",
                    random.Next(100, 1253),
                    DateTime.Now.AddDays(random.Next(5, 60)),
                    Difficulty.Intermediate,
                    categories[11],
                    mandators[0]
                ),
                new Job(
                    Guid.NewGuid(),
                    "Need Game Dev Team for MMO Game For PC",
                    @"Looking for a team to create a new MMO racing game, please apply and mail me for more details",
                    random.Next(100, 1253),
                    DateTime.Now.AddDays(random.Next(5, 60)),
                    Difficulty.Expert,
                    categories[0],
                    mandators[0]
                ),
                new Job(
                    Guid.NewGuid(),
                    "PHP MySQL website development ",
                    @"PHP MySQL developer required for completion of my website. About 30% of the 2nd version of the website still remains, and I require a new developer to finish off the process.

Very detailed project REQUIREMENTS document has been produced for the remainder of the dev, as well as screen videos which explain changes and updates required.

The code is well structured, well written and code notes are clear.

This next phase of dev is estimated at between 100 to 120 hours. An additional similar phase will follow.

Important: Some of the work is complex. There is report builder functionality, user functionality and report output functionality (PDF). Database complexity as well. Work includes some UI/UX look and feel, but this is not the emphasis. All colour pallets and fonts styles will be provided. **It is therefore important for you to demonstrate your ability to handle this complexity in references.

The top applications will be contacted and detailed scope of work and requirement documents will be shared and discussed in order for them to develop a quote for the work.

Please include the following details in your expression of interest:

Skills and experience with PHP, MySQL and related

Reference work

Availability over the next 2 months

I will review responses and engage with those that I feel are most suited for the job. Apologies - I will not be able to respond to everyone. I will only respond to those that I feel should be engaged further.",
                    random.Next(100, 1253),
                    DateTime.Now.AddDays(random.Next(5, 60)),
                    Difficulty.Expert,
                    categories[13],
                    mandators[1]
                ),
                new Job(
                    Guid.NewGuid(),
                    "Build me a new Hybrid Mobile App",
                    @"I want you to Build me a new Hybrid Mobile App. The detail are in the attched Document.

Go through it and Give me a timeline and Quote. You will be working for me. This is an agency project. If you succeed you will get more projects from me.

Once you give me the quote you can't back out or increase the Dev the question at the end of Doc to start your Bid description else you won't be considered.",
                    random.Next(100, 1253),
                    DateTime.Now.AddDays(random.Next(5, 60)),
                    Difficulty.Intermediate,
                    categories[14],
                    mandators[0]
                ),
                new Job(
                    Guid.NewGuid(),
                    "wechat mini program backend dev",
                    @"i am building WeChat mini-program solution for my e-commerce solution and I need a backend developer, i have database dev and frontend dev for now.

need to be done: backend system or service, i.e. order handling, payment, user login/registration. The Tencent cloud DB management features and photo search. ",
                    random.Next(100, 1253),
                    DateTime.Now.AddDays(random.Next(5, 60)),
                    Difficulty.Expert,
                    categories[2],
                    mandators[1]
                ),
                new Job(
                    Guid.NewGuid(),
                    "server migration -- 3",
                    @" - First, and highly recommended: take an image backup of your EFI partition e.g. using Macrium Reflect Free using the pre-installed Windows 10

- Make sure your BIOS is at the latest version (I lost time by not doing this right away, previous versions had defects making it even more difficult, ...)

- Make a bootable USB disk or hard drive from your downloaded copy of the Linux Mint or Ubuntu ISO file. UNetBootin (diskimage mode) or Rufus work great. You can do this from the pre-installed WIndows 10. Make sure it's UEFI enabled (GPT formatted USB). Good reading here.",
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
