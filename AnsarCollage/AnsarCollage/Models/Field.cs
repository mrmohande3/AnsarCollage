using System;
using System.Collections.Generic;
using System.Text;

namespace AnsarCollage.Models
{
    public class Field
    {
        public int id { get; set; }
        public string field { get; set; }
    }

    public class FieldResponse
    {
        public List<Field> Fields { get; set; }
    }

}
