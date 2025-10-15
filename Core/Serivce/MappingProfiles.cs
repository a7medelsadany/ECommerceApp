using AutoMapper;
using DomainLayer.Models;
using Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            #region product
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.BrandName, options => options.MapFrom(src => src.ProductBrand.Name))
                .ForMember(dest => dest.TypeName, options => options.MapFrom(src => src.ProductType.Name))
                .ForMember(dest => dest.PictureUrl, options => options.MapFrom<PictureURLResolver>());

            CreateMap<ProductBrand, BrandDto>();
            CreateMap<ProductType, TypeDto>();
            #endregion
        }
    }

}
