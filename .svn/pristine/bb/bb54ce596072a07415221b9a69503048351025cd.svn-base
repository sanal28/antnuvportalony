using Newtonsoft.Json;
using NuPortal.Common_Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuPortal.Controllers
{
    [SessionTimeout]
    public class TaskController : Controller
    {
        public ActionResult NewTask(int? hdnId, int? TypeId,int?projectId)
        {
            return View();
        }
        public ActionResult Status(int? hdnId, int? ProjectId)
        {
            return View();
        }
        public ActionResult MyTask()
        {
            return View();
        }
        public ActionResult TaskName(int? hdnId,int? TypeId,int? projectId,int? HoursType,int ? designFlag)
        {
            return View();
        }
        public ActionResult ProgressChart()
        {
            return View();
        }
        public ActionResult TasksLog(int? hdnId)
        {
            return View();
        }
        public ActionResult StatusUpdate()
        {
            return View();
        }
        public ActionResult ImportTask()
        {
            return View();
        }
        public JsonResult AutoCompleteResources(int Project,string EmpName)
        {
            Dictionary<string, string> oItems = new Dictionary<string, string>();
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            DataTable dtAutoComplete = JsonConvert.DeserializeObject<DataTable>(empService.ManagerAutoComplete(Project, EmpName, 0 ,2));
            if (dtAutoComplete != null && dtAutoComplete.Rows.Count > 0)
            {
                for (int i = 0; i < dtAutoComplete.Rows.Count; i++)
                {
                    oItems.Add(dtAutoComplete.Rows[i]["EmpId"].ToString(), dtAutoComplete.Rows[i]["FirstName"].ToString());
                }
            }


            return Json(oItems.ToList());
        }
        [HttpPost]
        public ActionResult UpdateTask(string TaskName, string StartDate, string EndDate, float PlannedHours, string ProjectPhase,
    int taskstatusId, string TaskDetails, string Comments, string Priority, int Billable, string UploadedFileUrl, int TskId,int ProjectId,int UpdateFlag)
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalProjectService.NuPortalProject empService = new NuPortalProjectService.NuPortalProject();
            empService.Url = Constants.ProjectService;
            try
            {
                    string ReturnId = empService.ProjectTaskOper(TskId, ProjectId, TaskName, Convert.ToDateTime(StartDate), Convert.ToDateTime(EndDate), PlannedHours, ProjectPhase,
                        taskstatusId, TaskDetails, Comments, Priority, Billable, UploadedFileUrl, DateTime.Now, DateTime.Now, Convert.ToInt32(Session["EmpId"]),
                        Convert.ToInt32(Session["EmpId"]), 1, 2,1, UpdateFlag);
                    if (ReturnId != string.Empty)
                        return Json(ReturnId);

            }
            catch (Exception ex)
            {
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                empService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }
        [HttpPost]
        public ActionResult SaveTask(string TaskName, string StartDate, string EndDate, float PlannedHours, string ProjectPhase,
           int taskstatusId, string TaskDetails, string Comments, string Priority, int Billable, string UploadedFileUrl,int ProjectId)
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalProjectService.NuPortalProject empService = new NuPortalProjectService.NuPortalProject();
            empService.Url = Constants.ProjectService;
            try
            {
                    string  ReturnId = empService.ProjectTaskOper(0, ProjectId, TaskName, Convert.ToDateTime(StartDate), Convert.ToDateTime(EndDate), PlannedHours, ProjectPhase,
                        taskstatusId, TaskDetails, Comments, Priority, Billable, UploadedFileUrl, DateTime.Now, DateTime.Now, Convert.ToInt32(Session["EmpId"]),
                        Convert.ToInt32(Session["EmpId"]), 1, 1,0,0);
                    if (ReturnId != string.Empty)
                        return Json(ReturnId);
            }
            catch (Exception ex)
            {
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                empService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }
        [HttpGet]
        public JsonResult GetTaskName()
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalDBService.NuPortalService taskService = new NuPortalDBService.NuPortalService();
            taskService.Url = Constants.DBService;
            try
            {
                string jsonTaskName = taskService.GetDDListBox(Convert.ToInt32(Session["CompanyId"]), 12);
                if (jsonTaskName != string.Empty)
                    return Json(jsonTaskName, JsonRequestBehavior.AllowGet);
                else
                {
                    outData = new Dictionary<string, string>();
                    outData.Add("Error", "Error");
                    return Json(JsonConvert.SerializeObject(outData), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                outData = new Dictionary<string, string>();
                outData.Add("Error", "Error");
                return Json(JsonConvert.SerializeObject(outData), JsonRequestBehavior.AllowGet);
            }
            finally
            {
                taskService = null;
            }
        }
        [HttpPost]
        public ActionResult SaveResources(int taskID, string jsonData, string EmpIdData)
        {
            NuPortalProjectService.NuPortalProject prjService = new NuPortalProjectService.NuPortalProject();
            prjService.Url = Constants.ProjectService;
            try
            {
                DataTable data = JsonConvert.DeserializeObject<DataTable>(jsonData);
                bool IsSuccess = prjService.SetResourceForTask(taskID, jsonData, EmpIdData);
                if (IsSuccess)
                    return Json(Common_Library.Constants.JsonSuccess);
            }
            catch (Exception ex)
            {
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                prjService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }
        [HttpGet]
        public JsonResult GetCompletedTasks(int ProjId)
        {
            NuPortalDBService.NuPortalService Dbservice = new NuPortalDBService.NuPortalService();
            Dbservice.Url = Constants.DBService;
            try
            {
                string JsonString = Dbservice.SelectGridInfo(ProjId, 12);
                if (JsonString != string.Empty)
                {
                    return Json(JsonString, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                Dbservice.Dispose();

            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetOpenTask(int ProjId)
        {
            NuPortalDBService.NuPortalService Dbservice = new NuPortalDBService.NuPortalService();
            Dbservice.Url = Constants.DBService;
            try
            {
                string JsonString = Dbservice.SelectGridInfo(ProjId, 11);
                if (JsonString != string.Empty)
                {
                    return Json(JsonString, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                Dbservice.Dispose();

            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteOpenTask(int reqID)
        {
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                string JsonString = empService.SelectEmployeeInfo(reqID, 28);
                if (JsonString != string.Empty)
                {
                    return Json(JsonString, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                empService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }
        [HttpGet]
        public JsonResult GetTaskDetails(int TaskId,int operationId,string TaskName,int ? Type)
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalDBService.NuPortalService Dbservice = new NuPortalDBService.NuPortalService();
            Dbservice.Url = Constants.DBService;
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                if (Type == 3 || Type == 2)
                {
                    if (operationId == 1)
                    {
                        string JsonString = Dbservice.SelectGridInfo(TaskId, 37);
                        if (JsonString != string.Empty)
                        {
                            return Json(JsonString, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else if (operationId == 2)
                    {
                        string ResourceDetails = empService.SelectEmployeeInfo(TaskId, 53);
                        if (ResourceDetails != string.Empty)
                        {
                            return Json(ResourceDetails, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
                else
                {
                    if (operationId == 1)
                    {
                        string JsonString = Dbservice.SelectGridInfo(TaskId, 3);
                        if (JsonString != string.Empty)
                        {
                            return Json(JsonString, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else if (operationId == 2)
                    {
                        string ResourceDetails = empService.SelectEmployeeInfo(TaskId, 29);
                        if (ResourceDetails != string.Empty)
                        {
                            return Json(ResourceDetails, JsonRequestBehavior.AllowGet);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                outData = new Dictionary<string, string>();
                outData.Add("Error", "Error");
                return Json(JsonConvert.SerializeObject(outData), JsonRequestBehavior.AllowGet);
            }
            finally
            {
                empService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }
        public JsonResult GetCompletedMyTasks()
        {
            NuPortalDBService.NuPortalService Dbservice = new NuPortalDBService.NuPortalService();
            Dbservice.Url = Constants.DBService;
            try
            {
                string JsonString = Dbservice.SelectGridInfo(Convert.ToInt32(Session["EmpId"]), 2);
                if (JsonString != string.Empty)
                {
                    return Json(JsonString, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                Dbservice.Dispose();

            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetComments(int RFTId,int ? Type)
        {
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                if (Type == 3 || Type == 2)
                {
                    string JsonString = empService.SelectEmployeeInfo(RFTId, 54);
                    if (JsonString != string.Empty)
                    {
                        return Json(JsonString, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    string JsonString = empService.SelectEmployeeInfo(RFTId, 50);
                    if (JsonString != string.Empty)
                    {
                        return Json(JsonString, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                empService.Dispose();
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveStatus(int taskstatusId, string Comments, string UploadedFileUrl, int TskId,int ProjectId,string TaskName,int Flag,int UpdateFlag)
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalProjectService.NuPortalProject empService = new NuPortalProjectService.NuPortalProject();
            empService.Url = Constants.ProjectService;
            Common_Library.GeneralFunctions general = new Common_Library.GeneralFunctions();
            try
            {
                if(TskId!=0)
                {
                    string ReturnId = empService.ProjectTaskOper(TskId, ProjectId, TaskName, general.SetDateVal(""), general.SetDateVal(""),0,"", taskstatusId,"", Comments,
                        "",0,UploadedFileUrl, DateTime.Now, DateTime.Now, Convert.ToInt32(Session["EmpId"]), Convert.ToInt32(Session["EmpId"]), 1,3, Flag, UpdateFlag);
                    if (ReturnId != string.Empty)
                        return Json(ReturnId);
                }
            }
            catch (Exception ex)
            {
                return Json(Common_Library.Constants.JsonError);
            }
            finally
            {
                empService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }
        public JsonResult GetMonthBasedDetails(int Month,int Year,int Operation)
        {
            NuPortalDBService.NuPortalService Dbservice = new NuPortalDBService.NuPortalService();
            Dbservice.Url = Constants.DBService;
            try
            {
                Dictionary<string, string> outData = new Dictionary<string, string>();
                string JsonString = Dbservice.SelectDetailsByMonth(Convert.ToInt32(Session["EmpId"]), Month, Year, Operation);
                if (JsonString != string.Empty)
                {
                    return Json(JsonString, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                Dbservice.Dispose();
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetStatusUpdates()
        {
            NuPortalDBService.NuPortalService Dbservice = new NuPortalDBService.NuPortalService();
            Dbservice.Url = Constants.DBService;
            try
            {
                string JsonString = Dbservice.SelectGridInfo(Convert.ToInt32(Session["EmpId"]), 34);
                if (JsonString != string.Empty)
                {
                    return Json(JsonString, JsonRequestBehavior.AllowGet);
                }
                else
                    ViewBag.Message = "No Records Found";

            }
            catch (Exception ex)
            {
                return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                Dbservice.Dispose();

            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
    }
}