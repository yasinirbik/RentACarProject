using Entities.Concrete;
using System.Collections.Generic;

//VERİTABANI OLUŞTURMAZSAK VEYA BİR VERİTABANI KULLANIMI DURUMU HİÇ OLMAZSA BİZ BURADAKİ DURUMM GİBİ VERİ TABANI OLUSTURUR VE ENİTİTYFRAMWORKLER DEĞİL BU BLOK KULLANILIR 
//LAKIN VERİTABANI KULLANDIĞIMIZ İÇİN BU KISIM GEREKSİZ HLE GELMİŞ "EF" KISMI GEREKLİ DURUMA GELMİŞTİR.



using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1,BrandId = 3,ColorId = 2,/*CarModel = "Q7",*/ModelYear = "2021",DailyPrice = 640000,Descriptions = "0 KM "},
                new Car{Id = 2,BrandId = 1,ColorId = 1,/*CarModel = "Passat",*/ModelYear = "2021",DailyPrice = 420000,Descriptions = "0 KM "},
                new Car{Id = 3,BrandId = 5,ColorId = 2,/*CarModel = "Corolla",*/ModelYear = "2020",DailyPrice = 250000,Descriptions = "33KM "},
                new Car{Id = 4,BrandId = 6,ColorId = 3,/*CarModel = "i30",*/ModelYear = "2016",DailyPrice = 72000,Descriptions= "290 KM "},
                new Car{Id = 5,BrandId = 2,ColorId = 1,/*CarModel = "Clio",*/ModelYear = "2013",DailyPrice = 56000,Descriptions = "697 KM "},
                new Car{Id = 6,BrandId = 4,ColorId = 8,/*CarModel = "Qashqai",*/ModelYear = "2021",DailyPrice = 515000,Descriptions = "0 KM "},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }
        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);//gönderilen carıd'nin sahip olduğu car eşitleme ile güncelleir.
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            //carToUpdate.CarModel = car.CarModel;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Descriptions = car.Descriptions;
            carToUpdate.ModelYear = car.ModelYear;
        }
        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int CarId, int ColorId, int BrandId)
        {
            return _cars.Where(c => c.Id == CarId && c.ColorId == ColorId && c.BrandId == BrandId).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
        public List<Car> GetAllByBrandId(Func<object, object> c)
        {
            throw new NotImplementedException();
        }

        public List<Car> GatAllByBrandId(Func<object, object> c)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
