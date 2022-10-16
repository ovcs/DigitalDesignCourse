namespace UniqueWordCounter.View
{
    internal interface IView
    {
        public void Report(string error);
        public void Message(string text);
    }
}
