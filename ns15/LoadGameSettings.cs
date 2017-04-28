using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ns15
{
	public class LoadGameSettings : Form
	{
		private IContainer icontainer_0;

		private ListBox listQB;

		private Button OK_Btn;

		private Button Cancel_Btn;

		private TextBox editBox;

		private int int_0 = -1;

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
			listQB = new ListBox();
			OK_Btn = new Button();
			Cancel_Btn = new Button();
			editBox = new TextBox();
			SuspendLayout();
			listQB.FormattingEnabled = true;
			listQB.Location = new Point(12, 12);
			listQB.Name = "listQB";
			listQB.Size = new Size(204, 82);
			listQB.TabIndex = 0;
			listQB.SelectedIndexChanged += listQB_SelectedIndexChanged;
			listQB.DoubleClick += listQB_DoubleClick;
			OK_Btn.DialogResult = DialogResult.OK;
			OK_Btn.Enabled = false;
			OK_Btn.Location = new Point(12, 100);
			OK_Btn.Name = "OK_Btn";
			OK_Btn.Size = new Size(75, 23);
			OK_Btn.TabIndex = 1;
			OK_Btn.Text = "OK";
			OK_Btn.UseVisualStyleBackColor = true;
			Cancel_Btn.DialogResult = DialogResult.Cancel;
			Cancel_Btn.Location = new Point(141, 100);
			Cancel_Btn.Name = "Cancel_Btn";
			Cancel_Btn.Size = new Size(75, 23);
			Cancel_Btn.TabIndex = 2;
			Cancel_Btn.Text = "Cancel";
			Cancel_Btn.UseVisualStyleBackColor = true;
			editBox.BorderStyle = BorderStyle.FixedSingle;
			editBox.Location = new Point(28, 12);
			editBox.Name = "editBox";
			editBox.Size = new Size(168, 20);
			editBox.TabIndex = 3;
			editBox.Visible = false;
			AutoScaleDimensions = new SizeF(6f, 13f);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(228, 133);
			Controls.Add(editBox);
			Controls.Add(Cancel_Btn);
			Controls.Add(OK_Btn);
			Controls.Add(listQB);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "LoadGameSettings";
			Text = "Choose which game settings to load.";
			ResumeLayout(false);
			PerformLayout();
		}

		public LoadGameSettings(string[] string_0)
		{
			InitializeComponent();
			method_1(string_0);
		}

		private void listQB_DoubleClick(object sender, EventArgs e)
		{
			method_0();
		}

		private void method_0()
		{
			int_0 = listQB.SelectedIndex;
			if (int_0 < 0)
			{
				return;
			}
			Rectangle itemRectangle = listQB.GetItemRectangle(int_0);
			string text = (string)listQB.Items[int_0];
			editBox.Location = new Point(itemRectangle.X + 30, itemRectangle.Y + 10);
			editBox.Show();
			editBox.Text = text;
			editBox.Focus();
			editBox.SelectAll();
			editBox.LostFocus += editBox_LostFocus;
		}

		private void editBox_LostFocus(object sender, EventArgs e)
		{
			listQB.Items[int_0] = editBox.Text;
			editBox.Hide();
		}

		public void method_1(string[] string_0)
		{
			listQB.Items.AddRange(string_0);
		}

		public string[] method_2()
		{
			string[] array = new string[listQB.Items.Count];
			listQB.Items.CopyTo(array, 0);
			return array;
		}

		public int method_3()
		{
			return listQB.SelectedIndex;
		}

		private void listQB_SelectedIndexChanged(object sender, EventArgs e)
		{
			OK_Btn.Enabled = (listQB.SelectedIndex > -1);
		}
	}
}
