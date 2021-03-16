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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from rentals in context.Rentals
                             join cars in context.Cars on rentals.CarId equals cars.Id
                             join colors in context.Colors on cars.ColorId equals colors.ColorId
                             join brands in context.Brands on cars.BrandId equals brands.BrandId
                             join customers in context.Customers on rentals.CustomerId equals customers.UserId
                             join users in context.Users on customers.UserId equals users.Id
                             select new RentalDetailDto
                             {
                                 Id = rentals.Id,
                                 CarName = cars.CarName,
                                 CarPrice = cars.DailyPrice,
                                 ModelYear = cars.ModelYear,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 CompanyName = customers.CompanyName,
                                 RentDate = rentals.RentDate,
                                 ReturnDate = rentals.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
