namespace UniqueWordCounter.Models.Data
{
    internal class InnerData : IHandlerData
    {
        List<string> strBuffer;
        string strBuff;


        public InnerData()
        {
        }
        public Queue<string> queueData { get => new(strBuffer); }
        public string StringData { get => strBuff != null ? strBuff : String.Empty; }

        public void Take(object? obj)
        {
            if (obj == null)
            {
                return;
            }

            if (obj.GetType() == typeof(List<string>))
            {
                strBuffer = (List<string>) obj;
            }
            else if (obj.GetType() == typeof(string))
            {
                strBuff = (string) obj;
            }
            else
            {
                throw new InvalidCastException($"Invalid Load objects {nameof(obj)}");
            }
        }
    }
}
