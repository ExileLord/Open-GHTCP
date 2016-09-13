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

		private Label label5;

		private Label label4;

		private Label label1;

		private Label label7;

		private Label label3;

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

		private zzTextureExplorer1 _textureExplorer;

		private Thread thread_0;

		private Size size_0;

		private IMGPixelFormat imgpixelFormat_0;

		private string string_1;

		private List<TreeNode> list_0 = new List<TreeNode>();

		private int int_0;

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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TexExplorer));
			this.ImagePreviewBox = new PictureBox();
			this.ImageInfoBox = new GroupBox();
			this.ExtractImgBtn = new Button();
			this.ReplaceImgBtn = new Button();
			this.label5 = new Label();
			this.label4 = new Label();
			this.label1 = new Label();
			this.label7 = new Label();
			this.label3 = new Label();
			this.HeightTxt = new TextBox();
			this.FormatTxt = new TextBox();
			this.WidthTxt = new TextBox();
			this.MipMapTxt = new TextBox();
			this.BPPTxt = new TextBox();
			this.ImgList = new ListBox();
			this.DataFolder_TreeView = new TreeView();
			this.RebuildBtn = new Button();
			this.tableLayoutPanel1 = new TableLayoutPanel();
			this.tableLayoutPanel2 = new TableLayoutPanel();
			this.tableLayoutPanel3 = new TableLayoutPanel();
			this.tableLayoutPanel4 = new TableLayoutPanel();
			this.TreeViewContainer = new ToolStripContainer();
			this.Search_ToolStrip = new ToolStrip();
			this.Search_TxtBox = new ToolStripTextBox();
			this.PrevSearch_Btn = new ToolStripButton();
			this.NextSearch_Btn = new ToolStripButton();
			this.SearchPos_Lbl = new ToolStripLabel();
			this.Search_Btn = new ToolStripButton();
			((ISupportInitialize)this.ImagePreviewBox).BeginInit();
			this.ImageInfoBox.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.TreeViewContainer.ContentPanel.SuspendLayout();
			this.TreeViewContainer.TopToolStripPanel.SuspendLayout();
			this.TreeViewContainer.SuspendLayout();
			this.Search_ToolStrip.SuspendLayout();
			base.SuspendLayout();
			this.ImagePreviewBox.BackColor = Color.Transparent;
			this.ImagePreviewBox.BorderStyle = BorderStyle.FixedSingle;
			this.ImagePreviewBox.Dock = DockStyle.Fill;
			this.ImagePreviewBox.Location = new Point(85, 3);
			this.ImagePreviewBox.Name = "ImagePreviewBox";
			this.ImagePreviewBox.Size = new Size(458, 446);
			this.ImagePreviewBox.SizeMode = PictureBoxSizeMode.CenterImage;
			this.ImagePreviewBox.TabIndex = 7;
			this.ImagePreviewBox.TabStop = false;
			this.ImageInfoBox.Controls.Add(this.ExtractImgBtn);
			this.ImageInfoBox.Controls.Add(this.ReplaceImgBtn);
			this.ImageInfoBox.Controls.Add(this.label5);
			this.ImageInfoBox.Controls.Add(this.label4);
			this.ImageInfoBox.Controls.Add(this.label1);
			this.ImageInfoBox.Controls.Add(this.label7);
			this.ImageInfoBox.Controls.Add(this.label3);
			this.ImageInfoBox.Controls.Add(this.HeightTxt);
			this.ImageInfoBox.Controls.Add(this.FormatTxt);
			this.ImageInfoBox.Controls.Add(this.WidthTxt);
			this.ImageInfoBox.Controls.Add(this.MipMapTxt);
			this.ImageInfoBox.Controls.Add(this.BPPTxt);
			this.ImageInfoBox.Enabled = false;
			this.ImageInfoBox.Location = new Point(255, 3);
			this.ImageInfoBox.Name = "ImageInfoBox";
			this.ImageInfoBox.Size = new Size(288, 100);
			this.ImageInfoBox.TabIndex = 8;
			this.ImageInfoBox.TabStop = false;
			this.ImageInfoBox.Text = "Image Information";
			this.ExtractImgBtn.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.ExtractImgBtn.Location = new Point(215, 67);
			this.ExtractImgBtn.Name = "ExtractImgBtn";
			this.ExtractImgBtn.Size = new Size(67, 27);
			this.ExtractImgBtn.TabIndex = 46;
			this.ExtractImgBtn.Text = "Extract";
			this.ExtractImgBtn.UseVisualStyleBackColor = true;
			this.ExtractImgBtn.Click += new EventHandler(this.ExtractImgBtn_Click);
			this.ReplaceImgBtn.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.ReplaceImgBtn.Location = new Point(137, 67);
			this.ReplaceImgBtn.Name = "ReplaceImgBtn";
			this.ReplaceImgBtn.Size = new Size(72, 27);
			this.ReplaceImgBtn.TabIndex = 45;
			this.ReplaceImgBtn.Text = "Replace";
			this.ReplaceImgBtn.UseVisualStyleBackColor = true;
			this.ReplaceImgBtn.Click += new EventHandler(this.ReplaceImgBtn_Click);
			this.label5.AutoSize = true;
			this.label5.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label5.Location = new Point(163, 44);
			this.label5.Name = "label5";
			this.label5.Size = new Size(59, 19);
			this.label5.TabIndex = 44;
			this.label5.Text = "Height:";
			this.label5.TextAlign = ContentAlignment.MiddleCenter;
			this.label4.AutoSize = true;
			this.label4.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(168, 18);
			this.label4.Name = "label4";
			this.label4.Size = new Size(54, 19);
			this.label4.TabIndex = 43;
			this.label4.Text = "Width:";
			this.label4.TextAlign = ContentAlignment.MiddleCenter;
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(44, 44);
			this.label1.Name = "label1";
			this.label1.Size = new Size(43, 19);
			this.label1.TabIndex = 42;
			this.label1.Text = "BPP:";
			this.label1.TextAlign = ContentAlignment.MiddleCenter;
			this.label7.AutoSize = true;
			this.label7.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label7.Location = new Point(6, 71);
			this.label7.Name = "label7";
			this.label7.Size = new Size(81, 19);
			this.label7.TabIndex = 41;
			this.label7.Text = "MipMaps:";
			this.label7.TextAlign = ContentAlignment.MiddleCenter;
			this.label3.AutoSize = true;
			this.label3.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label3.Location = new Point(25, 18);
			this.label3.Name = "label3";
			this.label3.Size = new Size(62, 19);
			this.label3.TabIndex = 40;
			this.label3.Text = "Format:";
			this.label3.TextAlign = ContentAlignment.MiddleCenter;
			this.HeightTxt.Location = new Point(228, 45);
			this.HeightTxt.Name = "HeightTxt";
			this.HeightTxt.ReadOnly = true;
			this.HeightTxt.Size = new Size(53, 20);
			this.HeightTxt.TabIndex = 13;
			this.FormatTxt.Location = new Point(93, 19);
			this.FormatTxt.Name = "FormatTxt";
			this.FormatTxt.ReadOnly = true;
			this.FormatTxt.Size = new Size(64, 20);
			this.FormatTxt.TabIndex = 11;
			this.WidthTxt.Location = new Point(228, 19);
			this.WidthTxt.Name = "WidthTxt";
			this.WidthTxt.ReadOnly = true;
			this.WidthTxt.Size = new Size(53, 20);
			this.WidthTxt.TabIndex = 5;
			this.MipMapTxt.Location = new Point(93, 72);
			this.MipMapTxt.Name = "MipMapTxt";
			this.MipMapTxt.ReadOnly = true;
			this.MipMapTxt.Size = new Size(38, 20);
			this.MipMapTxt.TabIndex = 3;
			this.BPPTxt.Location = new Point(93, 45);
			this.BPPTxt.Name = "BPPTxt";
			this.BPPTxt.ReadOnly = true;
			this.BPPTxt.Size = new Size(64, 20);
			this.BPPTxt.TabIndex = 2;
			this.ImgList.Dock = DockStyle.Fill;
			this.ImgList.FormattingEnabled = true;
			this.ImgList.IntegralHeight = false;
			this.ImgList.Location = new Point(3, 3);
			this.ImgList.Name = "ImgList";
			this.ImgList.Size = new Size(76, 446);
			this.ImgList.TabIndex = 9;
			this.ImgList.SelectedIndexChanged += new EventHandler(this.ImgList_SelectedIndexChanged);
			this.DataFolder_TreeView.Dock = DockStyle.Fill;
			this.DataFolder_TreeView.Location = new Point(0, 0);
			this.DataFolder_TreeView.Name = "DataFolder_TreeView";
			this.DataFolder_TreeView.Size = new Size(230, 545);
			this.DataFolder_TreeView.TabIndex = 10;
			this.DataFolder_TreeView.DoubleClick += new EventHandler(this.DataFolder_TreeView_DoubleClick);
			this.RebuildBtn.Dock = DockStyle.Fill;
			this.RebuildBtn.Enabled = false;
			this.RebuildBtn.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.RebuildBtn.Location = new Point(3, 3);
			this.RebuildBtn.Name = "RebuildBtn";
			this.RebuildBtn.Size = new Size(246, 100);
			this.RebuildBtn.TabIndex = 46;
			this.RebuildBtn.Text = "Rebuild Container";
			this.RebuildBtn.UseVisualStyleBackColor = true;
			this.RebuildBtn.Click += new EventHandler(this.RebuildBtn_Click);
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 236f));
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.TreeViewContainer, 0, 0);
			this.tableLayoutPanel1.Dock = DockStyle.Fill;
			this.tableLayoutPanel1.Location = new Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel1.Size = new Size(794, 576);
			this.tableLayoutPanel1.TabIndex = 47;
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
			this.tableLayoutPanel2.Dock = DockStyle.Fill;
			this.tableLayoutPanel2.Location = new Point(239, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 112f));
			this.tableLayoutPanel2.Size = new Size(552, 570);
			this.tableLayoutPanel2.TabIndex = 0;
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel3.Controls.Add(this.RebuildBtn, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.ImageInfoBox, 1, 0);
			this.tableLayoutPanel3.Dock = DockStyle.Fill;
			this.tableLayoutPanel3.Location = new Point(3, 461);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel3.Size = new Size(546, 106);
			this.tableLayoutPanel3.TabIndex = 0;
			this.tableLayoutPanel4.ColumnCount = 2;
			this.tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 82f));
			this.tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel4.Controls.Add(this.ImgList, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.ImagePreviewBox, 1, 0);
			this.tableLayoutPanel4.Dock = DockStyle.Fill;
			this.tableLayoutPanel4.Location = new Point(3, 3);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel4.Size = new Size(546, 452);
			this.tableLayoutPanel4.TabIndex = 1;
			this.TreeViewContainer.BottomToolStripPanelVisible = false;
			this.TreeViewContainer.ContentPanel.Controls.Add(this.DataFolder_TreeView);
			this.TreeViewContainer.ContentPanel.Size = new Size(230, 545);
			this.TreeViewContainer.Dock = DockStyle.Fill;
			this.TreeViewContainer.LeftToolStripPanelVisible = false;
			this.TreeViewContainer.Location = new Point(3, 3);
			this.TreeViewContainer.Name = "TreeViewContainer";
			this.TreeViewContainer.RightToolStripPanelVisible = false;
			this.TreeViewContainer.Size = new Size(230, 570);
			this.TreeViewContainer.TabIndex = 11;
			this.TreeViewContainer.Text = "toolStripContainer1";
			this.TreeViewContainer.TopToolStripPanel.Controls.Add(this.Search_ToolStrip);
			this.Search_ToolStrip.Dock = DockStyle.None;
			this.Search_ToolStrip.GripStyle = ToolStripGripStyle.Hidden;
			this.Search_ToolStrip.Items.AddRange(new ToolStripItem[]
			{
				this.Search_TxtBox,
				this.Search_Btn,
				this.PrevSearch_Btn,
				this.NextSearch_Btn,
				this.SearchPos_Lbl
			});
			this.Search_ToolStrip.Location = new Point(0, 0);
			this.Search_ToolStrip.Name = "Search_ToolStrip";
			this.Search_ToolStrip.Size = new Size(230, 25);
			this.Search_ToolStrip.Stretch = true;
			this.Search_ToolStrip.TabIndex = 0;
			this.Search_TxtBox.Name = "Search_TxtBox";
			this.Search_TxtBox.Size = new Size(70, 25);
			this.PrevSearch_Btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
			this.PrevSearch_Btn.Image = (Image)componentResourceManager.GetObject("PrevSearch_Btn.Image");
			this.PrevSearch_Btn.ImageTransparentColor = Color.Magenta;
			this.PrevSearch_Btn.Name = "PrevSearch_Btn";
			this.PrevSearch_Btn.Size = new Size(34, 22);
			this.PrevSearch_Btn.Text = "Prev";
			this.PrevSearch_Btn.Click += new EventHandler(this.PrevSearch_Btn_Click);
			this.NextSearch_Btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
			this.NextSearch_Btn.Image = (Image)componentResourceManager.GetObject("NextSearch_Btn.Image");
			this.NextSearch_Btn.ImageTransparentColor = Color.Magenta;
			this.NextSearch_Btn.Name = "NextSearch_Btn";
			this.NextSearch_Btn.Size = new Size(35, 22);
			this.NextSearch_Btn.Text = "Next";
			this.NextSearch_Btn.Click += new EventHandler(this.NextSearch_Btn_Click);
			this.SearchPos_Lbl.Name = "SearchPos_Lbl";
			this.SearchPos_Lbl.Size = new Size(24, 22);
			this.SearchPos_Lbl.Text = "0/0";
			this.Search_Btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
			this.Search_Btn.Image = (Image)componentResourceManager.GetObject("Search_Btn.Image");
			this.Search_Btn.ImageTransparentColor = Color.Magenta;
			this.Search_Btn.Name = "Search_Btn";
			this.Search_Btn.Size = new Size(46, 22);
			this.Search_Btn.Text = "Search";
			this.Search_Btn.Click += new EventHandler(this.Search_Btn_Click);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(794, 576);
			base.Controls.Add(this.tableLayoutPanel1);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "TexExplorer";
			this.Text = "Texture Explorer";
			((ISupportInitialize)this.ImagePreviewBox).EndInit();
			this.ImageInfoBox.ResumeLayout(false);
			this.ImageInfoBox.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel4.ResumeLayout(false);
			this.TreeViewContainer.ContentPanel.ResumeLayout(false);
			this.TreeViewContainer.TopToolStripPanel.ResumeLayout(false);
			this.TreeViewContainer.TopToolStripPanel.PerformLayout();
			this.TreeViewContainer.ResumeLayout(false);
			this.TreeViewContainer.PerformLayout();
			this.Search_ToolStrip.ResumeLayout(false);
			this.Search_ToolStrip.PerformLayout();
			base.ResumeLayout(false);
		}

		public TexExplorer(string string_2)
		{
			this.InitializeComponent();
			this.string_0 = string_2;
			base.Closed += new EventHandler(this.TexExplorer_Closed);
			this.Text = "Texture Explorer - LOOKING FOR TEXTURES (PLEASE WAIT!)";
			Class321 @class = new Class321(this.string_0);
			@class.method_1(new Class321.Delegate9(this.UpdateSearchText));
			@class.method_0(new Class321.Delegate8(this.method_1));
			this.thread_0 = new Thread(new ThreadStart(@class.method_2));
			this.thread_0.Start();
		}

		private void TexExplorer_Closed(object sender, EventArgs e)
		{
			this.method_2();
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
				Class321.Delegate9 method = new Class321.Delegate9(this.UpdateSearchText);
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

		private void method_1(TreeNode treeNode_0)
		{
			if (base.InvokeRequired)
			{
				Class321.Delegate8 method = new Class321.Delegate8(this.method_1);
				base.Invoke(method, new object[]
				{
					treeNode_0
				});
				return;
			}
			this.DataFolder_TreeView.Nodes.Add(treeNode_0);
			this.Text = "Texture Explorer";
			this.DataFolder_TreeView.Sort();
		}

		private void method_2()
		{
			if (this._textureExplorer != null)
			{
				this._textureExplorer.Dispose();
				this._textureExplorer = null;
			}
			this.ImgList.Items.Clear();
			this.ImgList.SelectedIndex = -1;
			Control arg_49_0 = this.RebuildBtn;
			this.ImageInfoBox.Enabled = false;
			arg_49_0.Enabled = false;
			this.ImagePreviewBox.Image = null;
		}

		private void DataFolder_TreeView_DoubleClick(object sender, EventArgs e)
		{
			if (this.DataFolder_TreeView.SelectedNode != null)
			{
				if (this.DataFolder_TreeView.SelectedNode.Tag is int && this.DataFolder_TreeView.SelectedNode.ToolTipText != "")
				{
					this.method_2();
					string toolTipText = this.DataFolder_TreeView.SelectedNode.ToolTipText;
					zzPakNode2 @class;
					if (File.Exists(toolTipText.Replace(".pak.xen", ".pab.xen")))
					{
						@class = new zzPabNode(toolTipText, toolTipText.Replace(".pak.xen", ".pab.xen"), false);
					}
					else
					{
						@class = new zzPakNode2(toolTipText, false);
					}
					this._textureExplorer = new zzTextureExplorer1(@class.method_13((int)this.DataFolder_TreeView.SelectedNode.Tag));
					for (int i = 1; i <= this._textureExplorer.method_4(); i++)
					{
						this.ImgList.Items.Add("Image " + i);
					}
					@class.Dispose();
					return;
				}
				if (this.DataFolder_TreeView.SelectedNode.ToolTipText != "")
				{
					this.method_2();
					this._textureExplorer = new zzTextureExplorer1(this.DataFolder_TreeView.SelectedNode.ToolTipText);
					for (int j = 1; j <= this._textureExplorer.method_4(); j++)
					{
						this.ImgList.Items.Add("Image " + j);
					}
				}
			}
		}

		private void ImgList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.ImgList.SelectedIndex >= 0)
			{
				DDSClass1 @class = this._textureExplorer[this.ImgList.SelectedIndex];
				this.imgpixelFormat_0 = @class.imgpixelFormat_0;
				this.BPPTxt.Text = string.Concat(@class.int_0);
				this.FormatTxt.Text = ((@class.imgpixelFormat_0 == IMGPixelFormat.Dxt1) ? "DXT1" : ((@class.imgpixelFormat_0 == IMGPixelFormat.Dxt3) ? "DXT3" : ((@class.imgpixelFormat_0 == IMGPixelFormat.Dxt5) ? "DXT5" : "A8R8G8B8")));
				this.MipMapTxt.Text = string.Concat(@class.int_1);
				this.WidthTxt.Text = string.Concat(@class.size_0.Width);
				this.HeightTxt.Text = string.Concat(@class.size_0.Height);
				Image image = @class.method_1();
				this.size_0 = image.Size;
				if (image.Width > this.ImagePreviewBox.Width || image.Height > this.ImagePreviewBox.Height)
				{
					image = KeyGenerator.ScaleImageFixedRatio(image, ImagePreviewBox.Size);
				}
				this.ImagePreviewBox.Image = image;
				this.ImageInfoBox.Enabled = true;
				return;
			}
			this.ImageInfoBox.Enabled = false;
		}

		private void ReplaceImgBtn_Click(object sender, EventArgs e)
		{
			string text = KeyGenerator.smethod_16("Select the image file to replace the texture.", "All Supported Formats|*.dds;*.bmp;*.jpg;*.gif;*.png|DDS Texture|*.dds|Bitmap|*.bmp|JPEG|*.jpg|Graphics Interchange Format|*.gif|Portable Network Graphics|*.png", true);
			if (text == "")
			{
				return;
			}
			Image image;
			if (text.EndsWith(".dds", StringComparison.OrdinalIgnoreCase))
			{
				image = new DDSClass1(text).method_1();
			}
			else
			{
				image = Image.FromFile(text);
			}
			if (!image.Size.Equals(this.size_0) && DialogResult.Yes == MessageBox.Show("The image dimensions don't match. Do you wish scale to the original dimension? (Ratio may change!)", "Replace Texture", MessageBoxButtons.YesNo))
			{
				image = KeyGenerator.ScaleImage(image, this.size_0);
			}
			this._textureExplorer.method_1(this.ImgList.SelectedIndex, image, this.imgpixelFormat_0);
			this.RebuildBtn.Enabled = true;
		}

		public ImageFormat GetImageFormat(string fileName)
		{
			string a;
			if ((a = KeyGenerator.smethod_14(fileName, 1).ToLower()) != null)
			{
				if (a == "jpg")
				{
					return ImageFormat.Jpeg;
				}
				if (a == "gif")
				{
					return ImageFormat.Gif;
				}
				if (a == "png")
				{
					return ImageFormat.Png;
				}
			}
			return ImageFormat.Bmp;
		}

		private void ExtractImgBtn_Click(object sender, EventArgs e)
		{
			string text = KeyGenerator.smethod_16("Select location to export the texture.", "All Supported Formats|*.dds;*.bmp;*.jpg;*.gif;*.png|DDS Texture|*.dds|Bitmap|*.bmp|JPEG|*.jpg|Graphics Interchange Format|*.gif|Portable Network Graphics|*.png", false);
			if (text == "")
			{
				return;
			}
			if (text.EndsWith(".dds", StringComparison.OrdinalIgnoreCase))
			{
				this._textureExplorer.method_3(this.ImgList.SelectedIndex, text);
				return;
			}
			this._textureExplorer[this.ImgList.SelectedIndex].method_1().Save(text, this.GetImageFormat(text));
		}

		private void RebuildBtn_Click(object sender, EventArgs e)
		{
			if (DialogResult.Yes != MessageBox.Show("Are you sure you wish to rebuild the container? (Overwriting File!)", "Replace Textures", MessageBoxButtons.YesNo))
			{
				return;
			}
			if (this._textureExplorer.method_5())
			{
				this._textureExplorer.method_6();
			}
			else
			{
				string toolTipText = this.DataFolder_TreeView.SelectedNode.ToolTipText;
				zzPakNode2 @class = File.Exists(toolTipText.Replace(".pak.xen", ".pab.xen")) ? new zzPabNode(toolTipText, toolTipText.Replace(".pak.xen", ".pab.xen"), false) : new zzPakNode2(toolTipText, false);
				@class.method_11((int)this.DataFolder_TreeView.SelectedNode.Tag).imethod_17(this._textureExplorer.method_7().method_1());
				@class.vmethod_1();
				@class.Dispose();
			}
			this.ImgList.Items.Clear();
			this.method_2();
		}

		private void NextSearch_Btn_Click(object sender, EventArgs e)
		{
			if (this.DataFolder_TreeView.SelectedNode == null)
			{
				return;
			}
			if (this.Search_TxtBox.Text.Equals(""))
			{
				foreach (TreeNode current in this.list_0)
				{
					current.BackColor = Color.Empty;
				}
				this.list_0.Clear();
				this.string_1 = "";
				this.SearchPos_Lbl.Text = "0/0";
				return;
			}
			if (!this.Search_TxtBox.Text.Equals(this.string_1))
			{
				foreach (TreeNode current2 in this.list_0)
				{
					current2.BackColor = Color.Transparent;
				}
				this.list_0.Clear();
				this.string_1 = this.Search_TxtBox.Text;
			}
			if (this.list_0.Count == 0)
			{
				if (!this.method_4())
				{
					MessageBox.Show("Value not found!");
					this.SearchPos_Lbl.Text = "0/0";
					return;
				}
				this.int_0 = -1;
			}
			this.int_0++;
			TreeView arg_170_0 = this.DataFolder_TreeView;
			List<TreeNode> arg_16B_0 = this.list_0;
			int arg_16B_1;
			if (this.list_0.Count <= this.int_0)
			{
				this.int_0 = 0;
				arg_16B_1 = 0;
			}
			else
			{
				arg_16B_1 = this.int_0;
			}
			arg_170_0.SelectedNode = arg_16B_0[arg_16B_1];
			this.SearchPos_Lbl.Text = this.int_0 + 1 + "/" + this.list_0.Count;
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
				foreach (TreeNode current in this.list_0)
				{
					current.BackColor = Color.Empty;
				}
				this.list_0.Clear();
				this.string_1 = "";
				this.SearchPos_Lbl.Text = "0/0";
				return;
			}
			if (!this.Search_TxtBox.Text.Equals(this.string_1))
			{
				foreach (TreeNode current2 in this.list_0)
				{
					current2.BackColor = Color.Empty;
				}
				this.list_0.Clear();
				this.string_1 = this.Search_TxtBox.Text;
			}
			if (this.list_0.Count == 0)
			{
				if (!this.method_4())
				{
					MessageBox.Show("Value not found!");
					this.SearchPos_Lbl.Text = "0/0";
					return;
				}
				this.int_0 = this.list_0.Count;
			}
			this.int_0--;
			this.DataFolder_TreeView.SelectedNode = this.list_0[(0 <= this.int_0) ? this.int_0 : (this.int_0 = this.list_0.Count - 1)];
			this.SearchPos_Lbl.Text = this.int_0 + 1 + "/" + this.list_0.Count;
			this.DataFolder_TreeView.Focus();
		}

		private void Search_Btn_Click(object sender, EventArgs e)
		{
			if (this.DataFolder_TreeView.SelectedNode == null)
			{
				return;
			}
			foreach (TreeNode current in this.list_0)
			{
				current.BackColor = Color.Empty;
			}
			this.list_0.Clear();
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
			this.int_0 = 0;
			this.DataFolder_TreeView.SelectedNode = this.list_0[this.int_0];
			this.SearchPos_Lbl.Text = this.int_0 + 1 + "/" + this.list_0.Count;
			this.DataFolder_TreeView.Focus();
		}

		private bool method_4()
		{
			TexExplorer.smethod_0(this.DataFolder_TreeView.SelectedNode, this.string_1, this.list_0);
			foreach (TreeNode current in this.list_0)
			{
				current.BackColor = Color.YellowGreen;
			}
			return this.list_0.Count != 0;
		}

		private static void smethod_0(TreeNode treeNode_0, string string_2, ICollection<TreeNode> icollection_0)
		{
			if (treeNode_0.Text.ToUpper().Contains(string_2.ToUpper()))
			{
				icollection_0.Add(treeNode_0);
			}
			for (int i = 0; i < treeNode_0.Nodes.Count; i++)
			{
				TexExplorer.smethod_0(treeNode_0.Nodes[i], string_2, icollection_0);
			}
		}
	}
}
