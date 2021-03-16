using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.Constants;
using Core.Aspects.AutoFac.Caching;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _CarImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _CarImageDal = carImageDal;
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(CarImage item)
        {
            IResult result =  BusinessRules.Run(CheckIfImageLimitPerCarExceeded(item.CarId));

            if (!result.Success)
                return result;

            item.Date = DateTime.Now;

            _CarImageDal.Add(item);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage item)
        {
            _CarImageDal.Delete(item);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_CarImageDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = _CarImageDal.GetAll(i => i.CarId == carId);
            if (result.Count>0)
            {
                return new SuccessDataResult<List<CarImage>>(result);
            }

            List<CarImage> defaultCar = new List<CarImage>() 
            { new CarImage(){ Id = 0,CarId = carId,Date = DateTime.Now} }; 
            return new SuccessDataResult<List<CarImage>>(defaultCar);
        }

        [CacheAspect]
        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>
                (_CarImageDal.Get(c => c.Id == id));
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Update(CarImage item)
        {
            _CarImageDal.Update(item);
            return new SuccessResult();
        }

        private IResult CheckIfImageLimitPerCarExceeded(int carId)
        {
            var result = _CarImageDal.GetAll(c => c.CarId == carId);
            if (result.Count<=5)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarImageLimitExeeded);
        }
    }
}
