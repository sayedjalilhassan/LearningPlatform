using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningPlatform.Logic
{
    class Question
    {
        int id;
        string question;
        string answer;
        public List<String> options = new List<String>();

        public Question(int id, string answer)
        {
            Id = id;
            Answer = answer;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Question_statement
        {
            get { return question; }
            set { question = value; }
        }

        public string Answer
        {
            get { return answer; }
            set { answer = value; }
        }

        public List<string> AllOptions
        {
            get { return options; }
        }

        public void addOption(String str)
        {
            this.AllOptions.Add(str);
        }

        public void InitializeOptions(List<string> str)
        {
            foreach (String s in str)
            {
                this.AllOptions.Add(s);
            }

        }

    }
}
