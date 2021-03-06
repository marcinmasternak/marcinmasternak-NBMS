﻿using System;
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
    public partial class Form1 : Form
    {
        public TemplateGenerator template = new TemplateGenerator();
        public TextDictionary textDictionary = new TextDictionary();
        public ListHolder _listHolder;

        public Form1(ListHolder listHolder)
        {
           
            InitializeComponent();
            _listHolder = listHolder;
        }

        private void boxDisplay_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBoxHeader.Text.Length > 0)
            {
                string messageType = template.headerChanged(textBoxHeader.Text.Substring(0, 1).ToUpper());
                if (messageType != null) textboxBody.Text = messageType;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = MessageManager1.CheckMessage(textBoxHeader.Text, textboxBody.Text, this);
            if (message != null) MessageBox.Show(message);
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void UpdateTextBox(string text)
        {
            textBoxPreview.Text = text;
        }

        public void SendMessage(string text)
        {
            MessageBox.Show(text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxHeader.Clear();
            textboxBody.Clear();
            textBoxPreview.Clear();
            template.oldType = "";
        }

        private void textboxBody_TextChanged(object sender, EventArgs e)
        {
           
        }

        public void getTrending(ListHolder list) 
        {
            _listHolder = list;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // public string SearchDictionary(string item)
        // {
        // return textDictionary.SearchDict(item);
        // }
    }
}
