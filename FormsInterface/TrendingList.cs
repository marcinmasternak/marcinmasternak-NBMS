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

        public void addHashTag(List<string> hashTagList)
        {
            foreach (string tag in hashTagList)
            {
                if (trendingDictionary.ContainsKey(tag))
                    trendingDictionary[tag]++;
                else
                    trendingDictionary[tag] = 1;
            }
        }

        public string getItems()
        {
            string retString = "";
            foreach (KeyValuePair<string, int> tagItem in trendingDictionary.OrderByDescending(key => key.Value) )
            {
                retString += tagItem.Value +"   " + tagItem.Key +"\n";
            }
                
            return retString;
        }






    }
}
