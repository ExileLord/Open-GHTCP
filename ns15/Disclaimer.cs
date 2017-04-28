using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ns15
{
	public class Disclaimer : Form
	{
		private IContainer icontainer_0;

		private RichTextBox richTextBox1;

		private Button AcceptBtn;

		private TableLayoutPanel tableLayoutPanel1;

		private TableLayoutPanel BtnLayoutPanel;

		private Button CancelBtn;

		private Timer timer_0;

		private int int_0 = 3;

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
			icontainer_0 = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Disclaimer));
			richTextBox1 = new RichTextBox();
			AcceptBtn = new Button();
			tableLayoutPanel1 = new TableLayoutPanel();
			BtnLayoutPanel = new TableLayoutPanel();
			CancelBtn = new Button();
			timer_0 = new Timer(icontainer_0);
			tableLayoutPanel1.SuspendLayout();
			BtnLayoutPanel.SuspendLayout();
			SuspendLayout();
			richTextBox1.Dock = DockStyle.Fill;
			richTextBox1.Location = new Point(3, 3);
			richTextBox1.Name = "richTextBox1";
			richTextBox1.ReadOnly = true;
			richTextBox1.Size = new Size(402, 267);
			richTextBox1.TabIndex = 0;
			richTextBox1.Text = componentResourceManager.GetString("richTextBox1.Text");
			AcceptBtn.DialogResult = DialogResult.OK;
			AcceptBtn.Dock = DockStyle.Fill;
			AcceptBtn.Location = new Point(3, 3);
			AcceptBtn.Name = "AcceptBtn";
			AcceptBtn.Size = new Size(198, 25);
			AcceptBtn.TabIndex = 1;
			AcceptBtn.Text = "I ACCEPT";
            AcceptBtn.Enabled = true;
			AcceptBtn.UseVisualStyleBackColor = true;
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			tableLayoutPanel1.Controls.Add(BtnLayoutPanel, 0, 1);
			tableLayoutPanel1.Controls.Add(richTextBox1, 0, 0);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Margin = new Padding(0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 89.83402f));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.16598f));
			tableLayoutPanel1.Size = new Size(408, 304);
			tableLayoutPanel1.TabIndex = 2;
			BtnLayoutPanel.ColumnCount = 2;
			BtnLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			BtnLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			BtnLayoutPanel.Controls.Add(CancelBtn, 1, 0);
			BtnLayoutPanel.Controls.Add(AcceptBtn, 0, 0);
			BtnLayoutPanel.Dock = DockStyle.Fill;
			BtnLayoutPanel.Location = new Point(0, 273);
			BtnLayoutPanel.Margin = new Padding(0);
			BtnLayoutPanel.Name = "BtnLayoutPanel";
			BtnLayoutPanel.RowCount = 1;
			BtnLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
			BtnLayoutPanel.Size = new Size(408, 31);
			BtnLayoutPanel.TabIndex = 0;
			CancelBtn.DialogResult = DialogResult.Cancel;
			CancelBtn.Dock = DockStyle.Fill;
			CancelBtn.Location = new Point(207, 3);
			CancelBtn.Name = "CancelBtn";
			CancelBtn.Size = new Size(198, 25);
			CancelBtn.TabIndex = 2;
			CancelBtn.Text = "I DONT ACCEPT";
			CancelBtn.UseVisualStyleBackColor = true;
			timer_0.Interval = 1000;
			timer_0.Tick += timer_0_Tick;
			AutoScaleDimensions = new SizeF(6f, 13f);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(408, 304);
			Controls.Add(tableLayoutPanel1);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "Disclaimer";
			Text = "User Agreement & Disclaimer";
			TopMost = true;
			tableLayoutPanel1.ResumeLayout(false);
			BtnLayoutPanel.ResumeLayout(false);
			ResumeLayout(false);
		}

		public Disclaimer()
		{
			InitializeComponent();
			AcceptBtn.Enabled = true;
			AcceptBtn.Text = "I ACCEPT";
			//this.timer_0.Enabled = true;
			//this.timer_0.Start();
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			if (--int_0 > 0)
			{
				AcceptBtn.Text = "Read Agreement First! (" + int_0 + ")";
				return;
			}
			timer_0.Stop();
			timer_0.Enabled = false;
			AcceptBtn.Enabled = true;
			AcceptBtn.Text = "I ACCEPT";
		}
	}
}
