using System;
using App.Exceptions;
using App.Interfaces;
using App.Validators;

namespace App.Services
{
    public class SignService
    {
        private readonly IUserRepository _userRepository;
        private readonly EmailValidator _emailValidator;
        private readonly PasswordValidator _passwordValidator;

        public SignService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _emailValidator = new EmailValidator();
            _passwordValidator = new PasswordValidator();
        }

        public bool Login(string email, string password)
        {
            if (!_emailValidator.Validate(email)) throw new InvalidEmailException(email);
            if(!_passwordValidator.Validate(password)) throw new InvalidPasswordException();
            var user = _userRepository.FindUser(email);
            if (user == null) throw new UserNotFoundException(email);
            var comparePass = user.Password.Equals(password);
            if (!comparePass) throw new NotPasswordMatchException();
            return true;
        }
    }
}