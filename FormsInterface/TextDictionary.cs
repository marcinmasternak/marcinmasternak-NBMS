using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsInterface
{
    public class TextDictionary
    {
        Dictionary<string, string> textDict = new Dictionary<string, string>();
        public TextDictionary()
        {
            string filename = "textwords.csv";
            if (System.IO.File.Exists(filename))
            {
                //textDict = new Dictionary<string, string>();
                foreach (string line in System.IO.File.ReadLines(filename))
                {
                    string[] pairs = line.Split(',');
                    textDict.Add(pairs[0], pairs[1]);
                }

             
            }
        }

        public string SearchDict(string key)
        {
            if ( textDict.ContainsKey(key) )
            {
                return textDict[key];
            }
            return "no key found";
        }
    }
}
