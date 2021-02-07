using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _ICarDal;

        public CarManager(ICarDal ıCarDal)
        {
            _ICarDal = ıCarDal;
        }

        public List<Car> GetAll()
        {
            return _ICarDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _ICarDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _ICarDal.GetAll(p => p.ColorId== id);
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                if (car.Description.Length > 2)
                    _ICarDal.Add(car);
                else
                    throw new ArgumentException("Description length is shorter than 2");
            }
            else
                throw new ArgumentException("Daily price is lower than 0");
        }

        public void Delete(Car car)
        {
            _ICarDal.Delete(car);
        }

        public void Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                if (car.Description.Length > 2)
                    _ICarDal.Update(car);
                else
                    throw new ArgumentException("Description length is shorter than 2");
            }
            else
                throw new ArgumentException("Daily price is lower than 0");
        }

        public Car GetById(int id)
        {
            return _ICarDal.Get(p => p.Id == id);
        }
    }
}
