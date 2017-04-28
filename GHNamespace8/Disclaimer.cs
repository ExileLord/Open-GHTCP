using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GHNamespace8
{
    public class Disclaimer : Form
    {
        private IContainer icontainer_0;

        private RichTextBox _richTextBox1;

        private Button _acceptBtn;

        private TableLayoutPanel _tableLayoutPanel1;

        private TableLayoutPanel _btnLayoutPanel;

        private Button _cancelBtn;

        private Timer _timer0;

        private int _int0 = 3;

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
            var componentResourceManager = new ComponentResourceManager(typeof(Disclaimer));
            _richTextBox1 = new RichTextBox();
            _acceptBtn = new Button();
            _tableLayoutPanel1 = new TableLayoutPanel();
            _btnLayoutPanel = new TableLayoutPanel();
            _cancelBtn = new Button();
            _timer0 = new Timer(icontainer_0);
            _tableLayoutPanel1.SuspendLayout();
            _btnLayoutPanel.SuspendLayout();
            SuspendLayout();
            _richTextBox1.Dock = DockStyle.Fill;
            _richTextBox1.Location = new Point(3, 3);
            _richTextBox1.Name = "_richTextBox1";
            _richTextBox1.ReadOnly = true;
            _richTextBox1.Size = new Size(402, 267);
            _richTextBox1.TabIndex = 0;
            _richTextBox1.Text = componentResourceManager.GetString("richTextBox1.Text");
            _acceptBtn.DialogResult = DialogResult.OK;
            _acceptBtn.Dock = DockStyle.Fill;
            _acceptBtn.Location = new Point(3, 3);
            _acceptBtn.Name = "_acceptBtn";
            _acceptBtn.Size = new Size(198, 25);
            _acceptBtn.TabIndex = 1;
            _acceptBtn.Text = "I ACCEPT";
            _acceptBtn.Enabled = true;
            _acceptBtn.UseVisualStyleBackColor = true;
            _tableLayoutPanel1.ColumnCount = 1;
            _tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            _tableLayoutPanel1.Controls.Add(_btnLayoutPanel, 0, 1);
            _tableLayoutPanel1.Controls.Add(_richTextBox1, 0, 0);
            _tableLayoutPanel1.Dock = DockStyle.Fill;
            _tableLayoutPanel1.Location = new Point(0, 0);
            _tableLayoutPanel1.Margin = new Padding(0);
            _tableLayoutPanel1.Name = "_tableLayoutPanel1";
            _tableLayoutPanel1.RowCount = 2;
            _tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 89.83402f));
            _tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.16598f));
            _tableLayoutPanel1.Size = new Size(408, 304);
            _tableLayoutPanel1.TabIndex = 2;
            _btnLayoutPanel.ColumnCount = 2;
            _btnLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            _btnLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            _btnLayoutPanel.Controls.Add(_cancelBtn, 1, 0);
            _btnLayoutPanel.Controls.Add(_acceptBtn, 0, 0);
            _btnLayoutPanel.Dock = DockStyle.Fill;
            _btnLayoutPanel.Location = new Point(0, 273);
            _btnLayoutPanel.Margin = new Padding(0);
            _btnLayoutPanel.Name = "_btnLayoutPanel";
            _btnLayoutPanel.RowCount = 1;
            _btnLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
            _btnLayoutPanel.Size = new Size(408, 31);
            _btnLayoutPanel.TabIndex = 0;
            _cancelBtn.DialogResult = DialogResult.Cancel;
            _cancelBtn.Dock = DockStyle.Fill;
            _cancelBtn.Location = new Point(207, 3);
            _cancelBtn.Name = "_cancelBtn";
            _cancelBtn.Size = new Size(198, 25);
            _cancelBtn.TabIndex = 2;
            _cancelBtn.Text = "I DONT ACCEPT";
            _cancelBtn.UseVisualStyleBackColor = true;
            _timer0.Interval = 1000;
            _timer0.Tick += timer_0_Tick;
            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(408, 304);
            Controls.Add(_tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Disclaimer";
            Text = "User Agreement & Disclaimer";
            TopMost = true;
            _tableLayoutPanel1.ResumeLayout(false);
            _btnLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        public Disclaimer()
        {
            InitializeComponent();
            _acceptBtn.Enabled = true;
            _acceptBtn.Text = "I ACCEPT";
            //this.timer_0.Enabled = true;
            //this.timer_0.Start();
        }

        private void timer_0_Tick(object sender, EventArgs e)
        {
            if (--_int0 > 0)
            {
                _acceptBtn.Text = "Read Agreement First! (" + _int0 + ")";
                return;
            }
            _timer0.Stop();
            _timer0.Enabled = false;
            _acceptBtn.Enabled = true;
            _acceptBtn.Text = "I ACCEPT";
        }
    }
}