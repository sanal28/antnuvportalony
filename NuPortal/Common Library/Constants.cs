using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NuPortal.Common_Library
{
    public class Constants
    {
        public const string JsonSuccess = "{\"Result\":\"Success\"}";
        public const string JsonError = "{\"Result\":\"Error\"}";
        public const string RequestService= "http://192.168.1.18:97/NuPortalRequestService.asmx";
        public const string HRService = "http://192.168.1.18:97/NuPortalHRService.asmx";
        public const string AdminService = "http://192.168.1.18:97/NuPortalAdminService.asmx";
        public const string RecruitmentService = "http://192.168.1.18:97/NuPortalRecruitmentService.asmx";
        public const string ProjectService = "http://192.168.1.18:97/NuPortalProjectService.asmx";
        public const string EmpService = "http://192.168.1.18:97/NuPortalEmployeeService.asmx";
        public const string DBService = "http://192.168.1.18:97/NuPortalService.asmx";
        public const string USRecService = "http://192.168.1.18:97/NuPortalUSRecService.asmx";
    }
}