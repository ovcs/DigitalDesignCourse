using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueWordCounter.Models.Repo
{
    internal class RemoteRepoMng : IWordRepoManager
    {
        Dictionary<string, int> dict;

        public RemoteRepoMng(Dictionary<string, int> dict)
        {
            this.dict = dict;
        }

        public RemoteRepoMng() : this(new()) { }
        
        public Word CreateAndGetWord(string value)
        {
            return new Word(0, value, dict[value]) ?? throw new ArgumentException();
        }

        public Word GetWordBy(string str)
        {
            return new Word(0, str, dict[str]) ?? throw new ArgumentException();
        }

        public void IncreaseCount(Word word)
        {
        }

        public List<string> Query(string orderBy)
        {
            return orderBy switch
            {
                "desc value count" => dict.OrderByDescending(e => e.Value)
                                        .Select(e => String.Format("{0} {1}", e.Value, e.Key))
                                        .ToList(),
                _ => dict.Values.Select(e => e.ToString()).ToList(),
            };
        }

        public void Import(Dictionary<string, int> dict)
        {
            this.dict = new(dict);
        }
    }
}
