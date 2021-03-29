using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IResult Add(Brand item);
        IResult Delete(Brand item);
        IResult Update(Brand item);
        IDataResult<Brand> GetById(int id);
    }
}
