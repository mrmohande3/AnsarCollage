﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AnsarCollage.Models
{
    public class ApiResult<T>
    {
        public string Status { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
