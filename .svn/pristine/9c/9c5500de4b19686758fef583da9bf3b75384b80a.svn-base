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
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult NewClient()
        {
            return View();
        }

        public ActionResult ClientInfo(int? hdnId, int ? ProjId, int ? TypeId)
        {
            return View();
        }


        [HttpPost]
        public ActionResult SaveNewClient(string CompanyName, string Website, string PurchaseOrder, string CompanyLogo)
        {
            NuPortalProjectService.NuPortalProject projectService = new NuPortalProjectService.NuPortalProject();
            projectService.Url = Constants.ProjectService;
            try
            {
                string ReturnId = projectService.CreateClient(Convert.ToInt32(Session["CompanyId"]), CompanyName, Website, PurchaseOrder, CompanyLogo, DateTime.Now, DateTime.Now, Convert.ToInt32(Session["EmpID"]),
                    Convert.ToInt32(Session["EmpID"]), 1);
                if (ReturnId != string.Empty)
                    return Json(ReturnId);
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
                projectService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }
        [HttpPost]
        public ActionResult UpdateClientInfo(int clientId,string CompanyName, string Website, string PurchaseOrderNumber, String CompanyLogo)
        {
            NuPortalProjectService.NuPortalProject projectService = new NuPortalProjectService.NuPortalProject();
            projectService.Url = Constants.ProjectService;
            try
            {
                bool IsSuccess = projectService.UpdateClient(clientId, CompanyName, Website, PurchaseOrderNumber, CompanyLogo, DateTime.Now,Convert.ToInt32(Session["EmpID"]),1);
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
                projectService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }
        [HttpPost]
        public ActionResult UpdateClientInfo1(int contactId,string ContactPerson, string ContactNumber, string Extension, string Mobile, string Designation, string Email, string Fax, string Department )
        {
            NuPortalProjectService.NuPortalProject projectService = new NuPortalProjectService.NuPortalProject();
            projectService.Url = Constants.ProjectService;
            try
            {
                bool IsSuccess = projectService.UpdateContact(contactId, ContactPerson, ContactNumber, Extension, Mobile, Designation, Email, Fax, Department, DateTime.Now, Convert.ToInt32(Session["EmpID"]), 1);

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
                projectService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }
       
        
        [HttpPost]
        public ActionResult SaveNewClientAddress(int ClientId, string jsonData)
        {
            DataTable data = JsonConvert.DeserializeObject<DataTable>(jsonData);

            NuPortalProjectService.NuPortalProject projectService = new NuPortalProjectService.NuPortalProject();
            projectService.Url = Constants.ProjectService;
            try
            {
                bool IsSuccess = projectService.SetClientAddress(ClientId, jsonData);
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
                projectService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }

        
        public JsonResult GetClientInfo(int ProjId)
        {
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                string jsonString = empService.SelectEmployeeInfo(ProjId, 15);
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
       
        public JsonResult GetClientAddress(int ProjId)
        {
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                string jsonString = empService.SelectEmployeeInfo(ProjId, 18);
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
    }
}