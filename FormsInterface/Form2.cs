using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsInterface
{
    public partial class Form2 : Form
    {
        ListHolder _trendingList;
        public Form2(ListHolder trendingList)
        {
            InitializeComponent();
            _trendingList = trendingList;
            fillTrendingList();
           

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public void getTrending(ListHolder list)
        {
            _trendingList = list;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        public void fillTrendingList()
        {
            //listBox1.Items.Add(_trendingList.getItems());
            //richTextBox1.Text += _trendingList.getItems() + "\n";
            var row = new String[2] { "Hashtffffffff aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaag", "1" };
            foreach(var item in _trendingList.getItems())
                listView1.Items.Add(new ListViewItem(item));
        }
    }
}
