using N39_HT2.Services;

var accountService = new AccountService();

try
{
    var result = await accountService.RegisterAsync("Azizbek", "Abdurahmonov", "abdura52.uz@gmail.com", "qwerty1234");
    if (result)
        Console.WriteLine("Muvaffaqiyatli ro'yhatdan o'tdingiz!");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
