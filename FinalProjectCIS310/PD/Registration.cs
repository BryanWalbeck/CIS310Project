using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCIS310
{
    public class Registration
    {
        public int ID { get; set; }
        public int customerID { get; set; }
        public int lessonID { get; set; }
        public DateTime scheduleDate { get; set; }
        public string completedLesson { get; set; }
        public DateTime cancelDate { get; set; }

        public Registration(int setCustomerID,
            int setLessonID, DateTime setPurchaseDate, string setComplete, 
            DateTime setCancelDate)
        {
            this.customerID = setCustomerID;
            this.lessonID = setLessonID;
            this.scheduleDate = setPurchaseDate;
            this.completedLesson = setComplete;
            this.cancelDate = setCancelDate;
        }

        public Registration()
        {

        }
    }
}
