using System.Text.RegularExpressions;
using App.Interfaces;

namespace App.Validators
{
    public class EmailValidator : IEmailValidator
    {
        public bool Validate(string data)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(data);
            return match.Success;
        }
    }
}