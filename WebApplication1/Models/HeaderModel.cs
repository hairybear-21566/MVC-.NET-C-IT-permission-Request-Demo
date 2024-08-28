using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class HeaderModel
    {
        public int id { get; set; }
        public string RefNo { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public string Project { get; set; }
        public string AssignedProject { get; set; }

        public int Status { get; set; }

    }
}