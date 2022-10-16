namespace UniqueWordCounter.Control
{
    internal interface IWCController
    {
        public bool Calc();
        public bool LoadFile(string path);
        public bool SaveResult(string path);
        public bool Quit();
    }
}
