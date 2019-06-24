using System;
using App.Exceptions;
using App.Interfaces;

namespace App.Controllers
{
    public class LoginController
    {
        private readonly ILoginService _signService;

        private readonly IView _view;

        public LoginController(ILoginService loginService, IView view)
        {
            _signService = loginService;
            _view = view;
        }
        
        
        private static string InputNecessaryField(string fieldName)
        {
            Console.WriteLine("Input your " + fieldName);
            var value = Console.ReadLine();
            return value;
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
                    email = InputNecessaryField("email");
                    emailIsInputted = true;
                }

                if (!passIsInputted)
                {
                    password = InputNecessaryField("password");
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