using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TVSWeb_Cloud.Models
{
    public class TypeOfQuestion
    {
        public int TypeID { get; set; }

        public string Name { get; set; }

        public List<Question> Questions { get; set; }
    }
}