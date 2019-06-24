using System;

namespace App.Views
{
    public class View
    {
        public string Msg { private get; set; }

        public void Display()
        {
            Console.WriteLine(Msg);
        }
    }
}