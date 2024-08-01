using AutoMapper;
using Footwear.Application.Mediator.Commands.ProductCommands;
using Footwear.Application.Mediator.Commands.SocialMediaCommands;
using Footwear.Application.Mediator.Results.ProductResults;
using Footwear.Application.Mediator.Results.SocialMediaResults;
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



        }
    }
}
