using Business.Abstract;
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

        public IResult Add(Rental rental)
        {
            _IRentalDal.Add(rental);
            return new SuccessResult();

        }

        public IResult Delete(Rental rental)
        {
            _IRentalDal.Delete(rental);
            return new SuccessResult();
        }
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
        public IResult Update(Rental rental)
        {
            _IRentalDal.Update(rental);
            return new SuccessResult();
        }

    }
}
