using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Text.Json;

namespace FormsInterface
{
    public abstract class MessageManager1
    {

        private static string headerErrorMessage = "Message header must be 10 characters long!\n" +
                                                    "It must start with type indicaotr letter [S,E,T] followed by 9 digits.";
        
        public MessageManager1()
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
                    CreateSms(header, body, myForm);
                    break;
                case "T":
                    //TweetManager tweetManager = new TweetManager(header, body, myForm);
                    break;
                case "E":
                    // EmailManager emailManager = new EmailManager(header, body, myForm);
                    break;
                default:
                    return headerErrorMessage;
            }
            return null;
        }

        static void CreateSms(string _header, string _body, Form1 myForm)
        {
            
            SmsMessage sms = new SmsMessage();
            sms.Header = _header.ToUpper();
        
            string message;
            message = sms.SplitBody(_body);
            if (message != null)
            {
                myForm.SendMessage(message);
                return;
            }
            if (sms.ValidateSender() == true)
            {
                myForm.SendMessage("This is the validated sender from sms object: " + sms.Sender);
                if (sms.ValidateText() == true)
                {
                    myForm.SendMessage("Length succesfully validated : " + sms.Content.Length);
                    sms.ExpandText(myForm);
                    myForm.UpdateTextBox(sms.PrintMessage());
                    System.IO.File.AppendAllText("my_json_file.txt", sms.SerializeToJson());
                }
                else
                {
                    myForm.SendMessage("Error!\nInvalid message text length!\n" +
                                         "Must be between 1 and 140 characters.\n" +
                                         sms.Content.Length + " characters detected.");
                }
            }

            else
                myForm.SendMessage("Error!\nInvalid phone number format!\n" +
                                    "Please enter 10 to 15 digits optionally " +
                                    " preceded by \"+\" sign or \"00\"" + " \nSMS sender :  " + sms.Sender);

        }
       

       



    }
}
