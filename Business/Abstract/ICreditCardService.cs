using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<List<CreditCard>> GetAll();
        IResult Add(CreditCard item);
        IResult Delete(CreditCard item);
        IResult Update(CreditCard item);
        IDataResult<CreditCard> GetById(int id);
        IDataResult<CreditCard> GetByUserId(int id);
    }
}
