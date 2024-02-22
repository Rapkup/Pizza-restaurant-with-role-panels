using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IDishService : IService<DishDTO>
    {
       List<DishDTO> SearchDish(string name);
    }
}
