namespace UniqueWordCounter.IO.Format
{
    internal class FormatRepo : ISerializeRepo
    {
        Dictionary<string, IDeserializator> deserializators;
        Dictionary<string, ISerializator> serializators;
        char formatChar = '.';

        public FormatRepo(Dictionary<string, IDeserializator> deserializators,
                          Dictionary<string, ISerializator> serializators)
        {
            this.deserializators = deserializators;
            this.serializators = serializators;
        }

        public IDeserializator GetDeserializator(string format)
        {
            if (!format.StartsWith(formatChar))
            {
                throw new IOException("Incorrect file format");
            }

            if (deserializators.ContainsKey(format))
            {
                return deserializators[format];
            }
            else
            {
                throw new IOException("Invalid file format");
            }
        }

        public ISerializator GetSerializator(string format)
        {
            if (!format.StartsWith(formatChar))
            {
                throw new IOException("Incorrect file format");
            }

            if (serializators.ContainsKey(format))
            {
                return serializators[format];
            }
            else
            {
                throw new IOException("Invalid file format");
            }
        }
    }
}
