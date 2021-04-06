using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        UserInfoDto GetUserInfo(Expression<Func<User, bool>> filter);
        void UpdateUserInfo(UserInfoDto userInfo);
    }
}
