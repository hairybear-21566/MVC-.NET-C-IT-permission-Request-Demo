﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    
    public class HomeController : Controller
    {

        private Project1Entities db = new Project1Entities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        // Handles the initial GET request and displays the form
        [HttpGet]
        public ActionResult Data()
        {
            // Populate ViewBag.Data with the key-value pairs for the initial view
            ViewBag.Data = new Dictionary<string, string>
            {
                { "1", "foo" },
                { "2", "bar" },
                { "3", "baz" },
                { "4", "gaaa" }
            };

            return View();
        }

        [HttpPost]
        public ActionResult Data(string input)
        {
            var keyValuePairs = new Dictionary<string, string>
    {
        { "1", "foo" },
        { "2", "bar" },
        { "3", "baz" },
        { "4", "gaaa" }
    };

            ViewBag.Data = keyValuePairs;
            List<RightModel> rights = new List<RightModel>();


            if (keyValuePairs.ContainsKey(input))
            {
                ViewBag.Result = $"Key: {input}, Value: {keyValuePairs[input]}";
              rights= DisplayUserRights(input);
            }
            else
            {
                ViewBag.Result = "Key not found.";
                ViewBag.Records = new List<RightModel>();
            }
            ViewBag.Records = "YES";

            return View(rights);
        }

        SqlConnection _connection = null;

        private void EproConnection()
        {
         
            string strConnection = "Data Source=TYLERHP\\SQLEXPRESS;Initial Catalog=Project1;Integrated Security=True;Trust Server Certificate=True";
            this._connection = new System.Data.SqlClient.SqlConnection();
            this._connection.ConnectionString = strConnection;
        }

        
        private void InitConnection()
        {
            //string queryString = "INSERT INTO Project1.dbo.Test VALUES ('8000','user name', 'user', 'form name',1,1,1,1,1,1,1);";

            string queryString = "INSERT INTO Test(project_name,name,View,status) VALUES (@project_name,@name,@View,@status)";

            SqlCommand command = new SqlCommand(queryString, _connection);
            command.Parameters.AddWithValue("@project_name", "abc");
            command.Parameters.AddWithValue("@name", "tyler");
            command.Parameters.AddWithValue("@View", true);
            command.Parameters.AddWithValue("@status", 100);

            command.ExecuteNonQuery();


            //var withBlock = sqlCmdEpro;
            //withBlock.Connection = _connection;
            //withBlock.CommandType = CommandType.Text;
            //try
            //{
            //    withBlock.CommandText = "Insert into Test1 (id) values (" + key + ")";
            //}
            //catch (Exception ex)
            //{
            //   Interaction.MsgBox(ex.Message + "Update" + d.Name);
            //}


            /*
            SqlConnection withBlock = new SqlConnection(this._connection.ConnectionString);
            
                using (SqlCommand getRole = new SqlCommand("findUserRole", withBlock))
                {

                    withBlock.Open(); //crashes at this line
                    getRole.CommandType = CommandType.StoredProcedure;
                    getRole.Parameters.Add(new SqlParameter("@Us", username));
                    SqlDataReader reader = getRole.ExecuteReader();

                }
                withBlock.Close();
             */
            /* 
            withBlock.Connection.Close();
            withBlock.Connection.Open();
            withBlock.ExecuteNonQuery();
            withBlock.Connection.Close();
            */
        }


        public void AddDb(Test obj)
        {

            string sql = "INSERT INTO Project1.dbo.Test VALUES ('8000','user name', 'user', obj.1,1,1,1,1,1)";


            string strConnection = "Data Source=TYLERHP\\SQLEXPRESS;Initial Catalog=Project1;Integrated Security=True";
            using (SqlConnection db = new SqlConnection(strConnection))
            {
                db.Open();
                SqlCommand command = new SQLcommand(sql, db);
                command.ExecuteNonQuery();

               

                  
                    db.Close();

                   

                }
                
                
            }
        

    [HttpPost]
    public ActionResult UpdateRecords(IList<RightModel> lst)
    {
            foreach (RightModel item in lst)
            {
                Test test = new Test
                {
                    status = item.status,
                    All = item.All,
                    Create = item.Create,
                    project_code = item.project_code,
                    Delete = item.Delete,
                    name = item.name,
                    Edit = item.Edit,
                    form_name = item.form_name,
                    View = item.View,
                    username = item.username
                };
                AddDb(test);
            }
           


            return View("Data");
        } 



        private List<String> GetFormsTimeKeeper() {
            return new List<String> {
                "Employee",
                "Sub Contractor Labour",
                "Daily Time Sheet",
                "Single Time Sheet 1",
                "Single Time SHeet 2",
                "Equipment Time Sheet",
                "Scan Details",
                "Activity Change",
                "Timesheet Query",
                "Employee Transfer Out",
                "Employee Transfer Out",
                "Transfer To Al Jaber EST",
                "Transfer From Al Jaber EST",
                "Transfer To Qatar",
                "Transfer From Qatar",
                "Employee Dept. Transfer",
                "Foreman Change",
                "Foreman Transfer",
                "Budgets",
                "Productivity",
            };
             }

        private List<String> GetFormsCostControl()
        {
            return new List<String>
            {
                "Location",
                "Sub Location",
                "Owner",
                "Unit",
                "Activity",
                "Sub Activity",
                "Project Activity",
                "Project Opening Balance",
                "Disciplines",
                "Item",
                "New Activity",
                "Foreman Activity",
                "Catergory",
                "Equipments",
                "Consultant/Others",
                "Diesel Rate",
                "Diesel Reciept",
                "Fuel Card",
                "Sub Contracted Hours",
                "Departments",
                "Support Office Timesheet",
                "Equipment Transfer",
                "Equipment Reciept",
                "Dynamic Reports"

            };
        }

        private List<String> GetReportsEquipments()
        {
            return new List<String>
            {
                "E01 - Equipment List",
                "E02 - Monthly Equipment Timesheet",
                "E04 - Equipment Cost Analysis - s...",
                "E05 - Equipment Cost Analysis - s...",
                "Disciplie List",
                "Activity List",
                "Sub Activity List",
                "Item List",
                "New Activity List",
                "Project Sub Activty List",
                "D01 - Prject Diesel Distrubution",
                "D02 - Monthly Diesel Distrubution",
                "D03 - Daily Disiel Distrubution",
                "D04 - Equipment Disiel Consumption",
                "D05 - Disiel Summary"

            };
        }

        private List<String> GetReportsCostControl() {
            return new List<string> { 
            "C01 - Basic Project Information",
            "C02 - Cumalative Man-hours - sorted",
            "C03 - Cumalative Man-hours - sorted",
            "C04 - Man-hour Summary - sorted",
            "C05 - Man-hour Summary - sorted",
            "C06 - Man-hour Summary - sorted",
            "C07 - Man-hour Cost Summary - sorted",
            "C08 - Cumalative Man-hous Cost ...",
            "C09 - Man-hour Cost - Sorted by A...",
            "C10 - Company/Projects Monthly ...",
            "C20 - Subcontracted Man-hour Cost",
            "C11 - Budget vs Actual Manhours",
            "C12 - Designation Actual Unit Rate",
            "C13 - Activity Actual Unit Rate",
            "C14 - Company/Project Actual Work",
            "C15 - Weekly Productivity Report",
            "C16 - Support Office Timesheet",
            "C17 - Support Office Timesheet Su...",
            "C18 - Support Office Timesheet Su..."
            };
        }

        private List<String> GetReportsTimeKeeper()
        {
            return new List<string> {
            "T01 - Employee List",
            "T02 - Monthly Timesheet",
             "T13 - Subcontractor Timesheet",
            "T03 - Foreman Timesheet",
            "T04 - Missing Timesheet",
            "T06 - Employee at Site",
            "T07 - Absence Report for Month",
            "T08 - Daily Manpower by Location",
            "T09 - Daily Manpower by Designation",
            "T10 - Man-hour Summary (All Emp...",
            "T11 - Leave Register",
            "T12 - Employee Transfer History",
            "T13 - Offshore Worked Days",
            "T14 - Productive Incentive",
            "T15 - Productive Incentive Date",
            "T16 - Absent Days",
            "T17 - Overtime",
            "Employee Transfers",
            "Sick Leave Details",
            "Employee Transfer (To AJE)",
            "Employee Transfer (From AJE)",
            "Transfer Not Yet Recieved"
            };
        }



        public List<RightModel>  DisplayUserRights(string userId)
        {

            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>
            {
                { "1", "foo" },
                { "2", "bar" },
                { "3", "baz" },
                { "4", "gaaa" }
            };

            List<RightModel> rights = new List<RightModel>();


            // Adding records
            // Reports - Time Keeper

            //var right = new RightModel();
            //right.FormName = "Reports - Time Keeper";
            //right.View = false;
            //right.Create = false;
            //right.Delete = false;
            //right.Print = false;
            //right.All = false;
            //right.Edit = false;
            //rights.Add(right);


            //right = new RightModel();
            //right.FormName = "Reports - Time Scam";
            //right.View = false;
            //right.Create = false;
            //right.Delete = false;
            //right.Print = false;
            //right.All = false;
            //right.Edit = false;
            //rights.Add(right);

            foreach (String s in this.GetFormsTimeKeeper()) {
                rights.Add(new RightModel(false, false, false, false, false, false, "Forms - Time Keeper: "+s));
            }
            foreach (String s in this.GetReportsEquipments())
            {
                rights.Add(new RightModel(false, false, false, false, false, false, "Reports - Equipment: " + s));
            }

            foreach (String s in this.GetFormsCostControl()) 
            {
                rights.Add(new RightModel(false, false, false, false, false, false, "Forms - Cost Control: " + s));
            }

            foreach (String s in this.GetReportsCostControl())
            {
                rights.Add(new RightModel(false, false, false, false, false, false, "Reports - Cost Control: " + s));
            }

            foreach(String s in this.GetReportsTimeKeeper())
            {
                rights.Add(new RightModel(false, false, false, false, false, false, "Reports - Time Keeper: " + s));
            }




            //foreach (string key in this.GetReportsTimeKeeper())
            //{
            //    var user = new User2Model("JohnDoe", "Password123","JohnDoe@email.com");
            //    var project = new ProjectsModel("...","...");
            //    var role = new RolesModel(key, "Reports - Time Keeper");
            //    var right = new RightModel(user, project, role);
            //    rights.Add(right);
            //}

            //foreach (string key in this.GetReportsEquipments())
            //{
            //    var user = new User2Model("JohnDoe", "Password123", "JohnDoe@email.com");
            //    var project = new ProjectsModel("...", "...");
            //    var role = new RolesModel(key, "Reports - Equipment");
            //    var right = new RightModel(user, project, role);
            //    rights.Add(right);
            //}

            //foreach (string key in this.GetReportsCostControl())
            //{
            //    var user = new User2Model("JohnDoe", "Password123", "JohnDoe@email.com");
            //    var project = new ProjectsModel("...", "...");
            //    var role = new RolesModel(key, "Reports - Cost Control");
            //    var right = new RightModel(user, project, role);
            //    rights.Add(right);
            //}

            //foreach (string key in this.GetFormsTimeKeeper())
            //{
            //    var user = new User2Model("JohnDoe", "Password123", "JohnDoe@email.com");
            //    var project = new ProjectsModel("...", "...");
            //    var role = new RolesModel(key, "Forms - TimeKeepers");
            //    var right = new RightModel(user, project, role);
            //    rights.Add(right);
            //}

            //foreach (string key in this.GetFormsCostControl())
            //{
            //    var user = new User2Model("JohnDoe", "Password123", "JohnDoe@email.com");
            //    var project = new ProjectsModel("...", "...");
            //    var role = new RolesModel(key, "Forms - Cost Control");
            //    var right = new RightModel(user, project, role);
            //    rights.Add(right);
            //}

            return rights;
         //   ViewBag.Records = rights ;

         //   ViewBag.Data = keyValuePairs;

        }
    }
}
