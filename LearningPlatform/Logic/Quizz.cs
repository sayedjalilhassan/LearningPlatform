using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningPlatform.Interface;
namespace LearningPlatform.Logic
{
    public class Quizz
    {
        int _quizId;
        string _quizName;
        string _answer;
        string _question;
        int correct_index = 0;
        List<string> options = new List<string>();

        public Quizz(int id, string name, string question, string answer)
        {
            this.Id = id;
            this.Name = name;
            this.Question = question;
            this.Answer = answer;
            //this.options.Add(question);
        }

        public int Id
        {
            get { return _quizId; }
            set { _quizId = value; }
        }

        public string Name
        {
            get { return _quizName; }
            set { _quizName = value; }
        }

        public string Answer
        {
            get { return _answer; }
            set { _answer = value; }
        }

        public string Question
        {
            get { return _question; }
            set { _question = value; }
        }

        public List<string> Options
        {
            get { return options; }
        }

        public int CorrectIndex
        {
            get { return correct_index; }
            set { correct_index = value; }
        }


    }
}