using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ns16;
using ns19;
using ns21;
using NeversoftTools.Texture.DDS;

namespace ns20
{
	public class TexExplorer : Form
	{
		private IContainer icontainer_0;

		private PictureBox _imagePreviewBox;

		private GroupBox _imageInfoBox;

		private TextBox _widthTxt;

		private TextBox _mipMapTxt;

		private TextBox _bppTxt;

		private ListBox _imgList;

		private TreeView _dataFolderTreeView;

		private TextBox _formatTxt;

		private TextBox _heightTxt;

		private Label _lblHeight;

		private Label _lblWidth;

		private Label _lblBpp;

		private Label _lblMipMaps;

		private Label _lblFormat;

		private Button _replaceImgBtn;

		private Button _rebuildBtn;

		private Button _extractImgBtn;

		private TableLayoutPanel _tableLayoutPanel1;

		private TableLayoutPanel _tableLayoutPanel2;

		private TableLayoutPanel _tableLayoutPanel3;

		private TableLayoutPanel _tableLayoutPanel4;

		private ToolStripContainer _treeViewContainer;

		private ToolStrip _searchToolStrip;

		private ToolStripTextBox _searchTxtBox;

		private ToolStripButton _prevSearchBtn;

		private ToolStripButton _nextSearchBtn;

		private ToolStripLabel _searchPosLbl;

		private ToolStripButton _searchBtn;

		private readonly string _string0;

		private TexFile _currentTexFile;

        private TextureMetadata _currentImgFile;

		private Thread _thread0;

		private Size _size0;

		private ImgPixelFormat _currentTexturePixelFormat;

		private string _string1;

		private readonly List<TreeNode> _nodeList = new List<TreeNode>();
        private GroupBox _groupBox1;
        private Label _label1;
        private Label _label6;
        private Label _label5;
        private Label _label4;
        private Label _label3;
        private Label _label2;
        private CheckBox _chkEditMetadata;
        private TextBox _txtWidth;
        private TextBox _txtKey;
        private TextBox _txtLength;
        private TextBox _txtStart;
        private TextBox _txtUnk4;
        private TextBox _txtMipMaps;
        private TextBox _txtUnk3;
        private TextBox _txtHeight;
        private TextBox _txtFlags;
        private Label _label9;
        private Label _label8;
        private Label _label7;
        private Button _btnCloneImage;
        private TableLayoutPanel _tblImageList;
        private int _count;

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
            _imagePreviewBox = new PictureBox();
            _imageInfoBox = new GroupBox();
            _extractImgBtn = new Button();
            _replaceImgBtn = new Button();
            _lblHeight = new Label();
            _lblWidth = new Label();
            _lblBpp = new Label();
            _lblMipMaps = new Label();
            _lblFormat = new Label();
            _heightTxt = new TextBox();
            _formatTxt = new TextBox();
            _widthTxt = new TextBox();
            _mipMapTxt = new TextBox();
            _bppTxt = new TextBox();
            _imgList = new ListBox();
            _dataFolderTreeView = new TreeView();
            _rebuildBtn = new Button();
            _tableLayoutPanel1 = new TableLayoutPanel();
            _tableLayoutPanel2 = new TableLayoutPanel();
            _tableLayoutPanel3 = new TableLayoutPanel();
            _tableLayoutPanel4 = new TableLayoutPanel();
            _groupBox1 = new GroupBox();
            _chkEditMetadata = new CheckBox();
            _txtWidth = new TextBox();
            _txtKey = new TextBox();
            _txtLength = new TextBox();
            _txtStart = new TextBox();
            _txtUnk4 = new TextBox();
            _txtMipMaps = new TextBox();
            _txtUnk3 = new TextBox();
            _txtHeight = new TextBox();
            _txtFlags = new TextBox();
            _label9 = new Label();
            _label8 = new Label();
            _label7 = new Label();
            _label6 = new Label();
            _label5 = new Label();
            _label4 = new Label();
            _label3 = new Label();
            _label2 = new Label();
            _label1 = new Label();
            _tblImageList = new TableLayoutPanel();
            _btnCloneImage = new Button();
            _treeViewContainer = new ToolStripContainer();
            _searchToolStrip = new ToolStrip();
            _searchTxtBox = new ToolStripTextBox();
            _searchBtn = new ToolStripButton();
            _prevSearchBtn = new ToolStripButton();
            _nextSearchBtn = new ToolStripButton();
            _searchPosLbl = new ToolStripLabel();
            ((ISupportInitialize)(_imagePreviewBox)).BeginInit();
            _imageInfoBox.SuspendLayout();
            _tableLayoutPanel1.SuspendLayout();
            _tableLayoutPanel2.SuspendLayout();
            _tableLayoutPanel3.SuspendLayout();
            _tableLayoutPanel4.SuspendLayout();
            _groupBox1.SuspendLayout();
            _tblImageList.SuspendLayout();
            _treeViewContainer.ContentPanel.SuspendLayout();
            _treeViewContainer.TopToolStripPanel.SuspendLayout();
            _treeViewContainer.SuspendLayout();
            _searchToolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // ImagePreviewBox
            // 
            _imagePreviewBox.BackColor = Color.Transparent;
            _imagePreviewBox.BorderStyle = BorderStyle.FixedSingle;
            _imagePreviewBox.Dock = DockStyle.Fill;
            _imagePreviewBox.Location = new Point(103, 3);
            _imagePreviewBox.Name = "_imagePreviewBox";
            _imagePreviewBox.Size = new Size(1015, 511);
            _imagePreviewBox.SizeMode = PictureBoxSizeMode.CenterImage;
            _imagePreviewBox.TabIndex = 7;
            _imagePreviewBox.TabStop = false;
            _imagePreviewBox.Click += ImagePreviewBox_Click;
            // 
            // ImageInfoBox
            // 
            _imageInfoBox.Controls.Add(_extractImgBtn);
            _imageInfoBox.Controls.Add(_replaceImgBtn);
            _imageInfoBox.Controls.Add(_lblHeight);
            _imageInfoBox.Controls.Add(_lblWidth);
            _imageInfoBox.Controls.Add(_lblBpp);
            _imageInfoBox.Controls.Add(_lblMipMaps);
            _imageInfoBox.Controls.Add(_lblFormat);
            _imageInfoBox.Controls.Add(_heightTxt);
            _imageInfoBox.Controls.Add(_formatTxt);
            _imageInfoBox.Controls.Add(_widthTxt);
            _imageInfoBox.Controls.Add(_mipMapTxt);
            _imageInfoBox.Controls.Add(_bppTxt);
            _imageInfoBox.Enabled = false;
            _imageInfoBox.Location = new Point(1030, 3);
            _imageInfoBox.Name = "_imageInfoBox";
            _imageInfoBox.Size = new Size(288, 100);
            _imageInfoBox.TabIndex = 8;
            _imageInfoBox.TabStop = false;
            _imageInfoBox.Text = "Image Information";
            // 
            // ExtractImgBtn
            // 
            _extractImgBtn.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _extractImgBtn.Location = new Point(215, 67);
            _extractImgBtn.Name = "_extractImgBtn";
            _extractImgBtn.Size = new Size(67, 27);
            _extractImgBtn.TabIndex = 46;
            _extractImgBtn.Text = "Extract";
            _extractImgBtn.UseVisualStyleBackColor = true;
            _extractImgBtn.Click += ExtractImgBtn_Click;
            // 
            // ReplaceImgBtn
            // 
            _replaceImgBtn.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _replaceImgBtn.Location = new Point(137, 67);
            _replaceImgBtn.Name = "_replaceImgBtn";
            _replaceImgBtn.Size = new Size(72, 27);
            _replaceImgBtn.TabIndex = 45;
            _replaceImgBtn.Text = "Replace";
            _replaceImgBtn.UseVisualStyleBackColor = true;
            _replaceImgBtn.Click += ReplaceImgBtn_Click;
            // 
            // lblHeight
            // 
            _lblHeight.AutoSize = true;
            _lblHeight.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _lblHeight.Location = new Point(163, 44);
            _lblHeight.Name = "_lblHeight";
            _lblHeight.Size = new Size(59, 19);
            _lblHeight.TabIndex = 44;
            _lblHeight.Text = "Height:";
            _lblHeight.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWidth
            // 
            _lblWidth.AutoSize = true;
            _lblWidth.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _lblWidth.Location = new Point(168, 18);
            _lblWidth.Name = "_lblWidth";
            _lblWidth.Size = new Size(54, 19);
            _lblWidth.TabIndex = 43;
            _lblWidth.Text = "Width:";
            _lblWidth.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPP
            // 
            _lblBpp.AutoSize = true;
            _lblBpp.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _lblBpp.Location = new Point(44, 44);
            _lblBpp.Name = "_lblBpp";
            _lblBpp.Size = new Size(43, 19);
            _lblBpp.TabIndex = 42;
            _lblBpp.Text = "BPP:";
            _lblBpp.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMipMaps
            // 
            _lblMipMaps.AutoSize = true;
            _lblMipMaps.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _lblMipMaps.Location = new Point(6, 71);
            _lblMipMaps.Name = "_lblMipMaps";
            _lblMipMaps.Size = new Size(81, 19);
            _lblMipMaps.TabIndex = 41;
            _lblMipMaps.Text = "MipMaps:";
            _lblMipMaps.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFormat
            // 
            _lblFormat.AutoSize = true;
            _lblFormat.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _lblFormat.Location = new Point(25, 18);
            _lblFormat.Name = "_lblFormat";
            _lblFormat.Size = new Size(62, 19);
            _lblFormat.TabIndex = 40;
            _lblFormat.Text = "Format:";
            _lblFormat.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // HeightTxt
            // 
            _heightTxt.Location = new Point(228, 45);
            _heightTxt.Name = "_heightTxt";
            _heightTxt.ReadOnly = true;
            _heightTxt.Size = new Size(53, 20);
            _heightTxt.TabIndex = 13;
            // 
            // FormatTxt
            // 
            _formatTxt.Location = new Point(93, 17);
            _formatTxt.Name = "_formatTxt";
            _formatTxt.ReadOnly = true;
            _formatTxt.Size = new Size(64, 20);
            _formatTxt.TabIndex = 11;
            // 
            // WidthTxt
            // 
            _widthTxt.Location = new Point(228, 19);
            _widthTxt.Name = "_widthTxt";
            _widthTxt.ReadOnly = true;
            _widthTxt.Size = new Size(53, 20);
            _widthTxt.TabIndex = 5;
            // 
            // MipMapTxt
            // 
            _mipMapTxt.Location = new Point(93, 72);
            _mipMapTxt.Name = "_mipMapTxt";
            _mipMapTxt.ReadOnly = true;
            _mipMapTxt.Size = new Size(38, 20);
            _mipMapTxt.TabIndex = 3;
            // 
            // BPPTxt
            // 
            _bppTxt.Location = new Point(93, 45);
            _bppTxt.Name = "_bppTxt";
            _bppTxt.ReadOnly = true;
            _bppTxt.Size = new Size(64, 20);
            _bppTxt.TabIndex = 2;
            // 
            // ImgList
            // 
            _imgList.Dock = DockStyle.Fill;
            _imgList.FormattingEnabled = true;
            _imgList.IntegralHeight = false;
            _imgList.Location = new Point(3, 3);
            _imgList.Name = "_imgList";
            _imgList.Size = new Size(88, 465);
            _imgList.TabIndex = 9;
            _imgList.SelectedIndexChanged += ImgList_SelectedIndexChanged;
            // 
            // DataFolder_TreeView
            // 
            _dataFolderTreeView.Dock = DockStyle.Fill;
            _dataFolderTreeView.Location = new Point(0, 0);
            _dataFolderTreeView.Name = "_dataFolderTreeView";
            _dataFolderTreeView.Size = new Size(230, 610);
            _dataFolderTreeView.TabIndex = 10;
            _dataFolderTreeView.DoubleClick += DataFolder_TreeView_DoubleClick;
            // 
            // RebuildBtn
            // 
            _rebuildBtn.Dock = DockStyle.Fill;
            _rebuildBtn.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _rebuildBtn.Location = new Point(3, 3);
            _rebuildBtn.Name = "_rebuildBtn";
            _rebuildBtn.Size = new Size(1021, 100);
            _rebuildBtn.TabIndex = 46;
            _rebuildBtn.Text = "Rebuild Container";
            _rebuildBtn.UseVisualStyleBackColor = true;
            _rebuildBtn.Click += RebuildBtn_Click;
            // 
            // tableLayoutPanel1
            // 
            _tableLayoutPanel1.ColumnCount = 2;
            _tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 236F));
            _tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _tableLayoutPanel1.Controls.Add(_tableLayoutPanel2, 1, 0);
            _tableLayoutPanel1.Controls.Add(_treeViewContainer, 0, 0);
            _tableLayoutPanel1.Dock = DockStyle.Fill;
            _tableLayoutPanel1.Location = new Point(0, 0);
            _tableLayoutPanel1.Name = "_tableLayoutPanel1";
            _tableLayoutPanel1.RowCount = 1;
            _tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            _tableLayoutPanel1.Size = new Size(1569, 641);
            _tableLayoutPanel1.TabIndex = 47;
            _tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // tableLayoutPanel2
            // 
            _tableLayoutPanel2.ColumnCount = 1;
            _tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _tableLayoutPanel2.Controls.Add(_tableLayoutPanel3, 0, 1);
            _tableLayoutPanel2.Controls.Add(_tableLayoutPanel4, 0, 0);
            _tableLayoutPanel2.Dock = DockStyle.Fill;
            _tableLayoutPanel2.Location = new Point(239, 3);
            _tableLayoutPanel2.Name = "_tableLayoutPanel2";
            _tableLayoutPanel2.RowCount = 2;
            _tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            _tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 112F));
            _tableLayoutPanel2.Size = new Size(1327, 635);
            _tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            _tableLayoutPanel3.ColumnCount = 2;
            _tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            _tableLayoutPanel3.Controls.Add(_rebuildBtn, 0, 0);
            _tableLayoutPanel3.Controls.Add(_imageInfoBox, 1, 0);
            _tableLayoutPanel3.Dock = DockStyle.Fill;
            _tableLayoutPanel3.Location = new Point(3, 526);
            _tableLayoutPanel3.Name = "_tableLayoutPanel3";
            _tableLayoutPanel3.RowCount = 1;
            _tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            _tableLayoutPanel3.Size = new Size(1321, 106);
            _tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            _tableLayoutPanel4.ColumnCount = 3;
            _tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            _tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            _tableLayoutPanel4.Controls.Add(_imagePreviewBox, 1, 0);
            _tableLayoutPanel4.Controls.Add(_groupBox1, 2, 0);
            _tableLayoutPanel4.Controls.Add(_tblImageList, 0, 0);
            _tableLayoutPanel4.Dock = DockStyle.Fill;
            _tableLayoutPanel4.Location = new Point(3, 3);
            _tableLayoutPanel4.Name = "_tableLayoutPanel4";
            _tableLayoutPanel4.RowCount = 1;
            _tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            _tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 632F));
            _tableLayoutPanel4.Size = new Size(1321, 517);
            _tableLayoutPanel4.TabIndex = 1;
            _tableLayoutPanel4.Paint += tableLayoutPanel4_Paint;
            // 
            // groupBox1
            // 
            _groupBox1.Controls.Add(_chkEditMetadata);
            _groupBox1.Controls.Add(_txtWidth);
            _groupBox1.Controls.Add(_txtKey);
            _groupBox1.Controls.Add(_txtLength);
            _groupBox1.Controls.Add(_txtStart);
            _groupBox1.Controls.Add(_txtUnk4);
            _groupBox1.Controls.Add(_txtMipMaps);
            _groupBox1.Controls.Add(_txtUnk3);
            _groupBox1.Controls.Add(_txtHeight);
            _groupBox1.Controls.Add(_txtFlags);
            _groupBox1.Controls.Add(_label9);
            _groupBox1.Controls.Add(_label8);
            _groupBox1.Controls.Add(_label7);
            _groupBox1.Controls.Add(_label6);
            _groupBox1.Controls.Add(_label5);
            _groupBox1.Controls.Add(_label4);
            _groupBox1.Controls.Add(_label3);
            _groupBox1.Controls.Add(_label2);
            _groupBox1.Controls.Add(_label1);
            _groupBox1.Location = new Point(1124, 3);
            _groupBox1.Name = "_groupBox1";
            _groupBox1.Size = new Size(194, 283);
            _groupBox1.TabIndex = 10;
            _groupBox1.TabStop = false;
            _groupBox1.Text = "Metadata";
            // 
            // chkEditMetadata
            // 
            _chkEditMetadata.AutoSize = true;
            _chkEditMetadata.Location = new Point(62, 254);
            _chkEditMetadata.Name = "_chkEditMetadata";
            _chkEditMetadata.Size = new Size(86, 17);
            _chkEditMetadata.TabIndex = 10;
            _chkEditMetadata.Text = "Allow Editing";
            _chkEditMetadata.UseVisualStyleBackColor = true;
            _chkEditMetadata.CheckedChanged += chkEditMetadata_CheckedChanged;
            // 
            // txtWidth
            // 
            _txtWidth.Location = new Point(62, 72);
            _txtWidth.Name = "_txtWidth";
            _txtWidth.ReadOnly = true;
            _txtWidth.Size = new Size(125, 20);
            _txtWidth.TabIndex = 9;
            // 
            // txtKey
            // 
            _txtKey.Location = new Point(62, 46);
            _txtKey.Name = "_txtKey";
            _txtKey.ReadOnly = true;
            _txtKey.Size = new Size(125, 20);
            _txtKey.TabIndex = 9;
            _txtKey.TextChanged += txtKey_TextChanged;
            // 
            // txtLength
            // 
            _txtLength.Location = new Point(62, 228);
            _txtLength.Name = "_txtLength";
            _txtLength.ReadOnly = true;
            _txtLength.Size = new Size(125, 20);
            _txtLength.TabIndex = 9;
            // 
            // txtStart
            // 
            _txtStart.Location = new Point(62, 202);
            _txtStart.Name = "_txtStart";
            _txtStart.ReadOnly = true;
            _txtStart.Size = new Size(125, 20);
            _txtStart.TabIndex = 9;
            // 
            // txtUnk4
            // 
            _txtUnk4.Location = new Point(62, 176);
            _txtUnk4.Name = "_txtUnk4";
            _txtUnk4.ReadOnly = true;
            _txtUnk4.Size = new Size(125, 20);
            _txtUnk4.TabIndex = 9;
            // 
            // txtMipMaps
            // 
            _txtMipMaps.Location = new Point(62, 150);
            _txtMipMaps.Name = "_txtMipMaps";
            _txtMipMaps.ReadOnly = true;
            _txtMipMaps.Size = new Size(125, 20);
            _txtMipMaps.TabIndex = 9;
            // 
            // txtUnk3
            // 
            _txtUnk3.Location = new Point(62, 124);
            _txtUnk3.Name = "_txtUnk3";
            _txtUnk3.ReadOnly = true;
            _txtUnk3.Size = new Size(125, 20);
            _txtUnk3.TabIndex = 9;
            // 
            // txtHeight
            // 
            _txtHeight.Location = new Point(62, 98);
            _txtHeight.Name = "_txtHeight";
            _txtHeight.ReadOnly = true;
            _txtHeight.Size = new Size(125, 20);
            _txtHeight.TabIndex = 9;
            // 
            // txtFlags
            // 
            _txtFlags.Location = new Point(62, 20);
            _txtFlags.Name = "_txtFlags";
            _txtFlags.ReadOnly = true;
            _txtFlags.Size = new Size(125, 20);
            _txtFlags.TabIndex = 9;
            // 
            // label9
            // 
            _label9.AutoSize = true;
            _label9.Location = new Point(8, 231);
            _label9.Name = "_label9";
            _label9.Size = new Size(43, 13);
            _label9.TabIndex = 8;
            _label9.Text = "Length:";
            // 
            // label8
            // 
            _label8.AutoSize = true;
            _label8.Location = new Point(8, 205);
            _label8.Name = "_label8";
            _label8.Size = new Size(32, 13);
            _label8.TabIndex = 7;
            _label8.Text = "Start:";
            // 
            // label7
            // 
            _label7.AutoSize = true;
            _label7.Location = new Point(8, 179);
            _label7.Name = "_label7";
            _label7.Size = new Size(36, 13);
            _label7.TabIndex = 6;
            _label7.Text = "Unk4:";
            // 
            // label6
            // 
            _label6.AutoSize = true;
            _label6.Location = new Point(6, 153);
            _label6.Name = "_label6";
            _label6.Size = new Size(53, 13);
            _label6.TabIndex = 5;
            _label6.Text = "MipMaps:";
            // 
            // label5
            // 
            _label5.AutoSize = true;
            _label5.Location = new Point(6, 127);
            _label5.Name = "_label5";
            _label5.Size = new Size(36, 13);
            _label5.TabIndex = 4;
            _label5.Text = "Unk3:";
            // 
            // label4
            // 
            _label4.AutoSize = true;
            _label4.Location = new Point(6, 101);
            _label4.Name = "_label4";
            _label4.Size = new Size(41, 13);
            _label4.TabIndex = 3;
            _label4.Text = "Height:";
            // 
            // label3
            // 
            _label3.AutoSize = true;
            _label3.Location = new Point(6, 75);
            _label3.Name = "_label3";
            _label3.Size = new Size(38, 13);
            _label3.TabIndex = 2;
            _label3.Text = "Width:";
            // 
            // label2
            // 
            _label2.AutoSize = true;
            _label2.Location = new Point(6, 49);
            _label2.Name = "_label2";
            _label2.Size = new Size(28, 13);
            _label2.TabIndex = 1;
            _label2.Text = "Key:";
            // 
            // label1
            // 
            _label1.AutoSize = true;
            _label1.Location = new Point(6, 23);
            _label1.Name = "_label1";
            _label1.Size = new Size(35, 13);
            _label1.TabIndex = 0;
            _label1.Text = "Flags:";
            // 
            // tblImageList
            // 
            _tblImageList.ColumnCount = 1;
            _tblImageList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _tblImageList.Controls.Add(_imgList, 0, 0);
            _tblImageList.Controls.Add(_btnCloneImage, 0, 1);
            _tblImageList.Dock = DockStyle.Fill;
            _tblImageList.Location = new Point(3, 3);
            _tblImageList.Name = "_tblImageList";
            _tblImageList.RowCount = 2;
            _tblImageList.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            _tblImageList.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            _tblImageList.Size = new Size(94, 511);
            _tblImageList.TabIndex = 11;
            _tblImageList.Paint += tableLayoutPanel5_Paint;
            // 
            // btnCloneImage
            // 
            _btnCloneImage.Location = new Point(3, 474);
            _btnCloneImage.Name = "_btnCloneImage";
            _btnCloneImage.Size = new Size(88, 34);
            _btnCloneImage.TabIndex = 11;
            _btnCloneImage.Text = "Clone";
            _btnCloneImage.UseVisualStyleBackColor = true;
            _btnCloneImage.Click += btnCloneImage_Click;
            // 
            // TreeViewContainer
            // 
            _treeViewContainer.BottomToolStripPanelVisible = false;
            // 
            // TreeViewContainer.ContentPanel
            // 
            _treeViewContainer.ContentPanel.Controls.Add(_dataFolderTreeView);
            _treeViewContainer.ContentPanel.Size = new Size(230, 610);
            _treeViewContainer.Dock = DockStyle.Fill;
            _treeViewContainer.LeftToolStripPanelVisible = false;
            _treeViewContainer.Location = new Point(3, 3);
            _treeViewContainer.Name = "_treeViewContainer";
            _treeViewContainer.RightToolStripPanelVisible = false;
            _treeViewContainer.Size = new Size(230, 635);
            _treeViewContainer.TabIndex = 11;
            _treeViewContainer.Text = "toolStripContainer1";
            // 
            // TreeViewContainer.TopToolStripPanel
            // 
            _treeViewContainer.TopToolStripPanel.Controls.Add(_searchToolStrip);
            // 
            // Search_ToolStrip
            // 
            _searchToolStrip.Dock = DockStyle.None;
            _searchToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            _searchToolStrip.Items.AddRange(new ToolStripItem[] {
            _searchTxtBox,
            _searchBtn,
            _prevSearchBtn,
            _nextSearchBtn,
            _searchPosLbl});
            _searchToolStrip.Location = new Point(0, 0);
            _searchToolStrip.Name = "_searchToolStrip";
            _searchToolStrip.Size = new Size(230, 25);
            _searchToolStrip.Stretch = true;
            _searchToolStrip.TabIndex = 0;
            // 
            // Search_TxtBox
            // 
            _searchTxtBox.Name = "_searchTxtBox";
            _searchTxtBox.Size = new Size(70, 25);
            // 
            // Search_Btn
            // 
            _searchBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            _searchBtn.ImageTransparentColor = Color.Magenta;
            _searchBtn.Name = "_searchBtn";
            _searchBtn.Size = new Size(46, 22);
            _searchBtn.Text = "Search";
            _searchBtn.Click += Search_Btn_Click;
            // 
            // PrevSearch_Btn
            // 
            _prevSearchBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            _prevSearchBtn.ImageTransparentColor = Color.Magenta;
            _prevSearchBtn.Name = "_prevSearchBtn";
            _prevSearchBtn.Size = new Size(34, 22);
            _prevSearchBtn.Text = "Prev";
            _prevSearchBtn.Click += PrevSearch_Btn_Click;
            // 
            // NextSearch_Btn
            // 
            _nextSearchBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            _nextSearchBtn.ImageTransparentColor = Color.Magenta;
            _nextSearchBtn.Name = "_nextSearchBtn";
            _nextSearchBtn.Size = new Size(35, 22);
            _nextSearchBtn.Text = "Next";
            _nextSearchBtn.Click += NextSearch_Btn_Click;
            // 
            // SearchPos_Lbl
            // 
            _searchPosLbl.Name = "_searchPosLbl";
            _searchPosLbl.Size = new Size(24, 22);
            _searchPosLbl.Text = "0/0";
            // 
            // TexExplorer
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1569, 641);
            Controls.Add(_tableLayoutPanel1);
            Name = "TexExplorer";
            Text = "Texture Explorer";
            ((ISupportInitialize)(_imagePreviewBox)).EndInit();
            _imageInfoBox.ResumeLayout(false);
            _imageInfoBox.PerformLayout();
            _tableLayoutPanel1.ResumeLayout(false);
            _tableLayoutPanel2.ResumeLayout(false);
            _tableLayoutPanel3.ResumeLayout(false);
            _tableLayoutPanel4.ResumeLayout(false);
            _groupBox1.ResumeLayout(false);
            _groupBox1.PerformLayout();
            _tblImageList.ResumeLayout(false);
            _treeViewContainer.ContentPanel.ResumeLayout(false);
            _treeViewContainer.TopToolStripPanel.ResumeLayout(false);
            _treeViewContainer.TopToolStripPanel.PerformLayout();
            _treeViewContainer.ResumeLayout(false);
            _treeViewContainer.PerformLayout();
            _searchToolStrip.ResumeLayout(false);
            _searchToolStrip.PerformLayout();
            ResumeLayout(false);

		}

		public TexExplorer(string string2)
		{
			InitializeComponent();
			_string0 = string2;
			Closed += TexExplorer_Closed;
			Text = "Texture Explorer - LOOKING FOR TEXTURES (PLEASE WAIT!)";
			var @class = new ZonePakLoader(_string0);
			@class.method_1(UpdateSearchText);
			@class.method_0(AddNode);
			_thread0 = new Thread(@class.method_2);
			_thread0.Start();
		}

		private void TexExplorer_Closed(object sender, EventArgs e)
		{
			DisposeTexFile();
			if (_thread0 != null && _thread0.IsAlive)
			{
				_thread0.Abort();
				_thread0 = null;
			}
		}

		private void UpdateSearchText(int percentComplete, string currentFile)
		{
			if (InvokeRequired)
			{
				ZonePakLoader.Delegate9 method = UpdateSearchText;
				Invoke(method, percentComplete, currentFile);
				return;
			}
			Text = string.Concat("Texture Explorer - LOOKING FOR TEXTURES - ", percentComplete, "% - (", currentFile, ")");
		}

		private void AddNode(TreeNode treeNode)
		{
			if (InvokeRequired)
			{
				ZonePakLoader.Delegate8 method = AddNode;
				Invoke(method, treeNode);
				return;
			}
			_dataFolderTreeView.Nodes.Add(treeNode);
			Text = "Texture Explorer";
			_dataFolderTreeView.Sort();
		}

		private void DisposeTexFile()
		{
			if (_currentTexFile != null)
			{
				_currentTexFile.Dispose();
				_currentTexFile = null;
                CurrentImgFile = null;
			}
			_imgList.Items.Clear();
			_imgList.SelectedIndex = -1;
			
			_imageInfoBox.Enabled = false;
			//this.RebuildBtn.Enabled = false;
			_imagePreviewBox.Image = null;
		}

		private void DataFolder_TreeView_DoubleClick(object sender, EventArgs e)
		{
			if (_dataFolderTreeView.SelectedNode != null)
			{
				if (_dataFolderTreeView.SelectedNode.Tag is int && _dataFolderTreeView.SelectedNode.ToolTipText != "")
				{
					DisposeTexFile();
					var toolTipText = _dataFolderTreeView.SelectedNode.ToolTipText;
					ZzPakNode2 pakNode;
					if (File.Exists(toolTipText.Replace(".pak.xen", ".pab.xen")))
					{
						pakNode = new ZzPabNode(toolTipText, toolTipText.Replace(".pak.xen", ".pab.xen"), false);
					}
					else
					{
						pakNode = new ZzPakNode2(toolTipText, false);
					}
					_currentTexFile = new TexFile(pakNode.method_13((int)_dataFolderTreeView.SelectedNode.Tag));

					for (var i = 1; i <= _currentTexFile.TextureCount(); i++)
					{
						_imgList.Items.Add("Image " + i);
					}
					pakNode.Dispose();
					return;
				}
				if (_dataFolderTreeView.SelectedNode.ToolTipText != "")
				{
					DisposeTexFile();
					_currentTexFile = new TexFile(_dataFolderTreeView.SelectedNode.ToolTipText);
					for (var j = 1; j <= _currentTexFile.TextureCount(); j++)
					{
						_imgList.Items.Add("Image " + j);
					}
				}
			}
		}

		private void ImgList_SelectedIndexChanged(object sender, EventArgs e)
		{
            var index = _imgList.SelectedIndex;


            if (index >= 0)
			{
				var texture = _currentTexFile[index];
				_currentTexturePixelFormat = texture.PixelFormat;
				_bppTxt.Text = string.Concat(texture.Bpp);

                switch(texture.PixelFormat)
                {
                    case ImgPixelFormat.Dxt1:
                        _formatTxt.Text = "DXT1";
                        break;

                    case ImgPixelFormat.Dxt3:
                        _formatTxt.Text = "DXT3";
                        break;

                    case ImgPixelFormat.Dxt5:
                        _formatTxt.Text = "DXT5";
                        break;

                    default:
                        _formatTxt.Text = "A8R8G8B8";
                        break;
                }

				_mipMapTxt.Text = string.Concat(texture.MipMapCount);
				_widthTxt.Text = string.Concat(texture.Size.Width);
				_heightTxt.Text = string.Concat(texture.Size.Height);

				var image = texture.GetImage();
				_size0 = image.Size;
				if (image.Width > _imagePreviewBox.Width || image.Height > _imagePreviewBox.Height)
				{
					image = KeyGenerator.ScaleImageFixedRatio(image, _imagePreviewBox.Size);
				}
				_imagePreviewBox.Image = image;
				_imageInfoBox.Enabled = true;

                var metadata = _currentTexFile.TextureList[index];
                CurrentImgFile = metadata;
            }
            else
            {
                _imageInfoBox.Enabled = false;
            }
			
		}





		private void ReplaceImgBtn_Click(object sender, EventArgs e)
		{
			var text = KeyGenerator.OpenOrSaveFile("Select the image file to replace the texture.", "All Supported Formats|*.dds;*.bmp;*.jpg;*.gif;*.png|DDS Texture|*.dds|Bitmap|*.bmp|JPEG|*.jpg|Graphics Interchange Format|*.gif|Portable Network Graphics|*.png", true);
			if (text == "")
			{
				return;
			}
			Image image;
			if (text.EndsWith(".dds", StringComparison.OrdinalIgnoreCase))
			{
				image = new DdsTexture(text).GetImage();
			}
			else
			{
				image = Image.FromFile(text);
			}
			if (!image.Size.Equals(_size0) && DialogResult.Yes == MessageBox.Show("The image dimensions don't match. Do you wish scale to the original dimension? (Ratio may change!)", "Replace Texture", MessageBoxButtons.YesNo))
			{
				image = KeyGenerator.ScaleImage(image, _size0);
			}
			_currentTexFile.ReplaceTexture(_imgList.SelectedIndex, image, _currentTexturePixelFormat);
			_rebuildBtn.Enabled = true;
		}

		public ImageFormat GetImageFormat(string fileName)
		{
			var ext = KeyGenerator.GetExtension(fileName, 1).ToLower();
			if (ext != null)
			{
				if (ext == "jpg")
				{
					return ImageFormat.Jpeg;
				}
				if (ext == "gif")
				{
					return ImageFormat.Gif;
				}
				if (ext == "png")
				{
					return ImageFormat.Png;
				}
			}
			return ImageFormat.Bmp;
		}

		private void ExtractImgBtn_Click(object sender, EventArgs e)
		{
			var fileName = KeyGenerator.OpenOrSaveFile("Select location to export the texture.", "All Supported Formats|*.dds;*.bmp;*.jpg;*.gif;*.png|DDS Texture|*.dds|Bitmap|*.bmp|JPEG|*.jpg|Graphics Interchange Format|*.gif|Portable Network Graphics|*.png", false);
			if (fileName == "")
			{
				return;
			}
			if (fileName.EndsWith(".dds", StringComparison.OrdinalIgnoreCase))
			{
				_currentTexFile.WriteBytes(_imgList.SelectedIndex, fileName);
				return;
			}
			_currentTexFile[_imgList.SelectedIndex].GetImage().Save(fileName, GetImageFormat(fileName));
		}

		private void RebuildBtn_Click(object sender, EventArgs e)
		{
			if (DialogResult.Yes != MessageBox.Show("Are you sure you wish to rebuild the container? (Overwriting File!)", "Replace Textures", MessageBoxButtons.YesNo))
			{
				return;
			}
			if (_currentTexFile.CanWrite())
			{
				_currentTexFile.WriteEverythingToFile();
			}
			else
			{
				var toolTipText = _dataFolderTreeView.SelectedNode.ToolTipText;
				var pakNode = File.Exists(toolTipText.Replace(".pak.xen", ".pab.xen")) ? new ZzPabNode(toolTipText, toolTipText.Replace(".pak.xen", ".pab.xen"), false) : new ZzPakNode2(toolTipText, false);
				pakNode.method_11((int)_dataFolderTreeView.SelectedNode.Tag).imethod_17(_currentTexFile.ToStream().ReadEverything());
				pakNode.vmethod_1();
				pakNode.Dispose();
			}
			_imgList.Items.Clear();
			DisposeTexFile();
		}

		private void NextSearch_Btn_Click(object sender, EventArgs e)
		{
			if (_dataFolderTreeView.SelectedNode == null)
			{
				return;
			}
			if (_searchTxtBox.Text.Equals(""))
			{
				foreach (var current in _nodeList)
				{
					current.BackColor = Color.Empty;
				}
				_nodeList.Clear();
				_string1 = "";
				_searchPosLbl.Text = "0/0";
				return;
			}
			if (!_searchTxtBox.Text.Equals(_string1))
			{
				foreach (var current2 in _nodeList)
				{
					current2.BackColor = Color.Transparent;
				}
				_nodeList.Clear();
				_string1 = _searchTxtBox.Text;
			}
			if (_nodeList.Count == 0)
			{
				if (!method_4())
				{
					MessageBox.Show("Value not found!");
					_searchPosLbl.Text = "0/0";
					return;
				}
				_count = -1;
			}
			_count++;
			var treeView = _dataFolderTreeView;
			var node = _nodeList;
			int arg16B1;
			if (_nodeList.Count <= _count)
			{
				_count = 0;
				arg16B1 = 0;
			}
			else
			{
				arg16B1 = _count;
			}
			treeView.SelectedNode = node[arg16B1];
			_searchPosLbl.Text = _count + 1 + "/" + _nodeList.Count;
			_dataFolderTreeView.Focus();
		}

		private void PrevSearch_Btn_Click(object sender, EventArgs e)
		{
			if (_dataFolderTreeView.SelectedNode == null)
			{
				return;
			}
			if (_searchTxtBox.Text.Equals(""))
			{
				foreach (var current in _nodeList)
				{
					current.BackColor = Color.Empty;
				}
				_nodeList.Clear();
				_string1 = "";
				_searchPosLbl.Text = "0/0";
				return;
			}
			if (!_searchTxtBox.Text.Equals(_string1))
			{
				foreach (var current2 in _nodeList)
				{
					current2.BackColor = Color.Empty;
				}
				_nodeList.Clear();
				_string1 = _searchTxtBox.Text;
			}
			if (_nodeList.Count == 0)
			{
				if (!method_4())
				{
					MessageBox.Show("Value not found!");
					_searchPosLbl.Text = "0/0";
					return;
				}
				_count = _nodeList.Count;
			}
			_count--;
			_dataFolderTreeView.SelectedNode = _nodeList[(0 <= _count) ? _count : (_count = _nodeList.Count - 1)];
			_searchPosLbl.Text = _count + 1 + "/" + _nodeList.Count;
			_dataFolderTreeView.Focus();
		}

		private void Search_Btn_Click(object sender, EventArgs e)
		{
			if (_dataFolderTreeView.SelectedNode == null)
			{
				return;
			}
			foreach (var current in _nodeList)
			{
				current.BackColor = Color.Empty;
			}
			_nodeList.Clear();
			_string1 = _searchTxtBox.Text;
			if (_string1.Equals(""))
			{
				_searchPosLbl.Text = "0/0";
				return;
			}
			if (!method_4())
			{
				MessageBox.Show("Value not found!");
				_searchPosLbl.Text = "0/0";
				return;
			}
			_count = 0;
			_dataFolderTreeView.SelectedNode = _nodeList[_count];
			_searchPosLbl.Text = _count + 1 + "/" + _nodeList.Count;
			_dataFolderTreeView.Focus();
		}

		private bool method_4()
		{
			AddNodeToContainerIfItHasThisString(_dataFolderTreeView.SelectedNode, _string1, _nodeList);
			foreach (var current in _nodeList)
			{
				current.BackColor = Color.YellowGreen;
			}
			return _nodeList.Count != 0;
		}

		private static void AddNodeToContainerIfItHasThisString(TreeNode node, string str, ICollection<TreeNode> nodeCollection)
		{
			if (node.Text.ToUpper().Contains(str.ToUpper()))
			{
				nodeCollection.Add(node);
			}
			for (var i = 0; i < node.Nodes.Count; i++)
			{
				AddNodeToContainerIfItHasThisString(node.Nodes[i], str, nodeCollection);
			}
		}

        private void ImagePreviewBox_Click(object sender, EventArgs e)
        {

        }

        private void chkEditMetadata_CheckedChanged(object sender, EventArgs e)
        {
            if (_chkEditMetadata.Checked)
            { 
                if (MessageBox.Show("Are you sure you want to edit the image metadata? You could corrupt your pak file!", "Warning!", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    _chkEditMetadata.Checked = false;
                }
            }

            MetadataReadonly = !_chkEditMetadata.Checked;

        }


        // Editing image metadata

        private TextureMetadata CurrentImgFile
        {
            set
            {
                _currentImgFile = value;
                if (value != null)
                {
                    MetadataReadonly = !_chkEditMetadata.Checked;
                    _txtFlags.Text = value.UnkFlags.ToString("X4");
                    _txtKey.Text = value.Key.ToString("X8");
                    _txtWidth.Text = value.Width.ToString();
                    _txtHeight.Text = value.Height.ToString();
                    _txtMipMaps.Text = value.MipMapCount.ToString();
                    _txtStart.Text = value.StartIndex.ToString("X8");
                    _txtLength.Text = value.Length.ToString();
                    _txtUnk3.Text = value.UnkShort3.ToString("X4");
                    _txtUnk4.Text = value.UnkShort4.ToString("X4");
                }
                else
                {
                    MetadataReadonly = true;
                    _txtFlags.Text = "";
                    _txtKey.Text = "";
                    _txtWidth.Text = "";
                    _txtHeight.Text = "";
                    _txtMipMaps.Text = "";
                    _txtStart.Text = "";
                    _txtLength.Text = "";
                    _txtUnk3.Text = "";
                    _txtUnk4.Text = "";
                }

            }

            get
            {
                return _currentImgFile;
            }
        }

        private bool MetadataReadonly
        {
            set
            {
                _txtFlags.ReadOnly = value;
                _txtKey.ReadOnly = value;
                _txtWidth.ReadOnly = value;
                _txtHeight.ReadOnly = value;
                _txtMipMaps.ReadOnly = value;
                _txtStart.ReadOnly = value;
                _txtLength.ReadOnly = value;
                _txtUnk3.ReadOnly = value;
                _txtUnk4.ReadOnly = value;
            }
        }

        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            int newKey;
            if (Int32.TryParse(_txtKey.Text, NumberStyles.HexNumber | NumberStyles.AllowHexSpecifier, null, out newKey))
            {
                _currentImgFile.Key = newKey;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCloneImage_Click(object sender, EventArgs e)
        {
            if (_imgList.Items.Count <= 0)
                return;

            if (_imgList.SelectedIndex < 0 || _imgList.SelectedIndex >= _currentTexFile.TextureCount())
                return;

            var cloneIndex = _currentTexFile.CloneTextureElement(_imgList.SelectedIndex);
            _imgList.Items.Add("Image " + (cloneIndex + 1) );
        }
    }
}
