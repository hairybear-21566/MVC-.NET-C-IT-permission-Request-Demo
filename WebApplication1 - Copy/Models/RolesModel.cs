using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RolesModel
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public String Category { get; set; }

        public virtual ICollection<RightModel> Rights { get; set; }

        public RolesModel(string description, string category)
        {
            Description = description;
            Category = category;
            Rights = new List<RightModel>(); // Initialize collection
        }
    }
}