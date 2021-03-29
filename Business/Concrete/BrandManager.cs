using Business.Abstract;
using Business.BusinessAspects.AutoFac;
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
    public class BrandManager : IBrandService
    {
        IBrandDal _IBrandDal;

        public BrandManager(IBrandDal ıBrandDal)
        {
            _IBrandDal = ıBrandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        //[SecuredOperation("admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand brand)
        {
            _IBrandDal.Add(brand);
            return new SuccessResult();

        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Delete(Brand brand)
        {
            _IBrandDal.Delete(brand);
            return new SuccessResult();

        }

        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>
                (_IBrandDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>
                (_IBrandDal.Get(p=>p.Id == id));

        }

        [ValidationAspect(typeof(BrandValidator))]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(Brand brand)
        {
            _IBrandDal.Update(brand);
            return new SuccessResult();
        }
    }
}
