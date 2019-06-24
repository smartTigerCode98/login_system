
using App.Exceptions;
using App.Interfaces;

namespace App.Services
{
    public class SignService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailValidator _emailValidator;
        private readonly IPasswordValidator _passwordValidator;

        public SignService(IUserRepository userRepository, IEmailValidator emailValidator, 
            IPasswordValidator passwordValidator)
        {
            _userRepository = userRepository;
            _emailValidator = emailValidator;
            _passwordValidator = passwordValidator;
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