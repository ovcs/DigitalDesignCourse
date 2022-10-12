using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWSaveFile
{
    internal class Serialize
    {
        public void SerializeDict(string path, Dictionary<string, int> dict)
        {
            DictSerializer ds = new DictSerializer(dict);
            TxtSaver ts = new TxtSaver(ds.GetText());
            ts.Save(path);
        }
    }
}
