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
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            //BrandCrudTest(brandManager);
            //ColorCrudTest(colorManager);
            //CarCrudTest(carManager);

            DisplayTables(carManager, colorManager, brandManager);

        }

        private static void DisplayTables(CarManager carManager, ColorManager colorManager, BrandManager brandManager)
        {
            Console.WriteLine("-- CARS --");
            foreach (var car in carManager.GetAll().Data)
                Console.WriteLine("{0} - {1} ", car.Id, car.Description);

            Console.WriteLine("-- COLORS --");
            foreach (var color in colorManager.GetAll().Data)
                Console.WriteLine("{0} - {1} ", color.Id, color.Name);

            Console.WriteLine("-- BRANDS --");
            foreach (var brand in brandManager.GetAll().Data)
                Console.WriteLine("{0} - {1} ", brand.Id, brand.Name);

            Console.WriteLine("-- CAR DETAILS --");
            foreach (var carDetail in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3}",
                    carDetail.CarName, carDetail.BrandName, carDetail.ColorName, carDetail.DailyPrice);
            }
        }

        private static void BrandCrudTest(BrandManager brandManager)
        {
            brandManager.Add(new Brand() { Id = 1, Name = "Honda" });
            brandManager.Add(new Brand() { Id = 2, Name = "Mercedes" });
            brandManager.Add(new Brand() { Id = 3, Name = "Mitsubushi" });
            brandManager.Add(new Brand() { Id = 4, Name = "Fiat" });
            brandManager.Add(new Brand() { Id = 5, Name = "Tesla" });
            brandManager.Delete(brandManager.GetById(5).Data);


            Brand UpdatedBrand = brandManager.GetById(1).Data;
            UpdatedBrand.Name = "Hyundai";
            brandManager.Update(UpdatedBrand);
        }

        private static void ColorCrudTest(ColorManager colorManager)
        {
            colorManager.Add(new Color() { Id = 1, Name = "Black" });
            colorManager.Add(new Color() { Id = 2, Name = "Red" });
            colorManager.Add(new Color() { Id = 3, Name = "White" });
            colorManager.Add(new Color() { Id = 4, Name = "Blue" });
            colorManager.Add(new Color() { Id = 5, Name = "Yellow" });
            colorManager.Delete(colorManager.GetById(5).Data);


            Color UpdatedColor = colorManager.GetById(1).Data;
            UpdatedColor.Name = "Green";
            colorManager.Update(UpdatedColor);
        }

        private static void CarCrudTest(CarManager carManager)
        {
            
            carManager.Add(new Car()
            {
                Id = 4,
                BrandId = 2,
                ColorId = 3,
                DailyPrice = 1250,
                Description = "Car 4",
                ModelYear = "1997"
            });
            carManager.Delete(carManager.GetById(3).Data);
            Car UpdatedCar = carManager.GetById(1).Data;
            UpdatedCar.Description = "Updated Car 1";
            carManager.Update(UpdatedCar);
        }
    }
}
