using NuPortal.Common_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuPortal.Controllers
{
    [SessionTimeout]
    public class NewContactsController : Controller
    {
        public ActionResult NewContacts()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewContacts(NuPortal.Models.NewContacts contacts,string submit= null)
        {
            NuPortalProjectService.NuPortalProject projectService = new NuPortalProjectService.NuPortalProject();
            projectService.Url = Constants.ProjectService;
            try
            {
                //if (ModelState.IsValid)
                //{
                bool IsSuccess = projectService.CreateContact(contacts.ClientId, contacts.ContactPerson, contacts.ContactNumber == null ? "" : contacts.ContactNumber,
                    contacts.extn == null ? "": contacts.extn, contacts.Mobile==null?"": contacts.Mobile, contacts.Designation==null?"": contacts.Designation,
                    contacts.Email==null?"": contacts.Email, contacts.Fax==null?"": contacts.Fax, contacts.Department==null?"": contacts.Department,
                        DateTime.Now, DateTime.Now, Convert.ToInt32(Session["EmpID"]), Convert.ToInt32(Session["EmpID"]), 1);
                    if (IsSuccess)
                    {
                        ModelState.Clear();
                        ViewBag.saveMessage = "Contact Created Successfully";                   
                    if (submit== "Save") {
                        return RedirectToAction("Projects","Projects");
                     }

                    }
                    else
                        ViewBag.validationMessage = "Error in saving data";
                //}
                //else
                //    ViewBag.validationMessage = "Please fill mandatory fields!";
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
                contacts = null;
                projectService = null;
            }
            return NewContacts();
        }
    }
}