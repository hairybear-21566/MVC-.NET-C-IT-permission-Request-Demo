using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RightModel
    {

        public int Id { get; set; } // Primary Key

        public string FormName { get; set; }
        public bool View {  get; set; }

        public bool Delete { get; set; }

        public bool Create { get; set; }

        public bool Edit { get; set; }

        public bool Print { get; set; }

        public bool All { get; set; }

        // Foreign Key
        public int User2ControllerId { get; set; }

        public int ProjectsControllerId { get; set; }

        public int RolesControllerId { get; set; }



        // Navigation property - A Right belongs to one User
        public virtual User2Model User2 { get; set; }

        public virtual ProjectsModel Project { get; set; }

        public virtual RolesModel Role { get; set; }

        // Constructor

        public RightModel()
        { }

        public RightModel(User2Model user, ProjectsModel project, RolesModel role)
        {
           
            User2 = user;
            User2ControllerId = user.Id; // Set foreign key
            Project = project;
            ProjectsControllerId = project.Id; // Set foreign key
            Role = role;
            RolesControllerId = role.Id; // Set foreign key

            this.View = false;
            this.Delete = false;
            this.Create = false;
            this.Print = false;
            this.Edit = false;
            this.All = false;
        }

    }
}