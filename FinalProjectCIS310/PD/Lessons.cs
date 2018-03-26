using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCIS310
{
    public class Lessons
    {
        public int ID { get; set; }
        public string lessonName { get; set; }
        public string lessonType { get; set; }
        public decimal lessonPrice { get; set; }
        public int lessonLength{ get; set; }

        public Lessons(string setLessonName, string setLessonType, decimal setLessonPrice, int setLessonLength)
        {
            this.lessonName = setLessonName;
            this.lessonType = setLessonType;
            this.lessonPrice = setLessonPrice;
            this.lessonLength = setLessonLength;
        }

        public Lessons()
        {

        }
    }
}
