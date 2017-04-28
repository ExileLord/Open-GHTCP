using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GHNamespace8
{
	public class LoadGameSettings : Form
	{
		private IContainer icontainer_0;

		private ListBox _listQb;

		private Button _okBtn;

		private Button _cancelBtn;

		private TextBox _editBox;

		private int _int0 = -1;

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
			_listQb = new ListBox();
			_okBtn = new Button();
			_cancelBtn = new Button();
			_editBox = new TextBox();
			SuspendLayout();
			_listQb.FormattingEnabled = true;
			_listQb.Location = new Point(12, 12);
			_listQb.Name = "_listQb";
			_listQb.Size = new Size(204, 82);
			_listQb.TabIndex = 0;
			_listQb.SelectedIndexChanged += listQB_SelectedIndexChanged;
			_listQb.DoubleClick += listQB_DoubleClick;
			_okBtn.DialogResult = DialogResult.OK;
			_okBtn.Enabled = false;
			_okBtn.Location = new Point(12, 100);
			_okBtn.Name = "_okBtn";
			_okBtn.Size = new Size(75, 23);
			_okBtn.TabIndex = 1;
			_okBtn.Text = "OK";
			_okBtn.UseVisualStyleBackColor = true;
			_cancelBtn.DialogResult = DialogResult.Cancel;
			_cancelBtn.Location = new Point(141, 100);
			_cancelBtn.Name = "_cancelBtn";
			_cancelBtn.Size = new Size(75, 23);
			_cancelBtn.TabIndex = 2;
			_cancelBtn.Text = "Cancel";
			_cancelBtn.UseVisualStyleBackColor = true;
			_editBox.BorderStyle = BorderStyle.FixedSingle;
			_editBox.Location = new Point(28, 12);
			_editBox.Name = "_editBox";
			_editBox.Size = new Size(168, 20);
			_editBox.TabIndex = 3;
			_editBox.Visible = false;
			AutoScaleDimensions = new SizeF(6f, 13f);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(228, 133);
			Controls.Add(_editBox);
			Controls.Add(_cancelBtn);
			Controls.Add(_okBtn);
			Controls.Add(_listQb);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "LoadGameSettings";
			Text = "Choose which game settings to load.";
			ResumeLayout(false);
			PerformLayout();
		}

		public LoadGameSettings(string[] string0)
		{
			InitializeComponent();
			method_1(string0);
		}

		private void listQB_DoubleClick(object sender, EventArgs e)
		{
			method_0();
		}

		private void method_0()
		{
			_int0 = _listQb.SelectedIndex;
			if (_int0 < 0)
			{
				return;
			}
			var itemRectangle = _listQb.GetItemRectangle(_int0);
			var text = (string)_listQb.Items[_int0];
			_editBox.Location = new Point(itemRectangle.X + 30, itemRectangle.Y + 10);
			_editBox.Show();
			_editBox.Text = text;
			_editBox.Focus();
			_editBox.SelectAll();
			_editBox.LostFocus += editBox_LostFocus;
		}

		private void editBox_LostFocus(object sender, EventArgs e)
		{
			_listQb.Items[_int0] = _editBox.Text;
			_editBox.Hide();
		}

		public void method_1(string[] string0)
		{
			_listQb.Items.AddRange(string0);
		}

		public string[] method_2()
		{
			var array = new string[_listQb.Items.Count];
			_listQb.Items.CopyTo(array, 0);
			return array;
		}

		public int method_3()
		{
			return _listQb.SelectedIndex;
		}

		private void listQB_SelectedIndexChanged(object sender, EventArgs e)
		{
			_okBtn.Enabled = (_listQb.SelectedIndex > -1);
		}
	}
}
