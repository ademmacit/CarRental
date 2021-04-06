using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public UserInfoDto GetUserInfoByMail(string email)
        {
            return _userDal.GetUserInfo(u => u.Email == email);
        }

        public void UpdateUserInfo(UserInfoDto userInfo)
        {
            _userDal.UpdateUserInfo(userInfo);
        }
    }
}
