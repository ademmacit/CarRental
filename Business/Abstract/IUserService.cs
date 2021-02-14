using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IResult Add(User customer);
        IResult Delete(User customer);
        IResult Update(User customer);
        IDataResult<User> GetById(int id);
    }
}
