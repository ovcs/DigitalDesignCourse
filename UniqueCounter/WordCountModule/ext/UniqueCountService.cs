using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCountModule.ext
{
    internal class UniqueCountService
    {
        public Dictionary<string, int> CountUniqueWords(List<string> words)
        {
            Dictionary<string, int> dict = new();

            for (int i = 0; i < words.Count; i++)
            {
                if (dict.ContainsKey(words[i]))
                {
                    dict[words[i]]++;
                }
                else
                {
                    dict.Add(words[i], 1);
                }
            }
            return dict;
        }

        public ConcurrentDictionary<string, int> CountUniqueWordsParallel(List<string> words)
        {
            ConcurrentDictionary<string, int> dict = new();

            Parallel.ForEach(words, e =>
            {
                if (!dict.TryAdd(e, 1))
                {
                    dict[e]++;
                }
            });

            
            return dict;
        }
    }
}
