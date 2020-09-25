using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using ApprovalTestsExcel.Core.Excel;
using CsvHelper;
using CsvHelper.Configuration;

namespace ApprovalTestsExcel.Core.Csv
{
    public class ReadCsvFiles
    {
        public List<T> ReadWithClass<T, T2>(string file, string delimiter = ";", Encoding enc = null, string cultureInfo = "de-DE") where T2 : ClassMap<T>
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (var sr = new StreamReader(file, enc ?? Encoding.GetEncoding(1252)))
            using (var csv = new CsvReader(sr, CultureInfo.GetCultureInfo(cultureInfo), false))
            {
                csv.Configuration.Delimiter = delimiter;
                csv.Configuration.RegisterClassMap<T2>();
                return csv.GetRecords<T>().ToList();
            }
        }


        public List<dynamic> ReadAsDynamic(string file)
        {
            var parser = new ExcelDataReaderToIParser(file, new ExcelDataOptions());

            using (var csv = new CsvReader(parser))
            {
                return csv.GetRecords<dynamic>().ToList();
            }
        }

        public List<dynamic> ReadAsExpandoObject(string file, ExpandoObject expando)
        {
            var parser = new ExcelDataReaderToIParser(file, new ExcelDataOptions());

            using (var csv = new CsvReader(parser))
            {
                
                foreach (var property in expando)
                {
                    Console.WriteLine(property.Key + ": " + property.Value);
                }
                
                return csv.GetRecords<dynamic>(expando).ToList();
            }
        }
    }
}