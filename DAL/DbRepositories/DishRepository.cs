using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using DAL.DB_Contexts;

namespace DAL.DB_Repositories
{
    public class DishRepository : IDishRepository
    {

        private EntityContext Database { get; set; }

        public DishRepository(EntityContext db)
        {
            Database = db;
        }

        public void Create(Dish entity)
        {
            Database.Dishes.Add(entity);
            Database.SaveChanges();
        }

        public void Update(Dish entity)
        {
            Database.Dishes.Update(entity);
            Database.SaveChanges();
        }

        public void Delete(int id)
        {
            Dish delDish = Database.Dishes.Find(id);
            Database.Dishes.Remove(delDish);
            Database.SaveChanges();

        }

        public IQueryable<Dish> GetAll()
        {
            return Database.Dishes.AsQueryable().AsNoTracking();
        }

        public Dish Get(int id)
        {
            Dish dish = Database.Dishes.Find(id);
            return dish;
        }

        public void SaveAll(IEnumerable<Dish> updatalist)
        {
            throw new NotImplementedException();
        }
    }
}
