using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Entities.Concrete.Car() { Id = 5, BrandId = 3, CarName = "new", ColorId = 4, DailyPrice = 111, Description = "ASFF", ModelYear = 1999});
            var result = carManager.GetAll();

            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName);
            }

        }
    }
}
