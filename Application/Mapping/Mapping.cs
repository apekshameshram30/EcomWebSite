using Application.DTOs;
using AutoMapper;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Registration, RegistrationDTO>().ReverseMap();
            CreateMap<Login, LoginDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<PaymentGateway, PaymentDTO>().ReverseMap();
        }
    }
}
