using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Dish : Temple
    {
        public int DishID { get; set; }
        public string DishName { get; set; }
        public string Description { get; set; }

        public Dish(int id, string name, string description)
        {
            DishID = id;
            DishName = name;
            Description = description;
        }

        public Dish(string name, string description)
        {

            DishName = name;
            Description = description;
        }

        public Dish()
        {

        }
    }


}
