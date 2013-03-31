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
    public partial class HomePage : XCoolForm.XCoolForm
    {
        Label titleLabel, helper;
        int quiz_index = 0;
        Button nextButton;
        Button submitButton;
        TextBox questionText;
        List<RadioButton> optionsRadioButtons = new List<RadioButton>();
        private XmlThemeLoader xtl = new XmlThemeLoader();
        public HomePage()
            : base()
        {
            InitializeComponent();
            if (Controller.getLessons().Count > 0)
                addQuiz();

        }

        private void addQuiz()
        {
            titleLabel = new Label();
            titleLabel.Location = new Point(((int)(innerPanel.Width / 2) - 50), 50);
            titleLabel.Text = Controller.selectedLesson.Title;
            titleLabel.Font = new Font("Sans serif", 12, FontStyle.Bold);
            this.innerPanel.Controls.Add(titleLabel);

            Label questionLabel = new Label();
            questionLabel.Location = new Point(0, titleLabel.Height + 100);
            questionLabel.Text = "Question";
            questionLabel.Font = new Font("Sans serif", 12, FontStyle.Bold);
            this.innerPanel.Controls.Add(questionLabel);

            questionText = new TextBox();
            questionText.Location = new Point(50, titleLabel.Height + 130);
            questionText.Text = Controller.selectedLesson.getQuizes().ElementAt(quiz_index).Question;
            questionText.Multiline = true;
            questionText.ReadOnly = true;
            questionText.Font = new Font("Sans serif", 10, FontStyle.Bold);
            questionText.Width = (int)innerPanel.Width / 2;
            questionText.Height = (questionText.Text.Split('\n').Length + 2) * questionText.Font.Height;
            this.innerPanel.Controls.Add(questionText);

            Label answerLabel = new Label();
            answerLabel.Location = new Point(0, questionText.Location.Y + questionText.Height + 10);
            answerLabel.Text = "Choose the correct Option: ";
            answerLabel.Font = new Font("Sans serif", 12, FontStyle.Bold);
            answerLabel.Width = Width = (int)innerPanel.Width / 2;
            this.innerPanel.Controls.Add(answerLabel);

            int previousHeight = answerLabel.Location.Y + answerLabel.Height + 20;
            this.optionsRadioButtons.Clear();
            for (int i = 0; i < Controller.selectedLesson.getQuizes().ElementAt(quiz_index).Options.Count; i++)
            {
                RadioButton radio = new RadioButton();
                radio.Name = i.ToString();
                radio.Text = Controller.selectedLesson.getQuizes().ElementAt(quiz_index).Options.ElementAt(i);
                radio.Location = new Point(50, previousHeight);
                previousHeight += radio.Height + 30;
                this.optionsRadioButtons.Add(radio);
                this.innerPanel.Controls.Add(radio);
            }

            submitButton = new Button();
            submitButton.Location = new Point(0, previousHeight + 100);
            submitButton.Text = "Submit";
            submitButton.Click += new EventHandler(this.submitbutton_Click);
            this.innerPanel.Controls.Add(submitButton);

            nextButton = new Button();
            nextButton.Location = new Point(100, previousHeight + 100);
            nextButton.Text = "Next";
            nextButton.Click += new EventHandler(this.nextbutton_Click);
            this.innerPanel.Controls.Add(nextButton);

            helper = new Label();
            helper.Location = new Point(0, previousHeight + 400);
            helper.Width = Width = (int)innerPanel.Width / 2;
            this.innerPanel.Controls.Add(helper);

            //Button b = new Button();
            //b.Location = new Point(0, 900);
            //b.Text = "Next";
            //b.Click += new EventHandler(this.button_Click);
            //this.innerPanel.Controls.Add(b);

        }

        /*
         * Custom event Listeners
         * */
        void button_Click(object sender, System.EventArgs e)
        {
            titleLabel.Text = Controller.selectedChapter.Title;
        }

        void nextbutton_Click(object sender, System.EventArgs e)
        {
            if (quiz_index < Controller.selectedLesson.getQuizes().Count - 1)
            {
                quiz_index++;
                innerPanel.Controls.Clear();
                addQuiz();
                titleLabel.Text = "Next";
            }
            else
            {
                MessageBox.Show("No more Quizez");
                quiz_index = 0;
                nextButton.Enabled = false;
            }

        }

        void submitbutton_Click(object sender, System.EventArgs e)
        {
            int count = 0;
            foreach (RadioButton r in this.optionsRadioButtons)
            {

                if (r.Checked)
                {
                    if (Controller.selectedLesson.getQuizes().ElementAt(quiz_index).CorrectIndex == count)
                        MessageBox.Show("Correct");
                    else
                        MessageBox.Show("Incorrect");
                    r.Checked = false;    
                    break;
                }
                count++;
            }
        }

        /*
         * end event Listeners
         * */


        private void Test_Load(object sender, EventArgs e)
        {
            xtl.ThemeForm = this;
            xtl.ApplyTheme(System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\Themes\WhiteTheme.xml"));
            this.TitleBar.TitleBarCaption = "Home Page";
            this.TitleBar.TitleBarFill = XCoolForm.XTitleBar.XTitleBarFill.AdvancedRendering;
            this.TitleBar.TitleBarType = XCoolForm.XTitleBar.XTitleBarType.Rounded;
            Color c = Color.FromArgb(0, 192, 192);
            this.TitleBar.TitleBarCaptionColor = c;
            this.TitleBar.TitleBarCaptionFont = new Font("Impact", 12, FontStyle.Regular);

            this.treeListView1.SetObjects(Controller.GetChapters());
            // Can the given object be expanded?
            this.treeListView1.CanExpandGetter = delegate(Object x)
            {
                return (x is Chapter);
            };

            // What objects should belong underneath the given model object?
            this.treeListView1.ChildrenGetter = delegate(Object x)
            {
                if (x is Chapter)
                {
                    Console.WriteLine("yES i AM A chapter");
                    //return Controller.GetLessonsForChapter(((Chapter)x).Title);
                    Console.WriteLine(((Chapter)x).Lessons.Count);
                    return ((Chapter)x).Lessons;
                }

                throw new ArgumentException("Should be a Chapter");
            };

            // Which image should be used for which model
            this.titleColoumn.ImageGetter = delegate(Object x)
            {

                if (x is Chapter)
                    return "folder_icon";
                else
                    return "video_icon";
            };

            this.treeListView1.SetObjects(Controller.GetChapters());
            //String path = @"C:\Users\Sayed_Jalil_Hassan\Desktop\Tutorial_ Android Application Development - Lists and Adapters - YouTube.MP4";

            // PlayFile(path);
        }

        private void play()
        {

        }

        private void PlayFile(String url)
        {
            string URL = url;
            //axWindowsMediaPlayer2.settings.autoStart = false;
            axWindowsMediaPlayer2.URL = URL;
        }

        private void Player_PlayStateChange(int NewState)
        {
            if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsStopped)
            {
                this.Close();
            }
        }

        private void Player_MediaError(object pMediaObject)
        {
            MessageBox.Show("Cannot play media file.");
            this.Close();
        }

        private void axWindowsMediaPlayer1_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {


        }

        private void axWindowsMediaPlayer2_Enter(object sender, EventArgs e)
        {

        }

        private void lessonsPage_Click(object sender, EventArgs e)
        {

        }

        private void treeListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (treeListView1.SelectedObject is Chapter)
            {
                Controller.selectedChapter = (Chapter)treeListView1.SelectedObject;
            }
            else if ((treeListView1.SelectedObject is Lesson))
            {
                Controller.selectedLesson = (Lesson)treeListView1.SelectedObject;
                String path = Controller.selectedLesson.VideoPath;
                quiz_index = 0;
                nextButton.Enabled = true;
                questionText.Text = Controller.selectedLesson.getQuizes().ElementAt(quiz_index).Question;
                //String path = @"C:\Users\Sayed_Jalil_Hassan\Desktop\types-of-motion-1.wmv";

                PlayFile(path);
            }


        }

        private void treeListView1_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            if (e.Item.Text == "Rest and Motion")
            {
                //String path = @"C:\Users\Sayed_Jalil_Hassan\Desktop\types-of-motion-1.wmv";

                //PlayFile(path);

            }

            if (e.Item.Selected)
            {
                //Controller.selectedLesson = (Lesson)treeListView1.SelectedObject;// SelectedItem;

            }

            // MessageBox.Show(e.Item.Text);
        }

        private Chapter findSelectedChapter()
        {

            return null;
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
