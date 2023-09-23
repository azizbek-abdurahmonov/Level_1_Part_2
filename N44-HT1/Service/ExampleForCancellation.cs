namespace N44_HT1.Service;

public static class ExampleForCancellation
{
    public static async ValueTask Execute(CancellationToken cancellationToken)
    {
        for (var index = 0; index < 100; index++)
        {
            // I - usul
            // if (cancellationToken.IsCancellationRequested)
            //     throw new TimeoutException("Time out ");

            // II - usul
            // cancellationToken.ThrowIfCancellationRequested();
            
            await Task.Delay(200, cancellationToken); // III - usul (async methodlarning ko'pchiligi token qabul qiladi)
        }
    }
}