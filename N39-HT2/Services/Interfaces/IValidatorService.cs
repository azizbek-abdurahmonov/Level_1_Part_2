namespace N39_HT2.Services.Interfaces;

public interface IValidatorService
{
    bool IsValidEmailAddress(string emailAddress);
    bool IsValidPassword(string password);
}
