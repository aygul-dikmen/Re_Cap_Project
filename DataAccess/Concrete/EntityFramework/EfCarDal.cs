using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from cars in context.Cars
                             join colors in context.Colors
                             on cars.ColorId equals colors.ColorId
                             join brands in context.Brands
                             on cars.BrandId equals brands.BrandId
                             select new CarDetailDto
                             {
                                 Id = cars.Id,
                                 CarName = cars.CarName,
                                 ColorName = colors.ColorName,
                                 BrandName = brands.BrandName,
                                 DailyPrice = cars.DailyPrice,
                                 Description = cars.Description
                             };
                return result.ToList();
            }
        }
    }
}
