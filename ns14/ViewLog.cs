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
			InitializeComponent();
			foreach (string current in Class216.sortedDictionary_0.Keys)
			{
				LogListBox.Items.Add(current);
			}
			LogListBox.SelectedIndex = LogListBox.Items.Count - 1;
		}

		private void LogListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			LogTextBox.Text = Class216.sortedDictionary_0[(string)LogListBox.SelectedItem];
		}

        protected override void Dispose(bool disposing)
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			splitContainer1 = new SplitContainer();
			LogListBox = new ListBox();
			LogTextBox = new RichTextBox();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			SuspendLayout();
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.Location = new Point(0, 0);
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Panel1.Controls.Add(LogListBox);
			splitContainer1.Panel2.Controls.Add(LogTextBox);
			splitContainer1.Size = new Size(476, 188);
			splitContainer1.SplitterDistance = 158;
			splitContainer1.TabIndex = 0;
			LogListBox.Dock = DockStyle.Fill;
			LogListBox.FormattingEnabled = true;
			LogListBox.Location = new Point(0, 0);
			LogListBox.Name = "LogListBox";
			LogListBox.Size = new Size(158, 186);
			LogListBox.TabIndex = 0;
			LogListBox.SelectedIndexChanged += LogListBox_SelectedIndexChanged;
			LogTextBox.Dock = DockStyle.Fill;
			LogTextBox.Location = new Point(0, 0);
			LogTextBox.Name = "LogTextBox";
			LogTextBox.ReadOnly = true;
			LogTextBox.Size = new Size(314, 188);
			LogTextBox.TabIndex = 0;
			LogTextBox.Text = "";
			AutoScaleDimensions = new SizeF(6f, 13f);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(476, 188);
			Controls.Add(splitContainer1);
			Name = "ViewLog";
			Text = "ViewLog";
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
