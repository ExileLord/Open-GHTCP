using ns14;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ns16
{
	public class ActionsWindow : Form
	{
		private delegate void Delegate7(object sender, EventArgs0 e);

		private Class232 class232_0;

		private EventHandler eventHandler_0;

		public bool bool_0;

		private Thread thread_0;

		private IContainer icontainer_0;

		private RichTextBox ActionsTxt;

		private SplitContainer splitContainer1;

		private Button CloseBtn;

		private Button ViewLogBtn;

		private ProgressBar progressBar;

		public ActionsWindow(List<Class245> list_0)
		{
			this.InitializeComponent();
			this.class232_0 = new Class232(list_0);
			this.class232_0.method_0(new Class232.Delegate6(this.method_2));
			this.ActionsTxt.Text = "";
		}

		public void method_0(EventHandler eventHandler_1)
		{
			EventHandler eventHandler = this.eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Combine(eventHandler2, eventHandler_1);
				eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, value, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}

		public void method_1()
		{
			this.thread_0 = new Thread(new ThreadStart(this.class232_0.method_1));
			this.thread_0.CurrentCulture = Thread.CurrentThread.CurrentCulture;
			this.thread_0.CurrentUICulture = Thread.CurrentThread.CurrentUICulture;
			this.thread_0.Start();
		}

		private void method_2(object sender, EventArgs0 e)
		{
			if (base.InvokeRequired)
			{
				ActionsWindow.Delegate7 method = new ActionsWindow.Delegate7(this.method_2);
				base.Invoke(method, new object[]
				{
					sender,
					e
				});
				return;
			}
			RichTextBox expr_34 = this.ActionsTxt;
			expr_34.Text += e.method_0();
			this.ActionsTxt.ScrollToCaret();
			this.progressBar.Value = e.method_1();
			if (e.method_0().StartsWith("FAILED"))
			{
				this.bool_0 = true;
			}
			if (e.method_1() == 100)
			{
				Control arg_9C_0 = this.CloseBtn;
				this.ViewLogBtn.Enabled = true;
				arg_9C_0.Enabled = true;
				this.eventHandler_0(this, EventArgs.Empty);
			}
		}

		private void CloseBtn_Click(object sender, EventArgs e)
		{
			if (this.thread_0 != null)
			{
				this.thread_0.Abort();
			}
			base.Close();
			base.Dispose();
		}

		private void ViewLogBtn_Click(object sender, EventArgs e)
		{
			new ViewLog().ShowDialog();
		}

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
			this.ActionsTxt = new RichTextBox();
			this.splitContainer1 = new SplitContainer();
			this.ViewLogBtn = new Button();
			this.CloseBtn = new Button();
			this.progressBar = new ProgressBar();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			base.SuspendLayout();
			this.ActionsTxt.Dock = DockStyle.Fill;
			this.ActionsTxt.Location = new Point(0, 0);
			this.ActionsTxt.Name = "ActionsTxt";
			this.ActionsTxt.ReadOnly = true;
			this.ActionsTxt.Size = new Size(338, 141);
			this.ActionsTxt.TabIndex = 0;
			this.ActionsTxt.Text = "";
			this.splitContainer1.Dock = DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = Orientation.Horizontal;
			this.splitContainer1.Panel1.Controls.Add(this.ActionsTxt);
			this.splitContainer1.Panel2.Controls.Add(this.progressBar);
			this.splitContainer1.Panel2.Controls.Add(this.ViewLogBtn);
			this.splitContainer1.Panel2.Controls.Add(this.CloseBtn);
			this.splitContainer1.Size = new Size(338, 171);
			this.splitContainer1.SplitterDistance = 141;
			this.splitContainer1.TabIndex = 1;
			this.ViewLogBtn.Enabled = false;
			this.ViewLogBtn.Location = new Point(84, 2);
			this.ViewLogBtn.Name = "ViewLogBtn";
			this.ViewLogBtn.Size = new Size(75, 23);
			this.ViewLogBtn.TabIndex = 1;
			this.ViewLogBtn.Text = "View Log";
			this.ViewLogBtn.UseVisualStyleBackColor = true;
			this.ViewLogBtn.Click += new EventHandler(this.ViewLogBtn_Click);
			this.CloseBtn.Enabled = false;
			this.CloseBtn.Location = new Point(3, 2);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.Size = new Size(75, 23);
			this.CloseBtn.TabIndex = 0;
			this.CloseBtn.Text = "Close";
			this.CloseBtn.UseVisualStyleBackColor = true;
			this.CloseBtn.Click += new EventHandler(this.CloseBtn_Click);
			this.progressBar.Location = new Point(165, 2);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new Size(170, 23);
			this.progressBar.TabIndex = 2;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(338, 171);
			base.Controls.Add(this.splitContainer1);
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.Name = "ActionsWindow";
			this.Text = "ExecuteActions";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
