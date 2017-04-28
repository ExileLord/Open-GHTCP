using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ns14;

namespace ns16
{
	public class ActionsWindow : Form
	{
		private delegate void Delegate7(object sender, EventArgs0 e);

		private readonly ActionList actionList;

		private EventHandler eventHandler_0;

		public bool bool_0;

		private Thread thread_0;

		private IContainer icontainer_0;

		private RichTextBox ActionsTxt;

		private SplitContainer splitContainer1;

		private Button CloseBtn;

		private Button ViewLogBtn;

		private ProgressBar progressBar;

		public ActionsWindow(List<QbEditor> listOfActions)
		{
			InitializeComponent();
			actionList = new ActionList(listOfActions);
			actionList.method_0(method_2);
			ActionsTxt.Text = "";
		}

		public void method_0(EventHandler eventHandler_1)
		{
			var eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				var value = (EventHandler)Delegate.Combine(eventHandler2, eventHandler_1);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}

		public void method_1()
		{
			thread_0 = new Thread(actionList.method_1);
			thread_0.CurrentCulture = Thread.CurrentThread.CurrentCulture;
			thread_0.CurrentUICulture = Thread.CurrentThread.CurrentUICulture;
			thread_0.Start();
		}

		private void method_2(object sender, EventArgs0 e)
		{
			if (InvokeRequired)
			{
				Delegate7 method = method_2;
				Invoke(method, sender, e);
				return;
			}
			var expr_34 = ActionsTxt;
			expr_34.Text += e.method_0();
			ActionsTxt.ScrollToCaret();
			progressBar.Value = e.method_1();
			if (e.method_0().StartsWith("FAILED"))
			{
				bool_0 = true;
			}
			if (e.method_1() == 100)
			{
				Control arg_9C_0 = CloseBtn;
				ViewLogBtn.Enabled = true;
				arg_9C_0.Enabled = true;
				eventHandler_0(this, EventArgs.Empty);
			}
		}

		private void CloseBtn_Click(object sender, EventArgs e)
		{
			if (thread_0 != null)
			{
				thread_0.Abort();
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
			ActionsTxt = new RichTextBox();
			splitContainer1 = new SplitContainer();
			ViewLogBtn = new Button();
			CloseBtn = new Button();
			progressBar = new ProgressBar();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			SuspendLayout();
			ActionsTxt.Dock = DockStyle.Fill;
			ActionsTxt.Location = new Point(0, 0);
			ActionsTxt.Name = "ActionsTxt";
			ActionsTxt.ReadOnly = true;
			ActionsTxt.Size = new Size(338, 141);
			ActionsTxt.TabIndex = 0;
			ActionsTxt.Text = "";
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.IsSplitterFixed = true;
			splitContainer1.Location = new Point(0, 0);
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Orientation = Orientation.Horizontal;
			splitContainer1.Panel1.Controls.Add(ActionsTxt);
			splitContainer1.Panel2.Controls.Add(progressBar);
			splitContainer1.Panel2.Controls.Add(ViewLogBtn);
			splitContainer1.Panel2.Controls.Add(CloseBtn);
			splitContainer1.Size = new Size(338, 171);
			splitContainer1.SplitterDistance = 141;
			splitContainer1.TabIndex = 1;
			ViewLogBtn.Enabled = false;
			ViewLogBtn.Location = new Point(84, 2);
			ViewLogBtn.Name = "ViewLogBtn";
			ViewLogBtn.Size = new Size(75, 23);
			ViewLogBtn.TabIndex = 1;
			ViewLogBtn.Text = "View Log";
			ViewLogBtn.UseVisualStyleBackColor = true;
			ViewLogBtn.Click += ViewLogBtn_Click;
			CloseBtn.Enabled = false;
			CloseBtn.Location = new Point(3, 2);
			CloseBtn.Name = "CloseBtn";
			CloseBtn.Size = new Size(75, 23);
			CloseBtn.TabIndex = 0;
			CloseBtn.Text = "Close";
			CloseBtn.UseVisualStyleBackColor = true;
			CloseBtn.Click += CloseBtn_Click;
			progressBar.Location = new Point(165, 2);
			progressBar.Name = "progressBar";
			progressBar.Size = new Size(170, 23);
			progressBar.TabIndex = 2;
			AutoScaleDimensions = new SizeF(6f, 13f);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(338, 171);
			Controls.Add(splitContainer1);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "ActionsWindow";
			Text = "ExecuteActions";
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
