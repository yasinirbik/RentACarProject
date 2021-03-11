using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal; //_brandDal a gel ampüle tıkla generate constructor de zaten 14-17 arasındaki kod direkt oluşacaktır.

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }
        //Aşağısı = (SQL) select * from categories where CategoryId = categoryId(3,5,etc.)
        public List<Brand> GetById(int brandId)
        {
            return _brandDal.GetAll(c => c.BrandId == brandId);
        }
    }
}
