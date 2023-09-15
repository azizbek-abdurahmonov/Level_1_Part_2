using N39_HT2.Services.Interfaces;
using System.Text.RegularExpressions;

namespace N39_HT2.Services;

public class ValidatorService : IValidatorService
{
    public bool IsValidEmailAddress(string emailAddress)
    {
        return Regex.IsMatch(emailAddress, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
    }

    public bool IsValidPassword(string password)
    {
        return Regex.IsMatch(password, @"^[A-Za-z0-9]{8,}$");
    }
}
