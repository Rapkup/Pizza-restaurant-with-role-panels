using AutoMapper;
using BLL.DTO;
using DAL.Models;

namespace BLL.Profilers
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientDTO, Client>().ReverseMap();

        }
    }
}
