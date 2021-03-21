using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, DbCarRentalContext>, ICarDal
    {
     
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (DbCarRentalContext context = new DbCarRentalContext())
            {
               
                    var result = from car in context.Cars
                                 join brand in context.Brands on car.BrandId equals brand.Id
                                 join color in context.Colors on car.ColorId equals color.Id
                                 select new CarDetailDto()
                                 {
                                     carId = car.Id,
                                     BrandName = brand.Name,
                                     CarName = car.Description,
                                     ColorName = color.Name,
                                     DailyPrice = car.DailyPrice,
                                     BrandId = brand.Id,
                                     ColorId = color.Id
                                 };
                     
                if (filter == null)
                    return result.ToList();
                else
                    return result.Where(filter).ToList();

            }
        }
    }
}
