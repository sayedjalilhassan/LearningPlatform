using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LearningPlatform.Logic;
using System.IO;

namespace LearningPlatform.Interface
{
    public partial class HomePage : XCoolForm.XCoolForm
    {
        Label titleLabel, helper;
        int quiz_index = 0;
        Button nextButton;
        Button submitButton;
        TextBox questionText;
        int correctCount = 0, wrongCount = 0;
        List<RadioButton> optionsRadioButtons = new List<RadioButton>();
        string lessonsfileName = @"..\..\Resources\assests\profile.txt";
        string quizezfileName = @"..\..\Resources\assests\performance.txt";
        private XmlThemeLoader xtl = new XmlThemeLoader();
        public HomePage()
            : base()
        {
            InitializeComponent();
            this.axWindowsMediaPlayer2.PlayStateChange +=
                new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.axWindowsMediaPlayer2_PlayStateChange);
            if (Controller.getLessons().Count > 0)
            {
                addQuiz();
                //Controller.getPreReqsForLesson(8);
            }
            this.innerPanel.Enabled = false;
            populateProfile();
           /*
            if (Controller.finishedLessons.Count > 0)
                MessageBox.Show(Controller.finishedLessons.ElementAt(Controller.finishedLessons.Count - 1).Title);
            else
                MessageBox.Show("No Finished Lessons"); */
        }

        private void Test_Load(object sender, EventArgs e)
        {
            //xtl.ThemeForm = this;
            //xtl.ApplyTheme(System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\Themes\WhiteTheme.xml"));
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
                submitButton.Enabled = true;
                quiz_index++;
                innerPanel.Controls.Clear();
                addQuiz();
                titleLabel.Text = "Next";
            }
            else
            {
                MessageBox.Show("You Scored "+correctCount +"out of " +Controller.selectedLesson.getQuizes().Count+"");
                string toWrite = Controller.selectedLesson.Id+" "+Controller.selectedLesson.Chapter.Id + " " +
                    correctCount + " "+ Controller.selectedLesson.getQuizes().Count;
                writetoFile(toWrite,quizezfileName);
                quiz_index = 0;
                correctCount = 0;
                nextButton.Enabled = false;
                submitButton.Enabled = false;
            }

        }

        void submitbutton_Click(object sender, System.EventArgs e)
        {
            int count = 0;
            int selectedCount = 0;
            foreach (RadioButton r in this.optionsRadioButtons)
            {

                if (r.Checked)
                {
                    if (Controller.selectedLesson.getQuizes().ElementAt(quiz_index).CorrectIndex == count)
                    {
                        MessageBox.Show("Correct");
                        this.correctCount++;
                    }
                    else
                        MessageBox.Show("Incorrect");
                    r.Checked = false;
                    break;
                }
                else
                {
                    selectedCount++;
                }
                count++;
            }
            if (selectedCount == optionsRadioButtons.Count)
                MessageBox.Show("Please Select an Option !");
            else
                submitButton.Enabled = false;
            /* string toWrite = Controller.selectedLesson.getQuizes().ElementAt (quiz_index).Id+" " 
                   + Controller.selectedLesson.Id + " " + Controller.selectedLesson.Title + " "; */

            //writetoFile(Controller.selectedLesson.Title + " " + Controller.selectedLesson.IsFinished + "", quizezfileName);
        }

        /*
         * end event Listeners
         * */




        private void axWindowsMediaPlayer2_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (isStopped())
            {
                Controller.selectedLesson.TotalPlayTime = axWindowsMediaPlayer2.Ctlcontrols.currentItem.duration;
               // MessageBox.Show(Controller.selectedLesson.IsFinished + "");
                
                // this.Close();
            }
            else if (isEnded())
            {   
                this.innerPanel.Enabled = true;
               // MessageBox.Show("Ended");
                Controller.selectedLesson.IsFinished = true;

                writetoFile(Controller.selectedLesson.Id + " " + Controller.selectedLesson.Chapter.Id + " "
                    + Controller.selectedLesson.IsFinished + "", lessonsfileName);

            }

        }

        private void PlayFile(String url)
        {
            string URL = url;
            //axWindowsMediaPlayer2.settings.autoStart = false;
            axWindowsMediaPlayer2.URL = URL;
        }

        private bool isEnded()
        {
            return axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsMediaEnded;
        }

        private bool isPlaying()
        {
            // MessageBox.Show(Controller.selectedLesson.PlayedTime + " " + Controller.selectedLesson.TotalPlayTime + "");
            return axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsReady || axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsPlaying;
        }

        private bool isStopped()
        {
            return axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsStopped;
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
                if(Controller.finishedLessons.Contains(Controller.selectedLesson))
                {
                    Controller.selectedLesson.IsFinished = true;
                }
                this.quiz_index = 0;
                this.submitButton.Enabled = true;
                this.nextButton.Enabled = true;
                this.questionText.Text = Controller.selectedLesson.getQuizes().ElementAt(quiz_index).Question;
                //String path = @"C:\Users\Sayed_Jalil_Hassan\Desktop\types-of-motion-1.wmv";
                if (!Controller.selectedLesson.IsFinished)
                {
                    this.innerPanel.Enabled = false;
                }
                else
                    this.innerPanel.Enabled = true;
                PlayFile(path);
            }


        }


        public void writetoFile(string data, string filename)
        {
            //string fileName = @"..\..\profile.txt";
            TextWriter tsw = new StreamWriter(filename, true);

            //Writing text to the file.
            tsw.WriteLine(data);


            //Close the file.
            tsw.Close();
        }


        public void populateProfile()
        {
            FileStream ifs = new FileStream(lessonsfileName, FileMode.Open);
            StreamReader sr = new StreamReader(ifs);
            string line = "";
            string[] tokens = null;

            while ((line = sr.ReadLine()) != null)
            {
                line = line.Trim();
                tokens = line.Split(' '); // separate from-node and to-nodes
                if (tokens.Length > 1)
                {
                    tokens[0] = tokens[0].Trim();
                    tokens[1] = tokens[1].Trim();
                    tokens[2] = tokens[2].Trim();

                    Lesson l = getLesson(int.Parse(tokens[0]), int.Parse(tokens[1]));
                    if (l != null)
                    {
                        l.IsFinished = bool.Parse(tokens[2]);
                        addLesson(l);
                    }
                }
                
                

            }
            sr.Close(); ifs.Close();
        }

        public Lesson getLesson(int id, int chapter_id)
        {
            foreach (Lesson l in Controller.getLessons())
            {
                if (l.Chapter.Id == chapter_id && l.Id == id)
                    return l;
            }
            return null;
        }

        public void addLesson(Lesson l)
        {

            if (!Controller.finishedLessons.Contains(l))
                Controller.finishedLessons.Add(l);
        }


        public void initializeRecommendationsPanel()
        {
            Label pageTitle = new Label();
            pageTitle.Location = new Point();
        }


    }
}
