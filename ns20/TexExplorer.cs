using NeversoftTools.Texture.DDS;
using ns16;
using ns19;
using ns21;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

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

		private string string_0;

		private TexFile _currentTexFile;

        private TextureMetadata _currentImgFile;

		private Thread thread_0;

		private Size size_0;

		private IMGPixelFormat _currentTexturePixelFormat;

		private string string_1;

		private List<TreeNode> nodeList = new List<TreeNode>();
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
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.ImagePreviewBox = new System.Windows.Forms.PictureBox();
            this.ImageInfoBox = new System.Windows.Forms.GroupBox();
            this.ExtractImgBtn = new System.Windows.Forms.Button();
            this.ReplaceImgBtn = new System.Windows.Forms.Button();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblBPP = new System.Windows.Forms.Label();
            this.lblMipMaps = new System.Windows.Forms.Label();
            this.lblFormat = new System.Windows.Forms.Label();
            this.HeightTxt = new System.Windows.Forms.TextBox();
            this.FormatTxt = new System.Windows.Forms.TextBox();
            this.WidthTxt = new System.Windows.Forms.TextBox();
            this.MipMapTxt = new System.Windows.Forms.TextBox();
            this.BPPTxt = new System.Windows.Forms.TextBox();
            this.ImgList = new System.Windows.Forms.ListBox();
            this.DataFolder_TreeView = new System.Windows.Forms.TreeView();
            this.RebuildBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkEditMetadata = new System.Windows.Forms.CheckBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.txtUnk4 = new System.Windows.Forms.TextBox();
            this.txtMipMaps = new System.Windows.Forms.TextBox();
            this.txtUnk3 = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtFlags = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tblImageList = new System.Windows.Forms.TableLayoutPanel();
            this.btnCloneImage = new System.Windows.Forms.Button();
            this.TreeViewContainer = new System.Windows.Forms.ToolStripContainer();
            this.Search_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.Search_TxtBox = new System.Windows.Forms.ToolStripTextBox();
            this.Search_Btn = new System.Windows.Forms.ToolStripButton();
            this.PrevSearch_Btn = new System.Windows.Forms.ToolStripButton();
            this.NextSearch_Btn = new System.Windows.Forms.ToolStripButton();
            this.SearchPos_Lbl = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePreviewBox)).BeginInit();
            this.ImageInfoBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tblImageList.SuspendLayout();
            this.TreeViewContainer.ContentPanel.SuspendLayout();
            this.TreeViewContainer.TopToolStripPanel.SuspendLayout();
            this.TreeViewContainer.SuspendLayout();
            this.Search_ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImagePreviewBox
            // 
            this.ImagePreviewBox.BackColor = System.Drawing.Color.Transparent;
            this.ImagePreviewBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImagePreviewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImagePreviewBox.Location = new System.Drawing.Point(103, 3);
            this.ImagePreviewBox.Name = "ImagePreviewBox";
            this.ImagePreviewBox.Size = new System.Drawing.Size(1015, 511);
            this.ImagePreviewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ImagePreviewBox.TabIndex = 7;
            this.ImagePreviewBox.TabStop = false;
            this.ImagePreviewBox.Click += new System.EventHandler(this.ImagePreviewBox_Click);
            // 
            // ImageInfoBox
            // 
            this.ImageInfoBox.Controls.Add(this.ExtractImgBtn);
            this.ImageInfoBox.Controls.Add(this.ReplaceImgBtn);
            this.ImageInfoBox.Controls.Add(this.lblHeight);
            this.ImageInfoBox.Controls.Add(this.lblWidth);
            this.ImageInfoBox.Controls.Add(this.lblBPP);
            this.ImageInfoBox.Controls.Add(this.lblMipMaps);
            this.ImageInfoBox.Controls.Add(this.lblFormat);
            this.ImageInfoBox.Controls.Add(this.HeightTxt);
            this.ImageInfoBox.Controls.Add(this.FormatTxt);
            this.ImageInfoBox.Controls.Add(this.WidthTxt);
            this.ImageInfoBox.Controls.Add(this.MipMapTxt);
            this.ImageInfoBox.Controls.Add(this.BPPTxt);
            this.ImageInfoBox.Enabled = false;
            this.ImageInfoBox.Location = new System.Drawing.Point(1030, 3);
            this.ImageInfoBox.Name = "ImageInfoBox";
            this.ImageInfoBox.Size = new System.Drawing.Size(288, 100);
            this.ImageInfoBox.TabIndex = 8;
            this.ImageInfoBox.TabStop = false;
            this.ImageInfoBox.Text = "Image Information";
            // 
            // ExtractImgBtn
            // 
            this.ExtractImgBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExtractImgBtn.Location = new System.Drawing.Point(215, 67);
            this.ExtractImgBtn.Name = "ExtractImgBtn";
            this.ExtractImgBtn.Size = new System.Drawing.Size(67, 27);
            this.ExtractImgBtn.TabIndex = 46;
            this.ExtractImgBtn.Text = "Extract";
            this.ExtractImgBtn.UseVisualStyleBackColor = true;
            this.ExtractImgBtn.Click += new System.EventHandler(this.ExtractImgBtn_Click);
            // 
            // ReplaceImgBtn
            // 
            this.ReplaceImgBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReplaceImgBtn.Location = new System.Drawing.Point(137, 67);
            this.ReplaceImgBtn.Name = "ReplaceImgBtn";
            this.ReplaceImgBtn.Size = new System.Drawing.Size(72, 27);
            this.ReplaceImgBtn.TabIndex = 45;
            this.ReplaceImgBtn.Text = "Replace";
            this.ReplaceImgBtn.UseVisualStyleBackColor = true;
            this.ReplaceImgBtn.Click += new System.EventHandler(this.ReplaceImgBtn_Click);
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeight.Location = new System.Drawing.Point(163, 44);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(59, 19);
            this.lblHeight.TabIndex = 44;
            this.lblHeight.Text = "Height:";
            this.lblHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWidth.Location = new System.Drawing.Point(168, 18);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(54, 19);
            this.lblWidth.TabIndex = 43;
            this.lblWidth.Text = "Width:";
            this.lblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBPP
            // 
            this.lblBPP.AutoSize = true;
            this.lblBPP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBPP.Location = new System.Drawing.Point(44, 44);
            this.lblBPP.Name = "lblBPP";
            this.lblBPP.Size = new System.Drawing.Size(43, 19);
            this.lblBPP.TabIndex = 42;
            this.lblBPP.Text = "BPP:";
            this.lblBPP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMipMaps
            // 
            this.lblMipMaps.AutoSize = true;
            this.lblMipMaps.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMipMaps.Location = new System.Drawing.Point(6, 71);
            this.lblMipMaps.Name = "lblMipMaps";
            this.lblMipMaps.Size = new System.Drawing.Size(81, 19);
            this.lblMipMaps.TabIndex = 41;
            this.lblMipMaps.Text = "MipMaps:";
            this.lblMipMaps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormat.Location = new System.Drawing.Point(25, 18);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(62, 19);
            this.lblFormat.TabIndex = 40;
            this.lblFormat.Text = "Format:";
            this.lblFormat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HeightTxt
            // 
            this.HeightTxt.Location = new System.Drawing.Point(228, 45);
            this.HeightTxt.Name = "HeightTxt";
            this.HeightTxt.ReadOnly = true;
            this.HeightTxt.Size = new System.Drawing.Size(53, 20);
            this.HeightTxt.TabIndex = 13;
            // 
            // FormatTxt
            // 
            this.FormatTxt.Location = new System.Drawing.Point(93, 17);
            this.FormatTxt.Name = "FormatTxt";
            this.FormatTxt.ReadOnly = true;
            this.FormatTxt.Size = new System.Drawing.Size(64, 20);
            this.FormatTxt.TabIndex = 11;
            // 
            // WidthTxt
            // 
            this.WidthTxt.Location = new System.Drawing.Point(228, 19);
            this.WidthTxt.Name = "WidthTxt";
            this.WidthTxt.ReadOnly = true;
            this.WidthTxt.Size = new System.Drawing.Size(53, 20);
            this.WidthTxt.TabIndex = 5;
            // 
            // MipMapTxt
            // 
            this.MipMapTxt.Location = new System.Drawing.Point(93, 72);
            this.MipMapTxt.Name = "MipMapTxt";
            this.MipMapTxt.ReadOnly = true;
            this.MipMapTxt.Size = new System.Drawing.Size(38, 20);
            this.MipMapTxt.TabIndex = 3;
            // 
            // BPPTxt
            // 
            this.BPPTxt.Location = new System.Drawing.Point(93, 45);
            this.BPPTxt.Name = "BPPTxt";
            this.BPPTxt.ReadOnly = true;
            this.BPPTxt.Size = new System.Drawing.Size(64, 20);
            this.BPPTxt.TabIndex = 2;
            // 
            // ImgList
            // 
            this.ImgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImgList.FormattingEnabled = true;
            this.ImgList.IntegralHeight = false;
            this.ImgList.Location = new System.Drawing.Point(3, 3);
            this.ImgList.Name = "ImgList";
            this.ImgList.Size = new System.Drawing.Size(88, 465);
            this.ImgList.TabIndex = 9;
            this.ImgList.SelectedIndexChanged += new System.EventHandler(this.ImgList_SelectedIndexChanged);
            // 
            // DataFolder_TreeView
            // 
            this.DataFolder_TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataFolder_TreeView.Location = new System.Drawing.Point(0, 0);
            this.DataFolder_TreeView.Name = "DataFolder_TreeView";
            this.DataFolder_TreeView.Size = new System.Drawing.Size(230, 610);
            this.DataFolder_TreeView.TabIndex = 10;
            this.DataFolder_TreeView.DoubleClick += new System.EventHandler(this.DataFolder_TreeView_DoubleClick);
            // 
            // RebuildBtn
            // 
            this.RebuildBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RebuildBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RebuildBtn.Location = new System.Drawing.Point(3, 3);
            this.RebuildBtn.Name = "RebuildBtn";
            this.RebuildBtn.Size = new System.Drawing.Size(1021, 100);
            this.RebuildBtn.TabIndex = 46;
            this.RebuildBtn.Text = "Rebuild Container";
            this.RebuildBtn.UseVisualStyleBackColor = true;
            this.RebuildBtn.Click += new System.EventHandler(this.RebuildBtn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 236F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TreeViewContainer, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1569, 641);
            this.tableLayoutPanel1.TabIndex = 47;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(239, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1327, 635);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.RebuildBtn, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.ImageInfoBox, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 526);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1321, 106);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel4.Controls.Add(this.ImagePreviewBox, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.groupBox1, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.tblImageList, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 632F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1321, 517);
            this.tableLayoutPanel4.TabIndex = 1;
            this.tableLayoutPanel4.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel4_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkEditMetadata);
            this.groupBox1.Controls.Add(this.txtWidth);
            this.groupBox1.Controls.Add(this.txtKey);
            this.groupBox1.Controls.Add(this.txtLength);
            this.groupBox1.Controls.Add(this.txtStart);
            this.groupBox1.Controls.Add(this.txtUnk4);
            this.groupBox1.Controls.Add(this.txtMipMaps);
            this.groupBox1.Controls.Add(this.txtUnk3);
            this.groupBox1.Controls.Add(this.txtHeight);
            this.groupBox1.Controls.Add(this.txtFlags);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1124, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 283);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Metadata";
            // 
            // chkEditMetadata
            // 
            this.chkEditMetadata.AutoSize = true;
            this.chkEditMetadata.Location = new System.Drawing.Point(62, 254);
            this.chkEditMetadata.Name = "chkEditMetadata";
            this.chkEditMetadata.Size = new System.Drawing.Size(86, 17);
            this.chkEditMetadata.TabIndex = 10;
            this.chkEditMetadata.Text = "Allow Editing";
            this.chkEditMetadata.UseVisualStyleBackColor = true;
            this.chkEditMetadata.CheckedChanged += new System.EventHandler(this.chkEditMetadata_CheckedChanged);
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(62, 72);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ReadOnly = true;
            this.txtWidth.Size = new System.Drawing.Size(125, 20);
            this.txtWidth.TabIndex = 9;
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(62, 46);
            this.txtKey.Name = "txtKey";
            this.txtKey.ReadOnly = true;
            this.txtKey.Size = new System.Drawing.Size(125, 20);
            this.txtKey.TabIndex = 9;
            this.txtKey.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(62, 228);
            this.txtLength.Name = "txtLength";
            this.txtLength.ReadOnly = true;
            this.txtLength.Size = new System.Drawing.Size(125, 20);
            this.txtLength.TabIndex = 9;
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(62, 202);
            this.txtStart.Name = "txtStart";
            this.txtStart.ReadOnly = true;
            this.txtStart.Size = new System.Drawing.Size(125, 20);
            this.txtStart.TabIndex = 9;
            // 
            // txtUnk4
            // 
            this.txtUnk4.Location = new System.Drawing.Point(62, 176);
            this.txtUnk4.Name = "txtUnk4";
            this.txtUnk4.ReadOnly = true;
            this.txtUnk4.Size = new System.Drawing.Size(125, 20);
            this.txtUnk4.TabIndex = 9;
            // 
            // txtMipMaps
            // 
            this.txtMipMaps.Location = new System.Drawing.Point(62, 150);
            this.txtMipMaps.Name = "txtMipMaps";
            this.txtMipMaps.ReadOnly = true;
            this.txtMipMaps.Size = new System.Drawing.Size(125, 20);
            this.txtMipMaps.TabIndex = 9;
            // 
            // txtUnk3
            // 
            this.txtUnk3.Location = new System.Drawing.Point(62, 124);
            this.txtUnk3.Name = "txtUnk3";
            this.txtUnk3.ReadOnly = true;
            this.txtUnk3.Size = new System.Drawing.Size(125, 20);
            this.txtUnk3.TabIndex = 9;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(62, 98);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.ReadOnly = true;
            this.txtHeight.Size = new System.Drawing.Size(125, 20);
            this.txtHeight.TabIndex = 9;
            // 
            // txtFlags
            // 
            this.txtFlags.Location = new System.Drawing.Point(62, 20);
            this.txtFlags.Name = "txtFlags";
            this.txtFlags.ReadOnly = true;
            this.txtFlags.Size = new System.Drawing.Size(125, 20);
            this.txtFlags.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Length:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Start:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Unk4:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "MipMaps:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Unk3:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Height:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Width:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Key:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flags:";
            // 
            // tblImageList
            // 
            this.tblImageList.ColumnCount = 1;
            this.tblImageList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblImageList.Controls.Add(this.ImgList, 0, 0);
            this.tblImageList.Controls.Add(this.btnCloneImage, 0, 1);
            this.tblImageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblImageList.Location = new System.Drawing.Point(3, 3);
            this.tblImageList.Name = "tblImageList";
            this.tblImageList.RowCount = 2;
            this.tblImageList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblImageList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblImageList.Size = new System.Drawing.Size(94, 511);
            this.tblImageList.TabIndex = 11;
            this.tblImageList.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel5_Paint);
            // 
            // btnCloneImage
            // 
            this.btnCloneImage.Location = new System.Drawing.Point(3, 474);
            this.btnCloneImage.Name = "btnCloneImage";
            this.btnCloneImage.Size = new System.Drawing.Size(88, 34);
            this.btnCloneImage.TabIndex = 11;
            this.btnCloneImage.Text = "Clone";
            this.btnCloneImage.UseVisualStyleBackColor = true;
            this.btnCloneImage.Click += new System.EventHandler(this.btnCloneImage_Click);
            // 
            // TreeViewContainer
            // 
            this.TreeViewContainer.BottomToolStripPanelVisible = false;
            // 
            // TreeViewContainer.ContentPanel
            // 
            this.TreeViewContainer.ContentPanel.Controls.Add(this.DataFolder_TreeView);
            this.TreeViewContainer.ContentPanel.Size = new System.Drawing.Size(230, 610);
            this.TreeViewContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeViewContainer.LeftToolStripPanelVisible = false;
            this.TreeViewContainer.Location = new System.Drawing.Point(3, 3);
            this.TreeViewContainer.Name = "TreeViewContainer";
            this.TreeViewContainer.RightToolStripPanelVisible = false;
            this.TreeViewContainer.Size = new System.Drawing.Size(230, 635);
            this.TreeViewContainer.TabIndex = 11;
            this.TreeViewContainer.Text = "toolStripContainer1";
            // 
            // TreeViewContainer.TopToolStripPanel
            // 
            this.TreeViewContainer.TopToolStripPanel.Controls.Add(this.Search_ToolStrip);
            // 
            // Search_ToolStrip
            // 
            this.Search_ToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.Search_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Search_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Search_TxtBox,
            this.Search_Btn,
            this.PrevSearch_Btn,
            this.NextSearch_Btn,
            this.SearchPos_Lbl});
            this.Search_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.Search_ToolStrip.Name = "Search_ToolStrip";
            this.Search_ToolStrip.Size = new System.Drawing.Size(230, 25);
            this.Search_ToolStrip.Stretch = true;
            this.Search_ToolStrip.TabIndex = 0;
            // 
            // Search_TxtBox
            // 
            this.Search_TxtBox.Name = "Search_TxtBox";
            this.Search_TxtBox.Size = new System.Drawing.Size(70, 25);
            // 
            // Search_Btn
            // 
            this.Search_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Search_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Search_Btn.Name = "Search_Btn";
            this.Search_Btn.Size = new System.Drawing.Size(46, 22);
            this.Search_Btn.Text = "Search";
            this.Search_Btn.Click += new System.EventHandler(this.Search_Btn_Click);
            // 
            // PrevSearch_Btn
            // 
            this.PrevSearch_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PrevSearch_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PrevSearch_Btn.Name = "PrevSearch_Btn";
            this.PrevSearch_Btn.Size = new System.Drawing.Size(34, 22);
            this.PrevSearch_Btn.Text = "Prev";
            this.PrevSearch_Btn.Click += new System.EventHandler(this.PrevSearch_Btn_Click);
            // 
            // NextSearch_Btn
            // 
            this.NextSearch_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.NextSearch_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NextSearch_Btn.Name = "NextSearch_Btn";
            this.NextSearch_Btn.Size = new System.Drawing.Size(35, 22);
            this.NextSearch_Btn.Text = "Next";
            this.NextSearch_Btn.Click += new System.EventHandler(this.NextSearch_Btn_Click);
            // 
            // SearchPos_Lbl
            // 
            this.SearchPos_Lbl.Name = "SearchPos_Lbl";
            this.SearchPos_Lbl.Size = new System.Drawing.Size(24, 22);
            this.SearchPos_Lbl.Text = "0/0";
            // 
            // TexExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1569, 641);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TexExplorer";
            this.Text = "Texture Explorer";
            ((System.ComponentModel.ISupportInitialize)(this.ImagePreviewBox)).EndInit();
            this.ImageInfoBox.ResumeLayout(false);
            this.ImageInfoBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tblImageList.ResumeLayout(false);
            this.TreeViewContainer.ContentPanel.ResumeLayout(false);
            this.TreeViewContainer.TopToolStripPanel.ResumeLayout(false);
            this.TreeViewContainer.TopToolStripPanel.PerformLayout();
            this.TreeViewContainer.ResumeLayout(false);
            this.TreeViewContainer.PerformLayout();
            this.Search_ToolStrip.ResumeLayout(false);
            this.Search_ToolStrip.PerformLayout();
            this.ResumeLayout(false);

		}

		public TexExplorer(string string_2)
		{
			this.InitializeComponent();
			this.string_0 = string_2;
			base.Closed += new EventHandler(this.TexExplorer_Closed);
			this.Text = "Texture Explorer - LOOKING FOR TEXTURES (PLEASE WAIT!)";
			ZonePakLoader @class = new ZonePakLoader(this.string_0);
			@class.method_1(new ZonePakLoader.Delegate9(this.UpdateSearchText));
			@class.method_0(new ZonePakLoader.Delegate8(this.AddNode));
			this.thread_0 = new Thread(new ThreadStart(@class.method_2));
			this.thread_0.Start();
		}

		private void TexExplorer_Closed(object sender, EventArgs e)
		{
			this.DisposeTexFile();
			if (this.thread_0 != null && this.thread_0.IsAlive)
			{
				this.thread_0.Abort();
				this.thread_0 = null;
			}
		}

		private void UpdateSearchText(int percentComplete, string currentFile)
		{
			if (base.InvokeRequired)
			{
				ZonePakLoader.Delegate9 method = new ZonePakLoader.Delegate9(this.UpdateSearchText);
				base.Invoke(method, new object[]
				{
					percentComplete,
					currentFile
				});
				return;
			}
			this.Text = string.Concat(new object[]
			{
				"Texture Explorer - LOOKING FOR TEXTURES - ",
				percentComplete,
				"% - (",
				currentFile,
				")"
			});
		}

		private void AddNode(TreeNode treeNode)
		{
			if (base.InvokeRequired)
			{
				ZonePakLoader.Delegate8 method = new ZonePakLoader.Delegate8(this.AddNode);
				base.Invoke(method, new object[]
				{
					treeNode
				});
				return;
			}
			this.DataFolder_TreeView.Nodes.Add(treeNode);
			this.Text = "Texture Explorer";
			this.DataFolder_TreeView.Sort();
		}

		private void DisposeTexFile()
		{
			if (this._currentTexFile != null)
			{
				this._currentTexFile.Dispose();
				this._currentTexFile = null;
                CurrentImgFile = null;
			}
			this.ImgList.Items.Clear();
			this.ImgList.SelectedIndex = -1;
			
			this.ImageInfoBox.Enabled = false;
			//this.RebuildBtn.Enabled = false;
			this.ImagePreviewBox.Image = null;
		}

		private void DataFolder_TreeView_DoubleClick(object sender, EventArgs e)
		{
			if (this.DataFolder_TreeView.SelectedNode != null)
			{
				if (this.DataFolder_TreeView.SelectedNode.Tag is int && this.DataFolder_TreeView.SelectedNode.ToolTipText != "")
				{
					this.DisposeTexFile();
					string toolTipText = this.DataFolder_TreeView.SelectedNode.ToolTipText;
					zzPakNode2 pakNode;
					if (File.Exists(toolTipText.Replace(".pak.xen", ".pab.xen")))
					{
						pakNode = new zzPabNode(toolTipText, toolTipText.Replace(".pak.xen", ".pab.xen"), false);
					}
					else
					{
						pakNode = new zzPakNode2(toolTipText, false);
					}
					this._currentTexFile = new TexFile(pakNode.method_13((int)this.DataFolder_TreeView.SelectedNode.Tag));

					for (int i = 1; i <= this._currentTexFile.TextureCount(); i++)
					{
						this.ImgList.Items.Add("Image " + i);
					}
					pakNode.Dispose();
					return;
				}
				if (this.DataFolder_TreeView.SelectedNode.ToolTipText != "")
				{
					this.DisposeTexFile();
					this._currentTexFile = new TexFile(this.DataFolder_TreeView.SelectedNode.ToolTipText);
					for (int j = 1; j <= this._currentTexFile.TextureCount(); j++)
					{
						this.ImgList.Items.Add("Image " + j);
					}
				}
			}
		}

		private void ImgList_SelectedIndexChanged(object sender, EventArgs e)
		{
            int index = ImgList.SelectedIndex;


            if (index >= 0)
			{
				DDSTexture texture = _currentTexFile[index];
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

				Image image = texture.GetImage();
				this.size_0 = image.Size;
				if (image.Width > this.ImagePreviewBox.Width || image.Height > this.ImagePreviewBox.Height)
				{
					image = KeyGenerator.ScaleImageFixedRatio(image, ImagePreviewBox.Size);
				}
				this.ImagePreviewBox.Image = image;
				this.ImageInfoBox.Enabled = true;

                TextureMetadata metadata = _currentTexFile.TextureList[index];
                CurrentImgFile = metadata;
            }
            else
            {
                this.ImageInfoBox.Enabled = false;
            }
			
		}





		private void ReplaceImgBtn_Click(object sender, EventArgs e)
		{
			string text = KeyGenerator.OpenOrSaveFile("Select the image file to replace the texture.", "All Supported Formats|*.dds;*.bmp;*.jpg;*.gif;*.png|DDS Texture|*.dds|Bitmap|*.bmp|JPEG|*.jpg|Graphics Interchange Format|*.gif|Portable Network Graphics|*.png", true);
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
			if (!image.Size.Equals(this.size_0) && DialogResult.Yes == MessageBox.Show("The image dimensions don't match. Do you wish scale to the original dimension? (Ratio may change!)", "Replace Texture", MessageBoxButtons.YesNo))
			{
				image = KeyGenerator.ScaleImage(image, this.size_0);
			}
			this._currentTexFile.ReplaceTexture(this.ImgList.SelectedIndex, image, this._currentTexturePixelFormat);
			this.RebuildBtn.Enabled = true;
		}

		public ImageFormat GetImageFormat(string fileName)
		{
			string ext = KeyGenerator.GetExtension(fileName, 1).ToLower();
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
			string fileName = KeyGenerator.OpenOrSaveFile("Select location to export the texture.", "All Supported Formats|*.dds;*.bmp;*.jpg;*.gif;*.png|DDS Texture|*.dds|Bitmap|*.bmp|JPEG|*.jpg|Graphics Interchange Format|*.gif|Portable Network Graphics|*.png", false);
			if (fileName == "")
			{
				return;
			}
			if (fileName.EndsWith(".dds", StringComparison.OrdinalIgnoreCase))
			{
				this._currentTexFile.WriteBytes(this.ImgList.SelectedIndex, fileName);
				return;
			}
			this._currentTexFile[this.ImgList.SelectedIndex].GetImage().Save(fileName, this.GetImageFormat(fileName));
		}

		private void RebuildBtn_Click(object sender, EventArgs e)
		{
			if (DialogResult.Yes != MessageBox.Show("Are you sure you wish to rebuild the container? (Overwriting File!)", "Replace Textures", MessageBoxButtons.YesNo))
			{
				return;
			}
			if (this._currentTexFile.CanWrite())
			{
				this._currentTexFile.WriteEverythingToFile();
			}
			else
			{
				string toolTipText = this.DataFolder_TreeView.SelectedNode.ToolTipText;
				zzPakNode2 pakNode = File.Exists(toolTipText.Replace(".pak.xen", ".pab.xen")) ? new zzPabNode(toolTipText, toolTipText.Replace(".pak.xen", ".pab.xen"), false) : new zzPakNode2(toolTipText, false);
				pakNode.method_11((int)this.DataFolder_TreeView.SelectedNode.Tag).imethod_17(this._currentTexFile.ToStream().ReadEverything());
				pakNode.vmethod_1();
				pakNode.Dispose();
			}
			this.ImgList.Items.Clear();
			this.DisposeTexFile();
		}

		private void NextSearch_Btn_Click(object sender, EventArgs e)
		{
			if (this.DataFolder_TreeView.SelectedNode == null)
			{
				return;
			}
			if (this.Search_TxtBox.Text.Equals(""))
			{
				foreach (TreeNode current in this.nodeList)
				{
					current.BackColor = Color.Empty;
				}
				this.nodeList.Clear();
				this.string_1 = "";
				this.SearchPos_Lbl.Text = "0/0";
				return;
			}
			if (!this.Search_TxtBox.Text.Equals(this.string_1))
			{
				foreach (TreeNode current2 in this.nodeList)
				{
					current2.BackColor = Color.Transparent;
				}
				this.nodeList.Clear();
				this.string_1 = this.Search_TxtBox.Text;
			}
			if (this.nodeList.Count == 0)
			{
				if (!this.method_4())
				{
					MessageBox.Show("Value not found!");
					this.SearchPos_Lbl.Text = "0/0";
					return;
				}
				this.count = -1;
			}
			this.count++;
			TreeView treeView = this.DataFolder_TreeView;
			List<TreeNode> node = this.nodeList;
			int arg_16B_1;
			if (this.nodeList.Count <= this.count)
			{
				this.count = 0;
				arg_16B_1 = 0;
			}
			else
			{
				arg_16B_1 = this.count;
			}
			treeView.SelectedNode = node[arg_16B_1];
			this.SearchPos_Lbl.Text = this.count + 1 + "/" + this.nodeList.Count;
			this.DataFolder_TreeView.Focus();
		}

		private void PrevSearch_Btn_Click(object sender, EventArgs e)
		{
			if (this.DataFolder_TreeView.SelectedNode == null)
			{
				return;
			}
			if (this.Search_TxtBox.Text.Equals(""))
			{
				foreach (TreeNode current in this.nodeList)
				{
					current.BackColor = Color.Empty;
				}
				this.nodeList.Clear();
				this.string_1 = "";
				this.SearchPos_Lbl.Text = "0/0";
				return;
			}
			if (!this.Search_TxtBox.Text.Equals(this.string_1))
			{
				foreach (TreeNode current2 in this.nodeList)
				{
					current2.BackColor = Color.Empty;
				}
				this.nodeList.Clear();
				this.string_1 = this.Search_TxtBox.Text;
			}
			if (this.nodeList.Count == 0)
			{
				if (!this.method_4())
				{
					MessageBox.Show("Value not found!");
					this.SearchPos_Lbl.Text = "0/0";
					return;
				}
				this.count = this.nodeList.Count;
			}
			this.count--;
			this.DataFolder_TreeView.SelectedNode = this.nodeList[(0 <= this.count) ? this.count : (this.count = this.nodeList.Count - 1)];
			this.SearchPos_Lbl.Text = this.count + 1 + "/" + this.nodeList.Count;
			this.DataFolder_TreeView.Focus();
		}

		private void Search_Btn_Click(object sender, EventArgs e)
		{
			if (this.DataFolder_TreeView.SelectedNode == null)
			{
				return;
			}
			foreach (TreeNode current in this.nodeList)
			{
				current.BackColor = Color.Empty;
			}
			this.nodeList.Clear();
			this.string_1 = this.Search_TxtBox.Text;
			if (this.string_1.Equals(""))
			{
				this.SearchPos_Lbl.Text = "0/0";
				return;
			}
			if (!this.method_4())
			{
				MessageBox.Show("Value not found!");
				this.SearchPos_Lbl.Text = "0/0";
				return;
			}
			this.count = 0;
			this.DataFolder_TreeView.SelectedNode = this.nodeList[this.count];
			this.SearchPos_Lbl.Text = this.count + 1 + "/" + this.nodeList.Count;
			this.DataFolder_TreeView.Focus();
		}

		private bool method_4()
		{
			TexExplorer.AddNodeToContainerIfItHasThisString(this.DataFolder_TreeView.SelectedNode, this.string_1, this.nodeList);
			foreach (TreeNode current in this.nodeList)
			{
				current.BackColor = Color.YellowGreen;
			}
			return this.nodeList.Count != 0;
		}

		private static void AddNodeToContainerIfItHasThisString(TreeNode node, string str, ICollection<TreeNode> nodeCollection)
		{
			if (node.Text.ToUpper().Contains(str.ToUpper()))
			{
				nodeCollection.Add(node);
			}
			for (int i = 0; i < node.Nodes.Count; i++)
			{
				TexExplorer.AddNodeToContainerIfItHasThisString(node.Nodes[i], str, nodeCollection);
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
            if (Int32.TryParse(txtKey.Text, System.Globalization.NumberStyles.HexNumber | System.Globalization.NumberStyles.AllowHexSpecifier, null, out newKey))
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

            int cloneIndex = _currentTexFile.CloneTextureElement(ImgList.SelectedIndex);
            ImgList.Items.Add("Image " + (cloneIndex + 1) );
        }
    }
}
