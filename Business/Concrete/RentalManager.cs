﻿using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Caching;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _IRentalDal;
        ICustomerFindeksDal _ICustomerFindeksDal;
        ICarDal _ICarDal;

        public RentalManager(IRentalDal rentalDal, ICustomerFindeksDal customerFindeksDal, ICarDal carDal)
        {
            _IRentalDal = rentalDal;
            _ICustomerFindeksDal = customerFindeksDal;
            _ICarDal = carDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {

            IResult result = BusinessRules.Run(CheckIfReturnDateForCarExists(rental),
                CheckIfCarIsReturnedBeforeRentalRent(rental),
                CheckIfCustomerFindeksIsEnough(rental));

            if (!result.Success)
                return result;


            _IRentalDal.Add(rental);
            return new SuccessResult();

        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _IRentalDal.Delete(rental);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult DeleteAll()
        {
            foreach (var rental in GetAll().Data)
            {
                Delete(rental);
            }
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>
                (_IRentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>
                (_IRentalDal.Get(p => p.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>
                (_IRentalDal.GetRentalDetails());
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            _IRentalDal.Update(rental);
            return new SuccessResult();
        }

        private IResult CheckIfReturnDateForCarExists(Rental rental)
        {
            if (_IRentalDal.GetAll
              (r => r.CarId == rental.CarId && r.ReturnDate == null).Count > 0)
            {
                return new ErrorResult(Messages.CarIsAlreadRented);
            }
            return new SuccessResult(); 
        }

        private IResult CheckIfCarIsReturnedBeforeRentalRent(Rental rental)
        {
            if (_IRentalDal.GetAll
             (r => r.CarId == rental.CarId &&
             r.ReturnDate > (DateTime?)rental.RentDate).Count > 0)
            {
                return new ErrorResult(Messages.CarIsAlreadRented);
            }
            return new SuccessResult();
        }

        // Because findeks points come from a mock server we can 
        //use CustomerFindeksManager here to get the value.
        //But in a real scenario this function would use another api to get findeks
        private IResult CheckIfCustomerFindeksIsEnough(Rental rental)
        {
            CustomerFindeks customerFindeks = _ICustomerFindeksDal.Get(c => c.CustomerId == rental.CustomerId);
            Car car = _ICarDal.Get(c => c.Id == rental.CarId);
            if (customerFindeks.Findeks>=car.Findeks)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.LowFindeksPoints);
        }

    }
}
