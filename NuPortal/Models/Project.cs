using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NuPortal.Models
{
    public class Project
    {
        [Required]
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Priority { get; set; }
        public string ClientName { get; set; }

        public string ProjectName { get; set; }
        public double PlannedHours { get; set; }
        public int DepartmentId { get; set; }
        public string ClientContact { get; set; }
        public string ProjectType { get; set; }
        public string ProjectCategory { get; set; }
        public string URL { get; set; }
        public string CostCentre { get; set; }
        public string Technologies { get; set; }
        [Required]
        public string Manager { get; set; }
        public string Resources { get; set; }
        public string ProjectDescription { get; set; }
        public int ProjectID { get; set; }
        public int CompanyId { get; set; }
        public int ClientId { get; set; }
        public int ContactId { get; set; }
        public string Attachments { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string Department { get; set; }

        public string Plann { get; set; }
    }
}