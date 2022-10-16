namespace UniqueWordCounter.IO.Format
{
    internal interface ISerializeRepo
    {
        public IDeserializator GetDeserializator(string format);
        public ISerializator GetSerializator(string format);
    }
}
