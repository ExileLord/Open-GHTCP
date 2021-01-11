using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GuitarHero.Tier;

namespace GHNamespace8
{
    public class TierManagement : Form
    {
        private IContainer icontainer_0;

        private ListBox _tierList;

        private Button _cancelBtn;

        private Button _btnOk;

        private int _int0;

        private int _int1;

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
            _tierList = new ListBox();
            _cancelBtn = new Button();
            _btnOk = new Button();
            SuspendLayout();
            _tierList.AllowDrop = true;
            _tierList.FormattingEnabled = true;
            _tierList.IntegralHeight = false;
            _tierList.Location = new Point(9, 9);
            _tierList.Margin = new Padding(0);
            _tierList.Name = "_tierList";
            _tierList.ScrollAlwaysVisible = true;
            _tierList.Size = new Size(234, 179);
            _tierList.TabIndex = 0;
            _tierList.MouseDown += TierList_MouseDown;
            _tierList.DragDrop += TierList_DragDrop;
            _tierList.DragEnter += TierList_DragEnter;
            _tierList.DragOver += TierList_DragOver;
            _cancelBtn.DialogResult = DialogResult.Cancel;
            _cancelBtn.Location = new Point(168, 191);
            _cancelBtn.Name = "_cancelBtn";
            _cancelBtn.Size = new Size(75, 23);
            _cancelBtn.TabIndex = 4;
            _cancelBtn.Text = "Cancel";
            _cancelBtn.UseVisualStyleBackColor = true;
            _btnOk.DialogResult = DialogResult.OK;
            _btnOk.Location = new Point(9, 191);
            _btnOk.Name = "_btnOk";
            _btnOk.Size = new Size(75, 23);
            _btnOk.TabIndex = 3;
            _btnOk.Text = "OK";
            _btnOk.UseVisualStyleBackColor = true;
            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(252, 219);
            Controls.Add(_cancelBtn);
            Controls.Add(_btnOk);
            Controls.Add(_tierList);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TierManagement";
            Text = "Tier Management";
            ResumeLayout(false);
        }

        public TierManagement(string string0, Gh3Tier[] gh3Tier0)
        {
            InitializeComponent();
            _tierList.Items.AddRange(gh3Tier0);
            Text = Text + " (" + string0 + ")";
        }

        private void TierList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks != 2 || e.Button != MouseButtons.Left)
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Right)
                {
                    int num = _tierList.IndexFromPoint(e.X, e.Y);
                    if (num >= 0 && num < _tierList.Items.Count && 1 < _tierList.Items.Count)
                    {
                        _tierList.Items.RemoveAt(num);
                    }
                }
                return;
            }
            int num2 = _tierList.IndexFromPoint(e.X, e.Y);
            if (num2 >= 0 && num2 < _tierList.Items.Count)
            {
                _tierList.DoDragDrop(_tierList.Items[_int0 = num2], DragDropEffects.Move);
                return;
            }
            _tierList.Items.Add(new Gh3Tier());
        }

        private void TierList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Gh3Tier)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void TierList_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Gh3Tier)))
            {
                _tierList.Items.RemoveAt(_int0);
                if (_int1 >= 0 && _int1 < _tierList.Items.Count)
                {
                    _tierList.Items.Insert(_int1, e.Data.GetData(typeof(Gh3Tier)));
                    _tierList.SelectedIndex = _int1;
                    return;
                }
                _tierList.Items.Add(e.Data.GetData(typeof(Gh3Tier)));
                _tierList.SelectedIndex = _tierList.Items.Count - 1;
            }
        }

        private void TierList_DragOver(object sender, DragEventArgs e)
        {
            _int1 = _tierList.IndexFromPoint(_tierList.PointToClient(new Point(e.X, e.Y)));
            _tierList.SelectedIndex = _int1;
        }

        public Gh3Tier[] method_0()
        {
            List<Gh3Tier> list = new List<Gh3Tier>();
            foreach (Gh3Tier item in _tierList.Items)
            {
                list.Add(item);
            }
            return list.ToArray();
        }
    }
}