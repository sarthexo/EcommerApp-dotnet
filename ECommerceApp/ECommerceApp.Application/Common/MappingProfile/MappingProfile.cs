using AutoMapper;
using ECommerceApp.Application.DTOs;
using ECommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Common.MappingProfile
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Product
            CreateMap<Product, ProductDto>();

            //Order and Items
            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>();

            //user
            CreateMap<User, UserDto>();
        }
    }
}
