using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsInterface
{
    public class TemplateGenerator
    {
        public string oldType;
        string smsTemplate = "Sender:\n\nMessage Text:\n";
        string emailTemplate = "Sender:\n\nSubject:\n\nMessage Text:\n";
        string tweetTemplate = "Sender:\n\nTweet text:\n";
        string invalidMessageTemplate = "Message header should start with one of the following letters:\n\n" +
                                        "S - for Text Message\n" +
                                        "T - for Tweet\n" +
                                        "E - for Email\n\n" +
                                        "Please re-enter the header!";

        public TemplateGenerator()
        {
            oldType = "";
        }

        public string headerChanged(string newType)
        {
            if (!newType.Equals(oldType))
            {
                oldType = newType;
                switch (newType)
                {
                    case "S":
                        return smsTemplate;
                        //break;
                    case "E":
                        return emailTemplate;
                        //break;
                    case "T":
                        return tweetTemplate;
                        //break;
                    default:
                        return invalidMessageTemplate;
                        //break;
                }
                
            }
            return null;
        }
    }
}
