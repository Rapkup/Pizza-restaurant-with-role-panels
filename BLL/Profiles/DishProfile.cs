using AutoMapper;
using BLL.DTO;
using DAL.Models;


namespace BLL.Profilers
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
           CreateMap<DishDTO, Dish>().ReverseMap();
           
        }
    }
}
