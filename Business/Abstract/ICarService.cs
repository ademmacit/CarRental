using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService : ICrudService<Car>
    {
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrand(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColor(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorAndBrand(int colorId, int brandId);

        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<CarDetailDto> GetCarDetailByCarId(int carId);
    }
}
