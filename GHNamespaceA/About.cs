using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace GHNamespaceA
{
    public class About : Form
    {
        private IContainer icontainer_0;

        private TableLayoutPanel _tableLayoutPanel;

        private PictureBox _logoPictureBox;

        private Label _labelProductName;

        private Label _labelVersion;

        private Label _labelCopyright;

        private Label _labelContributors;

        private TextBox _textBoxDescription;

        private Button _okButton;

        public About()
        {
            InitializeComponent();
            Text = string.Format("About {0}", method_0());
            _labelProductName.Text = method_2();
            _labelVersion.Text = string.Format("Version {0}", method_1());
            _labelCopyright.Text = method_3();
            _labelContributors.Text = method_4();
        }

        public string method_0()
        {
            object[] customAttributes = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            if (customAttributes.Length > 0)
            {
                AssemblyTitleAttribute assemblyTitleAttribute = (AssemblyTitleAttribute) customAttributes[0];
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
            object[] customAttributes = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(AssemblyProductAttribute), false);
            if (customAttributes.Length == 0)
            {
                return "";
            }
            return ((AssemblyProductAttribute) customAttributes[0]).Product;
        }

        public string method_3()
        {
            object[] customAttributes = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            if (customAttributes.Length == 0)
            {
                return "";
            }
            return ((AssemblyCopyrightAttribute) customAttributes[0]).Copyright;
        }

        public string method_4()
        {
            object[] customAttributes = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
            if (customAttributes.Length == 0)
            {
                return "";
            }
            return ((AssemblyCompanyAttribute) customAttributes[0]).Company;
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
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(About));
            _tableLayoutPanel = new TableLayoutPanel();
            _logoPictureBox = new PictureBox();
            _labelProductName = new Label();
            _labelVersion = new Label();
            _labelCopyright = new Label();
            _labelContributors = new Label();
            _textBoxDescription = new TextBox();
            _okButton = new Button();
            _tableLayoutPanel.SuspendLayout();
            ((ISupportInitialize) _logoPictureBox).BeginInit();
            SuspendLayout();
            _tableLayoutPanel.ColumnCount = 2;
            _tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
            _tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67f));
            _tableLayoutPanel.Controls.Add(_logoPictureBox, 0, 0);
            _tableLayoutPanel.Controls.Add(_labelProductName, 1, 0);
            _tableLayoutPanel.Controls.Add(_labelVersion, 1, 1);
            _tableLayoutPanel.Controls.Add(_labelCopyright, 1, 2);
            _tableLayoutPanel.Controls.Add(_labelContributors, 1, 3);
            _tableLayoutPanel.Controls.Add(_textBoxDescription, 1, 4);
            _tableLayoutPanel.Controls.Add(_okButton, 1, 5);
            _tableLayoutPanel.Dock = DockStyle.Fill;
            _tableLayoutPanel.Location = new Point(9, 9);
            _tableLayoutPanel.Name = "_tableLayoutPanel";
            _tableLayoutPanel.RowCount = 6;
            _tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
            _tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
            _tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
            _tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
            _tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
            _tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
            _tableLayoutPanel.Size = new Size(487, 265);
            _tableLayoutPanel.TabIndex = 0;
            _logoPictureBox.Dock = DockStyle.Fill;
            _logoPictureBox.Image = (Image) componentResourceManager.GetObject("logoPictureBox.Image");
            _logoPictureBox.Location = new Point(3, 3);
            _logoPictureBox.Name = "_logoPictureBox";
            _tableLayoutPanel.SetRowSpan(_logoPictureBox, 6);
            _logoPictureBox.Size = new Size(131, 259);
            _logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            _logoPictureBox.TabIndex = 12;
            _logoPictureBox.TabStop = false;
            _labelProductName.Dock = DockStyle.Fill;
            _labelProductName.Location = new Point(143, 0);
            _labelProductName.Margin = new Padding(6, 0, 3, 0);
            _labelProductName.MaximumSize = new Size(0, 17);
            _labelProductName.Name = "_labelProductName";
            _labelProductName.Size = new Size(271, 17);
            _labelProductName.TabIndex = 19;
            _labelProductName.Text = "Product Name";
            _labelProductName.TextAlign = ContentAlignment.MiddleLeft;
            _labelVersion.Dock = DockStyle.Fill;
            _labelVersion.Location = new Point(143, 26);
            _labelVersion.Margin = new Padding(6, 0, 3, 0);
            _labelVersion.MaximumSize = new Size(0, 17);
            _labelVersion.Name = "_labelVersion";
            _labelVersion.Size = new Size(271, 17);
            _labelVersion.TabIndex = 0;
            _labelVersion.Text = "Version";
            _labelVersion.TextAlign = ContentAlignment.MiddleLeft;
            _labelCopyright.Dock = DockStyle.Fill;
            _labelCopyright.Location = new Point(143, 52);
            _labelCopyright.Margin = new Padding(6, 0, 3, 0);
            _labelCopyright.MaximumSize = new Size(0, 17);
            _labelCopyright.Name = "_labelCopyright";
            _labelCopyright.Size = new Size(271, 17);
            _labelCopyright.TabIndex = 21;
            _labelCopyright.Text = "Copyright";
            _labelCopyright.TextAlign = ContentAlignment.MiddleLeft;
            _labelContributors.Dock = DockStyle.Fill;
            _labelContributors.Location = new Point(143, 78);
            _labelContributors.Margin = new Padding(6, 0, 3, 0);
            _labelContributors.MaximumSize = new Size(0, 170);
            _labelContributors.Name = "_labelContributors";
            _labelContributors.Size = new Size(271, 17);
            _labelContributors.TabIndex = 22;
            _labelContributors.Text = "Plus Version";
            _labelContributors.TextAlign = ContentAlignment.MiddleLeft;
            _textBoxDescription.Dock = DockStyle.Fill;
            _textBoxDescription.Location = new Point(143, 110);
            _textBoxDescription.Margin = new Padding(6, 6, 3, 3);
            _textBoxDescription.Multiline = true;
            _textBoxDescription.Name = "_textBoxDescription";
            _textBoxDescription.ReadOnly = true;
            _textBoxDescription.ScrollBars = ScrollBars.Both;
            _textBoxDescription.Size = new Size(271, 126);
            _textBoxDescription.TabIndex = 23;
            _textBoxDescription.Text = componentResourceManager.GetString("textBoxDescription.Text");
            _okButton.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            _okButton.DialogResult = DialogResult.Cancel;
            _okButton.Location = new Point(339, 239);
            _okButton.Name = "_okButton";
            _okButton.Size = new Size(75, 23);
            _okButton.TabIndex = 24;
            _okButton.Text = "&OK";
            AcceptButton = _okButton;
            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(435, 283);
            Controls.Add(_tableLayoutPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "About";
            Padding = new Padding(9);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "About";
            _tableLayoutPanel.ResumeLayout(false);
            _tableLayoutPanel.PerformLayout();
            ((ISupportInitialize) _logoPictureBox).EndInit();
            ResumeLayout(false);
        }
    }
}