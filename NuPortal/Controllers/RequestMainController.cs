﻿using Newtonsoft.Json;
using NuPortal.Common_Library;
using NuPortal.NuPortalDBService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuPortal.Controllers
{
    [SessionTimeout]
    public class RequestMainController : Controller
    {
        // GET: RequestMain
        public ActionResult RequestMain()
        {
            return View();
        }
        // GET: IconsView
        public ActionResult IconsView()
        {
            return View();
        }
        // GET: AllRequests
        public ActionResult AllRequests()
        {
            return View();
        }
        // GET: AllAllowances
        public ActionResult AllAllowances()
        {
            return View();
        }
        // GET: NewAllowance
        public ActionResult NewAllowance(int? hdnId, int? TypeId)
        {
            return View();
        }
        // GET: NewLeave
        public ActionResult LeaveCalendar()
        {
            return View();
        }
        // GET: NewLeave
        public ActionResult NewLeave(int? hdnId, int? TypeId, int? LeaveTypeId)
        {
            return View();
        }

        [HttpPost]
        public void SetTempData(int tempDataValue)
        {
            // Set your TempData key to the value passed in
            TempData["AllowanceID"] = tempDataValue;
        }
        [HttpGet]
        public JsonResult SelectEmployeeInfo()
        {
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                string jsonString = empService.SelectEmployeeInfo(Convert.ToInt32(Session["EmpID"]), 10);
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
            }
            finally
            {
                empService = null;
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult getLeaveInfo()
        {
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                string jsonString = empService.SelectEmployeeInfo(Convert.ToInt32(Session["EmpID"]), 25);
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
            }
            finally
            {
                empService = null;
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult getAllAllowanceInfo()
        {
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                string jsonString = empService.SelectEmployeeInfo(Convert.ToInt32(Session["EmpID"]), 20);
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
            }
            finally
            {
                empService = null;
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult getAvailableLeaveInfo(int Employee)
        {
            int EmpID = Employee != 0 ? Employee : Convert.ToInt32(Session["EmpID"]);
            NuPortalRequestService.NuPortalRequestService requestService = new NuPortalRequestService.NuPortalRequestService();
            requestService.Url = Constants.RequestService;
            try
            {
                string jsonString = requestService.GetAvailableAvailedLeaves(Convert.ToInt32(Session["CompanyId"]), EmpID);
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
            }
            finally
            {
                requestService = null;
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CancelRequest(int reqID, int operationID, bool IsCompOff)
        {
            NuPortalRequestService.NuPortalRequestService requestService = new NuPortalRequestService.NuPortalRequestService();
            requestService.Url = Constants.RequestService;
            try
            {
                bool IsSuccess = requestService.CancelRequest(reqID, operationID, IsCompOff);
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
            }
            finally
            {
                requestService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }
        [HttpPost]
        public ActionResult CancelAllowance(int reqID, int operationID)
        {
            NuPortalRequestService.NuPortalRequestService requestService = new NuPortalRequestService.NuPortalRequestService();
            requestService.Url = Constants.RequestService;
            try
            {
                bool IsSuccess = requestService.CancelRequest(reqID, 22, false);
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
            }
            finally
            {
                requestService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }
        [HttpPost]
        public ActionResult addAllowance(float Amount, string AttachmentUrl, string StartDate,
            string EndDate, string Description, int CategoryId, int CategoryTypeId)
        {
            NuPortalRequestService.NuPortalRequestService requestService = new NuPortalRequestService.NuPortalRequestService();
            requestService.Url = Constants.RequestService;
            Common_Library.GeneralFunctions general = new Common_Library.GeneralFunctions();
            DateTime StartDateS;
            DateTime EndDateS;
            try
            {
                StartDateS = Convert.ToDateTime(StartDate);
                EndDateS = general.SetDateVal(EndDate);

                bool IsSuccess = requestService.AddAllowanceReimbursement(Amount, AttachmentUrl, StartDateS,
             EndDateS, Description, CategoryId, CategoryTypeId, DateTime.Now, Convert.ToInt32(Session["EmpID"]), DateTime.Now, Convert.ToInt32(Session["EmpID"]), 1);

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
            }
            finally
            {
                requestService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }
        [HttpGet]
        public JsonResult GetRequestType()
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalDBService.NuPortalService dBService = new NuPortalDBService.NuPortalService();
            dBService.Url = Constants.DBService;
            try
            {
                string jsonType = dBService.GetDDListBox(Convert.ToInt32(Session["CompanyId"]), 8);
                if (jsonType != string.Empty)
                    return Json(jsonType, JsonRequestBehavior.AllowGet);
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
        [HttpGet]
        public JsonResult GetLeaveType()
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalDBService.NuPortalService dBService = new NuPortalDBService.NuPortalService();
            dBService.Url = Constants.DBService;
            try
            {
                string jsonLeave = dBService.GetDDListBox(Convert.ToInt32(Session["CompanyId"]), 11);
                if (jsonLeave != string.Empty)
                    return Json(jsonLeave, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public JsonResult fetchWeekOffDays()
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                string jsonLocation = empService.SelectEmployeeInfo(Convert.ToInt32(Session["EmpID"]), 31);
                if (jsonLocation != string.Empty)
                    return Json(jsonLocation, JsonRequestBehavior.AllowGet);
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
                empService = null;
            }
            outData = new Dictionary<string, string>();
            outData.Add("Error", "Error");
            return Json(JsonConvert.SerializeObject(outData), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult addLeaves(string LeaveStartDate, string LeaveEndDate, int LeaveTypeId, int LeaveAppliedDays, string Reason)
        {
            NuPortalRequestService.NuPortalRequestService requestService = new NuPortalRequestService.NuPortalRequestService();
            requestService.Url = Constants.RequestService;
            try
            {
                bool IsSuccess = requestService.CreateLeaveRequest(Convert.ToInt32(Session["EmpID"]), Convert.ToInt32(Session["EmpID"]), 0,
                    Convert.ToDateTime(LeaveStartDate), Convert.ToDateTime(LeaveEndDate), 1, 0, LeaveTypeId, LeaveAppliedDays, Convert.ToInt32(Session["EmpID"]), Convert.ToInt32(Session["EmpID"]), Reason, 1, 1);
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
            }
            finally
            {
                requestService = null;
            }

            return Json(Common_Library.Constants.JsonError);
        }

        [HttpGet]
        public JsonResult getAllowanceInfoforID(int allowanceID)
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                string jsonLocation = empService.SelectEmployeeInfo(allowanceID, 26);
                if (jsonLocation != string.Empty)
                    return Json(jsonLocation, JsonRequestBehavior.AllowGet);
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
                empService = null;
            }
            outData = new Dictionary<string, string>();
            outData.Add("Error", "Error");
            return Json(JsonConvert.SerializeObject(outData), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateStatus(int requestId, int empId, int statusId, int operation, bool IsCompOff)
        {
            NuPortalRequestService.NuPortalRequestService reqService = new NuPortalRequestService.NuPortalRequestService();
            reqService.Url = Constants.RequestService;
            try
            {
                bool IsSuccess = reqService.UpdateRequestStatus(requestId, empId, statusId, operation, IsCompOff);
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
            }
            finally
            {
                reqService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }

        [HttpPost]
        public ActionResult CancelLeave(int reqID, int leavetypeID, int operation, int status, int employee)
        {
            int EmpId = employee != 0 ? employee : Convert.ToInt32(Session["EmpID"]);
            NuPortalRequestService.NuPortalRequestService requestService = new NuPortalRequestService.NuPortalRequestService();
            requestService.Url = Constants.RequestService;
            try
            {
                bool IsSuccess = requestService.UpdateOrCancelMyLeave(reqID, EmpId,
                    Convert.ToInt32(Session["CompanyId"]),
                    leavetypeID, operation, status);
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
            }
            finally
            {
                requestService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }

        [HttpGet]
        public ActionResult GetLeaveByID(int LeaveId)
        {
            NuPortalService dBService = new NuPortalService();
            dBService.Url = Constants.DBService;
            try
            {
                string JsonData = dBService.SelectGridInfo(LeaveId, 10);
                if (JsonData != string.Empty)
                    return Json(JsonData, JsonRequestBehavior.AllowGet);
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
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAllLeaves(int month, int year)
        {
            NuPortalHRService.NuPortalHRService hrService = new NuPortalHRService.NuPortalHRService();
            hrService.Url = Constants.HRService;
            DataTable events = new DataTable();
            DataTable monthEvents = new DataTable();
            try
            {
                DateTime monthStart = new DateTime(year, month, 1);
                DateTime monthEnd = new DateTime(year, month, DateTime.DaysInMonth(year, month));
                monthStart = monthStart.AddDays(DayOfWeek.Sunday - monthStart.DayOfWeek);
                monthEnd = monthEnd.AddDays(DayOfWeek.Saturday - monthEnd.DayOfWeek);
                events = JsonConvert.DeserializeObject<DataTable>(hrService.GetDataForCalendar(Convert.ToInt32(Session["EmpID"]), monthStart, monthEnd, 2));

                monthEvents.Columns.Add("EventDate");
                monthEvents.Columns.Add("Name");
                monthEvents.Columns.Add("Month");
                if (events != null && events.Rows.Count > 0)
                    foreach (DataRow row in events.Rows)
                        if (Convert.ToDateTime(row["LeaveStartDate"]) <= monthEnd && Convert.ToDateTime(row["LeaveEndDate"]) >= monthStart)
                            for (DateTime dt = Convert.ToDateTime(row["LeaveStartDate"]); dt <= Convert.ToDateTime(row["LeaveEndDate"]); dt = dt.AddDays(1))
                                if (dt >= monthStart && dt <= monthEnd)
                                    monthEvents.Rows.Add(dt.ToString("yyyy/MM/dd"), Convert.ToString(row["FirstName"]) + " " + Convert.ToString(row["LastName"]), dt.Month == month ? "currentmonth" : dt.Month <= month ? "prevmonth" : "nextmonth");
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
                hrService = null;
                events = null;
                monthEvents = null;
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult CheckIfLeaveApplied(string LeaveStartDate, string LeaveEndDate, int Operation)
        {
            NuPortalHRService.NuPortalHRService hrService = new NuPortalHRService.NuPortalHRService();
            hrService.Url = Constants.HRService;
            try
            {
                string jsonData = hrService.GetDataForCalendar(Convert.ToInt32(Session["EmpID"]), Convert.ToDateTime(LeaveStartDate), Convert.ToDateTime(LeaveEndDate), Operation);
                if (jsonData != string.Empty)
                    return Json(jsonData, JsonRequestBehavior.AllowGet);
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
                hrService = null;
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult CheckIfReqApplied(string RequestedDate, int RequestType)
        {
            NuPortalRequestService.NuPortalRequestService reqService = new NuPortalRequestService.NuPortalRequestService();
            reqService.Url = Constants.RequestService;
            try
            {
                string jsonData = reqService.CheckIfReqApplied(Convert.ToDateTime(RequestedDate),Convert.ToInt32(Session["EmpID"]), RequestType, 1);
                if(jsonData!=string.Empty)
                    return Json(jsonData, JsonRequestBehavior.AllowGet);
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
                reqService = null;
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
    }
}