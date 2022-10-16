namespace UniqueWordCounter.View
{
    internal class ConsoleView : IView
    {
        int speedUpdate;
        public ConsoleView(int speedUpdate = 1000)
        {
            this.speedUpdate = speedUpdate;
        }

        public void Message(string text)
        {
            Console.Clear();
            Console.WriteLine(text);
            Thread.Sleep(speedUpdate);
        }

        public void Report(string error)
        {
            Console.Clear();
            Console.WriteLine($"Error: {error}");
            Console.ReadKey();
        }
    }
}
