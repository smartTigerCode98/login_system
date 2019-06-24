
using App.Controllers;
using App.Repositories;
using App.Services;
using App.Validators;
using App.Views;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new SignService(new InMemoryUserRepo(), new EmailValidator(), new PasswordValidator());
            var loginController = new LoginController(service, new View());
            loginController.Run();
        }
    }
}
