using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bitBucketAPI
{
    internal class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {

            var a = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directory = a.Substring(0, a.LastIndexOf("ApiBitBucket\\"));
            Console.WriteLine(directory);

            var path = GetPath();

            var lines = System.IO.File.ReadAllLines(path, Encoding.UTF8);
            var logName = $"{DateTime.Now.ToString("MM-dd-yyyy HH-mm-ss")}-log.txt";
            using (StreamWriter fs = File.CreateText(directory + logName))
            {
                Console.WriteLine(Environment.CurrentDirectory);
                foreach (var line in lines)
                {
                    Console.WriteLine($"USER: {line}");
                    client.DefaultRequestHeaders.Accept.Clear();

                    var stringTask = client.GetAsync($"https://api.bitbucket.org/2.0/users/" + line);
                    var msg = await stringTask;
                    fs.WriteLine(msg.ToString());
                    fs.WriteLine();
                    Console.WriteLine(msg);
                    Thread.Sleep(5000);
                }
            }


            foreach (var item in lines)
            {
                Console.WriteLine(item);
            }

            Thread.Sleep(5000);
            Environment.Exit(0);
        }

        static string GetPath()
        {
            var path = "";
            Console.WriteLine("Enter the full path to the file");

            path = Console.ReadLine();

            if (string.IsNullOrEmpty(path))
                GetPath();

            return path;
        }
    }
}
