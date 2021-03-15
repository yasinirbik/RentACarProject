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
            // GetAllTest();
            //UpdateTest();
            //GetAllBrandNameTest();
            //GetAllColorNameTest();
            // DTOTest();
            // NiyeCalismadiginiAnlamadigimAddTest();  // Çalışıyor db'ye ekleme yapıyor ama aynı zamnada listeleme yapmasını stesemde efrepository'deki "add" komutunun altndaki save.Context()'de hata veriyor ama eklme işleminde bir sorun yok.
            // UpdateTestWithResults(); //Hatasız çalışmakta
            //SimdilikCalismayanCustomerAdd();

        }

        private static void SimdilikCalismayanCustomerAdd()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer addedCustomer = new Customer() { UserId = 2, CompanyName = "Bursa Teknik Lisesi" };
            customerManager.Add(addedCustomer);
            var result = customerManager.Add(addedCustomer);
            if (result.Success == true)
            {
                var result2 = customerManager.GetCustomerDetails();
                if (result2.Success == true)
                {
                    foreach (var customer in result2.Data)
                    {
                        Console.WriteLine(customer.CompanyName);
                        Console.WriteLine();
                    }
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void UpdateTestWithResults()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car UpdatedCar = new Car() { Id = 3, CarName = "Honda crv", BrandId = 1, ColorId = 3, DailyPrice = 100, Descriptions = "Benzin falan", ModelYear = "2015" };
            carManager.Update(UpdatedCar);
            var result = carManager.Update(UpdatedCar);
            if (result.Success == true)
            {
                var result2 = carManager.GetCarDetails();
                if (result2.Success == true)
                {
                    foreach (var car in result2.Data)
                    {
                        Console.WriteLine(car.CarName);
                        Console.WriteLine();
                    }
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void NiyeCalismadiginiAnlamadigimAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car NewCar = new Car {  BrandId = 3, ColorId = 1, CarName = "Wolksvagen Arteon", DailyPrice = 120, ModelYear = "2019", Descriptions = "Manuel vites" };
            carManager.Add(NewCar);
            var result = carManager.Add(NewCar);
            if (result.Success == true)
            {
                var result2 = carManager.GetCarDetails();
                if (result2.Success == true)
                {
                    foreach (var car in result2.Data)
                    {
                        Console.WriteLine(car.CarName + "  ------->  " + car.BrandName + "  ------->  " + car.ColorName);
                        Console.WriteLine();
                        //Join edilmiş 3 farklı tablo'nun 3 ayrı elemanı ekrana listelenmiştir.
                    }
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void DTOTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "  ------->  " + car.BrandName + "  ------->  " + car.ColorName);
                    Console.WriteLine();
                    //Join edilmiş 3 farklı tablo'nun 3 ayrı elemanı ekrana listelenmiştir.
                }
                Console.WriteLine(result.Message); 
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void GetAllColorNameTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            {
                if (result.Success == true)
                {
                    foreach (var color in result.Data)
                    {
                        Console.WriteLine(color.ColorName);
                    }

                    Console.WriteLine(result.Message);
                }
                else
                {
                    Console.WriteLine(result.Message);
                }
            }
           
        }

        private static void GetAllBrandNameTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            {
                if (result.Success == true)
                {
                    foreach (var brand in result.Data)
                    {
                        Console.WriteLine(brand.BrandName);
                    }

                    Console.WriteLine(result.Message);
                }
                else
                {
                    Console.WriteLine(result.Message);
                }

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
            var result = carManager.GetAll();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName);
                }

                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
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
