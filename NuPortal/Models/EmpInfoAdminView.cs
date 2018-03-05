﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuPortal.Models
{
    public class EmpInfoAdminView
    {

        //[Required]
        public string firstName { get; set; }
        public string lastName { get; set; }
        //[Required]
        public string joiningDate { get; set; }
        public string confirmationDate { get; set; }
       
        //[Required]
        public string employeeCode { get; set; }
        //[Required]
        public string officeEmailId { get; set; }
       
        public string workLocation { get; set; }
        public string relievingDate { get; set; }
        public string workStartTime { get; set; }
        public string workEndTime { get; set; }
        //[Required]
        public int reportingTo { get; set; }

        public string profilePicUrl { get; set; }
        public string passPicUrl { get; set; }
        public string bgPicUrl { get; set; }
        public int weekOffDays { get; set; }
        public string quotes { get; set; }

               

        public List<SelectListItem> designation { get; set; }
        public int? designationId { get; set; }
        public List<SelectListItem> officeLocation { get; set; }
        public int? officeLocationId { get; set; }
        public List<SelectListItem> employmentType { get; set; }
        public int? employementId { get; set; }
        public List<SelectListItem> title { get; set; }
        public string titleId { get; set; }
        public List<SelectListItem> employmentStatus { get; set; }
        public int? employmentStatusId { get; set; }        
        public int applicantId { get; set; }
        public string imageUrl { get; set; }
        public string quoteText { get; set; }
    }
}