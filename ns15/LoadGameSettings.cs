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
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.listQB = new ListBox();
			this.OK_Btn = new Button();
			this.Cancel_Btn = new Button();
			this.editBox = new TextBox();
			base.SuspendLayout();
			this.listQB.FormattingEnabled = true;
			this.listQB.Location = new Point(12, 12);
			this.listQB.Name = "listQB";
			this.listQB.Size = new Size(204, 82);
			this.listQB.TabIndex = 0;
			this.listQB.SelectedIndexChanged += new EventHandler(this.listQB_SelectedIndexChanged);
			this.listQB.DoubleClick += new EventHandler(this.listQB_DoubleClick);
			this.OK_Btn.DialogResult = DialogResult.OK;
			this.OK_Btn.Enabled = false;
			this.OK_Btn.Location = new Point(12, 100);
			this.OK_Btn.Name = "OK_Btn";
			this.OK_Btn.Size = new Size(75, 23);
			this.OK_Btn.TabIndex = 1;
			this.OK_Btn.Text = "OK";
			this.OK_Btn.UseVisualStyleBackColor = true;
			this.Cancel_Btn.DialogResult = DialogResult.Cancel;
			this.Cancel_Btn.Location = new Point(141, 100);
			this.Cancel_Btn.Name = "Cancel_Btn";
			this.Cancel_Btn.Size = new Size(75, 23);
			this.Cancel_Btn.TabIndex = 2;
			this.Cancel_Btn.Text = "Cancel";
			this.Cancel_Btn.UseVisualStyleBackColor = true;
			this.editBox.BorderStyle = BorderStyle.FixedSingle;
			this.editBox.Location = new Point(28, 12);
			this.editBox.Name = "editBox";
			this.editBox.Size = new Size(168, 20);
			this.editBox.TabIndex = 3;
			this.editBox.Visible = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(228, 133);
			base.Controls.Add(this.editBox);
			base.Controls.Add(this.Cancel_Btn);
			base.Controls.Add(this.OK_Btn);
			base.Controls.Add(this.listQB);
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "LoadGameSettings";
			this.Text = "Choose which game settings to load.";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public LoadGameSettings(string[] string_0)
		{
			this.InitializeComponent();
			this.method_1(string_0);
		}

		private void listQB_DoubleClick(object sender, EventArgs e)
		{
			this.method_0();
		}

		private void method_0()
		{
			this.int_0 = this.listQB.SelectedIndex;
			if (this.int_0 < 0)
			{
				return;
			}
			Rectangle itemRectangle = this.listQB.GetItemRectangle(this.int_0);
			string text = (string)this.listQB.Items[this.int_0];
			this.editBox.Location = new Point(itemRectangle.X + 30, itemRectangle.Y + 10);
			this.editBox.Show();
			this.editBox.Text = text;
			this.editBox.Focus();
			this.editBox.SelectAll();
			this.editBox.LostFocus += new EventHandler(this.editBox_LostFocus);
		}

		private void editBox_LostFocus(object sender, EventArgs e)
		{
			this.listQB.Items[this.int_0] = this.editBox.Text;
			this.editBox.Hide();
		}

		public void method_1(string[] string_0)
		{
			this.listQB.Items.AddRange(string_0);
		}

		public string[] method_2()
		{
			string[] array = new string[this.listQB.Items.Count];
			this.listQB.Items.CopyTo(array, 0);
			return array;
		}

		public int method_3()
		{
			return this.listQB.SelectedIndex;
		}

		private void listQB_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.OK_Btn.Enabled = (this.listQB.SelectedIndex > -1);
		}
	}
}
