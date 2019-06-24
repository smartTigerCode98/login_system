namespace App.Interfaces
{
    public interface IView
    {
        string Msg { get; set; }
        void Display();
    }
}