using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCountModule.ext
{
    internal class TextSearcher
    {
        string wordsSearchPattern;

        public TextSearcher(string wordsSearchPattern)
        {
            this.wordsSearchPattern = wordsSearchPattern;
        }
        
        public List<string> FindWords(string book)
        {
            return Regex.Matches(book, wordsSearchPattern, RegexOptions.IgnoreCase)
                        .Select(e => e.ToString().ToLower())
                        .ToList();
        }
    }
}
