using System.Text;

namespace EmailMessageApp;

public class EmailMessage
{
    public static Task Exec()
    {
        var filePath = @"D:\PROJECTS\Level_1_Part_2\N43-T1\emailtemplates.txt";
        var mutex = new Mutex(false, "mutex1");

        return Task.Run(() =>
        {
            mutex.WaitOne();
            var stream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite);
            Console.WriteLine("Fayl ochildi...");

            var buffer = new byte[stream.Length];

            stream.Read(buffer, 0, buffer.Length);

            Console.WriteLine("Template o'qib olindi...");

            var buffer2 = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(buffer).Replace("{{Name}}", "Azizbek"));
            stream.Write(buffer2, 0, buffer2.Length);
            Console.WriteLine("Message faylga yozildi...");
            stream.Close();
            Console.WriteLine("Fayl yopildi...");
            mutex.ReleaseMutex();
        });
    }
}