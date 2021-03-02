using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {

            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);

        }

        public IResult Delete(User entity)
        {
            _userDal.Delete(entity);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId));
        }

        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult(Messages.UserUpdated);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }
    }
}
