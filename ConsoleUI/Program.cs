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
            //CarManager carManager = new CarManager(new EfCarDal());
            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //UserManager userManager = new UserManager(new EfUserDal());
            //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //RentalManager rentalManager = new RentalManager(new EfRentalDal());


            //RentalCrud(rentalManager);
            //UserCrud(userManager);
            //CustomerCrud(customerManager);
            //BrandCrudTest(brandManager);
            //ColorCrudTest(colorManager);
            //CarCrudTest(carManager);

            //DisplayTables(carManager, colorManager, brandManager);
        }

        private static void RentalCrud(RentalManager rentalManager)
        {
            rentalManager.Add(new Rental()
            {
                CarId = 1,
                CustomerId = 1,
                RentDate = new DateTime(2020, 12, 30),
                ReturnDate = null
            });
            rentalManager.Add(new Rental()
            {
                CarId = 2,
                CustomerId = 2,
                RentDate = new DateTime(2019, 05, 01),
                ReturnDate = new DateTime(2019, 07, 11)
            });
            rentalManager.Add(new Rental()
            {
                CarId = 3,
                CustomerId = 1,
                RentDate = new DateTime(2020, 02, 22),
                ReturnDate = new DateTime(2021, 01, 01)
            });

            //trying to rent a car that is already rented
            Console.WriteLine(rentalManager.Add(new Rental()
            {
                CarId = 1,
                CustomerId = 1,
                RentDate = new DateTime(2020, 02, 22),
                ReturnDate = new DateTime(2021, 01, 01)
            }).Message);


            foreach (var rental in rentalManager.GetAll().Data)
                Console.WriteLine("{0} - {1} ", rental.CarId, rental.ReturnDate);
        }

        private static void CustomerCrud(CustomerManager customerManager)
        {
            customerManager.Add(new Customer()
            {
                UserId = 1,
                CompanyName = "adems company"
            });
            customerManager.Add(new Customer()
            {
                UserId = 2,
                CompanyName = "Emres company"
            });
            customerManager.Add(new Customer()
            {
                UserId = 3,
                CompanyName = "Alis company"
            });
        }

        //private static void UserCrud(UserManager userManager)
        //{
        //    userManager.Add(new User()
        //    {
        //        Email = "user1@hotmail.com",
        //        FirstName = "adem",
        //        LastName = "macit",
        //        Password = "pass1"
        //    });
        //    userManager.Add(new User()
        //    {
        //        Email = "user2@Gmail.com",
        //        FirstName = "emre",
        //        LastName = "begit",
        //        Password = "pass2"
        //    });
        //    userManager.Add(new User()
        //    {
        //        Email = "user3@Gmail.com",
        //        FirstName = "ali",
        //        LastName = "çalışkan",
        //        Password = "pass3"
        //    });
        //}

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
            brandManager.Add(new Brand() {  Name = "Honda" });
            brandManager.Add(new Brand() {  Name = "Mercedes" });
            brandManager.Add(new Brand() {  Name = "Mitsubushi" });
            brandManager.Add(new Brand() {  Name = "Fiat" });
            brandManager.Add(new Brand() {  Name = "Tesla" });
            //brandManager.Delete(brandManager.GetById(5).Data);


            //Brand UpdatedBrand = brandManager.GetById(1).Data;
            //UpdatedBrand.Name = "Hyundai";
            //brandManager.Update(UpdatedBrand);
        }

        private static void ColorCrudTest(ColorManager colorManager)
        {
            colorManager.Add(new Color() {  Name = "Black" });
            colorManager.Add(new Color() {  Name = "Red" });
            colorManager.Add(new Color() {  Name = "White" });
            colorManager.Add(new Color() {  Name = "Blue" });
            colorManager.Add(new Color() {  Name = "Yellow" });
            //colorManager.Delete(colorManager.GetById(5).Data);


            //Color UpdatedColor = colorManager.GetById(1).Data;
            //UpdatedColor.Name = "Green";
            //colorManager.Update(UpdatedColor);
        }

        private static void CarCrudTest(CarManager carManager)
        {
            
            carManager.Add(new Car()
            {
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 1250,
                Description = "Car 1",
                ModelYear = "1997"
            });
            carManager.Add(new Car()
            {
                BrandId = 1,
                ColorId = 2,
                DailyPrice = 1250,
                Description = "Car 2",
                ModelYear = "2000"
            });
            carManager.Add(new Car()
            {
                BrandId = 2,
                ColorId = 2,
                DailyPrice = 1250,
                Description = "Car 3",
                ModelYear = "2007"
            });
            carManager.Add(new Car()
            {
                BrandId = 3,
                ColorId = 1,
                DailyPrice = 1250,
                Description = "Car 4",
                ModelYear = "2010"
            });
            //carManager.Delete(carManager.GetById(3).Data);
            //Car UpdatedCar = carManager.GetById(1).Data;
            //UpdatedCar.Description = "Updated Car 1";
            //carManager.Update(UpdatedCar);
        }
    }
}
