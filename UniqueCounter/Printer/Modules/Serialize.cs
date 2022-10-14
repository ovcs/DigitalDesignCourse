using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printer.Modules
{
    internal class Serialize
    {
        public static void SerializeDict(string path, Dictionary<string, int> dict)
        {
            string ds = new DictSerializer(dict).GetText();
            TxtSaver ts = new(ds);
            ts.Save(path);
        }
    }
}
