using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(IEntity entity)
        {
            using (DbCarRentalContext context = new DbCarRentalContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(IEntity entity)
        {
            using (DbCarRentalContext context = new DbCarRentalContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (DbCarRentalContext context = new DbCarRentalContext())
            {
                return context.Set<Car>().      //created a dbset for cars
                    SingleOrDefault(filter);    //uses linq operation SingleOrDefault with given filter
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (DbCarRentalContext context = new DbCarRentalContext())
            {
                if (filter == null)
                    return context.Set<Car>().ToList();
                else
                    return context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(IEntity entity)
        {
            using (DbCarRentalContext context = new DbCarRentalContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
