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
    public class EfBrandDal : IBrandDal
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

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (DbCarRentalContext context = new DbCarRentalContext())
            {
                return context.Set<Brand>().
                    SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (DbCarRentalContext context = new DbCarRentalContext())
            {
                if (filter == null)
                    return context.Set<Brand>().ToList();
                else
                    return context.Set<Brand>().Where(filter).ToList();
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
