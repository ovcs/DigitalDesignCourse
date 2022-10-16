using System.Text;
using System.Xml.Linq;

namespace UniqueWordCounter.IO.Format
{
    internal class Fb2 : IDeserializator
    {
        readonly XNamespace xmlns = "http://www.gribuser.ru/xml/fictionbook/2.1";

        public Fb2()
        {
        }

        public object Deserialize(StreamReader stream)
        {
            string searchModule = "p";
            XElement elem = XElement.Load(stream);
            var ns = elem.Name.Namespace != null ? elem.Name.Namespace : xmlns;
            return new StringBuilder().AppendJoin(" ",
                                       elem.Descendants(ns + searchModule)
                                              .Select(e => e.Value))
                                      .ToString();
        }

        public override string ToString() => ".fb2";
    }
}
