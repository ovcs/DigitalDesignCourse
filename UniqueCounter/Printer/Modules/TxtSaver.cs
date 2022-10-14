using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printer.Modules
{
    internal class TxtSaver
    {
        string text;
        public TxtSaver(string text)
        {
            this.text = text;
        }

        public void Save(string path)
        {
            File.WriteAllText(path, text);
        }
    }
}
