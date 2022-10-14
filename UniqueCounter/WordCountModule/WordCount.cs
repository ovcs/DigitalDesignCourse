using System.IO;
using WordCountModule.ext;

namespace WordCountModule
{
    public class WordCount
    {
        const string WORD_SEARCH_PATTERN = @"([^\W_]+[^\s.,?!:;""^&*><\|]*)";
        const string SEARCH_ZONE = "p";
        readonly FB2Loader fl = new FB2Loader();
        readonly TextSearcher ts = new(WORD_SEARCH_PATTERN);
        readonly UniqueCountService ucs = new();

        private Dictionary<string, int> CalcWordsFromFile(string path)
        {
            return ucs.CountUniqueWords(FindWords(path));
        }

        public Dictionary<string, int> CalcWordsFromFileParallel(string path)
        {
            return new Dictionary<string, int>(
                ucs.CountUniqueWordsParallel(FindWords(path))
                );
        }

        private List<string> FindWords(string path)
        {
            fl.LoadToFile(path);
            string book = fl.SerializeToText(SEARCH_ZONE);
            return ts.FindWords(book);
        }
    }
}
