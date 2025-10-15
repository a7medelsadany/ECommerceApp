﻿using AutoMapper;
using DomainLayer.Models;
using Microsoft.Extensions.Configuration;
using Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PictureURLResolver(IConfiguration configuration) : IValueResolver<Product, ProductDto, string>
    {
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.PictureUrl))
            {
                return string.Empty;
            }
            else
            {

                var Url = $"{configuration.GetSection("URLS")["BaseUrl"]}{source.PictureUrl}";
                return Url;
            }
        }
    }
}
