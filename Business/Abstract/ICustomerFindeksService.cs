using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICustomerFindeksService
    {

        IDataResult<List<CustomerFindeks>> GetAll();
        IResult Add(CustomerFindeks item);
        IResult Delete(CustomerFindeks item);
        IResult Update(CustomerFindeks item);
        IDataResult<CustomerFindeks> GetById(int id);
        IDataResult<CustomerFindeks> GetByCustomerId(int id);
    }
}
