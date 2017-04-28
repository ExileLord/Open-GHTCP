using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using GHNamespace7;

namespace GHNamespace9
{
    public class ActionsWindow : Form
    {
        private delegate void Delegate7(object sender, EventArgs0 e);

        private readonly ActionList _actionList;

        private EventHandler _eventHandler0;

        public bool Bool0;

        private Thread _thread0;

        private IContainer icontainer_0;

        private RichTextBox _actionsTxt;

        private SplitContainer _splitContainer1;

        private Button _closeBtn;

        private Button _viewLogBtn;

        private ProgressBar _progressBar;

        public ActionsWindow(List<QbEditor> listOfActions)
        {
            InitializeComponent();
            _actionList = new ActionList(listOfActions);
            _actionList.method_0(method_2);
            _actionsTxt.Text = "";
        }

        public void method_0(EventHandler eventHandler1)
        {
            var eventHandler = _eventHandler0;
            EventHandler eventHandler2;
            do
            {
                eventHandler2 = eventHandler;
                var value = (EventHandler) Delegate.Combine(eventHandler2, eventHandler1);
                eventHandler = Interlocked.CompareExchange(ref _eventHandler0, value, eventHandler2);
            } while (eventHandler != eventHandler2);
        }

        public void method_1()
        {
            _thread0 = new Thread(_actionList.method_1);
            _thread0.CurrentCulture = Thread.CurrentThread.CurrentCulture;
            _thread0.CurrentUICulture = Thread.CurrentThread.CurrentUICulture;
            _thread0.Start();
        }

        private void method_2(object sender, EventArgs0 e)
        {
            if (InvokeRequired)
            {
                Delegate7 method = method_2;
                Invoke(method, sender, e);
                return;
            }
            var expr34 = _actionsTxt;
            expr34.Text += e.method_0();
            _actionsTxt.ScrollToCaret();
            _progressBar.Value = e.method_1();
            if (e.method_0().StartsWith("FAILED"))
            {
                Bool0 = true;
            }
            if (e.method_1() == 100)
            {
                Control arg_9C0 = _closeBtn;
                _viewLogBtn.Enabled = true;
                arg_9C0.Enabled = true;
                _eventHandler0(this, EventArgs.Empty);
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            if (_thread0 != null)
            {
                _thread0.Abort();
            }
            Close();
            base.Dispose();
        }

        private void ViewLogBtn_Click(object sender, EventArgs e)
        {
            new ViewLog().ShowDialog();
        }

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
            _actionsTxt = new RichTextBox();
            _splitContainer1 = new SplitContainer();
            _viewLogBtn = new Button();
            _closeBtn = new Button();
            _progressBar = new ProgressBar();
            _splitContainer1.Panel1.SuspendLayout();
            _splitContainer1.Panel2.SuspendLayout();
            _splitContainer1.SuspendLayout();
            SuspendLayout();
            _actionsTxt.Dock = DockStyle.Fill;
            _actionsTxt.Location = new Point(0, 0);
            _actionsTxt.Name = "_actionsTxt";
            _actionsTxt.ReadOnly = true;
            _actionsTxt.Size = new Size(338, 141);
            _actionsTxt.TabIndex = 0;
            _actionsTxt.Text = "";
            _splitContainer1.Dock = DockStyle.Fill;
            _splitContainer1.IsSplitterFixed = true;
            _splitContainer1.Location = new Point(0, 0);
            _splitContainer1.Name = "_splitContainer1";
            _splitContainer1.Orientation = Orientation.Horizontal;
            _splitContainer1.Panel1.Controls.Add(_actionsTxt);
            _splitContainer1.Panel2.Controls.Add(_progressBar);
            _splitContainer1.Panel2.Controls.Add(_viewLogBtn);
            _splitContainer1.Panel2.Controls.Add(_closeBtn);
            _splitContainer1.Size = new Size(338, 171);
            _splitContainer1.SplitterDistance = 141;
            _splitContainer1.TabIndex = 1;
            _viewLogBtn.Enabled = false;
            _viewLogBtn.Location = new Point(84, 2);
            _viewLogBtn.Name = "_viewLogBtn";
            _viewLogBtn.Size = new Size(75, 23);
            _viewLogBtn.TabIndex = 1;
            _viewLogBtn.Text = "View Log";
            _viewLogBtn.UseVisualStyleBackColor = true;
            _viewLogBtn.Click += ViewLogBtn_Click;
            _closeBtn.Enabled = false;
            _closeBtn.Location = new Point(3, 2);
            _closeBtn.Name = "_closeBtn";
            _closeBtn.Size = new Size(75, 23);
            _closeBtn.TabIndex = 0;
            _closeBtn.Text = "Close";
            _closeBtn.UseVisualStyleBackColor = true;
            _closeBtn.Click += CloseBtn_Click;
            _progressBar.Location = new Point(165, 2);
            _progressBar.Name = "_progressBar";
            _progressBar.Size = new Size(170, 23);
            _progressBar.TabIndex = 2;
            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 171);
            Controls.Add(_splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ActionsWindow";
            Text = "ExecuteActions";
            _splitContainer1.Panel1.ResumeLayout(false);
            _splitContainer1.Panel2.ResumeLayout(false);
            _splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}