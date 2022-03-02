using System;
using System.Collections.Generic;
using System.Text;

namespace AnsarCollage.Models
{
    public class File
    {
        public int id { get; set; }
        public string title { get; set; }
        public string file { get; set; }
    }

    public class FileResponse
    {
        public List<File> Files { get; set; }
    }
}
