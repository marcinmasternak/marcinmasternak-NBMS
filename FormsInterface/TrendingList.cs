using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsInterface
{
    public class TrendingList
    {
        Dictionary<string, int> trendingDictionary = new Dictionary<string, int>();
        
        public TrendingList()
        {
            
        }

        public void addHashTag(string hashTag)
        {
            if (trendingDictionary.ContainsKey(hashTag))
                trendingDictionary[hashTag]++;
            else
                trendingDictionary[hashTag] = 1;
        }

        public string getItems()
        {
            string retString = "";
            foreach (KeyValuePair<string, int> tagItem in trendingDictionary)
            {
                retString += tagItem.Key;
            }
                
            return retString;
        }






    }
}
