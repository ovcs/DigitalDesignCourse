namespace UniqueWordCounter.IO
{
    internal interface ISaver
    {
        public void Save(string directory, string filename, ISerializator format);
    }
}
