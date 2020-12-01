using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FormsInterface
{
    public abstract class MessageManager
    {
        //private string messageHeader;
        //private string messageBody;
        //private string messageType;
        private static string headerErrorMessage = "Message header must be 10 characters long!\n" +
                                            "It must start with type indicaotr letter [S,E,T] followed by 9 digits.";
        public MessageManager()
        {
           
        }

        public static string CheckMessage(string header, string body, Form1 myForm)
        {
            string returnMessage;
            returnMessage = CheckHeader(header, body, myForm);
            if (returnMessage != null) return returnMessage;
            return null;
        }

        public static string CheckHeader(string header, string body, Form1 myForm)
        {
            if (header.Length != 10) return headerErrorMessage;
            if (!Regex.IsMatch(header.Substring(1, 9), "^[0-9]+$")) return headerErrorMessage;
            switch (header.Substring(0, 1).ToUpper())
            {
                case "S":
                    SmsManager smsManager = new SmsManager(header, body, myForm);
                    break;
                case "T":
                    TweetManager tweetManager = new TweetManager(header, body, myForm);
                    break;
                case "E":
                    EmailManager emailManager = new EmailManager(header, body, myForm);
                    break;
                default:
                    return headerErrorMessage;
            }
            return null;
        }

        public abstract string SplitBody(string Body);
      
      
    }

   
}
