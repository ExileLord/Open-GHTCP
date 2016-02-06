using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ns14
{
	public class ViewLog : Form
	{
		private IContainer icontainer_0;

		private SplitContainer splitContainer1;

		private ListBox LogListBox;

		private RichTextBox LogTextBox;

		public ViewLog()
		{
			this.InitializeComponent();
			foreach (string current in Class216.sortedDictionary_0.Keys)
			{
				this.LogListBox.Items.Add(current);
			}
			this.LogListBox.SelectedIndex = this.LogListBox.Items.Count - 1;
		}

		private void LogListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.LogTextBox.Text = Class216.sortedDictionary_0[(string)this.LogListBox.SelectedItem];
		}

        protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.splitContainer1 = new SplitContainer();
			this.LogListBox = new ListBox();
			this.LogTextBox = new RichTextBox();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			base.SuspendLayout();
			this.splitContainer1.Dock = DockStyle.Fill;
			this.splitContainer1.Location = new Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Panel1.Controls.Add(this.LogListBox);
			this.splitContainer1.Panel2.Controls.Add(this.LogTextBox);
			this.splitContainer1.Size = new Size(476, 188);
			this.splitContainer1.SplitterDistance = 158;
			this.splitContainer1.TabIndex = 0;
			this.LogListBox.Dock = DockStyle.Fill;
			this.LogListBox.FormattingEnabled = true;
			this.LogListBox.Location = new Point(0, 0);
			this.LogListBox.Name = "LogListBox";
			this.LogListBox.Size = new Size(158, 186);
			this.LogListBox.TabIndex = 0;
			this.LogListBox.SelectedIndexChanged += new EventHandler(this.LogListBox_SelectedIndexChanged);
			this.LogTextBox.Dock = DockStyle.Fill;
			this.LogTextBox.Location = new Point(0, 0);
			this.LogTextBox.Name = "LogTextBox";
			this.LogTextBox.ReadOnly = true;
			this.LogTextBox.Size = new Size(314, 188);
			this.LogTextBox.TabIndex = 0;
			this.LogTextBox.Text = "";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(476, 188);
			base.Controls.Add(this.splitContainer1);
			base.Name = "ViewLog";
			this.Text = "ViewLog";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
