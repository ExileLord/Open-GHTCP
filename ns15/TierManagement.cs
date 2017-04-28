using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GuitarHero.Tier;

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
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			TierList = new ListBox();
			CancelBtn = new Button();
			btnOK = new Button();
			SuspendLayout();
			TierList.AllowDrop = true;
			TierList.FormattingEnabled = true;
			TierList.IntegralHeight = false;
			TierList.Location = new Point(9, 9);
			TierList.Margin = new Padding(0);
			TierList.Name = "TierList";
			TierList.ScrollAlwaysVisible = true;
			TierList.Size = new Size(234, 179);
			TierList.TabIndex = 0;
			TierList.MouseDown += TierList_MouseDown;
			TierList.DragDrop += TierList_DragDrop;
			TierList.DragEnter += TierList_DragEnter;
			TierList.DragOver += TierList_DragOver;
			CancelBtn.DialogResult = DialogResult.Cancel;
			CancelBtn.Location = new Point(168, 191);
			CancelBtn.Name = "CancelBtn";
			CancelBtn.Size = new Size(75, 23);
			CancelBtn.TabIndex = 4;
			CancelBtn.Text = "Cancel";
			CancelBtn.UseVisualStyleBackColor = true;
			btnOK.DialogResult = DialogResult.OK;
			btnOK.Location = new Point(9, 191);
			btnOK.Name = "btnOK";
			btnOK.Size = new Size(75, 23);
			btnOK.TabIndex = 3;
			btnOK.Text = "OK";
			btnOK.UseVisualStyleBackColor = true;
			AutoScaleDimensions = new SizeF(6f, 13f);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(252, 219);
			Controls.Add(CancelBtn);
			Controls.Add(btnOK);
			Controls.Add(TierList);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "TierManagement";
			Text = "Tier Management";
			ResumeLayout(false);
		}

		public TierManagement(string string_0, GH3Tier[] gh3Tier_0)
		{
			InitializeComponent();
			TierList.Items.AddRange(gh3Tier_0);
			Text = Text + " (" + string_0 + ")";
		}

		private void TierList_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Clicks != 2 || e.Button != MouseButtons.Left)
			{
				if (e.Clicks == 2 && e.Button == MouseButtons.Right)
				{
					var num = TierList.IndexFromPoint(e.X, e.Y);
					if (num >= 0 && num < TierList.Items.Count && 1 < TierList.Items.Count)
					{
						TierList.Items.RemoveAt(num);
					}
				}
				return;
			}
			var num2 = TierList.IndexFromPoint(e.X, e.Y);
			if (num2 >= 0 && num2 < TierList.Items.Count)
			{
				TierList.DoDragDrop(TierList.Items[int_0 = num2], DragDropEffects.Move);
				return;
			}
			TierList.Items.Add(new GH3Tier());
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
				TierList.Items.RemoveAt(int_0);
				if (int_1 >= 0 && int_1 < TierList.Items.Count)
				{
					TierList.Items.Insert(int_1, e.Data.GetData(typeof(GH3Tier)));
					TierList.SelectedIndex = int_1;
					return;
				}
				TierList.Items.Add(e.Data.GetData(typeof(GH3Tier)));
				TierList.SelectedIndex = TierList.Items.Count - 1;
			}
		}

		private void TierList_DragOver(object sender, DragEventArgs e)
		{
			int_1 = TierList.IndexFromPoint(TierList.PointToClient(new Point(e.X, e.Y)));
			TierList.SelectedIndex = int_1;
		}

		public GH3Tier[] method_0()
		{
			var list = new List<GH3Tier>();
			foreach (GH3Tier item in TierList.Items)
			{
				list.Add(item);
			}
			return list.ToArray();
		}
	}
}
