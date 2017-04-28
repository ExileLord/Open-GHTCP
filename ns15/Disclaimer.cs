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
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.icontainer_0 = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Disclaimer));
			this.richTextBox1 = new RichTextBox();
			this.AcceptBtn = new Button();
			this.tableLayoutPanel1 = new TableLayoutPanel();
			this.BtnLayoutPanel = new TableLayoutPanel();
			this.CancelBtn = new Button();
			this.timer_0 = new Timer(this.icontainer_0);
			this.tableLayoutPanel1.SuspendLayout();
			this.BtnLayoutPanel.SuspendLayout();
			base.SuspendLayout();
			this.richTextBox1.Dock = DockStyle.Fill;
			this.richTextBox1.Location = new Point(3, 3);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new Size(402, 267);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = componentResourceManager.GetString("richTextBox1.Text");
			this.AcceptBtn.DialogResult = DialogResult.OK;
			this.AcceptBtn.Dock = DockStyle.Fill;
			this.AcceptBtn.Location = new Point(3, 3);
			this.AcceptBtn.Name = "AcceptBtn";
			this.AcceptBtn.Size = new Size(198, 25);
			this.AcceptBtn.TabIndex = 1;
			this.AcceptBtn.Text = "I ACCEPT";
            this.AcceptBtn.Enabled = true;
			this.AcceptBtn.UseVisualStyleBackColor = true;
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			this.tableLayoutPanel1.Controls.Add(this.BtnLayoutPanel, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 0, 0);
			this.tableLayoutPanel1.Dock = DockStyle.Fill;
			this.tableLayoutPanel1.Location = new Point(0, 0);
			this.tableLayoutPanel1.Margin = new Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 89.83402f));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.16598f));
			this.tableLayoutPanel1.Size = new Size(408, 304);
			this.tableLayoutPanel1.TabIndex = 2;
			this.BtnLayoutPanel.ColumnCount = 2;
			this.BtnLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			this.BtnLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			this.BtnLayoutPanel.Controls.Add(this.CancelBtn, 1, 0);
			this.BtnLayoutPanel.Controls.Add(this.AcceptBtn, 0, 0);
			this.BtnLayoutPanel.Dock = DockStyle.Fill;
			this.BtnLayoutPanel.Location = new Point(0, 273);
			this.BtnLayoutPanel.Margin = new Padding(0);
			this.BtnLayoutPanel.Name = "BtnLayoutPanel";
			this.BtnLayoutPanel.RowCount = 1;
			this.BtnLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
			this.BtnLayoutPanel.Size = new Size(408, 31);
			this.BtnLayoutPanel.TabIndex = 0;
			this.CancelBtn.DialogResult = DialogResult.Cancel;
			this.CancelBtn.Dock = DockStyle.Fill;
			this.CancelBtn.Location = new Point(207, 3);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new Size(198, 25);
			this.CancelBtn.TabIndex = 2;
			this.CancelBtn.Text = "I DONT ACCEPT";
			this.CancelBtn.UseVisualStyleBackColor = true;
			this.timer_0.Interval = 1000;
			this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(408, 304);
			base.Controls.Add(this.tableLayoutPanel1);
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.Name = "Disclaimer";
			this.Text = "User Agreement & Disclaimer";
			base.TopMost = true;
			this.tableLayoutPanel1.ResumeLayout(false);
			this.BtnLayoutPanel.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public Disclaimer()
		{
			this.InitializeComponent();
			this.AcceptBtn.Enabled = true;
			this.AcceptBtn.Text = "I ACCEPT";
			//this.timer_0.Enabled = true;
			//this.timer_0.Start();
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			if (--this.int_0 > 0)
			{
				this.AcceptBtn.Text = "Read Agreement First! (" + this.int_0 + ")";
				return;
			}
			this.timer_0.Stop();
			this.timer_0.Enabled = false;
			this.AcceptBtn.Enabled = true;
			this.AcceptBtn.Text = "I ACCEPT";
		}
	}
}
