using AutoMapper;
using BLL.DTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Profilers
{
    public class EntitysProfile : Profile
    {
        public EntitysProfile()
        {
            CreateMap<DishDTO, Dish>().ReverseMap();
            CreateMap<ClientDTO, Client>().ReverseMap();
            CreateMap<OrderDTO, Order>().ReverseMap();



        }
    }
}
