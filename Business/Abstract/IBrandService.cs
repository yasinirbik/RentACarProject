using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {//Bi ara bu ve Color service a crud operations ekle.
        IDataResult<List<Brand>> GetAll();
        IDataResult<List<Brand>> GetById(int brandId);//Gönderilen ıd'numarasına sahip kategori'yi geitirir.
    }
}
