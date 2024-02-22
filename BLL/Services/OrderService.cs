using BLL.DTO;
using BLL.Interfaces;
using AutoMapper;
using DAL.Interfaces;
using DAL.Models;

namespace BLL.Services
{
    internal class OrderService : IOrderService
    {

        private IMapper _mapper;
        private IOrderRepository _repository;

        public OrderService(IMapper mapper, IOrderRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void Create(OrderDTO entity)
        {
            Order order = _mapper.Map<Order>(entity);
            _repository.Create(order);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<(OrderDTO, int)> FindOrd(int id)
        {
            throw new NotImplementedException();
        }

        public OrderDTO Get(int id)
        {
            Order order = _repository.Get(id);
            return _mapper.Map<OrderDTO>(order);
        }

        public List<OrderDTO> GetAll()
        {
            List<OrderDTO> orderDTOs = new List<OrderDTO>();
            List<Order> orders = _repository.GetAll().ToList();
            for (int i = 0; i < orders.Count; i++)
                orderDTOs.Add(_mapper.Map<OrderDTO>(orders[i]));

            return orderDTOs;
        }
        public void SaveAll(IEnumerable<OrderDTO> updatalist)
        {
            List<Order> orders = new List<Order>();
            List<OrderDTO> dishDTOs = (List<OrderDTO>)updatalist;

            for (int i = 0; i < updatalist.Count(); i++)
                orders.Add(_mapper.Map<Order>(dishDTOs[i]));

            _repository.SaveAll(orders);
        }

        public void Update(OrderDTO entity)
        {
            Order order = _mapper.Map<Order>(entity);
            _repository.Update(order);
        }
    }
}
