using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Caching;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _ICreditCardDal;

        public CreditCardManager(ICreditCardDal ıCreditCardDal)
        {
            _ICreditCardDal = ıCreditCardDal;
        }

        //[SecuredOperation("admin")]
        //[ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResult Add(CreditCard item)
        {
            CreditCard foundCard = GetByUserId(item.UserId).Data;
            if (foundCard == null)
            {
                _ICreditCardDal.Add(item);
            }
            else
            {
                item.Id = foundCard.Id;
                _ICreditCardDal.Update(item);
            }
            return new SuccessResult();
        }

        //[SecuredOperation("admin")]
        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResult Delete(CreditCard item)
        {
            _ICreditCardDal.Delete(item);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>
                (_ICreditCardDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<CreditCard> GetById(int id)
        {
            return new SuccessDataResult<CreditCard>
                (_ICreditCardDal.Get(p => p.Id == id));

        }

        public IDataResult<CreditCard> GetByUserId(int userId)
        {

            return new SuccessDataResult<CreditCard>
                (_ICreditCardDal.Get(p => p.UserId == userId));
        }

        //[SecuredOperation("admin")]
        //[ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResult Update(CreditCard item)
        {
            _ICreditCardDal.Update(item);
            return new SuccessResult();
        }

    }
}
