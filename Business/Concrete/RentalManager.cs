﻿using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Caching;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _IRentalDal;

        public RentalManager(IRentalDal ıRentalDal)
        {
            _IRentalDal = ıRentalDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            //IS THIS VALIDATION CODE OR BUSINESS CODE ?
            //if there is any rental entry for the car we want that is not returned
            if (_IRentalDal.GetAll
                (r=>r.CarId == rental.CarId && r.ReturnDate==null).Count>0)
            {
                return new ErrorResult(Messages.CarIsAlreadRented); 
            }
            else
            {
                _IRentalDal.Add(rental);
                return new SuccessResult();
            }

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

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            _IRentalDal.Update(rental);
            return new SuccessResult();
        }

    }
}
