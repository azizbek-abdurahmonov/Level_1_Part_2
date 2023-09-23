using N44_HT1.Service;

var cancellationTokenSourse = new CancellationTokenSource(5000);

try
{
    await ExampleForCancellation.Execute(cancellationTokenSourse.Token);

}
catch(Exception ex)
{
    Console.WriteLine("Exception bo'ldi: " + ex.Message);
}
