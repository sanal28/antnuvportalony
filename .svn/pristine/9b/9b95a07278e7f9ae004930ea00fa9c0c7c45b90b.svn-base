using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuPortal.Common_Library
{
    public class GeneralFunctions
    {
        public DateTime SetDateVal(string DateVal)
        {
            try
            {
                if (DateVal == string.Empty || DateVal == null)
                    return Convert.ToDateTime("1753-01-01 12:00:00 AM");
                else
                    return Convert.ToDateTime(DateTime.ParseExact(DateVal, "MM/dd/yyyy", null).ToString("yyyy/MM/dd"));
            }
            catch
            {
                return Convert.ToDateTime("1753-01-01 12:00:00 AM");
            }
        }

        public void LogError(HttpContextBase Context,string ErrorMessage, string MethodName, string ActionName, string ControllerName)
        {
            try
            {
                string FilePath = Context.Server.MapPath("~/Logs/ErrorLog" + DateTime.Now.ToShortDateString() + ".txt");
                if (!File.Exists(FilePath))
                {
                    using (FileStream fs = new FileStream(FilePath, FileMode.Create))
                    {
                        //File Creation goes here
                    }
                }
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.WriteLine("Error Message : " + ErrorMessage);
                    writer.WriteLine("Method Name : " + MethodName);
                    writer.WriteLine("Action Name : " + ActionName);
                    writer.WriteLine("Controller Name : " + ControllerName);
                    writer.WriteLine("Date Time : " + DateTime.Now.ToString());
                    writer.WriteLine("---------------------------------------------------------------------------------");
                }
                //FileInfo info = new FileInfo(FilePath);
                //if (DateTime.Now.Day == 30 && info.CreationTime.Date != DateTime.Now.Date)
                //    File.Delete(FilePath);
            }
            catch
            {

            }
        }
    }
}