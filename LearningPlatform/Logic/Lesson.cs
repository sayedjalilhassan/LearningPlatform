using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningPlatform.Interface;
using System.IO;
namespace LearningPlatform.Logic
{
    public class Lesson
    {
        private string title;
        private Instructor instructor;
        private long sizeInBytes;
        private DateTime lastPlayed;
        private Chapter chapter;
        private int id;
        private double playedTime;
        private double totalPlayTime;
        private string videoPath;
        private bool isFinished;
        public List<LessonPreReq> preReqs = new List<LessonPreReq>();
        public Double difficultyfactor; // has inverse relation to the difficulty level
        public Double cumalative_average;
        //static private List<Lesson> AllLessons = new List<Lesson>();
        private List<Quizz> quizes_list = new List<Quizz>();
        //static private List<InstructorExample> AllInstructors = new List<InstructorExample>();

        public Lesson(int id, string title, Instructor instructor, Chapter chapter,Double diff_fac)
        {
            this.Id = id;
            this.Title = title;
            this.Instructor = instructor;
            this.difficultyfactor = diff_fac;
            this.Chapter = chapter;
            this.totalPlayTime = 0;
            this.playedTime = 0;

        }

        public Lesson(string title, Instructor instructor, Chapter chapter, string videopath, long sizeInBytes, DateTime lastPlayed)
        {
            this.Title = title;
            this.Instructor = instructor;
            this.LastPlayed = lastPlayed;
            this.SizeInBytes = sizeInBytes;
            this.Chapter = chapter;
            this.videoPath = videopath;
            this.totalPlayTime = 0;
            this.playedTime = 0;
            this.isFinished = false;
        }

        public Lesson()
        {
            // TODO: Complete member initialization
            this.Title = "Empty";
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public bool IsFinished
        {
            get { return isFinished; }
            set { isFinished = value; }
        }


        public Chapter Chapter
        {
            get { return chapter; }
            set { chapter = value; }
        }

        public string VideoPath
        {
            get { return videoPath; }
            set { videoPath = value; }
        }


        public Instructor Instructor
        {
            get { return instructor; }
            set { instructor = value; }
        }

        public List<LessonPreReq> PreReqs
        {
            get { return preReqs; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime LastPlayed
        {
            get { return lastPlayed; }
            set { lastPlayed = value; }
        }

        public double TotalPlayTime
        {
            get { return this.totalPlayTime; }
            set { this.totalPlayTime = value; }
        }

        public double PlayedTime
        {
            get { return this.playedTime; }
            set { this.playedTime = value; }
        }

        public long SizeInBytes
        {
            get { return sizeInBytes; }
            set { sizeInBytes = value; }
        }


        public double GetSizeInMb()
        {
            return ((double)this.SizeInBytes) / (1024.0 * 1024.0);
        }

        public List<LessonPreReq> getPreReqs()
        {
            if (this.preReqs.Count == 0)
            {
                populatePreReqs();
            }
            return this.PreReqs;
        }

        public void populatePreReqs()
        {
            FileStream ifs = new FileStream(@"..\..\Resources\assests\lessons\" + this.Id.ToString() + @"\pre_reqs.txt", FileMode.Open);
            StreamReader sr = new StreamReader(ifs);
            string line = "";
            string[] tokens = null;

            while ((line = sr.ReadLine()) != null)
            {
                if (line != "")
                {
                    tokens = line.Split(','); // separate from-node and to-nodes
                    //= Double.Parse(tokens[0].Trim());
                    if (tokens[0] != "")
                    {
                        if (getLesson(int.Parse(tokens[0].Trim())))
                        {
                            this.preReqs.ElementAt(this.preReqs.Count - 1).MasteringLevel =
                                double.Parse(tokens[1].Trim());
                            this.preReqs.ElementAt(this.preReqs.Count - 1).RelativeImportance =
                                double.Parse(tokens[2].Trim());
                        }

                    }
                    /*    
                    for (int index = 0; index < tokens.Length; ++index)
                    {
                        tokens[index] = tokens[index].Trim();
                        getLesson(int.Parse(tokens[index]));
                    } */
                }

            }

            sr.Close(); ifs.Close();
        }

        public bool getLesson(int id)
        {
            foreach (Lesson l in Controller.getLessons())
            {
                if (l.Id == id)
                {
                    this.preReqs.Add((LessonPreReq)(l));
                    return true;
                }

            }
            return false;
        }


        // What follows are DB-like functions

        public List<Quizz> getQuizes()
        {
            if (this.Id != 0)
            {
                AddQuestions();
                if (this.quizes_list.Count > 0)
                {
                    addQuestionsJpegs();
                    addAnswerJpegs();
                    addAnswers();
                    CAnswers();
                }
            }

            // if (Lesson.quizes_list.Count == 0)
            //   Lesson.quizes_list = Lesson.InitializeChapters();
            /*
            if (this.quizes_list.Count == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    Quizz q = new Quizz(1, "", "question number" + i + "", "answer is matrix");
                    q.Options.Add("Option 0");
                    q.Options.Add("Option 1");
                    q.Options.Add("Option 2");
                    q.CorrectIndex = 2;
                    this.quizes_list.Add(q);
                    Console.WriteLine(this.quizes_list.Last().Answer);
                }

            } */


            return quizes_list;
        }

        public void AddQuestions()
        {
            FileStream ifs = new FileStream(@"..\..\Resources\assests\lessons\" + this.Id.ToString() + @"\questions.txt", FileMode.Open);
            //FileStream ifs = new FileStream(@"..\..\Resources\assests\lessons\8\questions.txt", FileMode.Open);
            //FileStream ifs = new FileStream(@"Resources\assests\lessons\19\questions.txt", FileMode.Open);

            //FileStream ifs = new FileStream(@"Resources\assests\video_paths.txt", FileMode.Open);
            StreamReader sr = new StreamReader(ifs);
            string line = "";
            int i = 0;
            this.quizes_list.Clear();
            while ((line = sr.ReadLine()) != null)
            {
                Quizz q = new Quizz(i);
                q.Question = line;
                this.quizes_list.Add(q);
               // Console.WriteLine("Question Text: " + q.Question + "");
                i++;
            }
           // Console.WriteLine("Questions: " + this.quizes_list.Count + "");
            sr.Close(); ifs.Close();
        }

        public void addQuestionsJpegs()
        {
            FileStream ifs = new FileStream(@"..\..\Resources\assests\lessons\" + this.Id.ToString() + @"\q_jpegs.txt", FileMode.Open);
            //FileStream ifs = new FileStream(@"..\..\Resources\assests\lessons\8\q_jpegs.txt", FileMode.Open);
            //FileStream ifs = new FileStream(@"Resources\assests\lessons\19\q_jpegs.txt", FileMode.Open);
            //FileStream ifs = new FileStream(@"Resources\assests\video_paths.txt", FileMode.Open);
            StreamReader sr = new StreamReader(ifs);
            string line = "";
            int i = 0;
            string[] tokens = null;
            while ((line = sr.ReadLine()) != null)
            {
                if (line != "")
                {
                    tokens = line.Split(','); // separate from-node and to-nodes
                   // Console.WriteLine("qjepgs: " + tokens.Length);
                    for (int index = 0; index < tokens.Length; ++index)
                    {
                        tokens[index] = tokens[index].Trim();
                        this.quizes_list.ElementAt(i).q_jpegs.Add(tokens[index]);
                    }

                }
                i++;
            }
            sr.Close(); ifs.Close();
        }

        public void addAnswerJpegs()
        {
            FileStream ifs = new FileStream(@"..\..\Resources\assests\lessons\" + this.Id.ToString() + @"\ans_jpegs.txt", FileMode.Open);
            //FileStream ifs = new FileStream(@"..\..\Resources\assests\lessons\8\ans_jpegs.txt", FileMode.Open);
            // FileStream ifs = new FileStream(@"Resources\assests\lessons\19\ans_jpegs.txt", FileMode.Open);
            string[] opt = new string[] { "A", "B", "C", "D" };
            //FileStream ifs = new FileStream(@"Resources\assests\video_paths.txt", FileMode.Open);
            StreamReader sr = new StreamReader(ifs);
            string line = "";
            int i = 0;
            string[] tokens = null;
            while ((line = sr.ReadLine()) != null)
            {
                if (line != "")
                {
                    tokens = line.Split(','); // separate from-node and to-nodes

                    for (int index = 0; index < tokens.Length; ++index)
                    {
                        tokens[index] = tokens[index].Trim();
                        this.quizes_list.ElementAt(i).ans_jpegs.Add(tokens[index]);
                        this.quizes_list.ElementAt(i).Options.Add(opt[index]);
                    }
                }
                i++;

            }
            sr.Close(); ifs.Close();
        }

        public void addAnswers()
        {
            FileStream ifs = new FileStream(@"..\..\Resources\assests\lessons\" + this.Id.ToString() + @"\answers.txt", FileMode.Open);
            //FileStream ifs = new FileStream(@"..\..\Resources\assests\lessons\8\answers.txt", FileMode.Open);
            //FileStream ifs = new FileStream(@"Resources\assests\lessons\19\answers.txt", FileMode.Open);
            //FileStream ifs = new FileStream(@"Resources\assests\video_paths.txt", FileMode.Open);
            StreamReader sr = new StreamReader(ifs);
            string line = "";
            int i = 0;
            string[] tokens = null;
            while ((line = sr.ReadLine()) != null)
            {
                if (line != "")
                {
                    tokens = line.Split(','); // separate from-node and to-nodes

                    for (int index = 0; index < tokens.Length; ++index)
                    {
                        this.quizes_list.ElementAt(i).Options.Add(tokens[index]);
                    }

                }
                i++;
            }
            sr.Close(); ifs.Close();
        }

        public void CAnswers()
        {
            FileStream ifs = new FileStream(@"..\..\Resources\assests\lessons\" + this.Id.ToString() + @"\c_answers.txt", FileMode.Open);
            //FileStream ifs = new FileStream(@"..\..\Resources\assests\lessons\8\c_answers.txt", FileMode.Open);
            //FileStream ifs = new FileStream(@"Resources\assests\lessons\19\c_answers.txt", FileMode.Open);

            //FileStream ifs = new FileStream(@"Resources\assests\video_paths.txt", FileMode.Open);
            StreamReader sr = new StreamReader(ifs);
            string line = "";
            int i = 0;
            while ((line = sr.ReadLine()) != null)
            {
                if (line != "")
                {
                    this.quizes_list.ElementAt(i).CorrectIndex = int.Parse(line);

                }
                i++;
            }
            sr.Close(); ifs.Close();
        }



    }

}
