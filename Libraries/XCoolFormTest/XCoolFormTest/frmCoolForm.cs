using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace XCoolFormTest
{
    public partial class frmCoolForm : XCoolForm.XCoolForm
    {
        private XmlThemeLoader xtl = new XmlThemeLoader();
        public frmCoolForm() : base()
        {
            InitializeComponent();
        }

        private void frmCoolForm_Load(object sender, EventArgs e)
        {
            this.TitleBar.TitleBarBackImage = XCoolFormTest.Properties.Resources.predator_256x256;
            this.MenuIcon = XCoolFormTest.Properties.Resources.alien_vs_predator_3_48x48.GetThumbnailImage(24, 24, null, IntPtr.Zero);
            this.IconHolder.HolderButtons.Add(new XCoolForm.XTitleBarIconHolder.XHolderButton(XCoolFormTest.Properties.Resources.disc_predator_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero), "Blue Winter"));
            this.IconHolder.HolderButtons.Add(new XCoolForm.XTitleBarIconHolder.XHolderButton(XCoolFormTest.Properties.Resources.alien_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero), "Dark System"));
            this.IconHolder.HolderButtons.Add(new XCoolForm.XTitleBarIconHolder.XHolderButton(XCoolFormTest.Properties.Resources.alien_egg_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero), "Animal Kingdom"));
            this.IconHolder.HolderButtons.Add(new XCoolForm.XTitleBarIconHolder.XHolderButton(XCoolFormTest.Properties.Resources.predator_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero), "Valentine"));

           
            this.IconHolder.HolderButtons[0].FrameBackImage = XCoolFormTest.Properties.Resources.disc_predator_48x48;
            this.IconHolder.HolderButtons[1].FrameBackImage = XCoolFormTest.Properties.Resources.alien_48x48;
            this.IconHolder.HolderButtons[2].FrameBackImage = XCoolFormTest.Properties.Resources.alien_egg_48x48;
            this.IconHolder.HolderButtons[3].FrameBackImage = XCoolFormTest.Properties.Resources.predator_48x48;

            this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(60));
            this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(200, "INS"));
            this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(80, "Done"));
            this.StatusBar.EllipticalGlow = false;
           
            this.XCoolFormHolderButtonClick += new XCoolFormHolderButtonClickHandler(frmCoolForm_XCoolFormHolderButtonClick);
            xtl.ThemeForm = this;
        }

        private void frmCoolForm_XCoolFormHolderButtonClick(XCoolForm.XCoolForm.XCoolFormHolderButtonClickArgs e)
        {
            switch (e.ButtonIndex)
            {
                case 0:
                    this.TitleBar.TitleBarBackImage = XCoolFormTest.Properties.Resources.candy_cane;
                    this.TitleBar.TitleBarCaption = "Blue Winter Theme";
                    this.TitleBar.TitleBarFill = XCoolForm.XTitleBar.XTitleBarFill.AdvancedRendering;
                    this.TitleBar.TitleBarType = XCoolForm.XTitleBar.XTitleBarType.Rounded;

                    this.TitleBar.TitleBarButtons[2].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.FullFill;
                    this.TitleBar.TitleBarButtons[1].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.FullFill;
                    this.TitleBar.TitleBarButtons[0].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.FullFill;

                    this.IconHolder.HolderButtons[0].ButtonImage = XCoolFormTest.Properties.Resources.xmas_tree.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    this.IconHolder.HolderButtons[1].ButtonImage = XCoolFormTest.Properties.Resources.xmas_decoration_green.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    this.IconHolder.HolderButtons[2].ButtonImage = XCoolFormTest.Properties.Resources.xmas_decoration_red_.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    this.IconHolder.HolderButtons[3].ButtonImage = XCoolFormTest.Properties.Resources.snowman.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                 
                    this.IconHolder.HolderButtons[0].FrameBackImage = XCoolFormTest.Properties.Resources.xmas_tree;
                    this.IconHolder.HolderButtons[1].FrameBackImage = XCoolFormTest.Properties.Resources.xmas_decoration_green;
                    this.IconHolder.HolderButtons[2].FrameBackImage = XCoolFormTest.Properties.Resources.xmas_decoration_red_;
                    this.IconHolder.HolderButtons[3].FrameBackImage = XCoolFormTest.Properties.Resources.snowmansmall;
                    this.MenuIcon = XCoolFormTest.Properties.Resources.Snowman1.GetThumbnailImage(30, 30, null, IntPtr.Zero);

                    this.StatusBar.BarBackImage = XCoolFormTest.Properties.Resources.snowman.GetThumbnailImage(80, 80, null, IntPtr.Zero); ;
                    this.StatusBar.BarImageAlign = XCoolForm.XStatusBar.XStatusBarBackImageAlign.Right;

                    this.StatusBar.BarItems[1].BarItemText = "Snow level: 0.5 m";
                    xtl.ApplyTheme(Path.Combine(Environment.CurrentDirectory, @"..\..\Themes\BlueWinterTheme.xml"));
                    break;
                case 1:
                    this.Border.BorderStyle = XCoolForm.X3DBorderPrimitive.XBorderStyle.X3D;
                    this.TitleBar.TitleBarType = XCoolForm.XTitleBar.XTitleBarType.Rounded;
                    this.TitleBar.TitleBarCaption = "Dark System Theme";

                    this.TitleBar.TitleBarFill = XCoolForm.XTitleBar.XTitleBarFill.AdvancedRendering;

                    this.TitleBar.TitleBarButtons[2].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.UpperGlow;
                    this.TitleBar.TitleBarButtons[1].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.UpperGlow;
                    this.TitleBar.TitleBarButtons[0].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.UpperGlow;

                    this.IconHolder.HolderButtons[3].ButtonImage = XCoolFormTest.Properties.Resources.Quake_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    this.IconHolder.HolderButtons[2].ButtonImage = XCoolFormTest.Properties.Resources.Quake_III_Arena_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    this.IconHolder.HolderButtons[1].ButtonImage = XCoolFormTest.Properties.Resources.Quake_IV_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    this.IconHolder.HolderButtons[0].ButtonImage = XCoolFormTest.Properties.Resources.Quake_II_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero);

                    this.IconHolder.HolderButtons[3].FrameBackImage = XCoolFormTest.Properties.Resources.Quake_48x48;
                    this.IconHolder.HolderButtons[2].FrameBackImage = XCoolFormTest.Properties.Resources.Quake_III_Arena_48x48;
                    this.IconHolder.HolderButtons[1].FrameBackImage = XCoolFormTest.Properties.Resources.Quake_IV_48x48;
                    this.IconHolder.HolderButtons[0].FrameBackImage = XCoolFormTest.Properties.Resources.Quake_II_48x48;

                    this.MenuIcon = XCoolFormTest.Properties.Resources.GDI_256x256.GetThumbnailImage(30, 25, null, IntPtr.Zero);
                    this.TitleBar.TitleBarBackImage = XCoolFormTest.Properties.Resources.Quake_IV;

                    this.StatusBar.BarBackImage = XCoolFormTest.Properties.Resources.Quake_256x256;
                    this.StatusBar.BarImageAlign = XCoolForm.XStatusBar.XStatusBarBackImageAlign.Left;
                    this.StatusBar.BarItems[1].BarItemText = "Date: 12/12/2045";
                    xtl.ApplyTheme(Path.Combine(Environment.CurrentDirectory, @"..\..\Themes\DarkSystemTheme.xml"));
                    break;
                case 2:
                    this.Border.BorderStyle = XCoolForm.X3DBorderPrimitive.XBorderStyle.Flat;
                    this.TitleBar.TitleBarBackImage = XCoolFormTest.Properties.Resources.Mammooth_1;
                    this.TitleBar.TitleBarCaption = "Animal Kingdom Theme";

                    this.TitleBar.TitleBarButtons[2].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.None;
                    this.TitleBar.TitleBarButtons[1].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.None;
                    this.TitleBar.TitleBarButtons[0].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.None;

                    this.TitleBar.TitleBarType = XCoolForm.XTitleBar.XTitleBarType.Angular;
                    this.MenuIcon = XCoolFormTest.Properties.Resources.Mammooth_128x128.GetThumbnailImage(30, 30, null, IntPtr.Zero);
                    this.StatusBar.EllipticalGlow = false;

                    this.TitleBar.TitleBarFill = XCoolForm.XTitleBar.XTitleBarFill.UpperGlow;

                    this.StatusBar.BarBackImage = XCoolFormTest.Properties.Resources.Funshine_Bear_1;
                    this.StatusBar.BarImageAlign = XCoolForm.XStatusBar.XStatusBarBackImageAlign.Left;

                    this.StatusBar.BarItems[1].BarItemText = "Place: Madagascar";
                    this.StatusBar.BarItems[1].ItemTextAlign = StringAlignment.Center;
                    
                    this.IconHolder.HolderButtons[0].ButtonImage = XCoolFormTest.Properties.Resources.cow_32.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    this.IconHolder.HolderButtons[1].ButtonImage = XCoolFormTest.Properties.Resources.bird_32.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    this.IconHolder.HolderButtons[2].ButtonImage = XCoolFormTest.Properties.Resources.panda_32.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    this.IconHolder.HolderButtons[3].ButtonImage = XCoolFormTest.Properties.Resources.penguine_32.GetThumbnailImage(20, 20, null, IntPtr.Zero);

                    this.IconHolder.HolderButtons[0].FrameBackImage = XCoolFormTest.Properties.Resources.cow_32;
                    this.IconHolder.HolderButtons[1].FrameBackImage = XCoolFormTest.Properties.Resources.bird_32;
                    this.IconHolder.HolderButtons[2].FrameBackImage = XCoolFormTest.Properties.Resources.panda_32;
                    this.IconHolder.HolderButtons[3].FrameBackImage = XCoolFormTest.Properties.Resources.penguine_32;
                    xtl.ApplyTheme(Path.Combine(Environment.CurrentDirectory, @"..\..\Themes\AnimalKingdomTheme.xml"));
                    break;
                case 3:
                    this.Border.BorderStyle = XCoolForm.X3DBorderPrimitive.XBorderStyle.X3D;
                    this.TitleBar.TitleBarType = XCoolForm.XTitleBar.XTitleBarType.Rectangular;
                    this.TitleBar.TitleBarCaption = "Valentine Theme";
                    
                    this.TitleBar.TitleBarFill = XCoolForm.XTitleBar.XTitleBarFill.LinearRendering;
                    
                    this.TitleBar.TitleBarBackImage = XCoolFormTest.Properties.Resources.heart_valentine_128x128;
                    this.StatusBar.EllipticalGlow = false;
                    
                    this.StatusBar.BarBackImage = XCoolFormTest.Properties.Resources.paisley_6_48x48;
                    this.StatusBar.BarImageAlign = XCoolForm.XStatusBar.XStatusBarBackImageAlign.Center;
                    this.StatusBar.BarItems[1].BarItemText = "Hearts left: 4";
                    this.MenuIcon = XCoolFormTest.Properties.Resources.purple_flower_48x48.GetThumbnailImage(30, 30, null, IntPtr.Zero);

                    this.IconHolder.HolderButtons[0].ButtonImage = XCoolFormTest.Properties.Resources.butterfly_pink_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    this.IconHolder.HolderButtons[1].ButtonImage = XCoolFormTest.Properties.Resources.butterfly_purple_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    this.IconHolder.HolderButtons[2].ButtonImage = XCoolFormTest.Properties.Resources.lotus_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    this.IconHolder.HolderButtons[3].ButtonImage = XCoolFormTest.Properties.Resources.symbol_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero);

                    this.IconHolder.HolderButtons[0].FrameBackImage = XCoolFormTest.Properties.Resources.butterfly_pink_48x48;
                    this.IconHolder.HolderButtons[1].FrameBackImage = XCoolFormTest.Properties.Resources.butterfly_purple_48x48;
                    this.IconHolder.HolderButtons[2].FrameBackImage = XCoolFormTest.Properties.Resources.lotus_48x48;
                    this.IconHolder.HolderButtons[3].FrameBackImage = XCoolFormTest.Properties.Resources.symbol_48x48;
                    xtl.ApplyTheme(Path.Combine(Environment.CurrentDirectory, @"..\..\Themes\ValentineTheme.xml"));
                    break;
            }

        }
        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}