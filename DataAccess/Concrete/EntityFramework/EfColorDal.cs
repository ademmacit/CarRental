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
    public class EfColorDal : IColorDal
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

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (DbCarRentalContext context = new DbCarRentalContext())
            {
                return context.Set<Color>().
                    SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (DbCarRentalContext context = new DbCarRentalContext())
            {
                if (filter == null)
                    return context.Set<Color>().ToList();
                else
                    return context.Set<Color>().Where(filter).ToList();
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
