using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void AddExampleCars(CarManager carManager)
        {
            carManager.Add(
                new Car()
                {
                    Id = 1,
                    BrandId = 0,
                    ColorId = 0,
                    DailyPrice = 1000,
                    Description = "Car 1",
                    ModelYear = "2005"
                });

            carManager.Add(
                new Car()
                {
                    Id = 2,
                    BrandId = 1,
                    ColorId = 1,
                    DailyPrice = 2002,
                    Description = "Car 2",
                    ModelYear = "2015"
                });

            carManager.Add(
                new Car()
                {
                    Id = 3,
                    BrandId = 1,
                    ColorId = 2,
                    DailyPrice = 3000,
                    Description = "Car 3",
                    ModelYear = "2000"
                });

        }

        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
                Console.WriteLine(car.Description);

        }
    }
}
