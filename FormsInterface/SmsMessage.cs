using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Text.Json;

namespace FormsInterface
{
    public class SmsMessage :Message
    {
        public SmsMessage()
        {
        }

        public string Type { get; set; } = "SMS";
        public string Header { get; set; }
        public string Sender { get; set; }
        public string Content { get; set; }


        public override string SplitBody(string body)
        {
            var result = body.Split(new string[] { "Sender", "sender", "SENDER" }, 2, StringSplitOptions.None);
            if (result.Length < 2)
                return "Error: Message Sender not specified!";
            else
            {
                var messageTab = result[1].Split(new string[] { "Message Text", "Message text", "message text", "MESSAGE TEXT" }, 2, StringSplitOptions.None);
                if (messageTab.Length < 2)
                    return "Error: No message text entered, or \"Message Text\" delimiter missing!";
                Sender = messageTab[0].Trim(new Char[] { ' ', ':', '-', '\n' });
                Content = messageTab[1].Trim(new Char[] { ' ', ':', '-', '\n' });
                //for (int i = 0; i < messageTab.Length; i++)
                //{
                //    MessageContent.Add(messageTab[i].Trim(new Char[] { ' ', ':', '-', '\n' }));
                //}
                return null;
            }
        }

        public bool ValidateSender()
        {
            Sender = Sender.Trim(' ');
            string sanitizedSender = String.Join("", Sender.Split('-', ' ', '/'));
            if (Regex.IsMatch(sanitizedSender, "^[(\\+)0(00)]?[0-9]{10,15}$"))
            {
                sanitizedSender = sanitizedSender.TrimStart('0', '+');
                sanitizedSender = sanitizedSender.Insert(2, " ");
                //sanitizedSender = sanitizedSender.Insert(0, "");
                Sender = sanitizedSender;
                return true;
            }
            return false;
        }

        public override bool ValidateText()
        {
            int length = Content.Length;
            if (length > 0 && length <= 140)
                return true;
            return false;
        }

        public override string ExpandText(Form1 myForm)
        {

            var matches = Regex.Matches(Content, "<[A-Z]{2,10}>");     //finds any occurance of text in  <   >  brackets
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
                            "\n\nSender:                        +" + Sender +
                            "\n\n------------------------- Message Text ----------------------:\n\n" + Content;
            return outputString;
        }

        public override string SerializeToJson()
         {
            JsonSerializerOptions options = new JsonSerializerOptions();
        options.WriteIndented = true;
            return JsonSerializer.Serialize(this, options);
        }
    }


}
