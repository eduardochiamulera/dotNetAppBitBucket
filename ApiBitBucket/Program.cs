using ApiBitBucket.Service;
using ApiBitBucket.Utils;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace bitBucketAPI
{
    internal class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static BitBucketService service;
        private static ReadFileService readFile;
        static async Task Main(string[] args)
        {
            if (ApplicationUtils.ApplicationIsRunning())
                Thread.Sleep(ApplicationUtils.SIXTY_SECONDS);
            
            var path = ApplicationUtils.GetPath();
            readFile = new ReadFileService();
            readFile.ReadFile(path);
            service = new BitBucketService(readFile.ReadLines);
            await service.GetAsync();
            
            Environment.Exit(0);
        }

    }
}
