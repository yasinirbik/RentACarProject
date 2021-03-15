using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            var result = CheckReturnDate(rental.CarId);
            if (!result.Success)
            {
                return new ErrorResult(Messages.RentalNotAdded);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult CheckReturnDate(int carId)
        {
            var result = _rentalDal.GetCarRentalDetails(r => r.CarId == carId && r.ReturnDate == null);
            if (result.Count>0)
            {
                return new ErrorResult(Messages.RentalAddError);
            }
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            if (rental.CarId <= 0)
            {
                return new ErrorResult(Messages.RentalNotDeleted);
            }
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 24)
            {
                return new ErrorDataResult<List<Rental>>(Messages.RentalsNotListed);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<List<CarRentalDetailDto>> GetRentalDetails()
        {
            if (DateTime.Now.Hour == 24)
            {
                return new ErrorDataResult<List<CarRentalDetailDto>>(Messages.RentalDetailsNotListed);
            }
            return new SuccessDataResult<List<CarRentalDetailDto>>(_rentalDal.GetCarRentalDetails(),Messages.RentalDetailsListed);
        }

        public IResult Update(Rental rental)
        {
            if (rental.CarId <= 0)
            {
                return new ErrorResult(Messages.RentalNotUpdated);
            }
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult UpdateReturnDate(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.Id == rental.Id);
            var updateRental = result.LastOrDefault();
            if (updateRental.ReturnDate != null)
            {
                return new ErrorResult(Messages.RentalNotUpdateReturnDate);
            }
            updateRental.ReturnDate = rental.ReturnDate;
            _rentalDal.Update(updateRental);
            return new SuccessResult(Messages.RentalUpdatedReturnDate);
        }
    }
}
