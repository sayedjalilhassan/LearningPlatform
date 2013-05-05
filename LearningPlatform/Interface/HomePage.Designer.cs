namespace LearningPlatform.Interface
{
    partial class HomePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.treeListView1 = new BrightIdeasSoftware.TreeListView();
            this.titleColoumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.instructorColoumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.flatTabControl1 = new FlatTabControl.FlatTabControl();
            this.lessonsPage = new System.Windows.Forms.TabPage();
            this.axWindowsMediaPlayer2 = new AxWMPLib.AxWindowsMediaPlayer();
            this.quizezPage = new System.Windows.Forms.TabPage();
            this.outerPanel = new System.Windows.Forms.Panel();
            this.innerPanel = new System.Windows.Forms.Panel();
            this.prevNotesPage = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.recom_outerPanel = new System.Windows.Forms.Panel();
            this.recom_innerPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).BeginInit();
            this.flatTabControl1.SuspendLayout();
            this.lessonsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer2)).BeginInit();
            this.quizezPage.SuspendLayout();
            this.outerPanel.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.recom_outerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeListView1
            // 
            this.treeListView1.AllColumns.Add(this.titleColoumn);
            this.treeListView1.AllColumns.Add(this.instructorColoumn);
            this.treeListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.titleColoumn,
            this.instructorColoumn});
            this.treeListView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.treeListView1.Location = new System.Drawing.Point(787, 27);
            this.treeListView1.MaximumSize = new System.Drawing.Size(229, 434);
            this.treeListView1.MinimumSize = new System.Drawing.Size(229, 434);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.OwnerDraw = true;
            this.treeListView1.ShowGroups = false;
            this.treeListView1.Size = new System.Drawing.Size(229, 434);
            this.treeListView1.SmallImageList = this.imageList1;
            this.treeListView1.TabIndex = 0;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.View = System.Windows.Forms.View.Details;
            this.treeListView1.VirtualMode = true;
            this.treeListView1.SelectedIndexChanged += new System.EventHandler(this.treeListView1_SelectedIndexChanged);
            // 
            // titleColoumn
            // 
            this.titleColoumn.AspectName = "Title";
            this.titleColoumn.IsEditable = false;
            this.titleColoumn.Text = "Title";
            this.titleColoumn.Width = 227;
            // 
            // instructorColoumn
            // 
            this.instructorColoumn.AspectName = "Instructor.Title";
            this.instructorColoumn.IsEditable = false;
            this.instructorColoumn.Text = "Instructor";
            this.instructorColoumn.Width = 148;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "video_icon");
            this.imageList1.Images.SetKeyName(1, "folder_icon");
            // 
            // flatTabControl1
            // 
            this.flatTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flatTabControl1.Controls.Add(this.lessonsPage);
            this.flatTabControl1.Controls.Add(this.quizezPage);
            this.flatTabControl1.Controls.Add(this.prevNotesPage);
            this.flatTabControl1.Controls.Add(this.tabPage1);
            this.flatTabControl1.Controls.Add(this.tabPage2);
            this.flatTabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatTabControl1.Location = new System.Drawing.Point(11, 95);
            this.flatTabControl1.myBackColor = System.Drawing.Color.White;
            this.flatTabControl1.Name = "flatTabControl1";
            this.flatTabControl1.SelectedIndex = 0;
            this.flatTabControl1.Size = new System.Drawing.Size(1031, 499);
            this.flatTabControl1.TabIndex = 1;
            // 
            // lessonsPage
            // 
            this.lessonsPage.Controls.Add(this.axWindowsMediaPlayer2);
            this.lessonsPage.Controls.Add(this.treeListView1);
            this.lessonsPage.Location = new System.Drawing.Point(4, 25);
            this.lessonsPage.Name = "lessonsPage";
            this.lessonsPage.Padding = new System.Windows.Forms.Padding(3);
            this.lessonsPage.Size = new System.Drawing.Size(1023, 470);
            this.lessonsPage.TabIndex = 0;
            this.lessonsPage.Text = "Lessons";
            this.lessonsPage.UseVisualStyleBackColor = true;
            // 
            // axWindowsMediaPlayer2
            // 
            this.axWindowsMediaPlayer2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.axWindowsMediaPlayer2.Enabled = true;
            this.axWindowsMediaPlayer2.Location = new System.Drawing.Point(15, 27);
            this.axWindowsMediaPlayer2.Name = "axWindowsMediaPlayer2";
            this.axWindowsMediaPlayer2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer2.OcxState")));
            this.axWindowsMediaPlayer2.Size = new System.Drawing.Size(752, 434);
            this.axWindowsMediaPlayer2.TabIndex = 1;
            // 
            // quizezPage
            // 
            this.quizezPage.Controls.Add(this.outerPanel);
            this.quizezPage.Location = new System.Drawing.Point(4, 25);
            this.quizezPage.Name = "quizezPage";
            this.quizezPage.Padding = new System.Windows.Forms.Padding(3);
            this.quizezPage.Size = new System.Drawing.Size(1023, 470);
            this.quizezPage.TabIndex = 1;
            this.quizezPage.Text = "Quizzes";
            this.quizezPage.UseVisualStyleBackColor = true;
            // 
            // outerPanel
            // 
            this.outerPanel.Controls.Add(this.innerPanel);
            this.outerPanel.Location = new System.Drawing.Point(17, 28);
            this.outerPanel.Name = "outerPanel";
            this.outerPanel.Size = new System.Drawing.Size(990, 423);
            this.outerPanel.TabIndex = 0;
            // 
            // innerPanel
            // 
            this.innerPanel.AutoScroll = true;
            this.innerPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.innerPanel.Location = new System.Drawing.Point(16, 16);
            this.innerPanel.Name = "innerPanel";
            this.innerPanel.Size = new System.Drawing.Size(957, 392);
            this.innerPanel.TabIndex = 0;
            // 
            // prevNotesPage
            // 
            this.prevNotesPage.Location = new System.Drawing.Point(4, 25);
            this.prevNotesPage.Name = "prevNotesPage";
            this.prevNotesPage.Padding = new System.Windows.Forms.Padding(3);
            this.prevNotesPage.Size = new System.Drawing.Size(1023, 470);
            this.prevNotesPage.TabIndex = 2;
            this.prevNotesPage.Text = "Performance";
            this.prevNotesPage.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.recom_outerPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1023, 470);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Reccomendations";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1023, 470);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "Lecture Slides";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pictureBox1.Location = new System.Drawing.Point(11, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1031, 123);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Bernard MT Condensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(349, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Adaptive Learning Platform";
            // 
            // recom_outerPanel
            // 
            this.recom_outerPanel.Controls.Add(this.recom_innerPanel);
            this.recom_outerPanel.Location = new System.Drawing.Point(6, 6);
            this.recom_outerPanel.Name = "recom_outerPanel";
            this.recom_outerPanel.Size = new System.Drawing.Size(1011, 458);
            this.recom_outerPanel.TabIndex = 0;
            // 
            // recom_innerPanel
            // 
            this.recom_innerPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recom_innerPanel.Location = new System.Drawing.Point(16, 13);
            this.recom_innerPanel.Name = "recom_innerPanel";
            this.recom_innerPanel.Size = new System.Drawing.Size(981, 442);
            this.recom_innerPanel.TabIndex = 0;
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1053, 626);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flatTabControl1);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.MaximumSize = new System.Drawing.Size(1053, 626);
            this.MinimumSize = new System.Drawing.Size(1053, 626);
            this.Name = "HomePage";
            this.Text = "Test";
            this.Load += new System.EventHandler(this.Test_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).EndInit();
            this.flatTabControl1.ResumeLayout(false);
            this.lessonsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer2)).EndInit();
            this.quizezPage.ResumeLayout(false);
            this.outerPanel.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.recom_outerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private BrightIdeasSoftware.TreeListView treeListView1;
        private BrightIdeasSoftware.OLVColumn titleColoumn;
        private BrightIdeasSoftware.OLVColumn instructorColoumn;
        private System.Windows.Forms.ImageList imageList1;
        private FlatTabControl.FlatTabControl flatTabControl1;
        private System.Windows.Forms.TabPage prevNotesPage;
        private System.Windows.Forms.TabPage lessonsPage;
        private System.Windows.Forms.TabPage quizezPage;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel outerPanel;
        private System.Windows.Forms.Panel innerPanel;
        private System.Windows.Forms.Panel recom_outerPanel;
        private System.Windows.Forms.Panel recom_innerPanel;

    }


}