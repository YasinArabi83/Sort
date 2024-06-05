using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;

namespace DataAccess
{
    public class CsvContext
    {
        public List<int> ReadNumbers(string FilePath)
        {
            var numbers = new List<int>();

            using (var reader = new StreamReader(FilePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {

                while (csv.Read())
                {
                    if (csv.TryGetField<int>(0, out var number))
                    {
                        numbers.Add(number);
                    }
                }
            }

            return numbers;
        }
    }
}

