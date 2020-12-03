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
        ListHolder _listHolder;
        public Form2(ListHolder listHolder)
        {
            InitializeComponent();
            _listHolder = listHolder;
            fillTrendingList();
            fillMentionsList();
            fillUrlsList();
           

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

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
            var row = new String[2];
            foreach(var item in _listHolder.getTrendingTags())
                listView1.Items.Add(new ListViewItem(item));
        }

        public void fillMentionsList()
        {
            //listBox1.Items.Add(_trendingList.getItems());
            //richTextBox1.Text += _trendingList.getItems() + "\n";
            var row = new String[2];
            foreach (var item in _listHolder.getMentions())
                listView2.Items.Add(new ListViewItem(item));
        }

        public void fillUrlsList()
        {
            //listBox1.Items.Add(_trendingList.getItems());
            //richTextBox1.Text += _trendingList.getItems() + "\n";
            var row = new String[2];
            foreach (var item in _listHolder.getUrls())
                listView3.Items.Add(new ListViewItem(item));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
