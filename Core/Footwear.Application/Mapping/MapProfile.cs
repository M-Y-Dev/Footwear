﻿using AutoMapper;
using Footwear.Application.Mediator.Commands.ProductCommands;
using Footwear.Application.Mediator.Commands.RoleCommands;
using Footwear.Application.Mediator.Commands.SocialMediaCommands;
using Footwear.Application.Mediator.Commands.UserCommands;
using Footwear.Application.Mediator.Results.ProductResults;
using Footwear.Application.Mediator.Results.RoleResults;
using Footwear.Application.Mediator.Results.SocialMediaResults;
using Footwear.Application.Mediator.Results.UserResults;
using Footwear.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<SocialMedia, CreateSocialMediaCommand>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaCommand>().ReverseMap();
            CreateMap<SocialMedia, GetSocialMediaByIdQueryResult>().ReverseMap();
            CreateMap<SocialMedia, GetSocialMediaQueryResult>().ReverseMap();


            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Product, GetProductByIdQueryResult>().ReverseMap();
            CreateMap<Product, GetProductQueryResult>().ReverseMap();

            CreateMap<AppRole, CreateRoleCommand>().ReverseMap();
            CreateMap<AppRole, UpdateRoleCommand>().ReverseMap();
            CreateMap<AppRole, GetRoleQueryResult>().ReverseMap();
            CreateMap<AppRole, GetRoleByIdQueryResult>().ReverseMap();

            CreateMap<AppUser, CreateUserCommand>().ReverseMap();
            CreateMap<AppUser, UpdateUserCommand>().ReverseMap();
            CreateMap<AppUser, GetUserByIdQueryResult>().ReverseMap();
            CreateMap<AppUser, GetUserQueryResult>().ReverseMap();

        }
    }
}
