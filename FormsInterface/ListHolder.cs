﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsInterface
{
    public class ListHolder
    {
        Dictionary<string, int> trendingDictionary = new Dictionary<string, int>();
        
        public ListHolder()
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

        public List<string[]> getItems()
        {
            List<string[]> HashRowList = new List<string[]>();
            foreach (KeyValuePair<string, int> tagItem in trendingDictionary.OrderByDescending(key => key.Value) )
            {
                HashRowList.Add(new string[2] { tagItem.Key, tagItem.Value.ToString() } ); 
                        //= tagItem.Value +"   " + tagItem.Key +"\n";
            }
                
            return HashRowList;
        }






    }
}