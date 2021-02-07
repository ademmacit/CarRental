using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        IColorDal _IColorDal;

        public ColorManager(IColorDal ıColorDal)
        {
            _IColorDal = ıColorDal;
        }

        public void Add(Color brand)
        {
            _IColorDal.Add(brand);
        }

        public void Delete(Color brand)
        {
            _IColorDal.Delete(brand);
        }

        public List<Color> GetAll()
        {
            return _IColorDal.GetAll();
        }

        public Color GetById(int id)
        {
            return _IColorDal.Get(p => p.Id == id);

        }
        public void Update(Color brand)
        {
            _IColorDal.Update(brand);
        }

    }
}
