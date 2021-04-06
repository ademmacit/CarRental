using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User,DbCarRentalContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new DbCarRentalContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        public UserInfoDto GetUserInfo(Expression<Func<User, bool>> filter)
        {
            using (DbCarRentalContext context = new DbCarRentalContext())
            {
                var userFound = context.Set<User>().SingleOrDefault(filter);

                var userInfo = new UserInfoDto()
                {
                    Email = userFound.Email,
                    FirstName = userFound.FirstName,
                    Id = userFound.Id,
                    LastName = userFound.LastName
                };

                return userInfo;
            }
        }

        public void UpdateUserInfo(UserInfoDto userInfo)
        {
            using (DbCarRentalContext context = new DbCarRentalContext())
            {
                User userToBeUpdated = context.Set<User>().      
                    SingleOrDefault(u=>u.Id == userInfo.Id);

                userToBeUpdated.Email = userInfo.Email;
                userToBeUpdated.FirstName = userInfo.FirstName;
                userToBeUpdated.LastName = userInfo.LastName;

                var updatedEntity = context.Entry(userToBeUpdated);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
