using System;
using System.Collections.Generic;
using System.Text;

namespace AnsarCollage.Models
{
    public class Grade
    {
        public int id { get; set; }
        public string garde { get; set; }
    }

    public class GradeResponse
    {
        public List<Grade> Grades { get; set; }
    }
}
