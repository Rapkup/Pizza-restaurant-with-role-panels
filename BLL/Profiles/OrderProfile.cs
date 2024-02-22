using AutoMapper;
using BLL.DTO;
using DAL.Models;

namespace BLL.Profilers
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDTO, Order>().ReverseMap();
        }
    }
}
