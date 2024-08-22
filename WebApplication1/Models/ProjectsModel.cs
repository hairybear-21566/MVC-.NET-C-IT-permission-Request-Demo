using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ProjectsModel
    {
        public int Id { get; set; }
        public String ProjectName { get; set; }
        public String ProjectDesc { get; set; }

        public virtual ICollection<RightModel> Rights { get; set; }

        public ProjectsModel(string projectName, string projectDesc)
        {
            ProjectName = projectName;
            ProjectDesc = projectDesc;
            Rights = new List<RightModel>(); // Initialize collection
        }
    }
}