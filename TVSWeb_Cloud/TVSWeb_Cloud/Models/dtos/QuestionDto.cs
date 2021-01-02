using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TVSWeb_Cloud.Models.dtos
{
    public class QuestionDto
    {
        public QuestionDto()
        {

        }

        public QuestionDto(Question question)
        {
            this.QuestionID = question.QuestionID;
            this.QuestionTitle = question.QuestionTitle;
            this.QuestionContent = question.QuestionContent;
            this.TypeID = question.Type.TypeID;
            this.TypeName = question.Type.Name;
        }
        public int QuestionID { get; set; }
        public string QuestionTitle { get; set; }
        public string QuestionContent { get; set; }

        public int TypeID { get; set; }
        public string TypeName { get; set; }
    }
}