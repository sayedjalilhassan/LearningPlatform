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
            //@"..\..\Themes\WhiteTheme.xml"
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Controller controller = Controller.Instance;
            Application.Run(new HomePage());
        }
    }
}
