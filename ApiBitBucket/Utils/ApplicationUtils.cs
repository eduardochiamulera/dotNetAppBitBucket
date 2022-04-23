using System;
using System.IO;
using System.Linq;

namespace ApiBitBucket.Utils
{
    public class ApplicationUtils
    {
        public const string BASE_URL = "https://api.bitbucket.org/2.0/users/";
        public const int SIXTY_SECONDS = 60000;
        public const int FIVE_SECONDS = 5000;

        public static string DefaultDirectory()
        {
            var directory = System.Reflection.Assembly.GetExecutingAssembly().Location;
            directory = directory.Substring(0, directory.LastIndexOf("ApiBitBucket\\"));
            return directory;
        }

        public static string GetPath()
        {
            var path = "";
            Console.WriteLine("Enter the full path to the file");

            path = Console.ReadLine();

            if(!string.IsNullOrEmpty(path) && path.ToLower() == "exit")
                Environment.Exit(0);

            if (string.IsNullOrEmpty(path) || !File.Exists(path))
            {
                Console.WriteLine("File not found");
                Console.WriteLine("Enter EXIT to terminate");
                GetPath();
            }              

            return path;
        }

        public static bool ApplicationIsAlreadyRunning()
        {
            return System.Diagnostics.Process.GetProcessesByName(Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1;
        }
    }
}
