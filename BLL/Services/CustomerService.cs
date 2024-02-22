using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;

namespace BLL.Services
{
    internal class CustomerService : ICustomerService
    {

        private IMapper _mapper;
        private IClientRepository _repository;

        public CustomerService(IMapper mapper, IClientRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public void Create(ClientDTO entity)
        {
            Client customer = _mapper.Map<Client>(entity);
            _repository.Create(customer);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public ClientDTO Get(int id)
        {
            Client dish = _repository.Get(id);
            return _mapper.Map<ClientDTO>(dish);
        }

        public List<ClientDTO> GetAll()
        {
            List<Client> customers = _repository.GetAll().ToList();
            return _mapper.Map<List<Client>, List<ClientDTO>>(customers);
        }

        public List<(ClientDTO, int)> GetCust(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<ClientDTO> updatalist)
        {
            List<Client> customers = new List<Client>();
            List<DishDTO> customerDTOs = (List<DishDTO>)updatalist;

            for (int i = 0; i < updatalist.Count(); i++)
                customers.Add(_mapper.Map<Client>(customerDTOs[i]));

            _repository.SaveAll(customers);
        }

        public void Update(ClientDTO entity)
        {
            Client customer = _mapper.Map<Client>(entity);
            _repository.Update(customer);
        }
    }
}
