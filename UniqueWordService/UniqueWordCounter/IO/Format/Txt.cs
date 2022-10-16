using System.Text;

namespace UniqueWordCounter.IO.Format
{
    internal class Txt : IDeserializator, ISerializator
    {
        public string SerializatorFormat => ".txt";

        public object Deserialize(StreamReader stream)
        {
            return stream != null ? stream.ReadToEnd() : string.Empty;
        }

        public string Serialize(object tokens)
        {
            if (tokens.GetType() == typeof(List<string>))
            {
                List<string> list = (List<string>)tokens;
                return new StringBuilder().AppendJoin("\n", list).ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public override string ToString() => ".txt";
    }
}
