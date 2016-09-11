using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ns17
{
	public class About : Form
	{
		private IContainer icontainer_0;

		private TableLayoutPanel tableLayoutPanel;

		private PictureBox logoPictureBox;

		private Label labelProductName;

		private Label labelVersion;

		private Label labelCopyright;

		private Label labelCompanyName;

		private TextBox textBoxDescription;

		private Button okButton;

		public About()
		{
			this.InitializeComponent();
			this.Text = string.Format("About {0}", this.method_0());
			this.labelProductName.Text = this.method_2();
			this.labelVersion.Text = string.Format("Version {0}", this.method_1());
			this.labelCopyright.Text = this.method_3();
			this.labelCompanyName.Text = this.method_4();
		}

		public string method_0()
		{
			object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
			if (customAttributes.Length > 0)
			{
				AssemblyTitleAttribute assemblyTitleAttribute = (AssemblyTitleAttribute)customAttributes[0];
				if (assemblyTitleAttribute.Title != "")
				{
					return assemblyTitleAttribute.Title;
				}
			}
			return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
		}

		public string method_1()
		{
			return Assembly.GetExecutingAssembly().GetName().Version.ToString();
		}

		public string method_2()
		{
			object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
			if (customAttributes.Length == 0)
			{
				return "";
			}
			return ((AssemblyProductAttribute)customAttributes[0]).Product;
		}

		public string method_3()
		{
			object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
			if (customAttributes.Length == 0)
			{
				return "";
			}
			return ((AssemblyCopyrightAttribute)customAttributes[0]).Copyright;
		}

		public string method_4()
		{
			object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
			if (customAttributes.Length == 0)
			{
				return "";
			}
			return ((AssemblyCompanyAttribute)customAttributes[0]).Company;
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(About));
			this.tableLayoutPanel = new TableLayoutPanel();
			this.logoPictureBox = new PictureBox();
			this.labelProductName = new Label();
			this.labelVersion = new Label();
			this.labelCopyright = new Label();
			this.labelCompanyName = new Label();
			this.textBoxDescription = new TextBox();
			this.okButton = new Button();
			this.tableLayoutPanel.SuspendLayout();
			((ISupportInitialize)this.logoPictureBox).BeginInit();
			base.SuspendLayout();
			this.tableLayoutPanel.ColumnCount = 2;
			this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
			this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67f));
			this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.labelProductName, 1, 0);
			this.tableLayoutPanel.Controls.Add(this.labelVersion, 1, 1);
			this.tableLayoutPanel.Controls.Add(this.labelCopyright, 1, 2);
			this.tableLayoutPanel.Controls.Add(this.labelCompanyName, 1, 3);
			this.tableLayoutPanel.Controls.Add(this.textBoxDescription, 1, 4);
			this.tableLayoutPanel.Controls.Add(this.okButton, 1, 5);
			this.tableLayoutPanel.Dock = DockStyle.Fill;
			this.tableLayoutPanel.Location = new Point(9, 9);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 6;
			this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
			this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
			this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
			this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
			this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
			this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
			this.tableLayoutPanel.Size = new Size(487, 265);
			this.tableLayoutPanel.TabIndex = 0;
			this.logoPictureBox.Dock = DockStyle.Fill;
			this.logoPictureBox.Image = (Image)componentResourceManager.GetObject("logoPictureBox.Image");
			this.logoPictureBox.Location = new Point(3, 3);
			this.logoPictureBox.Name = "logoPictureBox";
			this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 6);
			this.logoPictureBox.Size = new Size(131, 259);
			this.logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			this.logoPictureBox.TabIndex = 12;
			this.logoPictureBox.TabStop = false;
			this.labelProductName.Dock = DockStyle.Fill;
			this.labelProductName.Location = new Point(143, 0);
			this.labelProductName.Margin = new Padding(6, 0, 3, 0);
			this.labelProductName.MaximumSize = new Size(0, 17);
			this.labelProductName.Name = "labelProductName";
			this.labelProductName.Size = new Size(271, 17);
			this.labelProductName.TabIndex = 19;
			this.labelProductName.Text = "Product Name";
			this.labelProductName.TextAlign = ContentAlignment.MiddleLeft;
			this.labelVersion.Dock = DockStyle.Fill;
			this.labelVersion.Location = new Point(143, 26);
			this.labelVersion.Margin = new Padding(6, 0, 3, 0);
			this.labelVersion.MaximumSize = new Size(0, 17);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new Size(271, 17);
			this.labelVersion.TabIndex = 0;
			this.labelVersion.Text = "Version";
			this.labelVersion.TextAlign = ContentAlignment.MiddleLeft;
			this.labelCopyright.Dock = DockStyle.Fill;
			this.labelCopyright.Location = new Point(143, 52);
			this.labelCopyright.Margin = new Padding(6, 0, 3, 0);
			this.labelCopyright.MaximumSize = new Size(0, 17);
			this.labelCopyright.Name = "labelCopyright";
			this.labelCopyright.Size = new Size(271, 17);
			this.labelCopyright.TabIndex = 21;
			this.labelCopyright.Text = "Copyright";
			this.labelCopyright.TextAlign = ContentAlignment.MiddleLeft;
			this.labelCompanyName.Dock = DockStyle.Fill;
			this.labelCompanyName.Location = new Point(143, 78);
			this.labelCompanyName.Margin = new Padding(6, 0, 3, 0);
			this.labelCompanyName.MaximumSize = new Size(0, 17);
			this.labelCompanyName.Name = "labelCompanyName";
			this.labelCompanyName.Size = new Size(271, 17);
			this.labelCompanyName.TabIndex = 22;
			this.labelCompanyName.Text = "Company Name";
			this.labelCompanyName.TextAlign = ContentAlignment.MiddleLeft;
			this.textBoxDescription.Dock = DockStyle.Fill;
			this.textBoxDescription.Location = new Point(143, 107);
			this.textBoxDescription.Margin = new Padding(6, 3, 3, 3);
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.ReadOnly = true;
			this.textBoxDescription.ScrollBars = ScrollBars.Both;
			this.textBoxDescription.Size = new Size(271, 126);
			this.textBoxDescription.TabIndex = 23;
			this.textBoxDescription.Text = componentResourceManager.GetString("textBoxDescription.Text");
			this.okButton.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.okButton.DialogResult = DialogResult.Cancel;
			this.okButton.Location = new Point(339, 239);
			this.okButton.Name = "okButton";
			this.okButton.Size = new Size(75, 23);
			this.okButton.TabIndex = 24;
			this.okButton.Text = "&OK";
			base.AcceptButton = this.okButton;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(435, 283);
			base.Controls.Add(this.tableLayoutPanel);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "About";
			base.Padding = new Padding(9);
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = "About";
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			((ISupportInitialize)this.logoPictureBox).EndInit();
			base.ResumeLayout(false);
		}
	}
}
