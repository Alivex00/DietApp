using AutoMapper;
using DietApp.BusinessLogic.DTOs;
using DietApp.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietApp.BusinessLogic.Infractructure
{
    public class MappingProfile: Profile 
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserDto>()
                .ReverseMap();
        }
    }
}
