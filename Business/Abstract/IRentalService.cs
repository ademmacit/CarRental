using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental item);
        IResult Delete(Rental item);
        IResult Update(Rental item);
        IDataResult<Rental> GetById(int id);

        IResult DeleteAll();
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
    }
}
