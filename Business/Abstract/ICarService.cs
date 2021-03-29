using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService 
    {
        IDataResult<List<Car>> GetAll();
        IResult Add(Car item);
        IResult Delete(Car item);
        IResult Update(Car item);
        IDataResult<Car> GetById(int id);


        IDataResult<List<CarDetailDto>> GetCarDetailsByBrand(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColor(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorAndBrand(int colorId, int brandId);

        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<CarDetailDto> GetCarDetailByCarId(int carId);
    }
}
