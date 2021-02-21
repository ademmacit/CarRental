using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _IBrandDal;

        public BrandManager(IBrandDal ıBrandDal)
        {
            _IBrandDal = ıBrandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _IBrandDal.Add(brand);
            return new SuccessResult();

        }

        public IResult Delete(Brand brand)
        {
            _IBrandDal.Delete(brand);
            return new SuccessResult();

        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>
                (_IBrandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>
                (_IBrandDal.Get(p=>p.Id == id));

        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            _IBrandDal.Update(brand);
            return new SuccessResult();
        }
    }
}
