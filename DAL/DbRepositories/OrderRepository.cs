using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using DAL.DB_Contexts;


namespace DAL.DB_Repositories
{
    public class OrderRepository : IOrderRepository
    {

        
        public EntityContext Database { get; set; }

        public OrderRepository(EntityContext db)
        {
            Database = db;
        }

        public void Create(Order entity)
        {
            Database.Orders.Add(entity);
            Database.SaveChanges();
        }

        public void Update(Order entity)
        {
            Database.Orders.Update(entity);
            Database.SaveChanges();
        }

        public void Delete(int id)
        {
            Order delOrder = Database.Orders.Find(id);
            Database.Orders.Remove(delOrder);
            Database.SaveChanges();

        }

        public IQueryable<Order> GetAll()
        {
            return Database.Orders.AsQueryable().AsNoTracking();
        }

        public Order Get(int id)
        {
            Order dish = Database.Orders.Find(id);
            return dish;
        }

        public void SaveAll(IEnumerable<Order> updatalist)
        {
            throw new NotImplementedException();
        }
    }
}
