using Newtonsoft.Json;
using NuPortal.Common_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuPortal.Controllers
{
    [SessionTimeout]
    public class ReimbursementController : Controller
    {
        // GET: Reimbursement
        public ActionResult Reimbursement(int? hdnId,int? TypeId)
        {
            return View();
        }
        // GET:All Reimbursement
        public ActionResult AllReimbursements()
        {
            return View();
        }
        [HttpPost]
        public void SetTempData(int tempDataValue)
        {
            // Set your TempData key to the value passed in
            TempData["ReimbursementID"] = tempDataValue;
        }
        [HttpPost]
        public JsonResult getReimbursementInfoforID(int reimbursementID)
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalDBService.NuPortalService dBService = new NuPortalDBService.NuPortalService();
            dBService.Url = Constants.DBService;

            try
            {
                string jsonLocation = dBService.SelectGridInfo(reimbursementID, 8);
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
                dBService = null;
            }
            outData = new Dictionary<string, string>();
            outData.Add("Error", "Error");
            return Json(JsonConvert.SerializeObject(outData), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult getAllReimbursementInfo()
        {
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                string jsonString = empService.SelectEmployeeInfo(Convert.ToInt32(Session["EmpID"]), 21);
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
        [HttpPost]
        public ActionResult CancelReimbursement(int reqID, int operationID)
        {
            NuPortalRequestService.NuPortalRequestService requestService = new NuPortalRequestService.NuPortalRequestService();
            requestService.Url = Constants.RequestService;
            try
            {
                bool IsSuccess = requestService.CancelRequest(reqID, 23, false);
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
        public ActionResult AddReimbursement(float Amount,string Attachments,DateTime StartDate,DateTime EndDate,string Description,int CategoryId)
        {
            NuPortalRequestService.NuPortalRequestService reqService = new NuPortalRequestService.NuPortalRequestService();
            reqService.Url = Constants.RequestService;
            try
            {
                bool IsSuccess = reqService.AddAllowanceReimbursement(Amount,Attachments,StartDate,EndDate,Description, CategoryId, 2,DateTime.Now, Convert.ToInt32(Session["EmpID"]), DateTime.Now, Convert.ToInt32(Session["EmpID"]), 1);
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

        [HttpGet]
        public JsonResult GetReimbursemenType()
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalDBService.NuPortalService dBService = new NuPortalDBService.NuPortalService();
            dBService.Url = Constants.DBService;
            try
            {
                string jsonReim = dBService.GetDDListBox(Convert.ToInt32(Session["CompanyId"]), 9);
                if (jsonReim != string.Empty)
                    return Json(jsonReim, JsonRequestBehavior.AllowGet);
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
    }
}