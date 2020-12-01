using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FormsInterface
{
    /*Processes the SMS message by dividing the body into Sender and content strings.
    Validates sender number format and sanitizes the string. Ensures content is entered and checks the length.
    Prints formated string in the forms test box.
     */

    //SMS atributes: { type, header ,sender, content }
    class SmsManager : MessageManager
    {
        List<string> MessageFields = new List<string> { "type", "header", "sender", "content" };
        List<string> MessageFieldsLong = new List<string> { "Message type:         ", "\nMessage header:    ",
                                                            "\nSender:                        ",
                                                            "\n------------------------- Message Text ----------------------:\n\n" };
        
        List<string> MessageContent = new List<string>();
        public SmsManager(string _header, string _body, Form1 myForm)
        {
            Sms sms = new Sms();
            sms.Header = _header.ToUpper();
            /*
             * 
             * */
            string message;
            MessageContent.Add("SMS");
            MessageContent.Add(_header.ToUpper());
            message = SplitBody(_body);
            if (message != null)
            {
                myForm.SendMessage(message);
                return;
            }
            if (ValidateSender(MessageContent[2]) == true)
            {
                if (ValidateText(MessageContent[3]) == true)
                {
                    MessageContent[3] = ExpandText(MessageContent[3], myForm);
                    myForm.UpdateTextBox(PrintMessage());
                }
                else
                {
                    myForm.SendMessage("Error!\nInvalid message text length!\n" +
                                         "Must be between 1 and 140 characters.\n" +
                                         MessageContent[3].Length + " characters detected.");

                }
            }
            
            else
                myForm.SendMessage("Error!\nInvalid phone number format!\n" +
                                    "Please enter 10 to 15 digits optionally " +
                                    " preceded by \"+\" sign or \"00\"");



        }

        //Divides body of the message into fields Sender and Content based on separator strings
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
                for (int i = 0; i < messageTab.Length; i++)
                {
                    MessageContent.Add(messageTab[i].Trim(new Char[] { ' ', ':', '-', '\n' }));
                }
                return null;
            }
        }

        //Generates string for message detail preview in the form textbox.
        public string PrintMessage()
        {
            string outputString = "";
            for (int i = 0; i < MessageFields.Count; i++)
            {
                outputString += MessageFieldsLong[i];
                outputString += MessageContent[i] + "\n";
            }
            return outputString;
        }

        //Checks that sender field contains valid international phone number
        //Sanitizes and re-formats the sender string and returns the value to the MessageFields list for later use.
        public bool ValidateSender(string sender)
        {
            sender = sender.Trim(' ');
            string sanitizedSender = String.Join("", sender.Split('-', ' ','/'));
            if (Regex.IsMatch(sanitizedSender, "^[(\\+)0(00)]?[0-9]{10,15}$"))
            {
                sanitizedSender = sanitizedSender.TrimStart('0', '+');
                sanitizedSender = sanitizedSender.Insert(2, " ");
                sanitizedSender = sanitizedSender.Insert(0, "+");
                MessageContent[2] = sanitizedSender;
                return true;
            }
                return false;
        }

        public bool ValidateText(string content)
        {
            int length = content.Length;
            if ( length > 0 && length <= 140 )
                return true;
            return false;
        }

        string ExpandText(string content, Form1 myForm)
        {

            var matches = Regex.Matches(content, "<.{2,10}>");     //finds any occurance of text in  <   >  brackets
            foreach (var match in matches)
            {
                string item = match.ToString();
                string itemTrimmed = item.Trim('<', '>');
                string searchResult = myForm.textDictionary.SearchDict(itemTrimmed);
                if (searchResult != null)
                {
                    content = content.Replace(item, itemTrimmed + " <" + searchResult + ">");
                }
            }
            return content;
        }
    }
}
