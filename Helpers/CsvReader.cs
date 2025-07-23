namespace NET.Utilities.Helpers
{
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Threading.Tasks;
    using Microsoft.VisualBasic.FileIO;

    /// Summary:
    ///     Csv reader helper class.
    public class CsvReader
    {
        private string[] delimiters = new[] { ",", ";" };

        public async Task<object> RunAsync(string path)
        {
            string[] headers = new string[0];
            var rows = new List<IDictionary<string, object>>();

            using (var parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.Delimiters = delimiters;

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    if (parser.LineNumber == 2)
                    {
                        headers = fields;
                    }
                    else if (parser.LineNumber > 2)
                    {
                        var record = new ExpandoObject() as IDictionary<string, object>;
                        for (int i = 0; i < fields.Length; i++)
                        {
                            if (i < headers.Length)
                            {
                                record[headers[i]] = fields[i];
                            }
                        }
                        rows.Add(record);
                    }
                }
            }

            return rows;
        }
    }
}