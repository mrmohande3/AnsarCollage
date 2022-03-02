using System;
using System.Collections.Generic;
using System.Text;

namespace AnsarCollage.Models
{
    public class Cours
    {
        public int id { get; set; }
        public string course { get; set; }
    }

    public class CoursResponse
    {
        public List<Cours> Courses { get; set; }
    }

}
