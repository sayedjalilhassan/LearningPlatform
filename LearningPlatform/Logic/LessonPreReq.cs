using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningPlatform.Logic
{
    public class LessonPreReq : Lesson
    {
        public Lesson base_instance;
        public double RelativeImportance { get; set; }

        public double MasteringLevel { get; set; }

        public LessonPreReq(Lesson l)
        {
            this.base_instance = l;
        }

        public LessonPreReq(int _importance, int _masteringLevel)
        {
            this.RelativeImportance = _importance;
            this.MasteringLevel = _masteringLevel;
        }

    }
}
