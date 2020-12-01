using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsInterface
{
    public class Sms
    {
        public Sms()
        {
        }

        public string Type { get; set; } = "SMS";
        public string Header { get; set; }
        public string Sender { get; set; }
        public string Content { get; set; }
    }
}
