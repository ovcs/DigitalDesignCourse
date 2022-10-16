using System.Text;
using UniqueWordCounter.Models.Data;

namespace UniqueWordCounter.IO
{
    internal class Reader : ILoader
    {
        InnerData innerdata;
        Encoding encoding;

        public Reader(InnerData innerdata, Encoding encoding)
        {
            this.innerdata = innerdata;
            this.encoding = encoding;
        }

        public Reader(InnerData innerdata) : this(innerdata, Encoding.UTF8)
        {
        }

        public void Load(string path, IDeserializator format)
        {
            if (string.IsNullOrEmpty(path) || format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            using StreamReader sr = new(path, encoding);
            innerdata.Take(format.Deserialize(sr));
        }
        /*
                ISerializator ser = GiveSerializator(
            Regex.Match(path, @"(?i:^.*\.([\w]+)+$)").Value);
        */
    }
}
