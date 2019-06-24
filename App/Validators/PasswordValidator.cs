using System.Text.RegularExpressions;
using App.Interfaces;

namespace App.Validators
{
    public class PasswordValidator : IDataValidator<string>
    {
        public bool Validate(string data)
        {
            var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,15}$");
            var match = regex.Match(data);
            return match.Success;
        }
    }
}