using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MediaPlayerTest
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnPlay;
		private System.Windows.Forms.Button btnPause;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.btnPause = new System.Windows.Forms.Button();
			this.btnPlay = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// axWindowsMediaPlayer1
			// 
			this.axWindowsMediaPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.axWindowsMediaPlayer1.Enabled = true;
			this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 0);
			this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
			this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
			this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(296, 272);
			this.axWindowsMediaPlayer1.TabIndex = 0;
			this.axWindowsMediaPlayer1.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.axWindowsMediaPlayer1_PlayStateChange);
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(208, 8);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.TabIndex = 1;
			this.btnBrowse.Text = "Browse...";
			this.btnBrowse.Click += new System.EventHandler(this.button1_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Title = "Open Media File...";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.btnPause);
			this.panel1.Controls.Add(this.btnPlay);
			this.panel1.Controls.Add(this.btnBrowse);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 226);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(292, 40);
			this.panel1.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.Location = new System.Drawing.Point(72, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(24, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "#";
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// btnPause
			// 
			this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnPause.Location = new System.Drawing.Point(40, 8);
			this.btnPause.Name = "btnPause";
			this.btnPause.Size = new System.Drawing.Size(24, 23);
			this.btnPause.TabIndex = 3;
			this.btnPause.Text = "||";
			this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
			// 
			// btnPlay
			// 
			this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnPlay.Location = new System.Drawing.Point(8, 8);
			this.btnPlay.Name = "btnPlay";
			this.btnPlay.Size = new System.Drawing.Size(24, 23);
			this.btnPlay.TabIndex = 2;
			this.btnPlay.Text = ">";
			this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.axWindowsMediaPlayer1);
			this.Name = "Form1";
			this.Text = "Windows Media Player in C#";
			((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if ( openFileDialog1.ShowDialog() == DialogResult.OK ) 
			{
				axWindowsMediaPlayer1.URL = openFileDialog1.FileName;
			}
		}

		private void btnPlay_Click(object sender, System.EventArgs e)
		{
			axWindowsMediaPlayer1.Ctlcontrols.play();
		}

		private void btnPause_Click(object sender, System.EventArgs e)
		{
			axWindowsMediaPlayer1.Ctlcontrols.pause();
		}

		private void button1_Click_1(object sender, System.EventArgs e)
		{
			axWindowsMediaPlayer1.Ctlcontrols.stop();
		}

		private void axWindowsMediaPlayer1_EndOfStream(object sender, AxWMPLib._WMPOCXEvents_EndOfStreamEvent e)
		{
			MessageBox.Show("File ended!");
		}

		private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
		{
			if ( axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped ) 
			{
				MessageBox.Show("File ended!");
				axWindowsMediaPlayer1.Ctlcontrols.play();
			}

			Font = new Font("Times", 12, FontStyle.Bold | FontStyle.Italic);
		}
	}
}
