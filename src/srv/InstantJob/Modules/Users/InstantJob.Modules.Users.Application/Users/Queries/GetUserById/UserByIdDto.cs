﻿using AutoMapper;
using InstantJob.BuildingBlocks.Application.Automapper;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Users.Domain.Users;
using System;

namespace InstantJob.Modules.Users.Application.Users.Queries.GetUserById
{
    public class UserByIdDto : IMapFrom<User>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int? Age { get; set; }

        public string Email { get; set; }

        public string Picture { get; set; }

        public Role Role { get; set; }

        public DateTime CreationDate { get; set; }

        public void CreateMap(Profile profile)
        {
            profile.CreateMap<User, UserByIdDto>()
                .ForMember(dto => dto.Picture, mce => mce.MapFrom(u => Convert.ToBase64String(u.Picture)));
        }
    }
}
