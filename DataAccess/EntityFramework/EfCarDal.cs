using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        //Arabaya özel operasyonlar buruaya yazılacak.
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext ())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join k in context.Colors
                             on c.ColorId  equals k.ColorId
                             select new CarDetailDto { Id = c.Id, CarName = c.CarName, BrandName = b.BrandName,
                                 ColorName = k.ColorName, DailyPrice = c.DailyPrice, ModelYear = c.ModelYear };
                return result.ToList();
            }
        }
    }
}
