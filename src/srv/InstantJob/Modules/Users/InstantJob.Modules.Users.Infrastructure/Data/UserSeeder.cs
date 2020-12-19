using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.Interfaces;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Users.Application.UserRegistrations.Abstractions;
using InstantJob.Modules.Users.Application.Users.Abstractions;
using InstantJob.Modules.Users.Application.Users.Commands.SeedUser;
using MediatR;

namespace InstantJob.Modules.Users.Infrastructure.Data
{
    public class UserSeeder : IDataSeeder
    {
        private readonly IMediator mediator;
        private readonly IUserRepository userRepository;
        private readonly IUserRegistrationRepository registrations;

        public UserSeeder(IMediator mediator, IUserRepository userRepository, IUserRegistrationRepository registrations)
        {
            this.mediator = mediator;
            this.userRepository = userRepository;
            this.registrations = registrations;
        }
        public async Task SeedAsync()
        {
            await SeedUsers();
        }

        private async Task SeedUsers()
        {
            if (userRepository.Get().Any())
            {
                return;
            }

            var seedCommands = new List<SeedUserCommand>
            {
                new SeedUserCommand
                {
                    Email = "root",
                    Name = "root",
                    Password = "root",
                    Role = Role.Administrator,
                    Surname = "root",
                },
                new SeedUserCommand
                {
                    Email = "tomasz.bajkacz@instantjob.com",
                    Name = "Tomasz",
                    Password = "root",
                    Role = Role.Contractor,
                    Surname = "Bajkacz"
                },
                new SeedUserCommand
                {
                    Email = "witold.grabowski@instantjob.com",
                    Name = "Witold",
                    Password = "root",
                    Role = Role.Contractor,
                    Surname = "Grabowski",
                },
                new SeedUserCommand
                {
                   Email = "Szymon.Nowak@instantjob.com",
                   Name = "Szymon",
                   Password = "root",
                   Role = Role.Contractor,
                   Surname = "Nowak",
                },
                new SeedUserCommand
                {
                    Email = "bartek.wojcik@instantjob.com",
                    Name = "Bartek",
                    Password = "root",
                    Role = Role.Mandator,
                    Surname = "Wójcik",
                },
                new SeedUserCommand
                {
                    Email = "klaudia.kowalska@instantjob.com",
                    Name = "Klaudia",
                    Password = "root",
                    Role = Role.Mandator,
                    Surname = "Kowalska",
                },
                new SeedUserCommand
                {
                    Email = "aleksandra.błaszczyk@instantjob.com",
                    Name = "Aleksandra",
                    Password = "root",
                    Role = Role.Contractor,
                    Surname = "Błaszczyk",
                },
                new SeedUserCommand
                {
                   Email = "Szymon.Kucharski@instantjob.com",
                   Name = "Szymon",
                   Password = "root",
                   Role = Role.Contractor,
                   Surname = "Kucharski",
                },
                new SeedUserCommand
                {
                   Email = "Paweł.Sokołowski@instantjob.com",
                   Name = "Paweł",
                   Password = "root",
                   Role = Role.Contractor,
                   Surname = "Sokołowski",
                },
                new SeedUserCommand
                {
                   Email = "Mateusz.Włodarczyk@instantjob.com",
                   Name = "Mateusz",
                   Password = "root",
                   Role = Role.Contractor,
                   Surname = "Włodarczyk",
                },
                new SeedUserCommand
                {
                   Email = "Oskar.Zalewski@instantjob.com",
                   Name = "Oskar",
                   Password = "root",
                   Role = Role.Contractor,
                   Surname = "Zalewski",
                },
                new SeedUserCommand
                {
                   Email = "Wiktor.Jędrzejewski@instantjob.com",
                   Name = "Wiktor",
                   Password = "root",
                   Role = Role.Contractor,
                   Surname = "Jędrzejewski",
                },
                new SeedUserCommand
                {
                   Email = "Jakub.Piasecki@instantjob.com",
                   Name = "Jakub",
                   Password = "root",
                   Role = Role.Contractor,
                   Surname = "Piasecki",
                },
                new SeedUserCommand
                {
                   Email = "Konrad.Kasprzyk@instantjob.com",
                   Name = "Konrad",
                   Password = "root",
                   Role = Role.Contractor,
                   Surname = "Kasprzyk",
                },
                new SeedUserCommand
                {
                   Email = "Kazimierz.Domański@instantjob.com",
                   Name = "Kazimierz",
                   Password = "root",
                   Role = Role.Contractor,
                   Surname = "Domański",
                },
                new SeedUserCommand
                {
                   Email = "Julia.Socha@instantjob.com",
                   Name = "Julia",
                   Password = "root",
                   Role = Role.Contractor,
                   Surname = "Socha",
                },
                new SeedUserCommand
                {
                   Email = "Wiktor.Jakubowski@instantjob.com",
                   Name = "Wiktor",
                   Password = "root",
                   Role = Role.Contractor,
                   Surname = "Jakubowski",
                },
                new SeedUserCommand
                {
                   Email = "Mateusz.Kot@instantjob.com",
                   Name = "Mateusz",
                   Password = "root",
                   Role = Role.Contractor,
                   Surname = "Kot",
                },
                new SeedUserCommand
                {
                   Email = "Małgorzata.Grabowska@instantjob.com",
                   Name = "Małgorzata",
                   Password = "root",
                   Role = Role.Contractor,
                   Surname = "Grabowska",
                },

            };

            foreach (var seedCommand in seedCommands)
            {
                await mediator.Send(seedCommand);
            }
        }
    }
}
