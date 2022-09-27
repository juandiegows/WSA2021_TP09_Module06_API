using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSA2021_TP09_Module06_API.Models.Response
{
    public class Response
    {
        public string Message { get; set; }
        public dynamic Data { get; set; }
        public bool Sucess { get; set; }
    }
}