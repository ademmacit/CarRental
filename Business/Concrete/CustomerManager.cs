using Business.Abstract;
using Business.BusinessAspects.AutoFac;
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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _ICustomerDal;

        public CustomerManager(ICustomerDal ıCustomerDal)
        {
            _ICustomerDal = ıCustomerDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _ICustomerDal.Add(customer);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        public IResult Delete(Customer customer)
        {
            _ICustomerDal.Delete(customer);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>
                (_ICustomerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>
                (_ICustomerDal.Get(p => p.Id == id));
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            _ICustomerDal.Update(customer);
            return new SuccessResult();
        }
    }
}
