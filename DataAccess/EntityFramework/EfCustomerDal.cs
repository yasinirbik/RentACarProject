using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext ())
            {
                var result = from cu in filter is null ? context.Customers : context.Customers.Where(filter)
                             join u in context.Users
                             on cu.UserId equals u.UserId
                             select new CustomerDetailDto()
                             {
                                 CustomerId = cu.Id,
                                 UserId = u.UserId,
                                 UserName = u.FirstName,
                                 UserLastName = u.LastName,
                                 CompanyName = cu.CompanyName,
                                 EMail = u.EMail
                             };
                return result.ToList();
            }
        }
    }
}
