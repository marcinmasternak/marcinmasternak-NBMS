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

        // HERE it all starts
     
        public SmsManager(string _header, string _body, Form1 myForm)
        {
            Sms sms = new Sms();
            sms.Header = _header.ToUpper();
            /*
             * 
             * */
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
