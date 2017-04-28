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
			InitializeComponent();
			Text = string.Format("About {0}", method_0());
			labelProductName.Text = method_2();
			labelVersion.Text = string.Format("Version {0}", method_1());
			labelCopyright.Text = method_3();
			labelCompanyName.Text = method_4();
		}

		public string method_0()
		{
			var customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
			if (customAttributes.Length > 0)
			{
				var assemblyTitleAttribute = (AssemblyTitleAttribute)customAttributes[0];
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
			var customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
			if (customAttributes.Length == 0)
			{
				return "";
			}
			return ((AssemblyProductAttribute)customAttributes[0]).Product;
		}

		public string method_3()
		{
			var customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
			if (customAttributes.Length == 0)
			{
				return "";
			}
			return ((AssemblyCopyrightAttribute)customAttributes[0]).Copyright;
		}

		public string method_4()
		{
			var customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
			if (customAttributes.Length == 0)
			{
				return "";
			}
			return ((AssemblyCompanyAttribute)customAttributes[0]).Company;
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
			var componentResourceManager = new ComponentResourceManager(typeof(About));
			tableLayoutPanel = new TableLayoutPanel();
			logoPictureBox = new PictureBox();
			labelProductName = new Label();
			labelVersion = new Label();
			labelCopyright = new Label();
			labelCompanyName = new Label();
			textBoxDescription = new TextBox();
			okButton = new Button();
			tableLayoutPanel.SuspendLayout();
			((ISupportInitialize)logoPictureBox).BeginInit();
			SuspendLayout();
			tableLayoutPanel.ColumnCount = 2;
			tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
			tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67f));
			tableLayoutPanel.Controls.Add(logoPictureBox, 0, 0);
			tableLayoutPanel.Controls.Add(labelProductName, 1, 0);
			tableLayoutPanel.Controls.Add(labelVersion, 1, 1);
			tableLayoutPanel.Controls.Add(labelCopyright, 1, 2);
			tableLayoutPanel.Controls.Add(labelCompanyName, 1, 3);
			tableLayoutPanel.Controls.Add(textBoxDescription, 1, 4);
			tableLayoutPanel.Controls.Add(okButton, 1, 5);
			tableLayoutPanel.Dock = DockStyle.Fill;
			tableLayoutPanel.Location = new Point(9, 9);
			tableLayoutPanel.Name = "tableLayoutPanel";
			tableLayoutPanel.RowCount = 6;
			tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
			tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
			tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
			tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
			tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
			tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
			tableLayoutPanel.Size = new Size(487, 265);
			tableLayoutPanel.TabIndex = 0;
			logoPictureBox.Dock = DockStyle.Fill;
			logoPictureBox.Image = (Image)componentResourceManager.GetObject("logoPictureBox.Image");
			logoPictureBox.Location = new Point(3, 3);
			logoPictureBox.Name = "logoPictureBox";
			tableLayoutPanel.SetRowSpan(logoPictureBox, 6);
			logoPictureBox.Size = new Size(131, 259);
			logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			logoPictureBox.TabIndex = 12;
			logoPictureBox.TabStop = false;
			labelProductName.Dock = DockStyle.Fill;
			labelProductName.Location = new Point(143, 0);
			labelProductName.Margin = new Padding(6, 0, 3, 0);
			labelProductName.MaximumSize = new Size(0, 17);
			labelProductName.Name = "labelProductName";
			labelProductName.Size = new Size(271, 17);
			labelProductName.TabIndex = 19;
			labelProductName.Text = "Product Name";
			labelProductName.TextAlign = ContentAlignment.MiddleLeft;
			labelVersion.Dock = DockStyle.Fill;
			labelVersion.Location = new Point(143, 26);
			labelVersion.Margin = new Padding(6, 0, 3, 0);
			labelVersion.MaximumSize = new Size(0, 17);
			labelVersion.Name = "labelVersion";
			labelVersion.Size = new Size(271, 17);
			labelVersion.TabIndex = 0;
			labelVersion.Text = "Version";
			labelVersion.TextAlign = ContentAlignment.MiddleLeft;
			labelCopyright.Dock = DockStyle.Fill;
			labelCopyright.Location = new Point(143, 52);
			labelCopyright.Margin = new Padding(6, 0, 3, 0);
			labelCopyright.MaximumSize = new Size(0, 17);
			labelCopyright.Name = "labelCopyright";
			labelCopyright.Size = new Size(271, 17);
			labelCopyright.TabIndex = 21;
			labelCopyright.Text = "Copyright";
			labelCopyright.TextAlign = ContentAlignment.MiddleLeft;
			labelCompanyName.Dock = DockStyle.Fill;
			labelCompanyName.Location = new Point(143, 78);
			labelCompanyName.Margin = new Padding(6, 0, 3, 0);
			labelCompanyName.MaximumSize = new Size(0, 17);
			labelCompanyName.Name = "labelCompanyName";
			labelCompanyName.Size = new Size(271, 17);
			labelCompanyName.TabIndex = 22;
			labelCompanyName.Text = "Company Name";
			labelCompanyName.TextAlign = ContentAlignment.MiddleLeft;
			textBoxDescription.Dock = DockStyle.Fill;
			textBoxDescription.Location = new Point(143, 107);
			textBoxDescription.Margin = new Padding(6, 3, 3, 3);
			textBoxDescription.Multiline = true;
			textBoxDescription.Name = "textBoxDescription";
			textBoxDescription.ReadOnly = true;
			textBoxDescription.ScrollBars = ScrollBars.Both;
			textBoxDescription.Size = new Size(271, 126);
			textBoxDescription.TabIndex = 23;
			textBoxDescription.Text = componentResourceManager.GetString("textBoxDescription.Text");
			okButton.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			okButton.DialogResult = DialogResult.Cancel;
			okButton.Location = new Point(339, 239);
			okButton.Name = "okButton";
			okButton.Size = new Size(75, 23);
			okButton.TabIndex = 24;
			okButton.Text = "&OK";
			AcceptButton = okButton;
			AutoScaleDimensions = new SizeF(6f, 13f);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(435, 283);
			Controls.Add(tableLayoutPanel);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "About";
			Padding = new Padding(9);
			ShowIcon = false;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterParent;
			Text = "About";
			tableLayoutPanel.ResumeLayout(false);
			tableLayoutPanel.PerformLayout();
			((ISupportInitialize)logoPictureBox).EndInit();
			ResumeLayout(false);
		}
	}
}
