using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LearningPlatform.Logic;

namespace LearningPlatform.Interface
{
    public partial class loginForm: XCoolForm.XCoolForm
    {
        Point lastClick;
        private XmlThemeLoader xtl = new XmlThemeLoader();
        public loginForm():base()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
        }

        private void emptyText(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Length > 0)
            {
                tb.BackColor = System.Drawing.SystemColors.Window;
            }
            else
            {
                tb.BackColor = Color.Red;
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            //new HomePage().Show();
            new HomePage().Show();
            
            
        }

        private void loginForm_MouseDown(object sender, MouseEventArgs e)
        {
            lastClick = new Point(e.X, e.Y); 
        }

        private void loginForm_MouseMove(object sender, MouseEventArgs e)
        {
            /// check if user clicked left or right mouse button,
            /// if left one is clicked, then... 
            if (e.Button == MouseButtons.Left) 
            {
                
                /// .... executes this code 

                //this.Left += e.X - lastClick.X;

                //this.Top += e.Y - lastClick.Y;

            };
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            xtl.ThemeForm = this;
            //xtl.ApplyTheme(System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\Themes\VistaTheme.xml"));
            //xtl.ApplyTheme(System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\Themes\AdobeMediaPlayerTheme.xml"));
            //xtl.ApplyTheme(System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\Themes\AnimalKingdomTheme.xml"));
            //xtl.ApplyTheme(System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\Themes\BlackTheme.xml"));
            //xtl.ApplyTheme(System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\Themes\BlueWinterTheme.xml"));
            //xtl.ApplyTheme(System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\Themes\DarkSystemTheme.xml"));
            //xtl.ApplyTheme(System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\Themes\MacOSTheme.xml"));
            //xtl.ApplyTheme(System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\Themes\StandardWindowsTheme.xml"));
            //xtl.ApplyTheme(System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\Themes\ValentineTheme.xml"));
            xtl.ApplyTheme(System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\Themes\WhiteTheme.xml"));
            this.TitleBar.TitleBarCaption = "Login Form";
            this.TitleBar.TitleBarFill = XCoolForm.XTitleBar.XTitleBarFill.AdvancedRendering;
            this.TitleBar.TitleBarType = XCoolForm.XTitleBar.XTitleBarType.Rounded;
            Color c = Color.FromArgb(0, 192, 192);
            this.TitleBar.TitleBarCaptionColor = c;
            this.TitleBar.TitleBarCaptionFont = new Font("Impact", 12, FontStyle.Regular);
            
            
            
            
        }

    }
}
