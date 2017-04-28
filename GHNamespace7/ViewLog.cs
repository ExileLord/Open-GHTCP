using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GHNamespace7
{
	public class ViewLog : Form
	{
		private IContainer icontainer_0;

		private SplitContainer _splitContainer1;

		private ListBox _logListBox;

		private RichTextBox _logTextBox;

		public ViewLog()
		{
			InitializeComponent();
			foreach (var current in Class216.SortedDictionary0.Keys)
			{
				_logListBox.Items.Add(current);
			}
			_logListBox.SelectedIndex = _logListBox.Items.Count - 1;
		}

		private void LogListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			_logTextBox.Text = Class216.SortedDictionary0[(string)_logListBox.SelectedItem];
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
			_splitContainer1 = new SplitContainer();
			_logListBox = new ListBox();
			_logTextBox = new RichTextBox();
			_splitContainer1.Panel1.SuspendLayout();
			_splitContainer1.Panel2.SuspendLayout();
			_splitContainer1.SuspendLayout();
			SuspendLayout();
			_splitContainer1.Dock = DockStyle.Fill;
			_splitContainer1.Location = new Point(0, 0);
			_splitContainer1.Name = "_splitContainer1";
			_splitContainer1.Panel1.Controls.Add(_logListBox);
			_splitContainer1.Panel2.Controls.Add(_logTextBox);
			_splitContainer1.Size = new Size(476, 188);
			_splitContainer1.SplitterDistance = 158;
			_splitContainer1.TabIndex = 0;
			_logListBox.Dock = DockStyle.Fill;
			_logListBox.FormattingEnabled = true;
			_logListBox.Location = new Point(0, 0);
			_logListBox.Name = "_logListBox";
			_logListBox.Size = new Size(158, 186);
			_logListBox.TabIndex = 0;
			_logListBox.SelectedIndexChanged += LogListBox_SelectedIndexChanged;
			_logTextBox.Dock = DockStyle.Fill;
			_logTextBox.Location = new Point(0, 0);
			_logTextBox.Name = "_logTextBox";
			_logTextBox.ReadOnly = true;
			_logTextBox.Size = new Size(314, 188);
			_logTextBox.TabIndex = 0;
			_logTextBox.Text = "";
			AutoScaleDimensions = new SizeF(6f, 13f);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(476, 188);
			Controls.Add(_splitContainer1);
			Name = "ViewLog";
			Text = "ViewLog";
			_splitContainer1.Panel1.ResumeLayout(false);
			_splitContainer1.Panel2.ResumeLayout(false);
			_splitContainer1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
