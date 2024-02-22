using BLL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BLL.DTO
{
    public class ClientDTO : IDTO
    {
        public ClientDTO()
        { }

        public int Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
