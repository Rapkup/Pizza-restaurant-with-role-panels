using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;

namespace BLL.Services
{
    internal class DishService : IDishService
    {
        private IMapper _mapper;
        private IDishRepository _repository;

        public DishService(IMapper mapper, IDishRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void Create(DishDTO entity)
        {
            Dish dish = _mapper.Map<Dish>(entity);
            _repository.Create(dish);

        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public DishDTO Get(int id)
        {
            Dish dish = _repository.Get(id);
            return _mapper.Map<DishDTO>(dish);
        }

        public List<DishDTO> GetAll()
        {
            List<DishDTO> dishDTOs = new List<DishDTO>();
            List<Dish> dishes = _repository.GetAll().ToList();
            for (int i = 0; i < dishes.Count; i++)
                dishDTOs.Add(_mapper.Map<DishDTO>(dishes[i]));

            return dishDTOs;
        }



        public void SaveAll(IEnumerable<DishDTO> updatalist)
        {
            List<Dish> dishes = new List<Dish>();
            List<DishDTO> dishDTOs = (List<DishDTO>)updatalist;

            for (int i = 0; i < updatalist.Count(); i++)
                dishes.Add(_mapper.Map<Dish>(dishDTOs[i]));

            _repository.SaveAll(dishes);
        }

        public List<DishDTO> SearchDish(string name)
        {
            List<DishDTO> dishDTOs = new List<DishDTO>();

            var dishes = _repository.GetAll();
            var dishesFind = dishes.Where(d => d.DishName.Contains(name));

            foreach (var dish in dishesFind)
            {
                var dishDTO = _mapper.Map<DishDTO>(dish);
                dishDTOs.Add(dishDTO);
            }

            return dishDTOs;
        }


        public void Update(DishDTO entity)
        {
            Dish dish = _mapper.Map<Dish>(entity);
            _repository.Update(dish);
        }
    }
}
