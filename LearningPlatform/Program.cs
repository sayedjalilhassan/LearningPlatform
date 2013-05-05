using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LearningPlatform.Logic;
using LearningPlatform.Interface;
namespace LearningPlatform
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException +=
            new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            //@"..\..\Themes\WhiteTheme.xml"
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Controller controller = Controller.Instance;
            Application.Run(new HomePage());
            //Application.Run(new loginForm());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                MessageBox.Show(ex.ToString());
                //MessageBox.Show("Whoops! Please contact the developers with the following"
                //      + " information:\n\n" + ex.Message + ex.StackTrace,
                //      "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                Application.Exit();
            }
        }
    }
}
