using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsInterface
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            TrendingList trendingList = new TrendingList();
            Form1 myForm = new Form1(trendingList);
            //myForm.getTrending(trendingList);

            Application.Run(myForm);
            Form2 myForm2 = new Form2(trendingList);
            //myForm2.getTrending(trendingList);
            Application.Run(myForm2);
            //Application.Run(new Form2());


        }
    }
}
//Application.Run(new Form1());