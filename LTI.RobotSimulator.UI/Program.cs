using System;
using System.Windows.Forms;

namespace LTI.RobotSimulator.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (Window window = new Window())
            {
                window.Show();

                while (window.Visible)
                {
                    Application.DoEvents();
                    window.OnUpdate();
                    window.OnRender();
                }
            }
        }
    }
}
