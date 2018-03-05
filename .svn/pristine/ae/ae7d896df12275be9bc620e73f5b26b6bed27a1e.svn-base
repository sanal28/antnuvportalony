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
    public class AdminHomeController : Controller
    {
        // GET: AdminHome
        public ActionResult AdminHome()
        {
            return View();
        }

        public ActionResult CustomizeRequest()
        {
            return View();
        }

        public ActionResult CustomizeGroups()
        {
            return View();
        }
        public ActionResult AssignGroup()
        {
            return View();
        }
        public ActionResult CreateDepartments()
        {
            return View();
        }
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetDefaultValues(int CategoryType,int Operation)
        {
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string jsonString = dbService.CancelItem(Convert.ToInt32(Session["CompanyId"]), CategoryType , Operation);
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
        public JsonResult AutoComplete(string Name, int Operation, string IdVal, string NameVal)
        {
            Dictionary<string, string> oItems = new Dictionary<string, string>();
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            DataTable dtAutoComplete = JsonConvert.DeserializeObject<DataTable>(empService.ManagerAutoComplete(Convert.ToInt32(Session["CompanyId"]), Name, 0, Operation));
            if (dtAutoComplete != null && dtAutoComplete.Rows.Count > 0)
            {
                for (int i = 0; i < dtAutoComplete.Rows.Count; i++)
                {
                    oItems.Add(dtAutoComplete.Rows[i][IdVal].ToString(), dtAutoComplete.Rows[i][NameVal].ToString());
                }
            }
            return Json(oItems.ToList());
        }

        [HttpPost]
        public JsonResult SaveCategory(int CategoryTypeId,string jsonData,int Operation)
        {
            NuPortalAdminService.NuPortalAdminService admService = new NuPortalAdminService.NuPortalAdminService();
            admService.Url = Constants.AdminService;
            try
            {
                string IsSuccess = admService.CustomizationByAdmin(jsonData, Convert.ToInt32(Session["CompanyId"]), 1,
                    Convert.ToInt32(Session["EmpID"]), CategoryTypeId, Operation);
                if (IsSuccess != string.Empty)
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
                admService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }

        [HttpGet]
        public JsonResult GetDataFromDB()
        {
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string jsonString = dbService.SelectGridInfo(Convert.ToInt32(Session["CompanyId"]), 33);
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
        [HttpGet]
        public JsonResult GetResourceGroups(int ResourceId)
        {
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string jsonString = dbService.CancelItem(Convert.ToInt32(Session["CompanyId"]), ResourceId, 4);
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
        public JsonResult SaveResourceGroups(string jsonData,int ResourceId)
        {
            NuPortalAdminService.NuPortalAdminService admService = new NuPortalAdminService.NuPortalAdminService();
            admService.Url = Constants.AdminService;
            try
            {
                bool IsSuccess = admService.SetGroupMembers(ResourceId, Convert.ToInt32(Session["EmpId"]), jsonData);
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
                admService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }
        [HttpGet]
        public JsonResult GetDepartments(int OperationId)
        {
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string jsonString = dbService.SelectGridInfo(Convert.ToInt32(Session["CompanyId"]), OperationId);
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
    }
}