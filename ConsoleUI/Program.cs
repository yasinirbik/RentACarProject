using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // GetAllCarTest();
            //UpdateCarTest();
            // GetAllBrandNameTest();
            // GetAllColorNameTest();
            DTOTest();

        }

        private static void DTOTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + "  ------->  " + car.BrandName + "  ------->  " + car.ColorName);
                //Join edilmiş 3 farklı tablo'nun 3 ayrı elemanı ekrana listelenmiştir.
            }
        }

        private static void GetAllColorNameTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void GetAllBrandNameTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void UpdateTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car UpdatedCar = new Car { Id = 5, BrandId = 1, ColorId = 3, DailyPrice = 45, Descriptions = "Güzel Bir Araç.", ModelYear = "2019" };
            carManager.Update(UpdatedCar);
            GetAllTest();
        }

        private static void GetAllTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);
            }
        }




        //Bu kısımlar Inmemory ile çalışmalar içindi
        //Car newCar = new Car { CarId = 35, CarModel = "C180", BrandId = 7, ColorId = 2, DailyPrice = 850000, ModelYear = 2020, Description = "120 KM" };
        //carManager.Add(newCar);//C180 ekledik
        //Car deletingCar = new Car { CarId = 4 };
        //carManager.Delete(deletingCar);//İ30'u sildik.
        //Car updatingCar = new Car { CarId = 2, CarModel = "Tofas" };//carID= 2 olan passatı bulur ve CarModel'i Tofas'a esitler
        //carManager.Update(updatingCar);//Passat'ı TOFAŞ olarak güncelledik


        //Car updatedCar = new Car { Id = 5, BrandId = 2, ColorId = 1, ModelYear = "2018", DailyPrice = 145, Descriptions = "benzinli Tank" };
        //carManager.Update(updatedCar); //5 no'lu boş datayı güncelledik, başarıyla çalışmakta
        //Car deletedCar = new Car { Id = 1};
        //carManager.Delete(deletedCar);1 NUMARALI CAR'I SİLDİ BAŞARIYLA ÇALIŞMAKTA
        //Car newCar = new Car { Id = 1,Descriptions = "Benzinsiz Tank", DailyPrice = 100 };
        //  carManager.Add(newCar); // Add fonksiyonu hata vermese de ekleme işlemini gerçekleştirememekte, dahasonra incelenecektir.

    }
}
