using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printer.Modules
{
    internal class DictSerializer
    {
        Dictionary<string, int> dict;
        public DictSerializer(Dictionary<string, int> dict)
        {
            this.dict = dict;
        }
        public string GetText()
        {
            StringBuilder sb = new StringBuilder();
            List<string> tmp = Query("desc value count");
            tmp.ForEach(e => sb.AppendLine(e));
            return sb.ToString();
        }

        List<string> Query(string options)
        {
            return options switch
            {
                "desc value count" => dict.OrderByDescending(e => e.Value)
                                        .Select(e => String.Format("{0} {1}", e.Value, e.Key))
                                        .ToList(),
                _ => dict.Select(e => e.ToString()).ToList(),
            };
        }
    }
}
