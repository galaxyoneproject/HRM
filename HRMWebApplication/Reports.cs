using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace HRMWebApplication
{
    public static class Reports
    {
        public static string GetReportViewerPath()
        {
            return WebConfigurationManager.AppSettings["ReportViewerPath"];
         }
    }
}