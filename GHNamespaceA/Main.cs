using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using MainMenu = GHNamespace8.MainMenu;

namespace GHNamespaceA
{
    public static class Start
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Mutex obj = new Mutex(true, "GHTCP", out bool flag);
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