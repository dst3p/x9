using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using X9.Common.Extensions;

namespace X9.Test
{
    class CheckDetail
    {
        public string TcbAccount { get; set; }
        public string Amount { get; set; }
        public string CheckNumber { get; set; }
        public string CheckRoutingNumber { get; set; }
        public string CheckAccountNumber { get; set; }
    }

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

                var fileName = file.Split('\\').Last();
                var output = String.Empty; //processor.FileSpec.ToJson()
                var checkDetails = new Collection<CheckDetail>();

                foreach (var bundle in processor.FileSpec.CashLetter.Bundles)
                {
                    var accountNumber = bundle.CheckItems[0].CheckDetail.OnUs.Split('/')[0];

                    foreach (var check in bundle.CheckItems.Skip(1))
                    {
                        var checkDetail = new CheckDetail();

                        checkDetail.TcbAccount = accountNumber;

                        var checkDetailOnUsParts = check.CheckDetail.OnUs.Split('/');

                        checkDetail.Amount = check.CheckDetail.ItemAmount;
                        checkDetail.CheckAccountNumber = checkDetailOnUsParts[0];
                        checkDetail.CheckNumber = checkDetailOnUsParts[1];
                        checkDetail.CheckRoutingNumber = check.CheckDetail.PayorBankRoutingNumber;

                        checkDetails.Add(checkDetail);
                    }
                }

                output = checkDetails.ToJson();

                File.WriteAllText($"{AppSettings.OutputFilesPath}{DateTime.Now:yyyyMMddhhmm}_{fileName}.json", output);
                File.WriteAllText($"{AppSettings.OutputFilesPath}{DateTime.Now:yyyyMMddhhmm}_{fileName}_FULL.json", processor.FileSpec.ToJson());
                //File.WriteAllText($"{AppSettings.OutputFilesPath}X9_JSON_Test.xml", processor.FileSpec.ToXml());
            }
        }

        private static string[] GetX9Files()
        {
            // get files in path
            return Directory.GetFiles(AppSettings.InputFilesPath);
        }
    }
}
