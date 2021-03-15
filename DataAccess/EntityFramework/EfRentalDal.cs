using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<CarRentalDetailDto> GetCarRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext ())
            {
                var result = from r in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars on r.CarId equals c.Id
                             join co in context.Colors on c.ColorId equals co.ColorId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cu in context.Customers on r.CustomerId equals cu.Id
                             join u in context.Users on cu.UserId equals u.UserId
                             select new CarRentalDetailDto
                             {
                                 RentalId = r.Id,
                                 CustomerName = u.FirstName,
                                 CustomerLastName = u.LastName,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
