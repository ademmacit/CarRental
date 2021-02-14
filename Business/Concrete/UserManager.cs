using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _IUserDal;

        public UserManager(IUserDal ıUserDal)
        {
            _IUserDal = ıUserDal;
        }

        public IResult Add(User user)
        {
            _IUserDal.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _IUserDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>
                (_IUserDal.GetAll());
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>
                (_IUserDal.Get(p=>p.Id == id));
        }

        public IResult Update(User user)
        {
            _IUserDal.Update(user);
            return new SuccessResult();
        }
    }
}
