using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business
{
    public interface ICrudService<T>
    {
        IDataResult<List<T>> GetAll();
        IResult Add(T item);
        IResult Delete(T item);
        IResult Update(T item);
        IDataResult<T> GetById(int id);
    }
}
