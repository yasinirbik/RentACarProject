using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal  _customerDal;
        public CustomerManager(ICustomerDal customerDal) 
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            if (customer.UserId <= 0)
            {
                return new ErrorResult(Messages.CustomerNotAdded);
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            if (customer.UserId <= 0)
            {
                return new ErrorResult(Messages.CustomerNotDeleted);
            }
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour == 24 )
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.CustomersListed);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            if (DateTime.Now.Hour == 24)
            {
                return new ErrorDataResult<List<CustomerDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails());
        }

        public IResult Update(Customer customer)
        {
            if (customer.UserId <= 0)
            {
                return new ErrorResult(Messages.CustomerNotUpdated);
            }
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
