using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator :AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).NotEmpty(); //Car name boş olamaz
            RuleFor(c => c.CarName).MinimumLength(2);//car name en az 2 harften oluşmalı
            RuleFor(c => c.DailyPrice).NotEmpty();//car.dailyprice boş olamaz.
            RuleFor(c => c.DailyPrice).GreaterThan(0);//Daily price büyük 0 olmalı
            RuleFor(c => c.DailyPrice).GreaterThan(10).When(c => c.BrandId == 1); //BU da der ki; eğer brandıd 1 ise araba daily price'ı 10'dan büyük olmalıdır.(koşul ekleyerek)
           /* //Bir de kendimiz eklesek kural? 
            RuleFor(c => c.CarName).Must(StartWithA).WithMessage("Arabalar a harfi ile başlamalı");//Mesaj ekelyebiliyoruz*/
        
        }
       /* private bool StartWithA(string arg)//true false
        {
            return arg.StartsWith("A");
        }*/ //Bu blok da(18-19/22-25) kendimiz generate constructor ile bir kurla uydurduk ve onu tanımladık mesela vurada diyorzi ki car.carname must starts with 'A'
    }
}
