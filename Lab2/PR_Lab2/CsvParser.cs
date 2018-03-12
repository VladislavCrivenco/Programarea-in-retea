using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_Lab2
{
    public interface ICsvParseble<T>
    {
        T Parse(string csvLine);
    }

    public class CsvParser<T>
    {
        private ICsvParseble<T> _parser;

        public CsvParser(ICsvParseble<T> parser)
        {
            _parser = parser ?? throw new ArgumentNullException("parser can not be null");
        }

        public List<T> ToList(string csv)
        {
            var result = new List<T>();
            var lines = csv.Split('\n');
            for (int i = 1; i < lines.Length; i++)
            {
                var model = _parser.Parse(lines[i]);
                if (model != null)
                {
                    result.Add(model);
                }
            }
            return result;
        }
    }
}
