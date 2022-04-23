using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ApiBitBucket.Utils;

namespace ApiBitBucket.Service
{
    public class BitBucketService
    {
        private readonly HttpClient _client;
        private readonly LogService _log;
        private readonly string[] _usersName;
        public BitBucketService(string[] usersName)
        {
            _client = new HttpClient();
            _usersName = usersName;
            _log = new LogService(); 
        }

        public async Task GetAsync()
        {
            foreach (var user in _usersName)
            {
                Console.WriteLine($"USER: {user}");
                _client.DefaultRequestHeaders.Accept.Clear();

                var url = ApplicationUtils.BASE_URL + user;
                var response = await _client.GetAsync(url);

                Console.WriteLine(response);
                _log.GenerateLog(url, response.ToString());
                await Task.Delay(5000);
            }
        }



    }
}
