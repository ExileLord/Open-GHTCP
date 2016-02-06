using GuitarHero.Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ns15
{
	public class TierManagement : Form
	{
		private IContainer icontainer_0;

		private ListBox TierList;

		private Button CancelBtn;

		private Button btnOK;

		private int int_0;

		private int int_1;

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
			this.TierList = new ListBox();
			this.CancelBtn = new Button();
			this.btnOK = new Button();
			base.SuspendLayout();
			this.TierList.AllowDrop = true;
			this.TierList.FormattingEnabled = true;
			this.TierList.IntegralHeight = false;
			this.TierList.Location = new Point(9, 9);
			this.TierList.Margin = new Padding(0);
			this.TierList.Name = "TierList";
			this.TierList.ScrollAlwaysVisible = true;
			this.TierList.Size = new Size(234, 179);
			this.TierList.TabIndex = 0;
			this.TierList.MouseDown += new MouseEventHandler(this.TierList_MouseDown);
			this.TierList.DragDrop += new DragEventHandler(this.TierList_DragDrop);
			this.TierList.DragEnter += new DragEventHandler(this.TierList_DragEnter);
			this.TierList.DragOver += new DragEventHandler(this.TierList_DragOver);
			this.CancelBtn.DialogResult = DialogResult.Cancel;
			this.CancelBtn.Location = new Point(168, 191);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new Size(75, 23);
			this.CancelBtn.TabIndex = 4;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			this.btnOK.DialogResult = DialogResult.OK;
			this.btnOK.Location = new Point(9, 191);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new Size(75, 23);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(252, 219);
			base.Controls.Add(this.CancelBtn);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.TierList);
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "TierManagement";
			this.Text = "Tier Management";
			base.ResumeLayout(false);
		}

		public TierManagement(string string_0, GH3Tier[] gh3Tier_0)
		{
			this.InitializeComponent();
			this.TierList.Items.AddRange(gh3Tier_0);
			this.Text = this.Text + " (" + string_0 + ")";
		}

		private void TierList_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Clicks != 2 || e.Button != MouseButtons.Left)
			{
				if (e.Clicks == 2 && e.Button == MouseButtons.Right)
				{
					int num = this.TierList.IndexFromPoint(e.X, e.Y);
					if (num >= 0 && num < this.TierList.Items.Count && 1 < this.TierList.Items.Count)
					{
						this.TierList.Items.RemoveAt(num);
					}
				}
				return;
			}
			int num2 = this.TierList.IndexFromPoint(e.X, e.Y);
			if (num2 >= 0 && num2 < this.TierList.Items.Count)
			{
				this.TierList.DoDragDrop(this.TierList.Items[this.int_0 = num2], DragDropEffects.Move);
				return;
			}
			this.TierList.Items.Add(new GH3Tier());
		}

		private void TierList_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(GH3Tier)))
			{
				e.Effect = DragDropEffects.Move;
			}
		}

		private void TierList_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(GH3Tier)))
			{
				this.TierList.Items.RemoveAt(this.int_0);
				if (this.int_1 >= 0 && this.int_1 < this.TierList.Items.Count)
				{
					this.TierList.Items.Insert(this.int_1, e.Data.GetData(typeof(GH3Tier)));
					this.TierList.SelectedIndex = this.int_1;
					return;
				}
				this.TierList.Items.Add(e.Data.GetData(typeof(GH3Tier)));
				this.TierList.SelectedIndex = this.TierList.Items.Count - 1;
			}
		}

		private void TierList_DragOver(object sender, DragEventArgs e)
		{
			this.int_1 = this.TierList.IndexFromPoint(this.TierList.PointToClient(new Point(e.X, e.Y)));
			this.TierList.SelectedIndex = this.int_1;
		}

		public GH3Tier[] method_0()
		{
			List<GH3Tier> list = new List<GH3Tier>();
			foreach (GH3Tier item in this.TierList.Items)
			{
				list.Add(item);
			}
			return list.ToArray();
		}
	}
}
