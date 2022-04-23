using System;
using System.IO;

namespace ApiBitBucket.Utils
{
    public class ApplicationUtils
    {
        public const string BASE_URL = "https://api.bitbucket.org/2.0/users/";

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

            if (string.IsNullOrEmpty(path) || !File.Exists(""))
            {
                Console.WriteLine("File not found");
                Console.WriteLine("Enter EXIT to terminate");
                GetPath();
            }              

            return path;
        }
    }
}
