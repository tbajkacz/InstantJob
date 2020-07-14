using InstantJob.Core.Common.Exceptions;
using InstantJob.Core.Common.Interfaces;
using InstantJob.Core.Users.Commands.ChangeUserPassword;
using InstantJob.Core.Users.Commands.CreateUser;
using InstantJob.Core.Users.Commands.UpdateUserInformation;
using InstantJob.Core.Users.Queries.FindUserByCredentials;
using InstantJob.Domain.Users.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstantJob.Infrastructure.Identity
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository userRepository;
        private readonly IHashService hashService;
        private readonly ICurrentUserService currentUser;

        public UserManager(IUserRepository userRepository, IHashService hashService, ICurrentUserService currentUser)
        {
            this.userRepository = userRepository;
            this.hashService = hashService;
            this.currentUser = currentUser;
        }

        public IEnumerable<User> Users => userRepository.Get();

        public async Task CreateAsync(CreateUserCommand param)
        {
            //TODO add email verification
            await CreateAsync(new User
            {
                Name = param.Name,
                Surname = param.Surname,
                Email = param.Email,
                Roles = param.Roles,
            }, param.Password);
        }

        public async Task CreateAsync(User user, string password)
        {
            user.PasswordHash = hashService.Hash(password);
            await userRepository.AddAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            await userRepository.UpdateAsync(user);
        }

        public async Task UpdateInformationAsync(UpdateUserInformationCommand param)
        {
            var user = await userRepository.GetByIdOrDefaultAsync(currentUser.UserId) ?? throw new InvalidUserSessionException();

            user.Age = param.Age;
            user.Name = param.Name;
            user.Surname = param.Surname;
            user.Picture = param.Picture;
            await UpdateAsync(user);
        }

        public async Task UpdatePasswordAsync(ChangeUserPasswordCommand param)
        {
            var user = await userRepository.GetByIdOrDefaultAsync(currentUser.UserId) ?? throw new InvalidUserSessionException();
            user.PasswordHash = hashService.Hash(param.Password);
            await UpdateAsync(user);
        }

        public async Task<User> ValidateCredentialsAsync(FindUserByCredentialsQuery param)
        {
            var user = await userRepository.FindByEmailAsync(param.Email); 

            return user == null ? null : hashService.CompareHashes(param.Password, user.PasswordHash) ? user : null;
        }
    }
}
