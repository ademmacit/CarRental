using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business
{
    public interface ICrudService<T>
    {
        IDataResult<List<T>> GetAll();
        IResult Add(T brand);
        IResult Delete(T brand);
        IResult Update(T brand);
        IDataResult<T> GetById(int id);
    }
}
