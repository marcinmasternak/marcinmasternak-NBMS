using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Text.Json;

namespace FormsInterface
{
    public abstract class Message
    {
        public Message()
        {
        }

        public string Type { get; set; }
        public string Header { get; set; }
        public string Sender { get; set; }
        public string Content { get; set; }


        public abstract string SplitBody(string body);

        public virtual bool ValidateText()
        {
            int length = Content.Length;
            if (length > 0 && length <= 140)
                return true;
            return false;
        }

        public virtual string ExpandText(Form1 myForm)
        {

            var matches = Regex.Matches(this.Content, "<.{2,10}>");     //finds any occurance of text in  <   >  brackets
            foreach (var match in matches)
            {
                string item = match.ToString();
                string itemTrimmed = item.Trim('<', '>');
                string searchResult = myForm.textDictionary.SearchDict(itemTrimmed);
                if (searchResult != null)
                {
                    this.Content = this.Content.Replace(item, itemTrimmed + " <" + searchResult + ">");
                }
            }
            return Content;
        }

        public abstract string PrintMessage();

        public abstract string SerializeToJson();
       



    }
}

