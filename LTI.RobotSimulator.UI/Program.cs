using System;
using System.Windows.Forms;
using SFML.System;

namespace LTI.RobotSimulator
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
                using (Clock clock = new Clock())
                {
                    window.Show();

                    while (window.Visible)
                    {
                        float deltaTime = clock.Restart().AsSeconds();

                        Application.DoEvents();
                        window.OnUpdate(deltaTime);
                        window.OnRender();
                    }
                }
            }
        }
    }
}
