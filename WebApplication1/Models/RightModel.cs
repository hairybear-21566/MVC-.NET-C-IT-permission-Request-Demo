using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplication1.Models
{
    public class RightModel
    {

        public int id { get; set; }
        public string RefNo { get; set; }
        public string project_code { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string form_name { get; set; }
        public bool View { get; set; }
        public bool Delete { get; set; }
        public bool  Print { get; set; }
        public bool Edit { get; set; }
        public bool All { get; set; }
        public bool Create { get; set; }
        public int status { get; set; }

        /*
                // Foreign Key
                public int User2ControllerId { get; set; }

                public int ProjectsControllerId { get; set; }

                public int RolesControllerId { get; set; }



                // Navigation property - A Right belongs to one User
                public virtual User2Model User2 { get; set; }

                public virtual ProjectsModel Project { get; set; }

                public virtual RolesModel Role { get; set; }
        */
        // Constructor

        public RightModel()
        { // can be also used to set default values in db from the way I have coded this thing
         
        }

        public RightModel(bool view,bool delete, bool create, bool print, bool edit, bool all, String formName,int status,string name, string RefNo,string project_code, string username)
        {
           
            //User2 = user;
            //User2ControllerId = user.Id; // Set foreign key
            //Project = project;
            //ProjectsControllerId = project.Id; // Set foreign key
            //Role = role;
            //RolesControllerId = role.Id; // Set foreign key

            this.View = view;
            this.Delete = delete;
            this.Create = create;
            this.Print = print;
            this.Edit = edit;
            this.All = all;
            this.form_name = formName;
            this.name = name;
            this.project_code = project_code;
            this.username = username;
            this.status = status;
            this.RefNo = RefNo;
        }

    }
}