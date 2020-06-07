using AutoMapper;
using InstantJob.Core.Common.Mappings;
using InstantJob.Core.Users.Entities;

namespace InstantJob.Core.Users.Dtos
{
    public class UserDto : IMapFrom<User>
    {
        public string Name { get; set; }
               
        public string Surname { get; set; }
    }
}
