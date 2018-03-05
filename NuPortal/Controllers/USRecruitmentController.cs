﻿using Newtonsoft.Json;
using NuPortal.Common_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuPortal.Controllers
{
    [SessionTimeout]
    public class USRecruitmentController : Controller
    {
        // GET: USRecruitment
        public ActionResult VisaProcessing(int? hdnId, int? TypeId)
        {
            return View();
        }
        public ActionResult VisaLog()
        {
            return View();
        }
        public ActionResult InvoiceLog()
        {
            return View();
        }
        public ActionResult ContractLog()
        {
            return View();
        }
        public ActionResult CandidateLog()
        {
            return View();
        }
        public ActionResult InterviewLog()
        {
            return View();
        }
        public ActionResult SubmissionLog()
        {
            return View();
        }
        public ActionResult LeadLog()
        {
            return View();
        }
        public ActionResult OpportunityLog()
        {
            return View();
        }
        public ActionResult VendorDetails(int? hdnId, int? TypeId)
        {
            return View();
        }
        public ActionResult NewContract(int? hdnId, int? TypeId)
        {
            return View();
        }
        public ActionResult AddLead()
        {
            return View();
        }
        public ActionResult InvoiceDetails(int? hdnId, int? TypeId)
        {
            return View();
        }
        public ActionResult CreateOpportunity()
        {
            return View();
        }
        public ActionResult ScheduleInterview(int? hdnId, int? TypeId)
        {
            return View();
        }
        public ActionResult AssociateOpportunity()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Vendors()
        {
            return View();
        }
        public ActionResult WeeklyTaskReport()
        {
            return View();
        }
        public ActionResult EmployeeTimeSheet()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SaveOpportunity(int OppId, string ClientName, string ContactPerson, string Location, int NoOfOpenings,
           string Street, string City, string State, string Country, string Zip, string Contact1, string Contact2, string Email,
           string Fax, string Website, string PositionTitle, string WorkExp, string Rate, float Hours, int PositionType, string ProfileType,
           int Industry, string TargetDate, string Note, string AttachmentPath, string JobDescription, int Operation)
        {
            NuPortalUSRecService.NuPortalUSRecService usRecService = new NuPortalUSRecService.NuPortalUSRecService();
            usRecService.Url = Constants.USRecService;
            try
            {
                string JsonData = usRecService.SaveOpportunity(OppId, Street, City, State, Zip,Country, ClientName,
                    Contact1, Contact2, ContactPerson, Convert.ToInt32(Session["EmpId"]),
                    PositionType, Industry, Convert.ToDateTime(TargetDate), Note, AttachmentPath, JobDescription,
                    Email, WorkExp, Fax, Hours, 0, 0, Location, Convert.ToInt32(Session["EmpId"]),
                    Convert.ToInt32(Session["CompanyId"]), NoOfOpenings, PositionTitle, ProfileType, Rate, Website, 1, Operation);
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
                usRecService = null;
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveInterView(int InterviewId, string Attachments, int Fk_Interviewtype,
           int Fk_SubmissionId, int Fk_TicketStatusId, string InterviewDate, string InterviewTime, string Note, string Location,
            int Operation)
        {
            NuPortalUSRecService.NuPortalUSRecService usRecService = new NuPortalUSRecService.NuPortalUSRecService();
            usRecService.Url = Constants.USRecService;
            try
            {

                string JsonData = usRecService.SaveInterView(InterviewId, Attachments, Convert.ToInt32(Session["EmpId"]), Fk_Interviewtype,
                   Fk_SubmissionId, Fk_TicketStatusId, Convert.ToDateTime(InterviewDate), InterviewTime, Note, Location, Convert.ToInt32(Session["EmpId"]), Operation);
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
                usRecService = null;
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveVendorDetails(int VendorDetailsId, int FK_LeadId, string CompanyName, string CompanyID, string CompanyAddress,
           string ContactPerson1Name, string ContactPerson1Title, string ContactPerson2Name, string ContactPerson2Title, string ContactPerson3Name,
           string ContactPerson3Title, string VendorID, string DepositoryBankName, string Branch, string City, string State, string RoutingNumber,
           string AccountName, string AccountNumber, int AccountType, string VendorName, string IDNumber, string SignedBy, string Designation,
           string Date, string Attachments,int FK_TicketStatusId, int Status, int Operation)
        {
            NuPortalUSRecService.NuPortalUSRecService usRecService = new NuPortalUSRecService.NuPortalUSRecService();
            usRecService.Url = Constants.USRecService;
            try
            {

                string JsonData = usRecService.SaveVendorDetails(VendorDetailsId, FK_LeadId, CompanyName, CompanyID, CompanyAddress, ContactPerson1Name,
                    ContactPerson1Title, ContactPerson2Name, ContactPerson2Title, ContactPerson3Name, ContactPerson3Title, VendorID, DepositoryBankName,
                    Branch, City, State, RoutingNumber, AccountName, AccountNumber, AccountType, VendorName, IDNumber, SignedBy, Designation, Convert.ToDateTime(Date),
                    Attachments, FK_TicketStatusId,Convert.ToInt32(Session["EmpId"]), Convert.ToInt32(Session["EmpId"]), 
                    Status, Operation);
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
                usRecService = null;
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveInvoiceDetails(int InvoiceId, int FK_SubmissionId,int FK_TicketStatus, string Name, string Email, string Terms, int FK_BillingCycle, string Street,
            string City, string State, string Country, string Zip, string CcList, int Status, int Operation)
        {
            NuPortalUSRecService.NuPortalUSRecService usRecService = new NuPortalUSRecService.NuPortalUSRecService();
            usRecService.Url = Constants.USRecService;
            try
            {
               
                string JsonData = usRecService.SaveInvoiceDetails(InvoiceId, FK_SubmissionId, FK_TicketStatus, Name, Email, Terms, FK_BillingCycle, Street, City,
                    State, Country, Zip, CcList, Status, Convert.ToInt32(Session["EmpId"]), Convert.ToInt32(Session["EmpId"]), Operation);

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
                usRecService = null;
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveInvoiceContactDetails(int Id, string jsonInvoiceDocs)
        {
            NuPortalUSRecService.NuPortalUSRecService usRecService = new NuPortalUSRecService.NuPortalUSRecService();
            usRecService.Url = Constants.USRecService;
            try
            {
                bool IsSuccess = usRecService.SaveInvoiceContactDetails(Id, jsonInvoiceDocs);
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
                usRecService = null;
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult SaveVisaProcessing(int VisaProcessingID,int FKSubmissionId,string CompanyAddress,string CompanyDescription,
            string CompanyEstDate,string CompanyName,string Email,
            string EmpAbroadAddress, string EmpCountryOfBirth, string  EmpDOB,string EmpFname,string EmpLname,
            string EmpMname,string EmpNearestConsulate,string EmpPlaceOfBirth, string EmpSSN,string EmpUSAddress,
            string Fax,string FederalTAXIDNumber,string GrossAnnualIncome,string I94IssueDate, string I94Number,
            string I94ValidityDate,int IsCompanyH1BDependent,string JobLocationAddress,string JobTitleOffered,
             string LastI797ApprovalReceipt,int MaritalStatus,string NameOfPersonToSign,string NetIncome,
            int NoOfEmployees,int NoOfH1BEmployees,string PassportIssueDate,string PassportNumber,string PassportValidityDate,
            string Phone, string SalaryOffered, string TitleOfPersonToSign,string TicketSubmissionDate,int FK_TicketStatusId,
            int Operation,int Candidate,string ClientName, string PositionTitle)
        {
            NuPortalUSRecService.NuPortalUSRecService usRecService = new NuPortalUSRecService.NuPortalUSRecService();
            usRecService.Url = Constants.USRecService;
            try
            {
                string JsonData = usRecService.SaveVisaProcessing(VisaProcessingID,FKSubmissionId,CompanyAddress, CompanyDescription,
                   Convert.ToDateTime(CompanyEstDate),CompanyName,Convert.ToInt32(Session["EmpId"]),
                   Email,EmpAbroadAddress,EmpCountryOfBirth,Convert.ToDateTime(EmpDOB),EmpFname,EmpLname,EmpMname,EmpNearestConsulate,
                   EmpPlaceOfBirth,EmpSSN,EmpUSAddress,Fax,FederalTAXIDNumber,GrossAnnualIncome, Convert.ToDateTime(I94IssueDate),I94Number,
                   Convert.ToDateTime(I94ValidityDate),IsCompanyH1BDependent,JobLocationAddress,JobTitleOffered,LastI797ApprovalReceipt,
                   MaritalStatus,Convert.ToInt32(Session["EmpId"]),NameOfPersonToSign,NetIncome,NoOfEmployees,
                   NoOfH1BEmployees,Convert.ToDateTime(PassportIssueDate),PassportNumber,Convert.ToDateTime(PassportValidityDate),
                   Phone,SalaryOffered,TitleOfPersonToSign, Convert.ToDateTime(TicketSubmissionDate),FK_TicketStatusId,Operation,Candidate,ClientName,PositionTitle);

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
                usRecService = null;
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveVisaDateDetails(int Id,string jsonVisaDateDetails)
        {
            NuPortalUSRecService.NuPortalUSRecService usRecService = new NuPortalUSRecService.NuPortalUSRecService();
            usRecService.Url = Constants.USRecService;
            try
            {
                bool IsSuccess = usRecService.SaveVisaDateDetails(Id,jsonVisaDateDetails);
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
                usRecService = null;
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveFamilyVisaDetails(int Id,string jsonFamilyVisaDetails)
        {
            NuPortalUSRecService.NuPortalUSRecService usRecService = new NuPortalUSRecService.NuPortalUSRecService();
            usRecService.Url = Constants.USRecService;
            try
            {
                bool IsSuccess = usRecService.SaveFamilyVisaDetails(Id,jsonFamilyVisaDetails);
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
                usRecService = null;
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
      
        [HttpPost]
        public ActionResult SaveSubmittedVisaDocs(int Id, string jsonSubmittedVisaDocs)
        {
            NuPortalUSRecService.NuPortalUSRecService usRecService = new NuPortalUSRecService.NuPortalUSRecService();
            usRecService.Url = Constants.USRecService;
            try
            {
                bool IsSuccess = usRecService.SaveSubmittedVisaDocs(Id,jsonSubmittedVisaDocs);
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
                usRecService = null;
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult loadScheduleInterView(int idval, int Operation)
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
            }
            finally
            {
                dbService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }

        [HttpPost]
        public ActionResult SaveReqDocs(int OppId, string jsonData)
        {
            NuPortalUSRecService.NuPortalUSRecService usRecService = new NuPortalUSRecService.NuPortalUSRecService();
            usRecService.Url = Constants.USRecService;
            try
            {
                bool IsSuccess = usRecService.SaveReqDocs(OppId, jsonData);
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
                usRecService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }

        [HttpPost]
        public ActionResult SaveSkills(int OppId, string jsonData)
        {
            NuPortalUSRecService.NuPortalUSRecService usRecService = new NuPortalUSRecService.NuPortalUSRecService();
            usRecService.Url = Constants.USRecService;
            try
            {
                bool IsSuccess = usRecService.setRecSkills(OppId, jsonData);
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
                usRecService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }

        [HttpGet]
        public JsonResult GetPositionType()
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string jsonPositionType = dbService.GetDDListBox(Convert.ToInt32(Session["CompanyId"]), 29);
                if (jsonPositionType != string.Empty)
                    return Json(jsonPositionType, JsonRequestBehavior.AllowGet);
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
        public JsonResult GetInterviewType()
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string jsonPositionType = dbService.GetDDListBox(Convert.ToInt32(Session["CompanyId"]), 37);
                if (jsonPositionType != string.Empty)
                    return Json(jsonPositionType, JsonRequestBehavior.AllowGet);
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
        public JsonResult GetBillingCycle()
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string jsonPositionType = dbService.GetDDListBox(Convert.ToInt32(Session["CompanyId"]), 36);
                if (jsonPositionType != string.Empty)
                    return Json(jsonPositionType, JsonRequestBehavior.AllowGet);
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
        public JsonResult GetContactType()
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string jsonPositionType = dbService.GetDDListBox(Convert.ToInt32(Session["CompanyId"]), 38);
                if (jsonPositionType != string.Empty)
                    return Json(jsonPositionType, JsonRequestBehavior.AllowGet);
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
        public JsonResult GetAccountType()
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string jsonPositionType = dbService.GetDDListBox(Convert.ToInt32(Session["CompanyId"]), 35);
                if (jsonPositionType != string.Empty)
                    return Json(jsonPositionType, JsonRequestBehavior.AllowGet);
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
        public JsonResult GetVisaType()
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string jsonPositionType = dbService.GetDDListBox(Convert.ToInt32(Session["CompanyId"]), 34);
                if (jsonPositionType != string.Empty)
                    return Json(jsonPositionType, JsonRequestBehavior.AllowGet);
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
        public JsonResult GetIndustry()
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string jsonIndustry = dbService.GetDDListBox(Convert.ToInt32(Session["CompanyId"]), 30);
                if (jsonIndustry != string.Empty)
                    return Json(jsonIndustry, JsonRequestBehavior.AllowGet);
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
        public JsonResult GetEmployeeType()
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string jsonEmployeeType = dbService.GetDDListBox(Convert.ToInt32(Session["CompanyId"]), 31);
                if (jsonEmployeeType != string.Empty)
                    return Json(jsonEmployeeType, JsonRequestBehavior.AllowGet);
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
        public JsonResult GetLeadType()
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string jsonEmployeeType = dbService.GetDDListBox(Convert.ToInt32(Session["CompanyId"]), 32);
                if (jsonEmployeeType != string.Empty)
                    return Json(jsonEmployeeType, JsonRequestBehavior.AllowGet);
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
        public JsonResult GetEmploymentType()
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string jsonEmploymentType = dbService.GetDDListBox(Convert.ToInt32(Session["CompanyId"]), 33);
                if (jsonEmploymentType != string.Empty)
                    return Json(jsonEmploymentType, JsonRequestBehavior.AllowGet);
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
        [HttpPost]
        public ActionResult AddLeadData(int LeadId, string FirstName, string LastName, string MobileNumber, int VisaType, string Street,
        string City, string State, string Country, string Zip, string DOB, string Gender, string Email, int EmployeeType, int ExperienceInMonths,
        string HighestQualification, string CurrentEmployer, string CurrentDesignation, string CurrentCTC, string CurrentLocation, int LeadType, string Rate, int Hours,
        int EmploymentType, string Source, string Note, string AttachmentUrl,int RecStatus,int Operation)
        {
            NuPortalUSRecService.NuPortalUSRecService usRecService = new NuPortalUSRecService.NuPortalUSRecService();
            usRecService.Url = Constants.USRecService;
            try
            {
                string ReturnId = usRecService.SaveLead(LeadId, Convert.ToInt32(Session["EmpId"]), CurrentCTC, CurrentDesignation, CurrentEmployer, VisaType, Street, City,
                    Zip, State, Country, HighestQualification, Source, CurrentLocation, Convert.ToDateTime(DOB), Email, EmployeeType, EmploymentType,
                   ExperienceInMonths, FirstName, Gender, Hours, LastName, LeadType, MobileNumber,
                    Convert.ToInt32(Session["EmpId"]), Note, Rate, 1, 0, AttachmentUrl, RecStatus, Operation);
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
            }
            finally
            {
                usRecService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }
        [HttpPost]
        public ActionResult SaveLeadListValues(int LeadId, string jsonData)
        {
            NuPortalUSRecService.NuPortalUSRecService usRecService = new NuPortalUSRecService.NuPortalUSRecService();
            usRecService.Url = Constants.USRecService;
            try
            {
                bool IsSuccess = usRecService.setLeadSkills(LeadId, jsonData);
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
                usRecService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }
        [HttpPost]
        public ActionResult SaveContract(int ContractId, int SubmissionId,int FK_TicketStatus, string Title, string Date, string SignedBy, string TitleClient, string DateClient,
            string SignedByClient, string State, string ContractExpiryDate, int IsRateConfirmationPresent,int Operation)
        {
            NuPortalUSRecService.NuPortalUSRecService usRecService = new NuPortalUSRecService.NuPortalUSRecService();
            usRecService.Url = Constants.USRecService;
            try
            {
                string ReturnId = usRecService.SaveContract(ContractId, SubmissionId, FK_TicketStatus ,Title, Convert.ToDateTime(Date), SignedBy, TitleClient,
                    Convert.ToDateTime(DateClient), SignedByClient, State, Convert.ToDateTime(ContractExpiryDate),
                    IsRateConfirmationPresent, Convert.ToInt32(Session["EmpId"]),
                    Convert.ToInt32(Session["EmpId"]), 1, Operation);
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
            }
            finally
            {
                usRecService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }
        [HttpPost]
        public ActionResult SaveContractDocuments(int ContractId, string jsonData)
        {
            NuPortalUSRecService.NuPortalUSRecService usRecService = new NuPortalUSRecService.NuPortalUSRecService();
            usRecService.Url = Constants.USRecService;
            try
            {
                bool ReturnId = usRecService.SaveContractDocs(ContractId, jsonData);
                if (ReturnId)
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
                usRecService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }
        [HttpGet]
        public JsonResult GetOpportunityDetails(string OppIds)
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalProjectService.NuPortalProject projectService = new NuPortalProjectService.NuPortalProject();
            projectService.Url = Constants.ProjectService;
            try
            {
                string JsonString = projectService.GetTimeSheetReport(OppIds, DateTime.Now, DateTime.Now, 0,0,500, 3);
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
            }
            outData = new Dictionary<string, string>();
            outData.Add("Error", "Error");
            return Json(JsonConvert.SerializeObject(outData), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveSubmissions(int SubmissionId,int FKSubmissionStatusId, int FK_OppId, int FK_LeadId, string Rate, int FK_TicketStatusId, int Operation)
        {
            NuPortalUSRecService.NuPortalUSRecService usRecService = new NuPortalUSRecService.NuPortalUSRecService();
            usRecService.Url = Constants.USRecService;
            try
            {
                string ReturnVal = usRecService.SaveSubmissions(SubmissionId,FKSubmissionStatusId, FK_OppId, FK_LeadId, Rate, Convert.ToInt32(Session["EmpId"]), FK_TicketStatusId,
                    0, 1, Convert.ToInt32(Session["EmpId"]), Convert.ToInt32(Session["EmpId"]), Operation);
                if (ReturnVal != string.Empty)
                    return Json(ReturnVal);
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
                usRecService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }

        [HttpPost]
        public ActionResult SaveSubmittedDocs(int Id, string jsonData)
        {
            NuPortalUSRecService.NuPortalUSRecService usRecService = new NuPortalUSRecService.NuPortalUSRecService();
            usRecService.Url = Constants.USRecService;
            try
            {
                bool IsSuccess = usRecService.SaveSubmittedDocs(Id, jsonData);
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
                usRecService = null;
            }
            return Json(Common_Library.Constants.JsonError);
        }
        [HttpGet]
        public JsonResult GetSubmittedStatus()
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string jsonLocation = dbService.GetDDListBox(Convert.ToInt32(Session["CompanyId"]), 40);
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
        public JsonResult GetInterviewStatus(int TicketStatusId)
        {
            Dictionary<string, string> outData = new Dictionary<string, string>();
            NuPortalDBService.NuPortalService dbService = new NuPortalDBService.NuPortalService();
            dbService.Url = Constants.DBService;
            try
            {
                string jsonInterview = dbService.GetDDListBox(TicketStatusId, 41);
                if (jsonInterview != "")
                    return Json(jsonInterview, JsonRequestBehavior.AllowGet);
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
        public JsonResult GetWeeklyReport(string StartDate, string EndDate, int ProjectId, 
            int ResourceId, int Offset, int RowCount, int Operation)
        {
            NuPortalUSRecService.NuPortalUSRecService usRecService = new NuPortalUSRecService.NuPortalUSRecService();
            usRecService.Url = Constants.USRecService;
            try
            {
                string ReturnVal = usRecService.GetTimeSheetReport(Convert.ToDateTime(StartDate),
                    Convert.ToDateTime(EndDate), ProjectId, ResourceId, Offset, RowCount, Operation);
                if (ReturnVal != string.Empty)
                    return Json(ReturnVal, JsonRequestBehavior.AllowGet);
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
                usRecService = null;
            }
            return Json(Common_Library.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
    }
}