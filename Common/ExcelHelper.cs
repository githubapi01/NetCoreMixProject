using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using CsvHelper;

namespace NetCoreMixProject
{
    public class ExcelHelper
    {
        public static void BuildCSV<T>(string path ,List<T> records)
        {
            using (var writer = new StreamWriter(path ,false,Encoding.UTF8))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords<T>(records);
                }
            }
        }
    }
}
