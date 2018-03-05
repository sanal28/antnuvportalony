﻿using Newtonsoft.Json;
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
    public class TimeSheetController : Controller
    {
        // GET: TimeSheet
        public ActionResult TimeSheet(int DesignFlag)
        {            
            ViewData["WeekDays"] = GetWeekDays(DateTime.Now);
            ViewBag.Manager = GetManager(Convert.ToInt32(Session["EmpId"]));
            return View();
        }

        private int GetManager(int EmpId)
        {
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            DataTable dt = new DataTable();
            try
            {
                dt = JsonConvert.DeserializeObject<DataTable>(empService.SelectEmployeeInfo(EmpId, 57));
                if (dt != null && dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0]["Manager"]);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
            }
            finally { empService.Dispose();dt.Dispose(); }
            return 0;
        }

        public List<string> GetWeekDays(DateTime dt)
        {
            List<string> currWeek = new List<string>();
            try
            {
                int diff = DayOfWeek.Sunday - dt.DayOfWeek;
                DateTime startDate = dt.AddDays(diff);
                currWeek.Add(startDate.ToString("dd-MM-yyyy"));
                for (int i = 1; i <= 6; i++)
                    currWeek.Add(startDate.AddDays(i).ToString("dd-MM-yyyy"));
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
            }
            return currWeek;
        }
        public ActionResult TimeSheetApproval(int hdnId,string TypeId)
        {
            ViewData["WeekDays"] = GetWeekDays(Convert.ToDateTime(TypeId));
            return View();
        }

        public ActionResult TimeSheetReport(int? hdnId)
        {
            return View();
        }

        public ActionResult TimeSheetFilter(int? hdnId)
        {
            return View();
        }

        public ActionResult TimeSheetGridView(int? projectId,int? HoursType)
        {
            return View();
        }
        
        public ActionResult TimesheetCalendar(int? EmpId)
        {
            return View();
        }

        [HttpGet]
        public JsonResult LoadTimeSheetGrid(int Id,int Operation,int OffSet,int RowCount)
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalProjectService.NuPortalProject projectService = new NuPortalProjectService.NuPortalProject();
            projectService.Url = Constants.ProjectService;
            Common_Library.GeneralFunctions gen = new Common_Library.GeneralFunctions();
            try
            {
                string JsonString = projectService.GetTimeSheetReport(Convert.ToString(Session["Resources"]),
                    gen.SetDateVal(Convert.ToString(Session["StartDate"])),
                     gen.SetDateVal(Convert.ToString(Session["EndDate"])), Id, OffSet, RowCount, Operation);
                if (JsonString != "")
                    return Json(JsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
            }
            finally
            {
                projectService = null;
                gen = null;
            }
            outData = new Dictionary<string, string>();
            outData.Add("Error", "Error");
            return Json(JsonConvert.SerializeObject(outData), JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public JsonResult ProjectInfo(int Id)
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalDBService.NuPortalService dBService = new NuPortalDBService.NuPortalService();
            dBService.Url = Constants.DBService;
            try
            {
                string JsonString = dBService.SelectGridInfo(Id, 14);
                if (JsonString != string.Empty)
                    return Json(JsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
            }
            finally
            {
                dBService = null;
            }
            outData = new Dictionary<string, string>();
            outData.Add("Error", "Error");
            return Json(JsonConvert.SerializeObject(outData), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SetSession(string jsonData)
        {
            Dictionary<string, string> dictSession;
            try
            {
                dictSession = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
                foreach (KeyValuePair<string, string> item in dictSession)
                {
                    if (item.Value != string.Empty)
                        Session[item.Key] = Convert.ToString(item.Value);
                }
                return Json(Common_Library.Constants.JsonSuccess);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null; 
            }
            finally
            {
                dictSession = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }

        [HttpGet]
        public JsonResult GetTasksList(int EmpId)
        {
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string JsonString = dbService.GetDDListBox(EmpId == 0 ? Convert.ToInt16(Session["EmpId"]) : EmpId, 19);
                if (JsonString != string.Empty)
                    return Json(JsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null; 
            }
            finally { dbService.Dispose(); }
            return Json(Common_Library.Constants.JsonError);
        }

        [HttpGet]
        public JsonResult BindTasks(int Project,int EmpId)
        {
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string JsonString = dbService.CancelItem(Project, EmpId == 0 ? Convert.ToInt16(Session["EmpId"]) : EmpId, 8);
                if (JsonString != string.Empty)
                    return Json(JsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
            }
            finally { dbService.Dispose(); }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SetWeekDays(string Btn, string date)
        {
            List<string> currWeek = new List<string>();
            DateTime currDt = Btn == "previous" ? Convert.ToDateTime(date).AddDays(-1) : Convert.ToDateTime(date).AddDays(1);
            int diff = DayOfWeek.Sunday - currDt.DayOfWeek;
            DateTime startDate = currDt.AddDays(diff);
            currWeek.Add(startDate.ToString("dd-MM-yyyy"));
            for (int i = 1; i <= 6; i++)
                currWeek.Add(startDate.AddDays(i).ToString("dd-MM-yyyy"));
            return Json(currWeek, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSessionVal(string SessionKey)
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            try
            {
                outData = new Dictionary<string, string>();
                if (Session[SessionKey] != null)
                    outData.Add(SessionKey, Convert.ToString(Session[SessionKey]));
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
            }
            outData = new Dictionary<string, string>();
            outData.Add("Error", "Error");
            return Json(JsonConvert.SerializeObject(outData), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SubmitTimesheet(string ids, string jsonStr)
        {
            NuPortalProjectService.NuPortalProject projectService = new NuPortalProjectService.NuPortalProject();
            projectService.Url = Constants.ProjectService;
            try
            {
                bool isSuccess = projectService.SetTaskDetails(ids, jsonStr);
                if (isSuccess)
                    return Json(Common_Library.Constants.JsonSuccess);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
            }
            finally { projectService.Dispose(); }
            return Json(Common_Library.Constants.JsonError);
        }

        [HttpGet]
        public ActionResult GetTimesheetDetails(string weekendDate,int EmpId)
        {
            NuPortalProjectService.NuPortalProject projectService = new NuPortalProjectService.NuPortalProject();
            projectService.Url = Constants.ProjectService;
            DataTable temp = new DataTable(), dt = new DataTable();
            try
            {
                DateTime endDate = Convert.ToDateTime(weekendDate);
                temp = JsonConvert.DeserializeObject<DataTable>(projectService.selectTaskDetails(EmpId!=0? EmpId: Convert.ToInt32(Session["EmpId"]), endDate));
                if (temp != null && temp.Rows.Count > 0)
                {
                    int Assign = Convert.ToInt32(temp.Rows[0]["AssignedTo"]);
                    dt.Columns.Add("ProjectName", typeof(string));
                    dt.Columns.Add("TaskName", typeof(string));
                    dt.Columns.Add("FK_TaskId", typeof(int));
                    dt.Columns.Add("TaskDetailsId", typeof(int));
                    dt.Columns.Add("Date", typeof(string));
                    dt.Columns.Add("Hour", typeof(float));
                    dt.Columns.Add("Status", typeof(int));
                    dt.Columns.Add("StartDate", typeof(string));
                    foreach (DataRow row in temp.Rows)
                        dt.Rows.Add(Convert.ToString(row["ProjectName"]), Convert.ToString(row["TaskName"]), Convert.ToInt32(row["FK_TaskId"]), Convert.ToInt32(row["TaskDetailsId"]), Convert.ToDateTime(row["Date"]).ToString("MM/dd/yyyy"), Convert.ToDecimal(row["Hour"]), Convert.ToInt32(row["TicketStatusId"]), Convert.ToDateTime(row["StartDate"]).ToString("MM/dd/yyyy"));

                    DateTime startDate = Convert.ToDateTime(weekendDate).AddDays(-6);

                    DataTable taskDist = dt.DefaultView.ToTable(true, "FK_TaskId", "TaskName", "ProjectName", "Status", "StartDate");
                    DataTable resultDt = new DataTable();
                    resultDt.Columns.Add("ProjectName", typeof(string));
                    resultDt.Columns.Add("TaskName", typeof(string));
                    resultDt.Columns.Add("FK_TaskId", typeof(int));
                    resultDt.Columns.Add("Date0", typeof(string));
                    resultDt.Columns.Add("Date1", typeof(string));
                    resultDt.Columns.Add("Date2", typeof(string));
                    resultDt.Columns.Add("Date3", typeof(string));
                    resultDt.Columns.Add("Date4", typeof(string));
                    resultDt.Columns.Add("Date5", typeof(string));
                    resultDt.Columns.Add("Date6", typeof(string));
                    resultDt.Columns.Add("TaskDetailsId", typeof(string));
                    resultDt.Columns.Add("AssignedTo", typeof(int));
                    resultDt.Columns.Add("Status", typeof(int));
                    resultDt.Columns.Add("Date0Class", typeof(string));
                    resultDt.Columns.Add("Date1Class", typeof(string));
                    resultDt.Columns.Add("Date2Class", typeof(string));
                    resultDt.Columns.Add("Date3Class", typeof(string));
                    resultDt.Columns.Add("Date4Class", typeof(string));
                    resultDt.Columns.Add("Date5Class", typeof(string));
                    resultDt.Columns.Add("Date6Class", typeof(string));
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow task in taskDist.Rows)
                        {
                            DataRow resultRow = resultDt.NewRow();
                            resultRow["ProjectName"] = task["ProjectName"];
                            resultRow["TaskName"] = task["TaskName"];
                            resultRow["FK_TaskId"] = task["FK_TaskId"];
                            resultRow["Status"] = task["Status"];
                            int cnt = 0;
                            string sheetIds = "";
                            for (DateTime dte = startDate; dte < startDate.AddDays(7); dte = dte.AddDays(1))
                            {
                                DataRow[] timesheets = dt.Select("FK_TaskId=" + task["FK_TaskId"] + " And Date='" + dte.ToString("MM/dd/yyyy") + "'");
                                if (timesheets != null && timesheets.Length > 0&& Convert.ToDecimal(timesheets[0]["Hour"])!=0)
                                {
                                    resultRow["Date" + cnt] = timesheets[0]["Hour"];
                                    sheetIds = sheetIds + Convert.ToString(timesheets[0]["TaskDetailsId"]) + "|";
                                }
                                else
                                    resultRow["Date" + cnt] = "";
                                if (dte < Convert.ToDateTime(DateTime.ParseExact(Convert.ToString(task["StartDate"]), "MM/dd/yyyy", null).ToString("yyyy/MM/dd")))
                                    resultRow["Date" + cnt+"Class"] = "disabled";
                                else
                                    resultRow["Date" + cnt + "Class"] = "";
                                cnt++;
                            }
                            resultRow["TaskDetailsId"] = sheetIds;
                            resultRow["AssignedTo"] = Assign;
                            resultDt.Rows.Add(resultRow);
                        }
                        return Json(JsonConvert.SerializeObject(resultDt), JsonRequestBehavior.AllowGet);
                    }
                    else
                        return Json("", JsonRequestBehavior.AllowGet);
                }
                else
                    return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
            }
            finally { projectService.Dispose(); dt = null; temp = null; }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAllTimesheet(int year, int month,int EmpId,int ProjectId)
        {
            NuPortalRecruitmentService.Recruitment recService = new NuPortalRecruitmentService.Recruitment();
            recService.Url = Constants.RecruitmentService;
            DataTable events = new DataTable();
            DataTable monthEvents = new DataTable();
            try
            {
                DateTime monthStart = new DateTime(year, month, 1);
                DateTime monthEnd = new DateTime(year, month, DateTime.DaysInMonth(year, month));
                monthStart = monthStart.AddDays(DayOfWeek.Sunday - monthStart.DayOfWeek);
                monthEnd = monthEnd.AddDays(DayOfWeek.Saturday - monthEnd.DayOfWeek);
                events = JsonConvert.DeserializeObject<DataTable>(recService.TimesheetReport(EmpId, ProjectId, monthStart, monthEnd));

                monthEvents.Columns.Add("EventDate");
                monthEvents.Columns.Add("ActHour");
                monthEvents.Columns.Add("EstHour");
                monthEvents.Columns.Add("Month");
                if (events != null && events.Rows.Count > 0)
                    foreach (DataRow row in events.Rows)
                    {
                        DateTime dt = Convert.ToDateTime(row["Date"]);
                        if (dt <= monthEnd && dt >= monthStart)
                            monthEvents.Rows.Add(dt.ToString("yyyy/MM/dd"), Convert.ToInt32(row["EmpWorkedHour"]).ToString("D2"), Convert.ToInt32(row["ProjectHours"]).ToString("D2"), dt.Month == month ? "currentmonth" : dt.Month <= month ? "prevmonth" : "nextmonth");
                    }
                return Json(JsonConvert.SerializeObject(monthEvents), JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
            }
            finally
            {
                if (recService != null)
                    recService.Dispose();
                if (events != null)
                    events.Dispose();
                if (monthEvents != null)
                    monthEvents.Dispose();
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
    }
}