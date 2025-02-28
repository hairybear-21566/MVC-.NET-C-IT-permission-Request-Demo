﻿using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using WebApplication1.Models;
using static System.Data.Entity.Infrastructure.Design.Executor;
using System.Reflection;


namespace WebApplication1.Controllers
{
    
    public class HomeController : Controller{

        //private Project1Entities db = new Project1Entities();
        private static readonly string strConnection = "Data Source=TYLERHP\\SQLEXPRESS;Initial Catalog=Project1;Integrated Security=True";

        // Returns list of form names
        private List<String> GetFormsTimeKeeper()
        {
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
        
        // Returns list of form names
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
        
        // Returns list of form names
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
        
        // Returns list of form names
        private List<String> GetReportsCostControl()
        {
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
        
        // Returns list of form names
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
        
        // Returns Index View
        public ActionResult Index()
        {
            return View();
        }
        
        // Returns About View
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        
        // Returns Contact View
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        // retrieves blank form records when creating new form
        public List<RightModel> GetBlankUserRights(string userId, string name, string RefNo, string project_code, string username)
        {

            List<RightModel> rights = new List<RightModel>();

            foreach (String s in this.GetFormsTimeKeeper())
            {
                rights.Add(new RightModel(false, false, false, false, false, false, "Forms - Time Keeper: " + s, 0, name, RefNo, project_code, username));
            }

            foreach (String s in this.GetFormsCostControl())
            {
                rights.Add(new RightModel(false, false, false, false, false, false, "Forms - Cost Control: " + s, 0, name, RefNo, project_code, username));
            }

            foreach (String s in this.GetReportsTimeKeeper())
            {
                rights.Add(new RightModel(false, false, false, false, false, false, "Reports - Time Keeper: " + s, 0, name, RefNo, project_code, username));
            }

            foreach (String s in this.GetReportsCostControl())
            {
                rights.Add(new RightModel(false, false, false, false, false, false, "Reports - Cost Control: " + s, 0, name, RefNo, project_code, username));
            }

            foreach (String s in this.GetReportsEquipments())
            {
                rights.Add(new RightModel(false, false, false, false, false, false, "Reports - Equipment: " + s, 0, name, RefNo, project_code, username));
            }

            ViewBag.Result = $"insertttttttttttt {RefNo}" + rights.ToString();

            return rights;


        }
        
        // Returns Data View (raw)
        [HttpGet]
        public ActionResult Data()
        {
            
            return View();
        }

        // handles first form submission where user can choose to view or create a form based on RefNo
        [HttpPost]
        public ActionResult Data(string input, string action)
        { // NOTE: all RefNo are hard coded and NOT auto-generated yet

            List < RightModel > rights = new List<RightModel>();

            // Logic for retrieving records for purely viewing
            // and handles the setting of a Viewbag param that prevents users from saving form
            if (action == "View") { // Grabbing entries using SELECT
                
                string sql = "SELECT a.* ,b.* FROM Project1.dbo.EzwereRequest a\r\nINNER JOIN Project1.dbo.EzwereRequestDetail b  ON a.id=b.RequestId\r\nWhere a.RefNo=@RefNo";
                
                using (SqlConnection db = new SqlConnection(strConnection))
                {
                    db.Open();
                    SqlCommand command = new SqlCommand(sql, db);
                    command.Parameters.AddWithValue("@RefNo", input);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    RightModel right = new RightModel(
                                        (bool)reader["View"],
                                        (bool)reader["Delete"],
                                        (bool)reader["Create"],
                                        (bool)reader["Print"],
                                        (bool)reader["Edit"],
                                        (bool)reader["All"],
                                        (string)reader["form_name"],
                                        (int)reader["status"],
                                        (string)reader["EmpName"],
                                        (string)reader["RefNo"],
                                        (string)reader["Project"],
                                        "username"
                                        );
                                    rights.Add(right);
                                    ViewBag.Result = "Select:found";
                                    ViewBag.Records = "YES";
                                    ViewBag.CanSubmit = "NO";
                                }
                            }
                            else 
                            {
                                ViewBag.Result = "Select:ERROR - not found (invalid RefNo)";
                                ViewBag.CanSubmit = "NO";
                            }
                        }
                        catch (Exception ex)
                        {
                            ViewBag.Result = ex.Message;
                        }
                    }
                    db.Close();
                }
            }
            // Logic for creating new form entry
            else{//action == "Create"

                string refNum = "123"; // NOTE: RefNo needs to be auto generated but is hard coded for now

                ViewBag.Records = "YES";
                ViewBag.CanSubmit = "YES";
                rights = GetBlankUserRights("userid","name",refNum,"project code","username"); // NOTE: placeholder strings
            }
            return View(rights);
        }
        
        // use for handling sql "write" operations
        // returns max(id) as int if retrieveMaxKey==True
       public int execSqlInsert(string sql, string strConnection, bool retrieveMaxKey)
        {
            // INSERT execution
            using (SqlConnection db = new SqlConnection(strConnection))
            {

                db.Open();
                SqlCommand command = new SqlCommand(sql, db);
                command.ExecuteNonQuery();
                db.Close();

            }

            
            if (retrieveMaxKey){ //retrieving max(id)
                string query = "SELECT max(id) FROM EzwereRequest";
                using (SqlConnection db = new SqlConnection(strConnection))
                {

                    db.Open();
                    SqlCommand command = new SqlCommand(query, db);
                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            bool ans = reader.Read();
                            int value = (int) reader[""];
                            ViewBag.Result = value;
                            db.Close();
                            return value;
                        }
                        else {
                            ViewBag.Result = "not found";
                            db.Close();
                            return -1; }
                    };
                }
            }
            ViewBag.Result = "not found";
            return -1;
        
        }

        // Handles sql read operations
        // used to be used but is not anymore
        // kept just to keep code working just in case
        public SqlDataReader execSqlSelect(string sql, string strConnection, string input)
        {

            using (SqlConnection db = new SqlConnection(strConnection))
            {
                db.Open();
                SqlCommand command = new SqlCommand(sql, db);
                command.Parameters.AddWithValue("@RefNo", input);
                SqlDataReader queryResults = command.ExecuteReader();
                db.Close();
                return queryResults;
            }

        }
        
        // for a given record INSERT appropriate data into each table
        public void AddDb(FormBody obj, HeaderModel model)
        {
            // INSERT: header data
            string sql;
            sql = "INSERT INTO EzwereRequest(RefNo, EmpCode, EmpName, Designation, Project, AssignedProject, Status) VALUES" +
                         " ('" + model.RefNo + "','"
                         + model.EmpCode + "'," 
                         + "'"+ model.EmpName + "',"
                         + "'"+model.Designation+"',"
                         + "'"+model.Project + "',"
                         + "'"+model.AssignedProject + "',"
                         + ""+model.Status + ")";

            // if -1 returned no max(id) found, hence empty table, thus need this case handling possibly
            // although should be fine without
            int RequestID=execSqlInsert(sql, HomeController.strConnection,true);

            // insert data into other table
             sql = "INSERT INTO EzwereRequestDetail(RequestId, form_name, [View], [Delete], [Create], [Print], [Edit], [All]) VALUES " +
                   " (" + RequestID +",'" + obj.form_name + "', " +
                         " " + (Convert.ToBoolean(obj.View) ? 1 : 0) + "," +
                         " " + (Convert.ToBoolean(obj.Delete) ? 1 : 0) + "," +
                         " " + (Convert.ToBoolean(obj.Create) ? 1 : 0) + "," +
                         " " + (Convert.ToBoolean(obj.Print) ? 1 : 0) + "," +
                         " " + (Convert.ToBoolean(obj.Edit) ? 1 : 0) + "," +
                         " " + (Convert.ToBoolean(obj.All) ? 1 : 0) +")";
                           
            execSqlInsert(sql, HomeController.strConnection,true);
                
            }

        // updating record on create
        [HttpPost]
        public ActionResult UpdateRecords(IList<RightModel> lst){

            // data for header in forms
            HeaderModel headerModel = new HeaderModel
            {
                Project = lst[0].project_code,
                AssignedProject = "Assigned Project", // missing field?
                EmpCode = "empcode", // missing field?
                EmpName = lst[0].name,
                Designation = "designation", // missing field?
                Status = 0,
                RefNo = lst[0].RefNo
            };
            // TODO:
            // if those fields should have been passed to Data.cshtml
            // then add fields to `RightModel` class and
            // parameter values to all its instatiotion

            foreach (RightModel item in lst)
            {
                
                FormBody test = new FormBody
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
                    username = item.username,
                    Print = item.Print,
                    RefNo = item.RefNo
                };
                AddDb(test, headerModel);
            }

            return View("Data");
        } 

        // Generates PDF for download
        public FileResult GeneratePDF(int RecordID)
        {
            // retrieve
            //_Services = new AjesServices();

            string url = System.Configuration.ConfigurationManager.AppSettings.Get("Url");

            url = url + "/content/images/logo.png";

            //var obj = await _Services.GeneratePDF<ServiceRequestReport>(RecordID, ServiceCode);

            string sql = "SELECT a.* ,b.* FROM Project1.dbo.EzwereRequest a\r\nINNER"+
                " JOIN EzwereRequestDetail b  ON a.id=b.RequestId\r\nWhere a.RefNo='123'";
            SqlDataReader reader;
            StringBuilder sb = new StringBuilder();
            string RefNum;

            using (SqlConnection db = new SqlConnection(HomeController.strConnection))
            {
                db.Open();
                SqlCommand command = new SqlCommand(sql, db);
                reader = command.ExecuteReader();

                if (!reader.HasRows)
                {
                    sb.Append("<h1>id not found</h1>");
                    RefNum = "######";
                }
                else
                {
                    reader.Read();
                    HeaderModel header = new HeaderModel
                    {
                        Project = (string)reader["Project"],
                        AssignedProject = (string)reader["AssignedProject"],
                        EmpCode = (string)reader["EmpCode"],
                        EmpName = (string)reader["EmpName"],
                        Designation = (string)reader["Designation"],
                        Status = (int)reader["Status"],
                        RefNo = (string)reader["RefNo"]
                    };
                    RefNum = header.RefNo;

                    sb.Append("<header class='clearfix'>");
                  
                    sb.Append("<br>");
                    sb.Append("<br>");

                    sb.Append("<h1>" + "Al Jaber Energy Services" + "</h1>");
                    sb.Append("<br>");
                    sb.Append("<h1> RefNo:" + header.RefNo + " </h1>");
                    sb.Append("<br>");
                    sb.Append("<br>");
                    sb.Append("<h2>Employee No</h2>");
                    sb.Append($"<p>{header.EmpCode}</p>");

                    sb.Append("<table border='1'>");

                    sb.Append("<thead>");
                    sb.Append("<tr>");
                    sb.Append("<th scope = 'col' width='40%'>Description</th>");
                    sb.Append("<th scope = 'col' > View </ th >");
                    sb.Append("<th scope='col'>Create</th>");
                    sb.Append("<th scope = 'col' > Delete </ th >");
                    sb.Append("<th scope='col'>Print</th>");
                    sb.Append("<th scope = 'col' > Edit </ th >");
                    sb.Append("<th scope='col'>All</th>");
                    sb.Append("</tr>");
                    sb.Append("</thead>");
                    sb.Append("<tbody>");
                    int count = 0;
                 
                    while (reader.HasRows==true)
                    {
                        count += 1;
                        try
                        {
                            bool viewrow = (bool)reader["View"];
                            sb.Append("<tr>");
                            sb.Append($"<td>{reader["form_name"]}</td>");
                            sb.Append("<td>" + ((bool)reader["All"] ? "Y" : "N") + "</td>");
                            sb.Append("<td>" + ((bool)reader["View"] ? "Y" : "N") + "</td>");
                            sb.Append("<td>" + ((bool)reader["Create"] ? "Y" : "N") + "</td>");
                            sb.Append("<td>" + ((bool)reader["Edit"] ? "Y" : "N") + "</td>");
                            sb.Append("<td>" + ((bool)reader["Print"] ? "Y" : "N") + "</td>");
                            sb.Append("<td>" + ((bool)reader["Delete"] ? "Y" : "N") + "</td>");
                            sb.Append("</tr>");
                            reader.Read();
                        }
                        catch (Exception ex){ break; }
                       
                    }
                    sb.Append("</tbody>");
                    sb.Append("</table>");
                    sb.Append("<br>");

                    sb.Append("</main>");
                    sb.Append("<footer>");
                    sb.Append("<br>");
                    sb.Append("Document was created on a computer and is valid without the signature and seal.");
                    sb.Append("</footer>");
                    db.Close();
            }
            }

            StringReader sr = new StringReader(sb.ToString());
            Document pdfDoc = new Document(PageSize.EXECUTIVE);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();

                htmlparser.Parse(sr);
                pdfDoc.Close();

                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                return File(bytes, "application/pdf", "UserRights-" + RefNum + ".PDF");
            }
        }
        
    }
}
