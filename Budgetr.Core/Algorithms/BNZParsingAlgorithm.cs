using Budgetr.Core.Abstractions;

using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Budgetr.Core.Algorithms
{
    public class BNZParsingAlgorithm : IParsingAlgorithm
    {
        private readonly string _filePath;
        private static List<string> _desiredHeaders = new List<string>
        {
            "Date",
            "Amount",
            "Payee"
        };
        public BNZParsingAlgorithm(string filePath)
        {
            _filePath = filePath;
        }

        public List<Dictionary<string, string>> ParseData()
        {
            DataTable table = CreateTable();
            List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Dictionary<string, string> row = new Dictionary<string, string>();
                foreach (string header in _desiredHeaders)
                {
                    row.Add(header, table.Rows[i][header].ToString());
                }
                data.Add(row);
            }
            return data;
        }

        private DataTable CreateTable()
        {
            DataTable table = new DataTable();
            using (StreamReader reader = new StreamReader(_filePath))
            {
                string[] headers = reader.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    table.Columns.Add(header);
                }
                while (!reader.EndOfStream)
                {
                    string[] rows = reader.ReadLine().Split(',');
                    table.Rows.Add(rows);
                }
            }
            return table;
        }
    }
}
