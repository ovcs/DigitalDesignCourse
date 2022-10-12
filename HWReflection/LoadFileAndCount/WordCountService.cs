using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HWReflection
{
    internal class WordCountService
    {
        List<string> words;
        string searchPattern;
        Dictionary<string, int> dictionary;
        public WordCountService(string searchPattern)
        {
            this.searchPattern = searchPattern;
            this.words = new List<string>();
            this.dictionary = new Dictionary<string, int>();
        }

        public Dictionary<string, int> Calc(List<string> book)
        {
            FindWords(book);
            CountUnique();
            return GetResult();
        }
        
        void FindWords(List<string> book)
        {
            for(int i = 0; i < book.Count; i++)
            {
                words.AddRange(Regex.Matches(book[i], searchPattern, RegexOptions.IgnoreCase).Select(e => e.ToString().ToLower()));
            }
        }

        int CountUnique()
        {
            for (int i = 0; i < words.Count; i++)
            {
                if (dictionary.ContainsKey(words[i]))
                {
                    dictionary[words[i]]++;
                }
                else
                {
                    dictionary.Add(words[i], 1);
                }
            }
            return dictionary.Count;
        }

        Dictionary<string, int> GetResult()
        {
            return dictionary != null ? dictionary : new Dictionary<string, int>();
        }
    }
}
