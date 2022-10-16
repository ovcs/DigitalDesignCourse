namespace UniqueWordCounter.IO
{
    internal interface IDeserializator
    {
        public object Deserialize(StreamReader stream);
    }
}
