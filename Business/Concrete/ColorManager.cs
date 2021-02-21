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
    public class ColorManager:IColorService
    {
        IColorDal _IColorDal;

        public ColorManager(IColorDal ıColorDal)
        {
            _IColorDal = ıColorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color brand)
        {
            _IColorDal.Add(brand);
            return new SuccessResult();
        }

        public IResult Delete(Color brand)
        {
            _IColorDal.Delete(brand);
            return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>
                (_IColorDal.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>
                (_IColorDal.Get(p => p.Id == id));

        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color brand)
        {
            _IColorDal.Update(brand);
            return new SuccessResult();
        }

    }
}
