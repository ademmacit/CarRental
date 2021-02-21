using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
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

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            _ICarDal.Add(car);
            return new SuccessResult();

        }

        public IResult Delete(Car car)
        {
            _ICarDal.Delete(car);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {

            _ICarDal.Update(car);
            return new SuccessResult();

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
