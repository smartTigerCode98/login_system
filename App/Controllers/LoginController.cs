using System;
using App.Exceptions;
using App.Interfaces;

namespace App.Controllers
{
    public class LoginController
    {
        private readonly ILoginService _signService;

        private readonly IView _view;

        private bool _emailIsInputted;
        private bool _passIsInputted;
        private string _email;
        private string _password;

        public LoginController(ILoginService loginService, IView view)
        {
            _signService = loginService;
            _view = view;
            _emailIsInputted = false;
            _passIsInputted = false;
            _email = "";
            _password = "";
        }
        
        private static string InputNecessaryField(string fieldName)
        {
            Console.WriteLine("Input your " + fieldName);
            var value = Console.ReadLine();
            return value;
        }

        private void InputEmail()
        {
            if (_emailIsInputted) return;
            _email = InputNecessaryField("email");
            _emailIsInputted = true;
        }

        private void InputPassword()
        {
            if (_passIsInputted) return;
            _password = InputNecessaryField("password");
            _passIsInputted = true;
        }

        private void SetStatusInputtedFields(bool emailStatus, bool passStatus)
        {
            _emailIsInputted = emailStatus;
            _passIsInputted = passStatus;
        }

        private void SaveExceptionMessage(Exception e)
        {
            _view.Msg = e.Message;
        }

        private void HandleException(Exception e, bool emailStatus, bool passStatus)
        {
            SaveExceptionMessage(e);
            SetStatusInputtedFields(emailStatus, passStatus);
        }

        public void Run()
        {
            while (true)
            {
                InputEmail();
                InputPassword();
                
                try
                { 
                    if (_signService.Login(_email, _password))
                    {
                        _view.Msg = $"{_email} welcome!";
                        break;
                    }
                }
                catch (InvalidEmailException e)
                {
                    HandleException(e, false, _passIsInputted);
                }
                catch (InvalidPasswordException e)
                {
                    HandleException(e, _emailIsInputted, false);
                }
                catch (UserNotFoundException e)
                {
                    HandleException(e, false, false);
                }
                catch (NotPasswordMatchException e)
                {
                    HandleException(e, _emailIsInputted, false);
                }   
                
                _view.Display();
            }
        }
    }
}