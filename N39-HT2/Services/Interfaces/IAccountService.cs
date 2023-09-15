namespace N39_HT2.Services.Interfaces;

public interface IAccountService
{
    Task<bool> Register(string firstName, string lastName, string emailAddress, string password);
}
