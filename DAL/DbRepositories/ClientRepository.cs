using DAL.Interfaces;

using DAL.DB_Contexts;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace DAL.DB_Repositories
{
    public class ClientRepository : IClientRepository
    {
        private EntityContext Database { get; set; }

        public ClientRepository(EntityContext db)
        {
            Database = db;
        }

        public void Create(Client entity)
        {
            Database.Clients.Add(entity);
            Database.SaveChanges();
        }

        public void Update(Client entity)
        {
            Database.Clients.Update(entity);
            Database.SaveChanges();
        }

        public void Delete(int id)
        {
            Client delCustomer = Database.Clients.Find(id);
            Database.Clients.Remove(delCustomer);
            Database.SaveChanges();
        }

        public IEnumerable<Client> GetAll()
        {
            return Database.Clients.AsQueryable().AsNoTracking();
        }

        public Client Get(int id)
        {
            Client customer = Database.Clients.Find(id);
            return customer;
        }

        public void SaveAll(IEnumerable<Client> updatalist)
        {
            throw new NotImplementedException();
        }

        IQueryable<Client> IRepository<Client>.GetAll()
        {
            return Database.Clients.AsQueryable().AsNoTracking();
        }
    }
}
