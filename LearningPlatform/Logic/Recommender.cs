using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningPlatform.Logic.Recommender
{

    public class Recommender
    {
        private Lesson inputLesson { get; set; }
        private Chapter inputChapter { get; set; }
        //private Course inputCourse { get; set; }

        //public Recommender()
        //{
        //}

        public Recommender(Lesson _inputLesson, Chapter _inputChater)
        {
            this.inputLesson = _inputLesson;
            this.inputChapter = _inputChater;
        }

        public Recommender(Lesson _inputLesson)
        {
            this.inputLesson = _inputLesson;
        }

        public Recommender(Chapter _inputChapter)
        {
            this.inputChapter = _inputChapter;
        }


        public Double calculateExpectedValue()
        {
            //List<LessonPreReq> pre_reqs = this.inputLesson.;
            Double _summation = 0, _summationImportance = 0, _expectedValue = 0;
            foreach (LessonPreReq pre_req in this.inputLesson.preReqs)
            {
                
                _summation += pre_req.MasteringLevel * pre_req.RelativeImportance;
                _summationImportance += pre_req.RelativeImportance;

            }
            _summation *= inputLesson.difficultyfactor;
            //Console.WriteLine("number of pre "+i);
            _expectedValue = _summation / _summationImportance;

            return _expectedValue;
        }
        
    }
}
