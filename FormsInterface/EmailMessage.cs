using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Text.Json;

namespace FormsInterface
{
    public class EmailMessage : Message
    {
        public EmailMessage()
        {
        }

        public string Type { get; set; } = "E-mail";
        public string Header { get; set; }
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        //addd subject
        public override string SplitBody(string body)
        {
            var splitTab = body.Split(new string[] { "Sender", "sender", "SENDER" }, 2, StringSplitOptions.None);
            var tab0 = splitTab[0];
            var tab1 = splitTab[1];
            if (splitTab.Length < 2)
                return "Error: Message Sender not specified!";
            else
            {
                splitTab = splitTab[1].Split(new string[] { "Subject", "subject", "SUBJECT"}, 2, StringSplitOptions.None);
               
                Sender = splitTab[0].Trim(new Char[] { ' ', ':', '-', '\n' });
                if (splitTab.Length < 2)
                    return "Error: No message subject entered, or \"Subject\" delimiter missing!";
                else
                {
                    splitTab = splitTab[1].Split(new string[] { "Message Text", "Message text", "message text", "MESSAGE TEXT" }, 2, StringSplitOptions.None);
                    Subject = splitTab[0].Trim(new Char[] { ' ', ':', '-', '\n' });
                    if (splitTab.Length < 2)
                        return "Error: No message text entered, or \"Message Text\" delimiter missing!";
                    else
                    {
                        splitTab = splitTab[1].Split(new string[] { "Message Text", "Message text", "message text", "MESSAGE TEXT" }, 2, StringSplitOptions.None);
                        Content = splitTab[0].Trim(new Char[] { ' ', ':', '-', '\n' });
                        return null;
                    }
                }
                //Sender = messageTab[0].Trim(new Char[] { ' ', ':', '-', '\n' });
                //Content = messageTab[1].Trim(new Char[] { ' ', ':', '-', '\n' });
                //for (int i = 0; i < messageTab.Length; i++)
                //{
                //    MessageContent.Add(messageTab[i].Trim(new Char[] { ' ', ':', '-', '\n' }));
                //}
                
            }
        }

        public bool ValidateSender()
        {
            Sender = Sender.Trim(' ');
            string sanitizedSender = String.Join("", Sender.Split('-', ' ', '/'));
            if (Regex.IsMatch(sanitizedSender, "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$"))
            {
                //sanitizedSender = sanitizedSender.TrimStart('0', '+');
                //sanitizedSender = sanitizedSender.Insert(2, " ");
                //sanitizedSender = sanitizedSender.Insert(0, "");
                Sender = sanitizedSender;
                return true;
            }
            return false;
        }

        public bool ValidateSubject()
        {
            int length = Subject.Length;
            if (length > 0 && length <= 20)
                return true;
            return false;
        }

        public override bool ValidateText()
        {
            int length = Content.Length;
            if (length > 0 && length <= 1028)
                return true;
            return false;
        }

        public override string ExpandText(Form1 myForm)
        {

            var matches = Regex.Matches(Content, "<.{2,10}>");     //finds any occurance of text in  <   >  brackets
            foreach (var match in matches)
            {
                string item = match.ToString();
                string itemTrimmed = item.Trim('<', '>');
                string searchResult = myForm.textDictionary.SearchDict(itemTrimmed);
                if (searchResult != null)
                {
                    Content = Content.Replace(item, itemTrimmed + " <" + searchResult + ">");
                }
            }
            return Content;
        }

        public override string PrintMessage()
        {
            string outputString = "";
            outputString += "Message type:         " + Type +
                            "\n\nMessage header:    " + Header +
                            "\n\nSender:                       " + Sender +
                            "\n\nSubject:                     " + Subject +
                            "\n\n------------------------- E-mail Text ----------------------:\n\n" + Content;
            return outputString;
        }

        public override string SerializeToJson()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;
            return JsonSerializer.Serialize(this, options);
        }

        public List<string> FindHashtags()
        {
            List<string> tags = new List<string>();
            foreach (var match in Regex.Matches(Content, "#[a-zA-Z0-9_]+"))
            {
                tags.Add(match.ToString());
            }
            tags = new HashSet<string>(tags).ToList();
            return tags;
        }

        public List<string> FindTweeterIds()
        {
            List<string> ids = new List<string>();
            foreach (var match in Regex.Matches(Content, "@[a-zA-Z0-9_]{4,15}"))
            {
                ids.Add(match.ToString());
            }
            ids = new HashSet<string>(ids).ToList();
            return ids;
        }

       

        public List<string> FindUrl()
        {
            //string expression =;
            List<string> urls = new List<string>();
            var matches = Regex.Matches(Content, "(http:\\/\\/www\\.|https:\\/\\/www\\.|http:\\/\\/|https:\\/\\/)[a-z0-9]+([\\-\\.]{1}[a-z0-9]+)*\\.[a-z]{2,5}(:[0-9]{1,5})?(\\/.*)?");     //finds any occurance of text in  <   >  brackets
            foreach (var match in matches)
            {
                string item = match.ToString();
                Content = Content.Replace(item, "<URL Quarantined>");
                urls.Add(item);
             
            }
            return urls;
        }
    }
}