using System;
using System.Collections.Generic;
using System.Text;

namespace AnsarCollage.Models
{
    public class Chapter
    {
        public int id { get; set; }
        public string chapter { get; set; }
    }

    public class ChapterReponse
    {
        public List<Chapter> Chapters { get; set; }
    }
}
