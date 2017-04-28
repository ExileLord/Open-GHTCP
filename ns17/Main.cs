using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using MainMenu = ns15.MainMenu;

namespace ns17
{
	public static class Start
	{
		[STAThread]
		private static void Main(string[] args)
		{
			bool flag;
			var obj = new Mutex(true, "GHTCP", out flag);
			if (!flag)
			{
				MessageBox.Show("GH3 Control Panel+ is already running.");
				return;
			}
			Thread.CurrentThread.CurrentUICulture = (Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US"));
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
			GC.KeepAlive(obj);
		}
	}
}
