using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 5000,
                ModelYear = "2000",Description = "Car 1 desc" },
                new Car{Id = 2, BrandId = 1, ColorId = 1, DailyPrice = 3000,
                ModelYear = "1990",Description = "Car 2 desc" },
                new Car{Id = 3, BrandId = 2, ColorId = 1, DailyPrice = 12000,
                ModelYear = "1995",Description = "Car 3 desc" },
                new Car{Id = 4, BrandId = 2, ColorId = 2, DailyPrice = 2000,
                ModelYear = "2010",Description = "Car 4 desc" },
                new Car{Id = 5, BrandId = 3, ColorId = 2, DailyPrice = 7000,
                ModelYear = "2005",Description = "Car 5 desc" },
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Add(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            var selectedCar = _cars.SingleOrDefault(c => c.Id == car.Id);
           
            _cars.Remove(selectedCar);
        }

        public void Delete(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            //TODO
            throw new NotImplementedException();
            //if (filter != null)
            //{
            //    return _cars.Where(filter).ToList();
            //}
            //else
            //{
            //    return _cars;
            //}
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }

        public void Update(IEntity entity)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
