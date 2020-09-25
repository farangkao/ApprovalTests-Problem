using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using ExcelDataReader;

namespace ApprovalTestsExcel.Core.Excel
{
    public class ExcelDataReaderToIParser : IParser
    {
        readonly CsvConfiguration _configuration;

        private IExcelDataReader reader;
        private FileStream stream;
        public int rowCount;
        
        public ExcelDataReaderToIParser(string XlsxPath, ExcelDataOptions options)
        {
            _configuration = new CsvConfiguration(System.Globalization.CultureInfo.CurrentCulture);
            Context = new ReadingContext(TextReader.Null, _configuration, false);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            stream = File.Open(XlsxPath, FileMode.Open, FileAccess.Read);
            reader = ExcelReaderFactory.CreateReader(stream);
            rowCount = reader.RowCount;
        }
        
        public void Dispose()
        {
            reader?.Dispose();
            stream?.Dispose();
        }

        public string[] Read()
        {
            //List<String> _a = new List<String>();
            //string[] data = new string[reader.FieldCount];
            var rowList = new List<string>();

            if (!reader.Read())
                return null;

            for (int i = 0; i < reader.FieldCount; i++)
            {
                object o = reader.GetValue(i);
                //Debug.Print(o == null ? "ist null" : o.ToString());
                rowList.Add(!string.IsNullOrEmpty(o?.ToString()) ? o.ToString() : null);
            }
            return rowList.ToArray();
        }

        public ReadingContext Context { get; }

        public IParserConfiguration Configuration => _configuration;

        public IFieldReader FieldReader => null;


        public Task<string[]> ReadAsync()
        {
            return new Task<string[]>(Read);
        }
    }

}