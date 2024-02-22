using BLL.DTO;

namespace BLL.Interfaces
{
    public interface ICustomerService : IService<ClientDTO>
    {
       
        List<(ClientDTO, int)> GetCust(int id);
        
    }
}
