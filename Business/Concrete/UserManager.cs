using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (user.UserId<=0)
            {
                return new ErrorResult(Messages.UserNotAdded);
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            if (user.UserId <= 0)
            {
                return new ErrorResult(Messages.UserNotDeleted);
            }
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 24)
            {
                return new ErrorDataResult<List<User>>(Messages.UsersNotListed);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public IResult Update(User user)
        {
            if(user.UserId <= 0)
            {
                return new ErrorResult(Messages.UserNotUpdated);
            }
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
