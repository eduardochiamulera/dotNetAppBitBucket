using System.IO;

namespace ApiBitBucket.Service
{
    public class ReadFileService
    {
        private string[] Lines;

        public string[] ReadLines { get => Lines; }

        public void ReadFile(string path)
        {
            Lines = File.ReadAllLines(path);
        }
    }
}
