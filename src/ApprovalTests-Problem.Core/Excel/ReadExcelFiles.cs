using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace ApprovalTestsExcel.Core.Excel
{
    public class ReadExcelFiles
    {
        public List<T> ReadWithClass<T, T2>(string file) where T2 : ClassMap<T>
        {
            var parser = new ExcelDataReaderToIParser(file, new ExcelDataOptions());

            using (var csv = new CsvReader(parser))
            {
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