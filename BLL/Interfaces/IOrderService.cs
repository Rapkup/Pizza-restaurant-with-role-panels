using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOrderService : IService<OrderDTO>
    {
       List<(OrderDTO, int)> FindOrd(int id);
    }
}
