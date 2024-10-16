﻿using AutoMapper;
using Modules.Orders.Core.Models;
using Modules.Orders.Data.Entities;

namespace Modules.Orders.Core.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Order, ViewOrderDto>();
            CreateMap<OrderItem, ViewOrderItemDto>();

        }
    }
}