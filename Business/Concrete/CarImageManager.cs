using Business.Abstract;
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

        public IResult Add(CarImage item)
        {
            IResult result =  BusinessRules.Run(CheckIfImageLimitPerCarExceeded(item.CarId));

            if (!result.Success)
                return result;

            item.Date = DateTime.Now;

            _CarImageDal.Add(item);
            return new SuccessResult();
        }

        public IResult Delete(CarImage item)
        {
            _CarImageDal.Delete(item);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_CarImageDal.GetAll());
        }

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

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>
                (_CarImageDal.Get(c => c.Id == id));
        }

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
            return new ErrorResult("Cannot add more than 5 images per car");
        }
    }
}
