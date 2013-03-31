using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningPlatform.Logic
{
    public class Instructor
    {
        private string title;
        public List<Lesson> lessons = new List<Lesson>();

        public Instructor(string name)
        {
            this.Title = name;
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public  List<Lesson> getLessons()
        {
                return this.lessons;
        }


    }
}
