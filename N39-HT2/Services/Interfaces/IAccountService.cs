namespace N39_HT2.Services.Interfaces;

public interface IAccountService
{
    Task<bool> RegisterAsync(string firstName, string lastName, string emailAddress, string password);
}
