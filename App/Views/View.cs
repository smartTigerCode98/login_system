using System;
using App.Interfaces;

namespace App.Views
{
    public class View : IView
    {
        public string Msg { get; set; }

        public void Display()
        {
            Console.WriteLine(Msg);
        }
    }
}