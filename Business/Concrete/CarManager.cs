using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Caching;
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

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>
                (_ICarDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>
                (_ICarDal.GetAll(p => p.BrandId == id));
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>
                (_ICarDal.GetAll(p => p.ColorId== id));
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {

            _ICarDal.Add(car);
            return new SuccessResult();

        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _ICarDal.Delete(car);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {

            _ICarDal.Update(car);
            return new SuccessResult();

        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>
                (_ICarDal.Get(p => p.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>
                (_ICarDal.GetCarDetails());
        }
    }
}
