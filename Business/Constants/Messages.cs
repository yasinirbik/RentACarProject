using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string InvalidCarValues = "Hatalı Deger girdiniz!";
        public static string CarAdded = "Araba eklendi!";
        public static string MaintenanceTime="Sistem Bakımda!";
        public static string CarDeleted = "Araba silindi!";
        public static string CarUpdated = "Araba Güncellendi!";
        public static string CarsListed = "Arabalar listelendi!";
        public static string BrandsListed = "Markalar Listelendi!";
        public static string BrandGotByBrandId = "İstenilen ID numarasına sahip marka ekrana verildi!";
        public static string ColorsListed = "Renkler Listelendi!";
        public static string ColorGotByColorId = "İstenilen ID numarasına sahip renk ekrana verildi!";
        public static string DetailsListed = "İstenilen araba detayları listelendi!";
        public static string CustomerAdded = "Müsteri Eklendi!";
        public static string RentalAdded = "Rent Eklendi!";
        public static string CustomerNotAdded = "Müşeri Eklenemedi.";
        public static string CustomerNotDeleted ="Müşteri Silinemedi.";
        public static string CustomerDeleted = "Müşteri Silindi.";
        public static string CustomersListed= "Müşteriler Listelendi.";
        public static string CustomerNotUpdated = "Müşteri Güncellenemedi.";
        public static string CustomerUpdated = "Müşteri Güncellendi.";
        public static string RentalNotAdded = "Rent Eklenemedi.";
        public static string RentalNotDeleted = "Rent Silinemedi";
        public static string RentalDeleted = "Rent Silindi.";
        public static string RentalsNotListed= "Rentler Listelenemedi.";
        public static string RentalsListed = "Rentler Listelendi.";
        public static string RentalDetailsNotListed = "Rent Deytayları Listelenemedi.";
        public static string RentalDetailsListed= "Rent Detayları Lİstelendi.";
        public static string RentalNotUpdated= "Rent Güncellenemedi.";
        public static string RentalUpdated = "Rent Güncellendi.";
        public static string UserNotAdded = "Kullanıcı Eklenemedi.";
        public static string UserAdded = "Kullanıcı Eklendi.";

        public static string UserNotDeleted = "Kullanıcı Silinemedi.";
        public static string UserDeleted = "Kullanıcı Silindi.";
        public static string UserNotUpdated = "Kullanıcı Güncellenemedi.";
        public static string UserUpdated = "Kullanıcı Güncellendi.";
        public static string UsersNotListed = "Kullanıcılar Listelenemedi.";
        public static string UsersListed = "Kullanıcılar Listelendi.";

        public static string RentalNotUpdateReturnDate = "Rent'in İade Tarihi Güncellenemedi.";
        public static string RentalUpdatedReturnDate = "Rent'in İade Tarihi Güncellendi." ;
        public static string RentalAddError = "Rent Ekleme Hatası. İade Edilmemiş Araç.";
    }
}
