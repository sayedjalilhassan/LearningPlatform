using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningPlatform.Logic
{
    public class Chapter
    {
        private string title;
        private string instructor;
        private DateTime lastPlayed = DateTime.MinValue;
        private List<Lesson> lessons = new List<Lesson>();
        private int id;

        public Chapter(string name)
        {
            this.Title = name;
        }

        public Chapter()
        {
            // TODO: Complete member initialization
        }

        public string Instructor
        {
            get { return instructor; }
            set { instructor = ""; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public void addLesson(Lesson s)
        {
            this.lessons.Add(s);
        }

        public List<Lesson> Lessons
        {
            get{
                List<Lesson> lessons = new List<Lesson>();
                foreach (Lesson s in Controller.getLessons())
                {
                    if (s.Chapter.Title.Equals(title))
                    {
                        lessons.Add(s);
                    }

                }

                return lessons;
            }
            
        }
        


        public long SizeInBytes
        {
            get
            {
                if (this.sizeInBytes == -1)
                {
                    this.sizeInBytes = 0;
                    foreach (Lesson s in this.Lessons)
                        this.sizeInBytes += s.SizeInBytes;
                }
                return this.sizeInBytes;
            }
        }
        private long sizeInBytes = -1;

        public DateTime LastPlayed
        {
            get
            {
                if (this.lastPlayed == DateTime.MinValue)
                {
                    foreach (Lesson s in this.Lessons)
                        if (s.LastPlayed > this.lastPlayed)
                            this.lastPlayed = s.LastPlayed;
                }
                return this.lastPlayed;
            }
        }

    }
}
