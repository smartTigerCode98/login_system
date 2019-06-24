using System;
using App.Exceptions;
using App.Interfaces;
using App.Services;
using App.Validators;
using App.Views;

namespace App.Controllers
{
    public class LoginController
    {
        private readonly SignService _signService;

        private readonly View _view;

        public LoginController(IUserRepository userRepository)
        {
            _signService = new SignService(userRepository, new EmailValidator(), new PasswordValidator());
            
            _view = new View();
            
        }

        public void Run()
        {
            var allIsOk = false;
            var emailIsInputted = false;
            var passIsInputted = false;
            var email = "";
            var password = "";

            while (!allIsOk)
            {
                if (!emailIsInputted)
                {
                    Console.WriteLine("Input your email");
                    email = Console.ReadLine();
                    emailIsInputted = true;
                }

                if (!passIsInputted)
                {
                    Console.WriteLine("Input your password");
                    password = Console.ReadLine();
                    passIsInputted = true;
                }
                try
                {
                    allIsOk = _signService.Login(email, password);
                    if (allIsOk)
                    {
                        _view.Msg = $"{email} welcome!";
                    }
                }
                catch (InvalidEmailException e)
                {
                    _view.Msg = e.Message;
                    emailIsInputted = false;
                }
                catch (InvalidPasswordException e)
                {
                    _view.Msg = e.Message;
                    passIsInputted = false;
                }
                catch (UserNotFoundException e)
                {
                    _view.Msg = e.Message;
                    emailIsInputted = false;
                    passIsInputted = false;
                }
                catch (NotPasswordMatchException e)
                {
                    _view.Msg = e.Message;
                    passIsInputted = false;
                }   
                
                _view.Display();
            }
        }
    }
}