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

		private PictureBox ImagePreviewBox;

		private GroupBox ImageInfoBox;

		private TextBox WidthTxt;

		private TextBox MipMapTxt;

		private TextBox BPPTxt;

		private ListBox ImgList;

		private TreeView DataFolder_TreeView;

		private TextBox FormatTxt;

		private TextBox HeightTxt;

		private Label lblHeight;

		private Label lblWidth;

		private Label lblBPP;

		private Label lblMipMaps;

		private Label lblFormat;

		private Button ReplaceImgBtn;

		private Button RebuildBtn;

		private Button ExtractImgBtn;

		private TableLayoutPanel tableLayoutPanel1;

		private TableLayoutPanel tableLayoutPanel2;

		private TableLayoutPanel tableLayoutPanel3;

		private TableLayoutPanel tableLayoutPanel4;

		private ToolStripContainer TreeViewContainer;

		private ToolStrip Search_ToolStrip;

		private ToolStripTextBox Search_TxtBox;

		private ToolStripButton PrevSearch_Btn;

		private ToolStripButton NextSearch_Btn;

		private ToolStripLabel SearchPos_Lbl;

		private ToolStripButton Search_Btn;

		private readonly string string_0;

		private TexFile _currentTexFile;

        private TextureMetadata _currentImgFile;

		private Thread thread_0;

		private Size size_0;

		private IMGPixelFormat _currentTexturePixelFormat;

		private string string_1;

		private readonly List<TreeNode> nodeList = new List<TreeNode>();
        private GroupBox groupBox1;
        private Label label1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private CheckBox chkEditMetadata;
        private TextBox txtWidth;
        private TextBox txtKey;
        private TextBox txtLength;
        private TextBox txtStart;
        private TextBox txtUnk4;
        private TextBox txtMipMaps;
        private TextBox txtUnk3;
        private TextBox txtHeight;
        private TextBox txtFlags;
        private Label label9;
        private Label label8;
        private Label label7;
        private Button btnCloneImage;
        private TableLayoutPanel tblImageList;
        private int count;

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
            ImagePreviewBox = new PictureBox();
            ImageInfoBox = new GroupBox();
            ExtractImgBtn = new Button();
            ReplaceImgBtn = new Button();
            lblHeight = new Label();
            lblWidth = new Label();
            lblBPP = new Label();
            lblMipMaps = new Label();
            lblFormat = new Label();
            HeightTxt = new TextBox();
            FormatTxt = new TextBox();
            WidthTxt = new TextBox();
            MipMapTxt = new TextBox();
            BPPTxt = new TextBox();
            ImgList = new ListBox();
            DataFolder_TreeView = new TreeView();
            RebuildBtn = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            chkEditMetadata = new CheckBox();
            txtWidth = new TextBox();
            txtKey = new TextBox();
            txtLength = new TextBox();
            txtStart = new TextBox();
            txtUnk4 = new TextBox();
            txtMipMaps = new TextBox();
            txtUnk3 = new TextBox();
            txtHeight = new TextBox();
            txtFlags = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tblImageList = new TableLayoutPanel();
            btnCloneImage = new Button();
            TreeViewContainer = new ToolStripContainer();
            Search_ToolStrip = new ToolStrip();
            Search_TxtBox = new ToolStripTextBox();
            Search_Btn = new ToolStripButton();
            PrevSearch_Btn = new ToolStripButton();
            NextSearch_Btn = new ToolStripButton();
            SearchPos_Lbl = new ToolStripLabel();
            ((ISupportInitialize)(ImagePreviewBox)).BeginInit();
            ImageInfoBox.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            groupBox1.SuspendLayout();
            tblImageList.SuspendLayout();
            TreeViewContainer.ContentPanel.SuspendLayout();
            TreeViewContainer.TopToolStripPanel.SuspendLayout();
            TreeViewContainer.SuspendLayout();
            Search_ToolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // ImagePreviewBox
            // 
            ImagePreviewBox.BackColor = Color.Transparent;
            ImagePreviewBox.BorderStyle = BorderStyle.FixedSingle;
            ImagePreviewBox.Dock = DockStyle.Fill;
            ImagePreviewBox.Location = new Point(103, 3);
            ImagePreviewBox.Name = "ImagePreviewBox";
            ImagePreviewBox.Size = new Size(1015, 511);
            ImagePreviewBox.SizeMode = PictureBoxSizeMode.CenterImage;
            ImagePreviewBox.TabIndex = 7;
            ImagePreviewBox.TabStop = false;
            ImagePreviewBox.Click += ImagePreviewBox_Click;
            // 
            // ImageInfoBox
            // 
            ImageInfoBox.Controls.Add(ExtractImgBtn);
            ImageInfoBox.Controls.Add(ReplaceImgBtn);
            ImageInfoBox.Controls.Add(lblHeight);
            ImageInfoBox.Controls.Add(lblWidth);
            ImageInfoBox.Controls.Add(lblBPP);
            ImageInfoBox.Controls.Add(lblMipMaps);
            ImageInfoBox.Controls.Add(lblFormat);
            ImageInfoBox.Controls.Add(HeightTxt);
            ImageInfoBox.Controls.Add(FormatTxt);
            ImageInfoBox.Controls.Add(WidthTxt);
            ImageInfoBox.Controls.Add(MipMapTxt);
            ImageInfoBox.Controls.Add(BPPTxt);
            ImageInfoBox.Enabled = false;
            ImageInfoBox.Location = new Point(1030, 3);
            ImageInfoBox.Name = "ImageInfoBox";
            ImageInfoBox.Size = new Size(288, 100);
            ImageInfoBox.TabIndex = 8;
            ImageInfoBox.TabStop = false;
            ImageInfoBox.Text = "Image Information";
            // 
            // ExtractImgBtn
            // 
            ExtractImgBtn.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ExtractImgBtn.Location = new Point(215, 67);
            ExtractImgBtn.Name = "ExtractImgBtn";
            ExtractImgBtn.Size = new Size(67, 27);
            ExtractImgBtn.TabIndex = 46;
            ExtractImgBtn.Text = "Extract";
            ExtractImgBtn.UseVisualStyleBackColor = true;
            ExtractImgBtn.Click += ExtractImgBtn_Click;
            // 
            // ReplaceImgBtn
            // 
            ReplaceImgBtn.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ReplaceImgBtn.Location = new Point(137, 67);
            ReplaceImgBtn.Name = "ReplaceImgBtn";
            ReplaceImgBtn.Size = new Size(72, 27);
            ReplaceImgBtn.TabIndex = 45;
            ReplaceImgBtn.Text = "Replace";
            ReplaceImgBtn.UseVisualStyleBackColor = true;
            ReplaceImgBtn.Click += ReplaceImgBtn_Click;
            // 
            // lblHeight
            // 
            lblHeight.AutoSize = true;
            lblHeight.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeight.Location = new Point(163, 44);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new Size(59, 19);
            lblHeight.TabIndex = 44;
            lblHeight.Text = "Height:";
            lblHeight.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWidth
            // 
            lblWidth.AutoSize = true;
            lblWidth.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWidth.Location = new Point(168, 18);
            lblWidth.Name = "lblWidth";
            lblWidth.Size = new Size(54, 19);
            lblWidth.TabIndex = 43;
            lblWidth.Text = "Width:";
            lblWidth.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPP
            // 
            lblBPP.AutoSize = true;
            lblBPP.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBPP.Location = new Point(44, 44);
            lblBPP.Name = "lblBPP";
            lblBPP.Size = new Size(43, 19);
            lblBPP.TabIndex = 42;
            lblBPP.Text = "BPP:";
            lblBPP.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMipMaps
            // 
            lblMipMaps.AutoSize = true;
            lblMipMaps.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMipMaps.Location = new Point(6, 71);
            lblMipMaps.Name = "lblMipMaps";
            lblMipMaps.Size = new Size(81, 19);
            lblMipMaps.TabIndex = 41;
            lblMipMaps.Text = "MipMaps:";
            lblMipMaps.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFormat
            // 
            lblFormat.AutoSize = true;
            lblFormat.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFormat.Location = new Point(25, 18);
            lblFormat.Name = "lblFormat";
            lblFormat.Size = new Size(62, 19);
            lblFormat.TabIndex = 40;
            lblFormat.Text = "Format:";
            lblFormat.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // HeightTxt
            // 
            HeightTxt.Location = new Point(228, 45);
            HeightTxt.Name = "HeightTxt";
            HeightTxt.ReadOnly = true;
            HeightTxt.Size = new Size(53, 20);
            HeightTxt.TabIndex = 13;
            // 
            // FormatTxt
            // 
            FormatTxt.Location = new Point(93, 17);
            FormatTxt.Name = "FormatTxt";
            FormatTxt.ReadOnly = true;
            FormatTxt.Size = new Size(64, 20);
            FormatTxt.TabIndex = 11;
            // 
            // WidthTxt
            // 
            WidthTxt.Location = new Point(228, 19);
            WidthTxt.Name = "WidthTxt";
            WidthTxt.ReadOnly = true;
            WidthTxt.Size = new Size(53, 20);
            WidthTxt.TabIndex = 5;
            // 
            // MipMapTxt
            // 
            MipMapTxt.Location = new Point(93, 72);
            MipMapTxt.Name = "MipMapTxt";
            MipMapTxt.ReadOnly = true;
            MipMapTxt.Size = new Size(38, 20);
            MipMapTxt.TabIndex = 3;
            // 
            // BPPTxt
            // 
            BPPTxt.Location = new Point(93, 45);
            BPPTxt.Name = "BPPTxt";
            BPPTxt.ReadOnly = true;
            BPPTxt.Size = new Size(64, 20);
            BPPTxt.TabIndex = 2;
            // 
            // ImgList
            // 
            ImgList.Dock = DockStyle.Fill;
            ImgList.FormattingEnabled = true;
            ImgList.IntegralHeight = false;
            ImgList.Location = new Point(3, 3);
            ImgList.Name = "ImgList";
            ImgList.Size = new Size(88, 465);
            ImgList.TabIndex = 9;
            ImgList.SelectedIndexChanged += ImgList_SelectedIndexChanged;
            // 
            // DataFolder_TreeView
            // 
            DataFolder_TreeView.Dock = DockStyle.Fill;
            DataFolder_TreeView.Location = new Point(0, 0);
            DataFolder_TreeView.Name = "DataFolder_TreeView";
            DataFolder_TreeView.Size = new Size(230, 610);
            DataFolder_TreeView.TabIndex = 10;
            DataFolder_TreeView.DoubleClick += DataFolder_TreeView_DoubleClick;
            // 
            // RebuildBtn
            // 
            RebuildBtn.Dock = DockStyle.Fill;
            RebuildBtn.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RebuildBtn.Location = new Point(3, 3);
            RebuildBtn.Name = "RebuildBtn";
            RebuildBtn.Size = new Size(1021, 100);
            RebuildBtn.TabIndex = 46;
            RebuildBtn.Text = "Rebuild Container";
            RebuildBtn.UseVisualStyleBackColor = true;
            RebuildBtn.Click += RebuildBtn_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 236F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Controls.Add(TreeViewContainer, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1569, 641);
            tableLayoutPanel1.TabIndex = 47;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(239, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 112F));
            tableLayoutPanel2.Size = new Size(1327, 635);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.Controls.Add(RebuildBtn, 0, 0);
            tableLayoutPanel3.Controls.Add(ImageInfoBox, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 526);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(1321, 106);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel4.Controls.Add(ImagePreviewBox, 1, 0);
            tableLayoutPanel4.Controls.Add(groupBox1, 2, 0);
            tableLayoutPanel4.Controls.Add(tblImageList, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 632F));
            tableLayoutPanel4.Size = new Size(1321, 517);
            tableLayoutPanel4.TabIndex = 1;
            tableLayoutPanel4.Paint += tableLayoutPanel4_Paint;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chkEditMetadata);
            groupBox1.Controls.Add(txtWidth);
            groupBox1.Controls.Add(txtKey);
            groupBox1.Controls.Add(txtLength);
            groupBox1.Controls.Add(txtStart);
            groupBox1.Controls.Add(txtUnk4);
            groupBox1.Controls.Add(txtMipMaps);
            groupBox1.Controls.Add(txtUnk3);
            groupBox1.Controls.Add(txtHeight);
            groupBox1.Controls.Add(txtFlags);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(1124, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(194, 283);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Metadata";
            // 
            // chkEditMetadata
            // 
            chkEditMetadata.AutoSize = true;
            chkEditMetadata.Location = new Point(62, 254);
            chkEditMetadata.Name = "chkEditMetadata";
            chkEditMetadata.Size = new Size(86, 17);
            chkEditMetadata.TabIndex = 10;
            chkEditMetadata.Text = "Allow Editing";
            chkEditMetadata.UseVisualStyleBackColor = true;
            chkEditMetadata.CheckedChanged += chkEditMetadata_CheckedChanged;
            // 
            // txtWidth
            // 
            txtWidth.Location = new Point(62, 72);
            txtWidth.Name = "txtWidth";
            txtWidth.ReadOnly = true;
            txtWidth.Size = new Size(125, 20);
            txtWidth.TabIndex = 9;
            // 
            // txtKey
            // 
            txtKey.Location = new Point(62, 46);
            txtKey.Name = "txtKey";
            txtKey.ReadOnly = true;
            txtKey.Size = new Size(125, 20);
            txtKey.TabIndex = 9;
            txtKey.TextChanged += txtKey_TextChanged;
            // 
            // txtLength
            // 
            txtLength.Location = new Point(62, 228);
            txtLength.Name = "txtLength";
            txtLength.ReadOnly = true;
            txtLength.Size = new Size(125, 20);
            txtLength.TabIndex = 9;
            // 
            // txtStart
            // 
            txtStart.Location = new Point(62, 202);
            txtStart.Name = "txtStart";
            txtStart.ReadOnly = true;
            txtStart.Size = new Size(125, 20);
            txtStart.TabIndex = 9;
            // 
            // txtUnk4
            // 
            txtUnk4.Location = new Point(62, 176);
            txtUnk4.Name = "txtUnk4";
            txtUnk4.ReadOnly = true;
            txtUnk4.Size = new Size(125, 20);
            txtUnk4.TabIndex = 9;
            // 
            // txtMipMaps
            // 
            txtMipMaps.Location = new Point(62, 150);
            txtMipMaps.Name = "txtMipMaps";
            txtMipMaps.ReadOnly = true;
            txtMipMaps.Size = new Size(125, 20);
            txtMipMaps.TabIndex = 9;
            // 
            // txtUnk3
            // 
            txtUnk3.Location = new Point(62, 124);
            txtUnk3.Name = "txtUnk3";
            txtUnk3.ReadOnly = true;
            txtUnk3.Size = new Size(125, 20);
            txtUnk3.TabIndex = 9;
            // 
            // txtHeight
            // 
            txtHeight.Location = new Point(62, 98);
            txtHeight.Name = "txtHeight";
            txtHeight.ReadOnly = true;
            txtHeight.Size = new Size(125, 20);
            txtHeight.TabIndex = 9;
            // 
            // txtFlags
            // 
            txtFlags.Location = new Point(62, 20);
            txtFlags.Name = "txtFlags";
            txtFlags.ReadOnly = true;
            txtFlags.Size = new Size(125, 20);
            txtFlags.TabIndex = 9;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(8, 231);
            label9.Name = "label9";
            label9.Size = new Size(43, 13);
            label9.TabIndex = 8;
            label9.Text = "Length:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(8, 205);
            label8.Name = "label8";
            label8.Size = new Size(32, 13);
            label8.TabIndex = 7;
            label8.Text = "Start:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(8, 179);
            label7.Name = "label7";
            label7.Size = new Size(36, 13);
            label7.TabIndex = 6;
            label7.Text = "Unk4:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 153);
            label6.Name = "label6";
            label6.Size = new Size(53, 13);
            label6.TabIndex = 5;
            label6.Text = "MipMaps:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 127);
            label5.Name = "label5";
            label5.Size = new Size(36, 13);
            label5.TabIndex = 4;
            label5.Text = "Unk3:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 101);
            label4.Name = "label4";
            label4.Size = new Size(41, 13);
            label4.TabIndex = 3;
            label4.Text = "Height:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 75);
            label3.Name = "label3";
            label3.Size = new Size(38, 13);
            label3.TabIndex = 2;
            label3.Text = "Width:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 49);
            label2.Name = "label2";
            label2.Size = new Size(28, 13);
            label2.TabIndex = 1;
            label2.Text = "Key:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 23);
            label1.Name = "label1";
            label1.Size = new Size(35, 13);
            label1.TabIndex = 0;
            label1.Text = "Flags:";
            // 
            // tblImageList
            // 
            tblImageList.ColumnCount = 1;
            tblImageList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblImageList.Controls.Add(ImgList, 0, 0);
            tblImageList.Controls.Add(btnCloneImage, 0, 1);
            tblImageList.Dock = DockStyle.Fill;
            tblImageList.Location = new Point(3, 3);
            tblImageList.Name = "tblImageList";
            tblImageList.RowCount = 2;
            tblImageList.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblImageList.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblImageList.Size = new Size(94, 511);
            tblImageList.TabIndex = 11;
            tblImageList.Paint += tableLayoutPanel5_Paint;
            // 
            // btnCloneImage
            // 
            btnCloneImage.Location = new Point(3, 474);
            btnCloneImage.Name = "btnCloneImage";
            btnCloneImage.Size = new Size(88, 34);
            btnCloneImage.TabIndex = 11;
            btnCloneImage.Text = "Clone";
            btnCloneImage.UseVisualStyleBackColor = true;
            btnCloneImage.Click += btnCloneImage_Click;
            // 
            // TreeViewContainer
            // 
            TreeViewContainer.BottomToolStripPanelVisible = false;
            // 
            // TreeViewContainer.ContentPanel
            // 
            TreeViewContainer.ContentPanel.Controls.Add(DataFolder_TreeView);
            TreeViewContainer.ContentPanel.Size = new Size(230, 610);
            TreeViewContainer.Dock = DockStyle.Fill;
            TreeViewContainer.LeftToolStripPanelVisible = false;
            TreeViewContainer.Location = new Point(3, 3);
            TreeViewContainer.Name = "TreeViewContainer";
            TreeViewContainer.RightToolStripPanelVisible = false;
            TreeViewContainer.Size = new Size(230, 635);
            TreeViewContainer.TabIndex = 11;
            TreeViewContainer.Text = "toolStripContainer1";
            // 
            // TreeViewContainer.TopToolStripPanel
            // 
            TreeViewContainer.TopToolStripPanel.Controls.Add(Search_ToolStrip);
            // 
            // Search_ToolStrip
            // 
            Search_ToolStrip.Dock = DockStyle.None;
            Search_ToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            Search_ToolStrip.Items.AddRange(new ToolStripItem[] {
            Search_TxtBox,
            Search_Btn,
            PrevSearch_Btn,
            NextSearch_Btn,
            SearchPos_Lbl});
            Search_ToolStrip.Location = new Point(0, 0);
            Search_ToolStrip.Name = "Search_ToolStrip";
            Search_ToolStrip.Size = new Size(230, 25);
            Search_ToolStrip.Stretch = true;
            Search_ToolStrip.TabIndex = 0;
            // 
            // Search_TxtBox
            // 
            Search_TxtBox.Name = "Search_TxtBox";
            Search_TxtBox.Size = new Size(70, 25);
            // 
            // Search_Btn
            // 
            Search_Btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            Search_Btn.ImageTransparentColor = Color.Magenta;
            Search_Btn.Name = "Search_Btn";
            Search_Btn.Size = new Size(46, 22);
            Search_Btn.Text = "Search";
            Search_Btn.Click += Search_Btn_Click;
            // 
            // PrevSearch_Btn
            // 
            PrevSearch_Btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            PrevSearch_Btn.ImageTransparentColor = Color.Magenta;
            PrevSearch_Btn.Name = "PrevSearch_Btn";
            PrevSearch_Btn.Size = new Size(34, 22);
            PrevSearch_Btn.Text = "Prev";
            PrevSearch_Btn.Click += PrevSearch_Btn_Click;
            // 
            // NextSearch_Btn
            // 
            NextSearch_Btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            NextSearch_Btn.ImageTransparentColor = Color.Magenta;
            NextSearch_Btn.Name = "NextSearch_Btn";
            NextSearch_Btn.Size = new Size(35, 22);
            NextSearch_Btn.Text = "Next";
            NextSearch_Btn.Click += NextSearch_Btn_Click;
            // 
            // SearchPos_Lbl
            // 
            SearchPos_Lbl.Name = "SearchPos_Lbl";
            SearchPos_Lbl.Size = new Size(24, 22);
            SearchPos_Lbl.Text = "0/0";
            // 
            // TexExplorer
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1569, 641);
            Controls.Add(tableLayoutPanel1);
            Name = "TexExplorer";
            Text = "Texture Explorer";
            ((ISupportInitialize)(ImagePreviewBox)).EndInit();
            ImageInfoBox.ResumeLayout(false);
            ImageInfoBox.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tblImageList.ResumeLayout(false);
            TreeViewContainer.ContentPanel.ResumeLayout(false);
            TreeViewContainer.TopToolStripPanel.ResumeLayout(false);
            TreeViewContainer.TopToolStripPanel.PerformLayout();
            TreeViewContainer.ResumeLayout(false);
            TreeViewContainer.PerformLayout();
            Search_ToolStrip.ResumeLayout(false);
            Search_ToolStrip.PerformLayout();
            ResumeLayout(false);

		}

		public TexExplorer(string string_2)
		{
			InitializeComponent();
			string_0 = string_2;
			Closed += TexExplorer_Closed;
			Text = "Texture Explorer - LOOKING FOR TEXTURES (PLEASE WAIT!)";
			var @class = new ZonePakLoader(string_0);
			@class.method_1(UpdateSearchText);
			@class.method_0(AddNode);
			thread_0 = new Thread(@class.method_2);
			thread_0.Start();
		}

		private void TexExplorer_Closed(object sender, EventArgs e)
		{
			DisposeTexFile();
			if (thread_0 != null && thread_0.IsAlive)
			{
				thread_0.Abort();
				thread_0 = null;
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
			DataFolder_TreeView.Nodes.Add(treeNode);
			Text = "Texture Explorer";
			DataFolder_TreeView.Sort();
		}

		private void DisposeTexFile()
		{
			if (_currentTexFile != null)
			{
				_currentTexFile.Dispose();
				_currentTexFile = null;
                CurrentImgFile = null;
			}
			ImgList.Items.Clear();
			ImgList.SelectedIndex = -1;
			
			ImageInfoBox.Enabled = false;
			//this.RebuildBtn.Enabled = false;
			ImagePreviewBox.Image = null;
		}

		private void DataFolder_TreeView_DoubleClick(object sender, EventArgs e)
		{
			if (DataFolder_TreeView.SelectedNode != null)
			{
				if (DataFolder_TreeView.SelectedNode.Tag is int && DataFolder_TreeView.SelectedNode.ToolTipText != "")
				{
					DisposeTexFile();
					var toolTipText = DataFolder_TreeView.SelectedNode.ToolTipText;
					zzPakNode2 pakNode;
					if (File.Exists(toolTipText.Replace(".pak.xen", ".pab.xen")))
					{
						pakNode = new zzPabNode(toolTipText, toolTipText.Replace(".pak.xen", ".pab.xen"), false);
					}
					else
					{
						pakNode = new zzPakNode2(toolTipText, false);
					}
					_currentTexFile = new TexFile(pakNode.method_13((int)DataFolder_TreeView.SelectedNode.Tag));

					for (var i = 1; i <= _currentTexFile.TextureCount(); i++)
					{
						ImgList.Items.Add("Image " + i);
					}
					pakNode.Dispose();
					return;
				}
				if (DataFolder_TreeView.SelectedNode.ToolTipText != "")
				{
					DisposeTexFile();
					_currentTexFile = new TexFile(DataFolder_TreeView.SelectedNode.ToolTipText);
					for (var j = 1; j <= _currentTexFile.TextureCount(); j++)
					{
						ImgList.Items.Add("Image " + j);
					}
				}
			}
		}

		private void ImgList_SelectedIndexChanged(object sender, EventArgs e)
		{
            var index = ImgList.SelectedIndex;


            if (index >= 0)
			{
				var texture = _currentTexFile[index];
				_currentTexturePixelFormat = texture.PixelFormat;
				BPPTxt.Text = string.Concat(texture.BPP);

                switch(texture.PixelFormat)
                {
                    case IMGPixelFormat.Dxt1:
                        FormatTxt.Text = "DXT1";
                        break;

                    case IMGPixelFormat.Dxt3:
                        FormatTxt.Text = "DXT3";
                        break;

                    case IMGPixelFormat.Dxt5:
                        FormatTxt.Text = "DXT5";
                        break;

                    default:
                        FormatTxt.Text = "A8R8G8B8";
                        break;
                }

				MipMapTxt.Text = string.Concat(texture.MipMapCount);
				WidthTxt.Text = string.Concat(texture.Size.Width);
				HeightTxt.Text = string.Concat(texture.Size.Height);

				var image = texture.GetImage();
				size_0 = image.Size;
				if (image.Width > ImagePreviewBox.Width || image.Height > ImagePreviewBox.Height)
				{
					image = KeyGenerator.ScaleImageFixedRatio(image, ImagePreviewBox.Size);
				}
				ImagePreviewBox.Image = image;
				ImageInfoBox.Enabled = true;

                var metadata = _currentTexFile.TextureList[index];
                CurrentImgFile = metadata;
            }
            else
            {
                ImageInfoBox.Enabled = false;
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
				image = new DDSTexture(text).GetImage();
			}
			else
			{
				image = Image.FromFile(text);
			}
			if (!image.Size.Equals(size_0) && DialogResult.Yes == MessageBox.Show("The image dimensions don't match. Do you wish scale to the original dimension? (Ratio may change!)", "Replace Texture", MessageBoxButtons.YesNo))
			{
				image = KeyGenerator.ScaleImage(image, size_0);
			}
			_currentTexFile.ReplaceTexture(ImgList.SelectedIndex, image, _currentTexturePixelFormat);
			RebuildBtn.Enabled = true;
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
				_currentTexFile.WriteBytes(ImgList.SelectedIndex, fileName);
				return;
			}
			_currentTexFile[ImgList.SelectedIndex].GetImage().Save(fileName, GetImageFormat(fileName));
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
				var toolTipText = DataFolder_TreeView.SelectedNode.ToolTipText;
				var pakNode = File.Exists(toolTipText.Replace(".pak.xen", ".pab.xen")) ? new zzPabNode(toolTipText, toolTipText.Replace(".pak.xen", ".pab.xen"), false) : new zzPakNode2(toolTipText, false);
				pakNode.method_11((int)DataFolder_TreeView.SelectedNode.Tag).imethod_17(_currentTexFile.ToStream().ReadEverything());
				pakNode.vmethod_1();
				pakNode.Dispose();
			}
			ImgList.Items.Clear();
			DisposeTexFile();
		}

		private void NextSearch_Btn_Click(object sender, EventArgs e)
		{
			if (DataFolder_TreeView.SelectedNode == null)
			{
				return;
			}
			if (Search_TxtBox.Text.Equals(""))
			{
				foreach (var current in nodeList)
				{
					current.BackColor = Color.Empty;
				}
				nodeList.Clear();
				string_1 = "";
				SearchPos_Lbl.Text = "0/0";
				return;
			}
			if (!Search_TxtBox.Text.Equals(string_1))
			{
				foreach (var current2 in nodeList)
				{
					current2.BackColor = Color.Transparent;
				}
				nodeList.Clear();
				string_1 = Search_TxtBox.Text;
			}
			if (nodeList.Count == 0)
			{
				if (!method_4())
				{
					MessageBox.Show("Value not found!");
					SearchPos_Lbl.Text = "0/0";
					return;
				}
				count = -1;
			}
			count++;
			var treeView = DataFolder_TreeView;
			var node = nodeList;
			int arg_16B_1;
			if (nodeList.Count <= count)
			{
				count = 0;
				arg_16B_1 = 0;
			}
			else
			{
				arg_16B_1 = count;
			}
			treeView.SelectedNode = node[arg_16B_1];
			SearchPos_Lbl.Text = count + 1 + "/" + nodeList.Count;
			DataFolder_TreeView.Focus();
		}

		private void PrevSearch_Btn_Click(object sender, EventArgs e)
		{
			if (DataFolder_TreeView.SelectedNode == null)
			{
				return;
			}
			if (Search_TxtBox.Text.Equals(""))
			{
				foreach (var current in nodeList)
				{
					current.BackColor = Color.Empty;
				}
				nodeList.Clear();
				string_1 = "";
				SearchPos_Lbl.Text = "0/0";
				return;
			}
			if (!Search_TxtBox.Text.Equals(string_1))
			{
				foreach (var current2 in nodeList)
				{
					current2.BackColor = Color.Empty;
				}
				nodeList.Clear();
				string_1 = Search_TxtBox.Text;
			}
			if (nodeList.Count == 0)
			{
				if (!method_4())
				{
					MessageBox.Show("Value not found!");
					SearchPos_Lbl.Text = "0/0";
					return;
				}
				count = nodeList.Count;
			}
			count--;
			DataFolder_TreeView.SelectedNode = nodeList[(0 <= count) ? count : (count = nodeList.Count - 1)];
			SearchPos_Lbl.Text = count + 1 + "/" + nodeList.Count;
			DataFolder_TreeView.Focus();
		}

		private void Search_Btn_Click(object sender, EventArgs e)
		{
			if (DataFolder_TreeView.SelectedNode == null)
			{
				return;
			}
			foreach (var current in nodeList)
			{
				current.BackColor = Color.Empty;
			}
			nodeList.Clear();
			string_1 = Search_TxtBox.Text;
			if (string_1.Equals(""))
			{
				SearchPos_Lbl.Text = "0/0";
				return;
			}
			if (!method_4())
			{
				MessageBox.Show("Value not found!");
				SearchPos_Lbl.Text = "0/0";
				return;
			}
			count = 0;
			DataFolder_TreeView.SelectedNode = nodeList[count];
			SearchPos_Lbl.Text = count + 1 + "/" + nodeList.Count;
			DataFolder_TreeView.Focus();
		}

		private bool method_4()
		{
			AddNodeToContainerIfItHasThisString(DataFolder_TreeView.SelectedNode, string_1, nodeList);
			foreach (var current in nodeList)
			{
				current.BackColor = Color.YellowGreen;
			}
			return nodeList.Count != 0;
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
            if (chkEditMetadata.Checked)
            { 
                if (MessageBox.Show("Are you sure you want to edit the image metadata? You could corrupt your pak file!", "Warning!", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    chkEditMetadata.Checked = false;
                }
            }

            MetadataReadonly = !chkEditMetadata.Checked;

        }


        // Editing image metadata

        private TextureMetadata CurrentImgFile
        {
            set
            {
                _currentImgFile = value;
                if (value != null)
                {
                    MetadataReadonly = !chkEditMetadata.Checked;
                    txtFlags.Text = value.unkFlags.ToString("X4");
                    txtKey.Text = value.Key.ToString("X8");
                    txtWidth.Text = value.Width.ToString();
                    txtHeight.Text = value.Height.ToString();
                    txtMipMaps.Text = value.MipMapCount.ToString();
                    txtStart.Text = value.StartIndex.ToString("X8");
                    txtLength.Text = value.Length.ToString();
                    txtUnk3.Text = value.unkShort3.ToString("X4");
                    txtUnk4.Text = value.unkShort4.ToString("X4");
                }
                else
                {
                    MetadataReadonly = true;
                    txtFlags.Text = "";
                    txtKey.Text = "";
                    txtWidth.Text = "";
                    txtHeight.Text = "";
                    txtMipMaps.Text = "";
                    txtStart.Text = "";
                    txtLength.Text = "";
                    txtUnk3.Text = "";
                    txtUnk4.Text = "";
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
                txtFlags.ReadOnly = value;
                txtKey.ReadOnly = value;
                txtWidth.ReadOnly = value;
                txtHeight.ReadOnly = value;
                txtMipMaps.ReadOnly = value;
                txtStart.ReadOnly = value;
                txtLength.ReadOnly = value;
                txtUnk3.ReadOnly = value;
                txtUnk4.ReadOnly = value;
            }
        }

        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            int newKey;
            if (Int32.TryParse(txtKey.Text, NumberStyles.HexNumber | NumberStyles.AllowHexSpecifier, null, out newKey))
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
            if (ImgList.Items.Count <= 0)
                return;

            if (ImgList.SelectedIndex < 0 || ImgList.SelectedIndex >= _currentTexFile.TextureCount())
                return;

            var cloneIndex = _currentTexFile.CloneTextureElement(ImgList.SelectedIndex);
            ImgList.Items.Add("Image " + (cloneIndex + 1) );
        }
    }
}
