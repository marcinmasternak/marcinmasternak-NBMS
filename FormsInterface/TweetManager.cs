using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsInterface
{
    class TweetManager : MessageManager
    {
        public TweetManager(string header, string body, Form1 myForm)
        {

        }

        public override string SplitBody(string body)
        {
            var result = body.Split(new string[] { "Sender", "sender", "SENDER" }, 2, StringSplitOptions.None);
            if (result.Length < 2)
                return "Error: Message Sender not specified!";
            else
            {
                var messageTab = result[1].Split(new string[] { "Message Body", "Message body", "message body", "MESSAGE BODY" }, 2, StringSplitOptions.None);

                for (int i = 0; i < messageTab.Length; i++)
                {
                    messageTab[i] = messageTab[i].TrimStart(new Char[] { ' ', ':', '-' });
                }
                return messageTab[0] + "\n" + messageTab[1];
            }
        }
    }
}
