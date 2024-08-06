using AutoMapper;
using Footwear.Application.Mediator.Commands.AboutCommands;
using Footwear.Application.Mediator.Commands.AddressCommands;
using Footwear.Application.Mediator.Commands.CategoryCommands;
using Footwear.Application.Mediator.Commands.CommentCommands;
using Footwear.Application.Mediator.Commands.ContactCommands;
using Footwear.Application.Mediator.Commands.ProductCommands;
using Footwear.Application.Mediator.Commands.RoleCommands;
using Footwear.Application.Mediator.Commands.SocialMediaCommands;
using Footwear.Application.Mediator.Commands.UserCommands;
using Footwear.Application.Mediator.Results.AboutResults;
using Footwear.Application.Mediator.Results.AddressResults;
using Footwear.Application.Mediator.Results.CategoryResults;
using Footwear.Application.Mediator.Results.CommentResults;
using Footwear.Application.Mediator.Results.ContactResults;
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
            CreateMap<Product, GetProductWithCategoryQueryResult>().ReverseMap();

            CreateMap<AppRole, CreateRoleCommand>().ReverseMap();
            CreateMap<AppRole, UpdateRoleCommand>().ReverseMap();
            CreateMap<AppRole, GetRoleQueryResult>().ReverseMap();
            CreateMap<AppRole, GetRoleByIdQueryResult>().ReverseMap();

            CreateMap<AppUser, CreateUserCommand>().ReverseMap();
            CreateMap<AppUser, UpdateUserCommand>().ReverseMap();
            CreateMap<AppUser, GetUserByIdQueryResult>().ReverseMap();
            CreateMap<AppUser, GetUserQueryResult>().ReverseMap();

            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
            CreateMap<Category, GetCategoryByIdQueryResult>().ReverseMap();
            CreateMap<Category, GetCategoryQueryResult>().ReverseMap();

            CreateMap<About, CreateAboutCommand>().ReverseMap();
            CreateMap<About, UpdateAboutCommand>().ReverseMap();
            CreateMap<About, GetAboutByIdQueryResult>().ReverseMap();
            CreateMap<About, GetAboutQueryResult>().ReverseMap();

            CreateMap<Comment, CreateCommentCommand>().ReverseMap();
            CreateMap<Comment, UpdateCommentCommand>().ReverseMap();
            CreateMap<Comment, GetCommentByIdQueryResult>().ReverseMap();
            CreateMap<Comment, GetCommentQueryResult>().ReverseMap();
            
            CreateMap<Contact,CreateContactCommand>().ReverseMap();
            CreateMap<Contact, UpdateContactCommand>().ReverseMap();
            CreateMap<Contact,GetContactByIdQueryResult>().ReverseMap();
            CreateMap<Contact,GetContactQueryResult>().ReverseMap();

            CreateMap<Address, CreateAddressCommand>().ReverseMap();
            CreateMap<Address, UpdateAddressCommand>().ReverseMap();
            CreateMap<Address, GetAddressByIdQueryResult>().ReverseMap();
            CreateMap<Address, GetAddressQueryResult>().ReverseMap();



        }
    }
}
