using Newtonsoft.Json;
using System;
using System.IO;
using X9.Common.Extensions;

namespace X9.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var file in GetX9Files())
            {
                var processor = new Processor();

                using (var inputStream = new FileStream(file, FileMode.Open))
                {
                    processor.Execute(inputStream);
                }

                File.WriteAllText($"{AppSettings.OutputFilesPath}X9_JSON_Test.json", processor.FileSpec.ToJson());
                File.WriteAllText($"{AppSettings.OutputFilesPath}X9_JSON_Test.xml", processor.FileSpec.ToXml());
            }

            Console.ReadLine();
        }

        private static string[] GetX9Files()
        {
            // get files in path
            return Directory.GetFiles(AppSettings.InputFilesPath);
        }
    }
}
