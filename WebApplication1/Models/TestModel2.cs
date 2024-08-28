using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Test
    {
        public int id { get; set; }
        public string RefNo { get; set; }
        public string project_code { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string form_name { get; set; }
        public bool View { get; set; }
        public Nullable<bool> Delete { get; set; }
        public Nullable<bool> Create { get; set; }
        public Nullable<bool> Print { get; set; }
        public Nullable<bool> Edit { get; set; }
        public Nullable<bool> All { get; set; }
        public int status { get; set; }
    }
}
