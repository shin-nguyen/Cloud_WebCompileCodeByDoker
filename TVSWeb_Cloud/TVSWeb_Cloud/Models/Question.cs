using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TVSWeb_Cloud.Models
{
    public class Question
    {
        public int QuestionID { get; set; }

        public string QuestionTitle { get; set; }
        public string QuestionContent { get; set; }

        public TypeOfQuestion Type { get; set; }
        public int TypeID { get; set; }
    }
}