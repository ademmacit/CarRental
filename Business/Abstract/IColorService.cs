using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IResult Add(Color item);
        IResult Delete(Color item);
        IResult Update(Color item);
        IDataResult<Color> GetById(int id);
    }
}
