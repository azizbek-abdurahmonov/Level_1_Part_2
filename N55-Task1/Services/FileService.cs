namespace N55_Task1.Services;

public class FileService
{
    public void FindFile(string folderPath, string tagetFile)
    {
        var directory = new DirectoryInfo(folderPath);
        var files = directory.GetFiles();
        var directories = directory.GetDirectories();


        foreach (var file in files)
        {
            if (file.Name.Equals(tagetFile))
            {
                Console.WriteLine(file.ToString());
            }
        }

        foreach (var d in directories)
        {
            FindFile(d.ToString(), tagetFile);
        }
    }
}