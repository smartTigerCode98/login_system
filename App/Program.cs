using System;
using App.Controllers;
using App.Repositories;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var loginController = new LoginController(new InMemoryUserRepo());
            loginController.Run();
        }
    }
}
