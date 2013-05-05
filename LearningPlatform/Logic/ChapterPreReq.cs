using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningPlatform.Logic
{
    class ChapterPreReq : Chapter
    {
        int RelativeImportance { get; set; }

        int MasteringLevel { get; set; }

        public ChapterPreReq()
        {
        }

        public ChapterPreReq(int _importance, int _masteringLevel)
        {
            this.RelativeImportance = _importance;
            this.MasteringLevel = _masteringLevel;
        }
    }
}
