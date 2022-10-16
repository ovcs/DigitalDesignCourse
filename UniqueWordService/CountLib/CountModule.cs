using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CountLib
{
    public class WordCount
    {
        public Dictionary<string, int> CalcUniqueWords(string text)
        {
            ConcurrentDictionary<string, int> dict = new ConcurrentDictionary<string, int>();
            List<string> words = new List<string>();

            words = TextHandler.FindWords(text);
            Parallel.ForEach(words, e =>
            {
                if (!dict.TryAdd(e, 1))
                    dict[e]++;
            });

            return new Dictionary<string, int>(dict);
        }
    }

    public static class TextHandler
    {
        private const string WORD_SEARCH_PATTERN = @"([^\W_]+[^\s.,?!:;""^&*><\|]*)";
        public static List<string> FindWords(string text)
        {
            return Regex.Matches(text, WORD_SEARCH_PATTERN, RegexOptions.IgnoreCase).Cast<Match>()
                        .Select(e => e.ToString().ToLower())
                        .ToList();
        }
    }
}
