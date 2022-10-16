namespace UniqueWordCounter.Models.Repo
{
    internal interface IWordRepoManager
    {
        public Word CreateAndGetWord(string value);
        public Word GetWordBy(string str);
        public void IncreaseCount(Word word);
        public void Import(Dictionary<string, int> dict);
        public List<string> Query(string orderBy);
    }
}
