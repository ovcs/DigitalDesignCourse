using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HWReflection
{
    internal class FB2FileLoader
    {
        readonly XNamespace xmlns = "http://www.gribuser.ru/xml/fictionbook/2.1";
        public List<string> DeserializeToList(string path)
        {
            string searchModule = "p";
            XElement elem = XElement.Load(path);
            var ns = elem.Name.Namespace != null ? elem.Name.Namespace : xmlns;
            var book = elem.Descendants(ns + searchModule).Select(e => e.Value).ToList();
            return book;
        }
    }
}
