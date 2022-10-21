using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeachSpace.Web.Models
{
    public class CreateSchedule
    {

        public int UserID { get; set; }
        public int TopicID { get; set; }  
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.TimeSpan> Time { get; set; }
        public string MODE { get; set; }
    }
}