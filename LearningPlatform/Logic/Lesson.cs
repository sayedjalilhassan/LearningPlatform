using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningPlatform.Interface;
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
        private string videoPath;
        //static private List<Lesson> AllLessons = new List<Lesson>();
        private List<Quizz> quizes_list = new List<Quizz>();
        //static private List<InstructorExample> AllInstructors = new List<InstructorExample>();

        public Lesson(string title, Instructor instructor, Chapter chapter, long sizeInBytes, DateTime lastPlayed)
        {
            this.Title = title;
            this.Instructor = instructor;
            this.LastPlayed = lastPlayed;
            this.SizeInBytes = sizeInBytes;
            this.Chapter = chapter;
        }

        public Lesson(string title, Instructor instructor, Chapter chapter, string videopath, long sizeInBytes, DateTime lastPlayed)
        {
            this.Title = title;
            this.Instructor = instructor;
            this.LastPlayed = lastPlayed;
            this.SizeInBytes = sizeInBytes;
            this.Chapter = chapter;
            this.videoPath = videopath;
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


        public long SizeInBytes
        {
            get { return sizeInBytes; }
            set { sizeInBytes = value; }
        }


        public double GetSizeInMb()
        {
            return ((double)this.SizeInBytes) / (1024.0 * 1024.0);
        }

        // What follows are DB-like functions

        public List<Quizz> getQuizes()
        {
            // if (Lesson.quizes_list.Count == 0)
            //   Lesson.quizes_list = Lesson.InitializeChapters();
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

            }


            return quizes_list;
        }

    }

}
