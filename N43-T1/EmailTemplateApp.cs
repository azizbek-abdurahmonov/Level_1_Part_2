using System.Security.Cryptography;
using System.Text;

namespace N43_T1;

public class EmailTemplateApp
{
    public static Task ExecuteAsync()
    {
        string filePath = @"D:\PROJECTS\Level_1_Part_2\N43-T1\emailtemplates.txt";
        var mutex = new Mutex(false, "mutex1");

        return Task.Run(() =>
        {
            mutex.WaitOne();

            var stream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite);

            Console.WriteLine("File ochildi...");

            var data = Encoding.UTF8.GetBytes("Salom {{Name}}, bla bla bla bla ...");
            stream.Write(data);

            Thread.Sleep(10_000);
            stream.Flush();
            Console.WriteLine("Faylga yozildi!");
            stream.Close();
            Console.WriteLine("Fayl yopildi!");
            mutex.ReleaseMutex();
        });
    }
}