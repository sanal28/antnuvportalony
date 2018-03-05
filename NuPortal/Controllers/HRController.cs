using Newtonsoft.Json;
using NuPortal.Common_Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuPortal.Controllers
{
    [SessionTimeout]
    public class HRController : Controller
    {
        // GET: HR
        public ActionResult PollDetailsLog()
        {
            return View();
        }
        public ActionResult EmployeeProgressChart()
        {
            return View();
        }
        public ActionResult LeaveCalendar(int? EmpLeaveType)
        {
            return View();
        }
        public ActionResult HRView()
        {
            return View();
        }
        public ActionResult OfficePollLog()
        {
            return View();
        }
        public ActionResult OfficePoll()
        {
            return View();
        }
        public ActionResult HRHome()
        {
            return View();
        }
        public ActionResult AddEvents(int? hdnId)
        {
            return View();
        }
        public ActionResult AddAnnouncement(int? hdnId)
        {
            return View();
        }
        public ActionResult AnnouncementLog()
        {
            return View();
        }
        public ActionResult Announcement()
        {
            return View();
        }
        public ActionResult AnnouncementReadMore()
        {
            return View();
        }
        public ActionResult TrainingLog()
        {
            return View();
        }
        public ActionResult NewTraining()
        {
            return View();
        }
        public ActionResult TrainingDetails(int? TrainId)
        {
            return View();
        }
        public ActionResult TrainingAssesment(int? hdnId,int? TrainId)
        {
            return View();
        }
        public ActionResult ExitInterviewLog()
        {
            return View();
        }
        public ActionResult ExitDocument(int? EmpId)
        {
            return View();
        }
        public ActionResult Events()
        {
            return View();
        }
        [HttpPost]
        public ActionResult saveEvents(int Id,String Title,DateTime StartDate,DateTime EndDate,String Description,String StartTime,String EndTime,int Operation)
        {
            NuPortalHRService.NuPortalHRService hrService = new NuPortalHRService.NuPortalHRService();
            hrService.Url = Constants.HRService;
            try
            {               
                string jsonString = hrService.AnnouncementOrEventsOper(Id,String.Empty,Convert.ToInt32(Session["EmpID"]),Description,EndDate,Convert.ToInt32(Session["CompanyId"]),Convert.ToInt32(Session["EmpID"]),StartDate,1,Title,StartTime,EndTime,Operation);               
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                hrService = null;

            }

            return Json(Common_Library.Constants.JsonError);
        }
        [HttpPost]
        public JsonResult GetEvents(int eventId,int Operation)
        {            
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                string jsonString = empService.SelectEmployeeInfo(eventId, Operation);
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                empService = null;
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetLeaveCalendar(int Id,int year, int month)
        {
            NuPortalHRService.NuPortalHRService hrService = new NuPortalHRService.NuPortalHRService();
            hrService.Url = Constants.HRService;
            DataTable leave = new DataTable();
            DataTable monthLeave = new DataTable();
            try
            {
                DateTime monthStart = new DateTime(year, month, 1);
                DateTime monthEnd = new DateTime(year, month, DateTime.DaysInMonth(year, month));
                monthStart = monthStart.AddDays(DayOfWeek.Sunday - monthStart.DayOfWeek);
                monthEnd = monthEnd.AddDays(DayOfWeek.Saturday - monthEnd.DayOfWeek);
                leave = JsonConvert.DeserializeObject<DataTable>(hrService.GetDataForCalendar(Id,monthStart, monthEnd, 5));


                monthLeave.Columns.Add("DisplayName");
                monthLeave.Columns.Add("Date");
                monthLeave.Columns.Add("Month");
                monthLeave.Columns.Add("TaskStatus");

                if (leave != null && leave.Rows.Count > 0)
                    foreach (DataRow row in leave.Rows)
                        if (Convert.ToDateTime(row["LeaveStartDate"]) <= monthEnd && Convert.ToDateTime(row["LeaveEndDate"]) >= monthStart)
                            for (DateTime dt = Convert.ToDateTime(row["LeaveStartDate"]); dt <= Convert.ToDateTime(row["LeaveEndDate"]); dt = dt.AddDays(1))
                                if (dt >= monthStart && dt <= monthEnd)
                                    monthLeave.Rows.Add(row["DisplayName"],dt.ToString("yyyy/MM/dd"), dt.Month == month ? "currentmonth" : dt.Month <= month ? "prevmonth" : "nextmonth",row["StatusId"]);
                return Json(JsonConvert.SerializeObject(monthLeave), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
            }
            finally { hrService.Dispose(); monthLeave.Dispose(); }
        }
        [HttpPost]
        public ActionResult NewAnnouncement(string Title, string UploadedFileUrl, string StartDate, string EndDate, string Description)
        {
            NuPortalHRService.NuPortalHRService hrService = new NuPortalHRService.NuPortalHRService();
            hrService.Url = Constants.HRService;
            try
            {
                string jsonString = hrService.AnnouncementOrEventsOper(0, UploadedFileUrl, Convert.ToInt32(Session["EmpID"]),
                    Description, Convert.ToDateTime(EndDate), Convert.ToInt32(Session["CompanyId"]),
                    Convert.ToInt32(Session["EmpID"]), Convert.ToDateTime(StartDate), 1, Title, string.Empty, string.Empty, 1);
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                hrService = null;

            }
            return Json(Common_Library.Constants.JsonError);
        }
        public JsonResult GetAnnouncementsLog()
        {
            NuPortalDBService.NuPortalService Dbservice = new NuPortalDBService.NuPortalService();
            Dbservice.Url = Constants.DBService;
            try
            {
                string jsonString = Dbservice.SelectGridInfo(Convert.ToInt32(Session["CompanyId"]), 18);
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                Dbservice = null;
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAnnouncement(int announcementId,int operationId)
        {
            Dictionary<string, string> oItems = new Dictionary<string, string>();
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                string jsonString = empService.SelectEmployeeInfo(announcementId, operationId);
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                empService = null;
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteAnnouncement(int rowId,int Operation)
        {
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                string JsonString = empService.SelectEmployeeInfo(rowId, Operation);
                if (JsonString != string.Empty)
                {
                    return Json(JsonString, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                empService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }
        public ActionResult UpdateAnnouncement(string Title, string UploadedFileUrl, string StartDate, string EndDate, string Description,
            int announcementId)
        {
            NuPortalHRService.NuPortalHRService hrService = new NuPortalHRService.NuPortalHRService();
            hrService.Url = Constants.HRService;
            try
            {
                string jsonString = hrService.AnnouncementOrEventsOper(announcementId, UploadedFileUrl, Convert.ToInt32(Session["EmpID"]),
                    Description, Convert.ToDateTime(EndDate), Convert.ToInt32(Session["CompanyId"]),
                    Convert.ToInt32(Session["EmpID"]), Convert.ToDateTime(StartDate), 1, Title, string.Empty, string.Empty, 3);
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                hrService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }
        //Announcement on Home page
        public JsonResult GetAnnouncementsHome()
        {
            NuPortalDBService.NuPortalService Dbservice = new NuPortalDBService.NuPortalService();
            Dbservice.Url = Constants.DBService;
            try
            {
                string jsonString = Dbservice.SelectGridInfo(Convert.ToInt32(Session["CompanyId"]), 16);
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                Dbservice = null;
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
      
        //Save Training Document
        [HttpPost]
        public ActionResult saveNewTraining(string Subject, int Trainer, DateTime StartDate, DateTime EndDate, string StartTime, string EndTime, string Details, string Attachment)
        {
            NuPortalHRService.NuPortalHRService hrService = new NuPortalHRService.NuPortalHRService();
            hrService.Url = Constants.HRService;
            try
            {
                string jsonString = hrService.SaveTraining(0,Attachment,Convert.ToInt32(Session["EmpID"]),Details,EndDate, EndTime, Convert.ToInt32(Session["CompanyID"]), Trainer, 0, Convert.ToInt32(Session["EmpID"]),StartDate,StartTime,1,Subject,1);
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                hrService = null;

            }

            return Json(Common_Library.Constants.JsonError);
        }
        //Update Training Document
        [HttpPost]
        public JsonResult updateTrainingDetails(int id, string Subject, int Trainer, DateTime StartDate, DateTime EndDate, string StartTime, string EndTime, string Details, string Attachment)
        {
            NuPortalHRService.NuPortalHRService hrService = new NuPortalHRService.NuPortalHRService();
            hrService.Url = Constants.HRService;
            try
            {
                string jsonString = hrService.SaveTraining(id, Attachment, Convert.ToInt32(Session["EmpID"]), Details, EndDate, EndTime, Convert.ToInt32(Session["CompanyID"]),
                    Trainer, 0, Convert.ToInt32(Session["EmpID"]), StartDate, StartTime, 1, Subject, 2);
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                hrService = null;

            }

            return Json(Common_Library.Constants.JsonError);
        }

        //Get Training Log
        public JsonResult getTrainingLog()
        {
            NuPortalDBService.NuPortalService Dbservice = new NuPortalDBService.NuPortalService();
            Dbservice.Url = Constants.DBService;
            try
            {
                string jsonString = Dbservice.SelectGridInfo(Convert.ToInt32(Session["CompanyID"]), 20);
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                Dbservice = null;
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult saveExitDocument(int Name, DateTime RelievingDate, string Attachments, string Operation)
        {

         
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                string jsonString = empService.UpdateExitInterview(Name, RelievingDate, Attachments,Convert.ToString(Operation));
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                empService = null;

            }

            return Json(Common_Library.Constants.JsonError);
        }

        [HttpPost]
        public ActionResult DeleteEvent(int EventId,int OperationId)
        {
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                string jsonString = empService.SelectEmployeeInfo(EventId, OperationId);
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                empService = null;
            }
        }
        //Get Interview Log
        public JsonResult getInterviewLog()
        {
            NuPortalDBService.NuPortalService Dbservice = new NuPortalDBService.NuPortalService();
            Dbservice.Url = Constants.DBService;
            try
            {
                string jsonString = Dbservice.SelectGridInfo(Convert.ToInt32(Session["CompanyID"]), 24);
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                Dbservice = null;
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult removeDocument(int EmpId, string Operation)
        {
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                string jsonString = empService.UpdateExitInterview(EmpId, DateTime.Now, string.Empty, Convert.ToString(Operation));
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                empService = null;

            }

            return Json(Common_Library.Constants.JsonError);
        }

        [HttpPost]
        public ActionResult CancelTickets(int idval,int Operation)
        {

            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;

            try
            {
                string jsonString = dbService.CancelItem(idval,Convert.ToInt32(Session["EmpID"]), Operation);
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                dbService = null;

            }

            return Json(Common_Library.Constants.JsonError);
        }
        [HttpPost]
        public ActionResult EditTickets(int idval, int Operation)
        {
            NuPortalHRService.NuPortalHRService hrservice = new NuPortalHRService.NuPortalHRService();
            hrservice.Url = Constants.HRService;

            try
            {
                string jsonString = hrservice.UpdateTrainingTicket(0,0,Convert.ToInt32(Session["EmpID"]), idval, Convert.ToInt32(Session["EmpID"]),0,0,Operation);
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                hrservice = null;

            }

            return Json(Common_Library.Constants.JsonError);
        }
        // View Training Details
        [HttpGet]
        public JsonResult viewTrainingDetails(int idval, int Operation)
        {

            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;

            try
            {
                string jsonString = dbService.SelectGridInfo(idval,Operation);
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                dbService = null;

            }

            return Json(Common_Library.Constants.JsonError);
        }
        //select assesment log view
        [HttpGet]
        public JsonResult getTrainingAssesment(int idval, int Operation)
        {

            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;

            try
            {
                string jsonString = dbService.SelectGridInfo(idval, Operation);
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                dbService = null;

            }

            return Json(Common_Library.Constants.JsonError);
        }
        //Get exitintdoc
        [HttpGet]
        public JsonResult loadExitInterview(int idval, int Operation)
        {
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                string jsonString = empService.SelectEmployeeInfo(idval, Operation);
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                empService = null;

            }
            return Json(Common_Library.Constants.JsonError);
        }
        //Get Field Type in Office Poll
        [HttpGet]
        public JsonResult getFieldType()
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string jsonLocation = dbService.GetDDListBox(Convert.ToInt32(Session["CompanyId"]), 21);
                return Json(jsonLocation, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                outData = new Dictionary<string, string>();
                outData.Add("Error", "Error");
                return Json(JsonConvert.SerializeObject(outData), JsonRequestBehavior.AllowGet);
            }
            finally
            {
                dbService = null;
            }
        }
        //Save Office Poll
        [HttpPost]
        public ActionResult saveOfficePoll(string Title, string Note, string AttachmentPath,DateTime EndDate)
        {
            NuPortalHRService.NuPortalHRService hrService = new NuPortalHRService.NuPortalHRService();
            hrService.Url = Constants.HRService;
            try
            {
                string jsonString = hrService.SaveOfficePoll(Title,Note, Convert.ToInt32(Session["CompanyId"]),AttachmentPath, 
                    Convert.ToInt32(Session["EmpID"]), Convert.ToInt32(Session["EmpID"]), EndDate, 0, 1, 1);
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                hrService = null;

            }

            return Json(Common_Library.Constants.JsonError);
        }

        [HttpPost]
        public ActionResult saveQuestion(int PollId, int QuestionTypeId, string Question)
        {
            NuPortalHRService.NuPortalHRService hrService = new NuPortalHRService.NuPortalHRService();
            hrService.Url = Constants.HRService;
            try
            {
                string jsonString = hrService.SaveQuestion(PollId,QuestionTypeId,Question, Convert.ToInt32(Session["EmpID"]), Convert.ToInt32(Session["EmpID"]),2);
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                hrService = null;

            }

            return Json(Common_Library.Constants.JsonError);
        }
        
        [HttpPost]
        public ActionResult SetOptions(string jsonOptions)
        {
            NuPortalHRService.NuPortalHRService hrService = new NuPortalHRService.NuPortalHRService();
            hrService.Url = Constants.HRService;
            try
            {
                bool IsSuccess = hrService.SetOptionsForQuestion(jsonOptions);
                if (IsSuccess)
                    return Json(Common_Library.Constants.JsonSuccess);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                hrService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }

        [HttpGet]
        public JsonResult loadOfficePoll(int idval, int Operation)
        {
            NuPortalEmpService.NuPortalEmployeeService  empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                string jsonString = empService.SelectEmployeeInfo(idval, Operation);
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                empService = null;

            }

            return Json(Common_Library.Constants.JsonError);
        }

        [HttpGet]
        public JsonResult checkPollStatus(int PollId, int Operation)
        {          
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string jsonString = dbService.CancelItem(PollId, Convert.ToInt32(Session["EmpID"]), Operation);
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                dbService = null;

            }

            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult saveOfficePollResult(string jsonOptions)
        {
            NuPortalHRService.NuPortalHRService hrService = new NuPortalHRService.NuPortalHRService();
            hrService.Url = Constants.HRService;
            try
            {
                bool IsSuccess = hrService.SaveOptionsPollResult(jsonOptions);
                if (IsSuccess)
                    return Json(Common_Library.Constants.JsonSuccess);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                hrService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }
        [HttpPost]
        public ActionResult savePollResultTextBox(int QuestionId, string TextValue, int Operation)
        {
            NuPortalHRService.NuPortalHRService hrService = new NuPortalHRService.NuPortalHRService();
            hrService.Url = Constants.HRService;
            try
            {
                bool IsSuccess = hrService.SaveTbPollResult(QuestionId, TextValue, Convert.ToInt32(Session["EmpID"]), Convert.ToInt32(Session["EmpID"]), Operation);
                if (IsSuccess)
                    return Json(Common_Library.Constants.JsonSuccess);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                hrService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }
        public JsonResult GetEmployeeProgressChat(int empId,int Month, int Year, int Operation)
        {
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                Dictionary<string, string> outData = new Dictionary<string, string>();
                string JsonString = dbService.SelectDetailsByMonth(empId, Month, Year, Operation);
                if (JsonString != string.Empty)
                {
                    return Json(JsonString, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                dbService.Dispose();
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult getPublicPoll(int Operation)
        {
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string jsonString = dbService.GetDDListBox(Convert.ToInt32(Session["CompanyId"]), Operation);
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                dbService = null;

            }

            return Json(Common_Library.Constants.JsonError);
        }
        [HttpPost]
        public ActionResult savePublicPoll(int QuestionId, int PublishTypeId,string TextVal,int Operation )
        {
            NuPortalHRService.NuPortalHRService hrService = new NuPortalHRService.NuPortalHRService();
            hrService.Url = Constants.HRService;
            try
            {
                bool IsSuccess = hrService.SavePollPublishType(QuestionId,PublishTypeId,TextVal, Convert.ToInt32(Session["EmpID"]), Operation);
                if (IsSuccess)
                    return Json(Common_Library.Constants.JsonSuccess);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                hrService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }
        [HttpGet]
        public JsonResult getPollResults(int qId, int Operation)
        {
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                string jsonString = empService.SelectEmployeeInfo(qId, Operation);
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                empService = null;

            }

            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult loadPollDetails(string JsonData,int Operation,int OffSet,int RowCount)
        {
            
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string jsonString = dbService.GetFilterForGrid(JsonData, Convert.ToInt32(Session["CompanyId"]), OffSet, RowCount, Operation);
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                dbService = null;

            }

            return Json(Common_Library.Constants.JsonError);
        }
        [HttpPost]
        public JsonResult DeleteOfficePoll(int PollId, int Operation)
        {
            NuPortalHRService.NuPortalHRService hrService = new NuPortalHRService.NuPortalHRService();
            hrService.Url = Constants.HRService;
            try
            {
                string jsonString = hrService.DeleteOfficePoll(PollId, Operation);
                if (jsonString != string.Empty)
                    return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
                return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                hrService = null;
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
    }
}