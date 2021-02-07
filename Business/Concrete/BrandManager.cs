using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _IBrandDal;

        public BrandManager(IBrandDal ıBrandDal)
        {
            _IBrandDal = ıBrandDal;
        }

        public void Add(Brand brand)
        {
            _IBrandDal.Add(brand);
        }

        public void Delete(Brand brand)
        {
            _IBrandDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _IBrandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _IBrandDal.Get(p=>p.Id == id);

        }
        public void Update(Brand brand)
        {
            _IBrandDal.Update(brand);
        }
    }
}
