namespace SupermarketData
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
			this.components = new System.ComponentModel.Container();
			this.fileNameInput = new System.Windows.Forms.TextBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.loadFileButton = new System.Windows.Forms.Button();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.beautifulXMLParse = new System.Windows.Forms.Button();
			this.linkedinPage = new System.Windows.Forms.LinkLabel();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// fileNameInput
			// 
			this.fileNameInput.Location = new System.Drawing.Point(230, 15);
			this.fileNameInput.Name = "fileNameInput";
			this.fileNameInput.Size = new System.Drawing.Size(739, 20);
			this.fileNameInput.TabIndex = 0;
			this.fileNameInput.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// loadFileButton
			// 
			this.loadFileButton.Location = new System.Drawing.Point(36, 41);
			this.loadFileButton.Name = "loadFileButton";
			this.loadFileButton.Size = new System.Drawing.Size(112, 30);
			this.loadFileButton.TabIndex = 2;
			this.loadFileButton.Text = "Load file";
			this.loadFileButton.UseVisualStyleBackColor = true;
			this.loadFileButton.Click += new System.EventHandler(this.loadFileButton_Click);
			// 
			// webBrowser1
			// 
			this.webBrowser1.Location = new System.Drawing.Point(36, 90);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size(1135, 562);
			this.webBrowser1.TabIndex = 3;
			this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
			// 
			// beautifulXMLParse
			// 
			this.beautifulXMLParse.Location = new System.Drawing.Point(168, 41);
			this.beautifulXMLParse.Name = "beautifulXMLParse";
			this.beautifulXMLParse.Size = new System.Drawing.Size(112, 30);
			this.beautifulXMLParse.TabIndex = 5;
			this.beautifulXMLParse.Text = "Beautiful XML parse";
			this.beautifulXMLParse.UseVisualStyleBackColor = true;
			this.beautifulXMLParse.Click += new System.EventHandler(this.beautifulXMLParse_Click);
			// 
			// linkedinPage
			// 
			this.linkedinPage.AutoSize = true;
			this.linkedinPage.Location = new System.Drawing.Point(1059, 666);
			this.linkedinPage.Name = "linkedinPage";
			this.linkedinPage.Size = new System.Drawing.Size(112, 13);
			this.linkedinPage.TabIndex = 16;
			this.linkedinPage.TabStop = true;
			this.linkedinPage.Text = "Razvan Olariu, 342AA";
			this.linkedinPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkedinPage_LinkClicked);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(33, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(191, 13);
			this.label1.TabIndex = 17;
			this.label1.Text = "File name (include .xml/.json extension)";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1183, 688);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.linkedinPage);
			this.Controls.Add(this.beautifulXMLParse);
			this.Controls.Add(this.webBrowser1);
			this.Controls.Add(this.loadFileButton);
			this.Controls.Add(this.fileNameInput);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox fileNameInput;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.Button loadFileButton;
		private System.Windows.Forms.WebBrowser webBrowser1;
		private System.Windows.Forms.Button beautifulXMLParse;
		private System.Windows.Forms.LinkLabel linkedinPage;
		private System.Windows.Forms.Label label1;
	}
}

