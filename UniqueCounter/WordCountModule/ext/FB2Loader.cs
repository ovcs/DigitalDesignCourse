using System.Text;
using System.Xml.Linq;

namespace WordCountModule.ext
{
    internal class FB2Loader
    {
        XElement element;

        public void LoadToFile(string path)
        {
            element = XElement.Load(path);
        }

        public string SerializeToText(string searchModule)
        {
            return new StringBuilder().AppendJoin(" ",
                                       element.Descendants(element.Name.Namespace + searchModule)
                                              .Select(e => e.Value))
                                      .ToString();  
        }
    }
}