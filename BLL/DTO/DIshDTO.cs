

using BLL.Interfaces;

namespace BLL.DTO
{
    public class DishDTO : IDTO
    {


        public DishDTO()
        {
        }

        public DishDTO(string Name, string description)
        {
            DishName = Name;
            Description = description;
        }

        public int DishID { get; set; }
        public string DishName { get; set; }
        public string Description { get; set; }
    }
}
