using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWReflection
{
    public class СountWords
    {
        private Dictionary<string, int> CalcWordsFromFile(string path)
        {
            string searchPattern = @"([^\W_]+[^\s.,?!:;""^&*><\|]*)";
            FB2FileLoader fl = new FB2FileLoader();
            WordCountService wcs = new WordCountService(searchPattern);

            List<string> cellsBook = fl.DeserializeToList(path);
            return wcs.Calc(cellsBook);
        }
    }
}
