using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>
                (_ICarDal.GetAll());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>
                (_ICarDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>
                (_ICarDal.GetAll(p => p.ColorId== id));
        }

        public IResult Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                if (car.Description.Length > 2)
                {
                    _ICarDal.Add(car);
                    return new SuccessResult();
                }
                else
                    return new ErrorResult("Description length is shorter than 2");
            }
            else
                return new ErrorResult("Daily price is lower than 0");
        }

        public IResult Delete(Car car)
        {
            _ICarDal.Delete(car);
            return new SuccessResult();
        }

        public IResult Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                if (car.Description.Length > 2)
                {
                    _ICarDal.Update(car);
                    return new SuccessResult();
                }
                else
                    return new ErrorResult("Description length is shorter than 2");
            }
            else
                return new ErrorResult("Daily price is lower than 0");
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>
                (_ICarDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>
                (_ICarDal.GetCarDetails());
        }
    }
}
