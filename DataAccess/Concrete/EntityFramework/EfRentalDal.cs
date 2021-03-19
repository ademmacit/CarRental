using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, DbCarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (DbCarRentalContext context = new DbCarRentalContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars on rental.CarId equals car.Id
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join customer in context.Customers on rental.CustomerId equals customer.Id
                             join user in context.Users on customer.UserId equals user.Id
                             select new RentalDetailDto()
                             {
                                 BrandName = brand.Name,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                             };
                return result.ToList();
            }
        }
    }
}
