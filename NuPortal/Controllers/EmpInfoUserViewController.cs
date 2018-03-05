﻿using Newtonsoft.Json;
using NuPortal.Common_Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace NuPortal.Controllers
{
    [SessionTimeout]
    public class EmpInfoUserViewController : Controller
    {

        public ActionResult EmpInfoUserView(int? EmpViewType)
        {
            //if (Session["EmpID"] != null)
            //    return EmpInfoUserView();
            //else
            //    return RedirectToAction("LoginView","Login");
            return View();
        }

        [HttpPost]
        public ActionResult UpdateEmpInfo(int EmployeeId, string title, string fname, string lname, string empCode, int designation, string officeEmail, int empType, int location,
            string workLocation, string joinDate, string confirmDate, int manager, string relDate, string profilePic, string passportPic, string bgPic, int powerval,
            string StartTime, string EndTime,string quotes, int EmpStatus)
        {
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                bool IsSuccess = empService.UpdateEmployee(EmployeeId, fname, lname, title, empCode, designation, manager, profilePic,
                    passportPic, bgPic, Convert.ToDateTime(joinDate), Convert.ToDateTime(confirmDate), officeEmail, location, 
                    workLocation, empType, Convert.ToDateTime(relDate), DateTime.Now,
                    Convert.ToInt32(Session["EmpID"]), powerval, StartTime, EndTime, quotes, EmpStatus);
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
                empService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }

        [HttpPost]
        public ActionResult SavePerInfo(int EmployeeId, string address1, string city1, string state1, string country1, string zipcode1, string phone1, string address2, string city2,
            string state2, string country2, string zipcode2, string phone2, string EmergencyPhone, string Email, string Dob, string BloodGroup, string Nationality,
            string Gender)
        {
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                bool IsSuccess = empService.SetPersonalInfo(EmployeeId, address1, city1, state1, country1, zipcode1,
                    phone1, address2, city2, state2, country2, zipcode2, phone2, EmergencyPhone, Email, Convert.ToDateTime(Dob), Gender, Nationality, BloodGroup,
                    DateTime.Now, DateTime.Now, Convert.ToInt32(Session["EmpID"]), Convert.ToInt32(Session["EmpID"]));
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
                empService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }

        [HttpPost]
        public ActionResult SaveAcademic(int EmployeeId, string jsonData)
        {
            DataTable data = JsonConvert.DeserializeObject<DataTable>(jsonData);
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                bool IsSuccess = empService.SetAcademic(EmployeeId, jsonData);
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
                empService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }

        [HttpPost]
        public ActionResult SaveExperience(int EmployeeId, string jsonData)
        {
            DataTable data = JsonConvert.DeserializeObject<DataTable>(jsonData);
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                bool IsSuccess = empService.SetExperience(EmployeeId, jsonData);
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
                empService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }

        [HttpPost]
        public ActionResult SaveIdentity(int EmployeeId, string jsonData)
        {
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                DataTable data = JsonConvert.DeserializeObject<DataTable>(jsonData);
                bool IsSuccess = empService.SetIdentityDetails(EmployeeId, jsonData);
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
                empService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }

        [HttpPost]
        public ActionResult SaveCompetancy(int EmployeeId, string jsonData)
        {
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                DataTable data = JsonConvert.DeserializeObject<DataTable>(jsonData);
                bool IsSuccess = empService.SetCompetency(EmployeeId, jsonData);
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
                empService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }

        [HttpPost]
        public ActionResult UploadFiles()
        {
            Dictionary<string, string> outFiles = new Dictionary<string, string>();
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fname, filename;
                        //string[] fnameArray = files.Keys[i].Split('|');
                        //if (fnameArray.Length > 1)
                        //{
                        //    filename = fnameArray[1];
                        //}
                        //else
                            filename = files[i].FileName;
                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = filename.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = filename;
                        }
                        fname = Path.GetFileNameWithoutExtension(fname) + "^_^_^" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(fname);
                        // Get the complete folder path and store the file inside it.  
                        string finalPath = Path.Combine(Server.MapPath("~/Uploads/"),fname);
                        file.SaveAs(finalPath);
                        outFiles.Add(filename, "../Uploads/" + fname);
                    }
                    var json = JsonConvert.SerializeObject(outFiles);
                    // Returns message that successfully uploaded  
                    return Json(json);
                }
                catch (Exception ex)
                {
                    GeneralFunctions genFun = new GeneralFunctions();
                    genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                        Convert.ToString(ControllerContext.RouteData.Values["action"]),
                        Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                    genFun = null;
                    outFiles = new Dictionary<string, string>();
                    outFiles.Add("Error", ex.ToString());
                    return Json(JsonConvert.SerializeObject(outFiles));
                }
            }
            else
            {
                outFiles = new Dictionary<string, string>();
                outFiles.Add("Error", "No Files to upload");
                return Json(JsonConvert.SerializeObject(outFiles));
            }
        }

        //Load data to form
        [HttpGet]
        public JsonResult GetEmpInfo(int EmployeeId,int Operation)
        {
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                string jsonString = empService.SelectEmployeeInfo(EmployeeId, Operation);
                //0-emp info,1-per info,2-academic,3-identity,4-experience,5-competancy
                //jsonString = JsonConvert.SerializeObject(jsonString);
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
        public JsonResult GetProfileCompleteness(int EmployeeId)
        {
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                string jsonString = empService.GetEmployeeProfileCompleted(EmployeeId);
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

        //Bind ddls

        [HttpGet]
        public JsonResult GetDesignation()
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string jsonDesignation = dbService.GetDDListBox(Convert.ToInt32(Session["CompanyId"]), 0);
                if (jsonDesignation != "")
                    return Json(jsonDesignation, JsonRequestBehavior.AllowGet);
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
                dbService = null;
            }
            outData = new Dictionary<string, string>();
            outData.Add("Error", "Error");
            return Json(JsonConvert.SerializeObject(outData), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetLocation()
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string jsonLocation = dbService.GetDDListBox(Convert.ToInt32(Session["CompanyId"]), 1);
                if (jsonLocation != "")
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
                dbService = null;
            }
            outData = new Dictionary<string, string>();
            outData.Add("Error", "Error");
            return Json(JsonConvert.SerializeObject(outData), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetEmptType()
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string jsonEmptType = dbService.GetDDListBox(Convert.ToInt32(Session["CompanyId"]), 2);
                if (jsonEmptType != "")
                    return Json(jsonEmptType, JsonRequestBehavior.AllowGet);
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
                dbService = null;
            }
            outData = new Dictionary<string, string>();
            outData.Add("Error", "Error");
            return Json(JsonConvert.SerializeObject(outData), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetDdlIdentity()
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string jsonLocation = dbService.GetDDListBox(Convert.ToInt32(Session["CompanyId"]), 3);
                if (jsonLocation != "")
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
                dbService = null;
            }
            outData = new Dictionary<string, string>();
            outData.Add("Error", "Error");
            return Json(JsonConvert.SerializeObject(outData), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetDataFromDDl()
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string jsonLocation = dbService.GetDDListBox(Convert.ToInt32(Session["CompanyId"]), 20);
                if (jsonLocation != "")
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
                dbService = null;
            }
            outData = new Dictionary<string, string>();
            outData.Add("Error", "Error");
            return Json(JsonConvert.SerializeObject(outData), JsonRequestBehavior.AllowGet);
        }
        
        public void ClearSession()
        {
            try
            {
                FormsAuthentication.SignOut();
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();
                HttpCookie aCookie;
                foreach (string key in Request.Cookies.AllKeys)
                {
                    aCookie = Request.Cookies[key];
                    aCookie = new HttpCookie(key);
                    aCookie.Expires = DateTime.Now.AddMonths(-10);
                    Response.AppendCookie(aCookie);
                }
                foreach (System.Collections.DictionaryEntry entry in HttpContext.Cache)
                {
                    HttpContext.Cache.Remove((string)entry.Key);
                }
                FormsAuthentication.RedirectToLoginPage();
            }
            catch (Exception ex)
            {
                GeneralFunctions genFun = new GeneralFunctions();
                genFun.LogError(ControllerContext.HttpContext, ex.Message, ex.TargetSite.Name,
                    Convert.ToString(ControllerContext.RouteData.Values["action"]),
                    Convert.ToString(ControllerContext.RouteData.Values["controller"]));
                genFun = null;
            }
        }

        [HttpGet]
        public JsonResult GetEmployeeDetails(int EmpId)
        {
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            DataTable dt = new DataTable(), temp = new DataTable();
            try
            {
                temp = JsonConvert.DeserializeObject<DataTable>(empService.SelectEmployeeInfo(EmpId, 60));
                return Json(JsonConvert.SerializeObject(temp), JsonRequestBehavior.AllowGet);
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
            finally { empService.Dispose(); dt.Dispose(); temp.Dispose(); }
        }

        [HttpPost]
        public JsonResult SetEmpGallery(int EmpId, string jsonData)
        {
            NuPortalEmpService.NuPortalEmployeeService empService = new NuPortalEmpService.NuPortalEmployeeService();
            empService.Url = Constants.EmpService;
            try
            {
                bool IsSuccess = empService.SetEmpGallery(EmpId, jsonData);
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
                empService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }
    }
}