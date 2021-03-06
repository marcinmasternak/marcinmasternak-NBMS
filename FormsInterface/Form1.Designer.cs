﻿namespace FormsInterface
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.boxEntry = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textboxBody = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxHeader = new System.Windows.Forms.TextBox();
            this.boxDisplay = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxPreview = new System.Windows.Forms.RichTextBox();
            this.boxEntry.SuspendLayout();
            this.boxDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxEntry
            // 
            this.boxEntry.Controls.Add(this.btnClear);
            this.boxEntry.Controls.Add(this.button1);
            this.boxEntry.Controls.Add(this.textboxBody);
            this.boxEntry.Controls.Add(this.label2);
            this.boxEntry.Controls.Add(this.label1);
            this.boxEntry.Controls.Add(this.textBoxHeader);
            this.boxEntry.Location = new System.Drawing.Point(8, 9);
            this.boxEntry.Name = "boxEntry";
            this.boxEntry.Size = new System.Drawing.Size(336, 450);
            this.boxEntry.TabIndex = 0;
            this.boxEntry.TabStop = false;
            this.boxEntry.Text = "Message Entry";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(22, 402);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(58, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(243, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Process";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textboxBody
            // 
            this.textboxBody.Location = new System.Drawing.Point(4, 102);
            this.textboxBody.Name = "textboxBody";
            this.textboxBody.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.textboxBody.Size = new System.Drawing.Size(326, 281);
            this.textboxBody.TabIndex = 3;
            this.textboxBody.Text = "";
            this.textboxBody.TextChanged += new System.EventHandler(this.textboxBody_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Body";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Header";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxHeader
            // 
            this.textBoxHeader.Location = new System.Drawing.Point(4, 51);
            this.textBoxHeader.MaxLength = 10;
            this.textBoxHeader.Name = "textBoxHeader";
            this.textBoxHeader.Size = new System.Drawing.Size(78, 21);
            this.textBoxHeader.TabIndex = 0;
            this.textBoxHeader.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // boxDisplay
            // 
            this.boxDisplay.Controls.Add(this.button2);
            this.boxDisplay.Controls.Add(this.textBoxPreview);
            this.boxDisplay.Location = new System.Drawing.Point(360, 9);
            this.boxDisplay.Name = "boxDisplay";
            this.boxDisplay.Size = new System.Drawing.Size(336, 450);
            this.boxDisplay.TabIndex = 1;
            this.boxDisplay.TabStop = false;
            this.boxDisplay.Text = "Message Preview";
            this.boxDisplay.Enter += new System.EventHandler(this.boxDisplay_Enter);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(217, 402);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "End session";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxPreview
            // 
            this.textBoxPreview.Location = new System.Drawing.Point(4, 102);
            this.textBoxPreview.Name = "textBoxPreview";
            this.textBoxPreview.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.textBoxPreview.Size = new System.Drawing.Size(314, 281);
            this.textBoxPreview.TabIndex = 0;
            this.textBoxPreview.Text = "";
            this.textBoxPreview.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 460);
            this.Controls.Add(this.boxDisplay);
            this.Controls.Add(this.boxEntry);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Napier Bank Messaging Service";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.boxEntry.ResumeLayout(false);
            this.boxEntry.PerformLayout();
            this.boxDisplay.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox boxEntry;
        private System.Windows.Forms.GroupBox boxDisplay;
        private System.Windows.Forms.TextBox textBoxHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox textboxBody;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox textBoxPreview;
        private System.Windows.Forms.Button btnClear;
    }
}

