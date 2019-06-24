namespace App.Interfaces
{
    public interface ILoginService
    {
        bool Login(string email, string password);
    }
}