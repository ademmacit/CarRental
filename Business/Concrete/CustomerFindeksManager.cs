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
    public class CustomerFindeksManager : ICustomerFindeksService
    {
        ICustomerFindeksDal _ICustomerFindeksDal;

        public CustomerFindeksManager(ICustomerFindeksDal ıCustomerFindeksDal)
        {
            _ICustomerFindeksDal = ıCustomerFindeksDal;
        }

        public IResult Add(CustomerFindeks item)
        {
            _ICustomerFindeksDal.Add(item);
            return new SuccessResult();

        }

        public IResult Delete(CustomerFindeks item)
        {
            _ICustomerFindeksDal.Delete(item);
            return new SuccessResult();

        }

        public IDataResult<List<CustomerFindeks>> GetAll()
        {
            return new SuccessDataResult<List<CustomerFindeks>>
                (_ICustomerFindeksDal.GetAll());
        }

        public IDataResult<CustomerFindeks> GetByCustomerId(int id)
        {
            return new SuccessDataResult<CustomerFindeks>
                (_ICustomerFindeksDal.Get(p => p.CustomerId == id));
        }

        public IDataResult<CustomerFindeks> GetById(int id)
        {
            return new SuccessDataResult<CustomerFindeks>
                (_ICustomerFindeksDal.Get(p => p.Id == id));

        }

        public IResult Update(CustomerFindeks item)
        {
            _ICustomerFindeksDal.Update(item);
            return new SuccessResult();
        }
    }
}
