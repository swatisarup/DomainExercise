using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Reporting
{
    /// <summary>
    /// Creates a single instance of Extent Report 
    /// </summary>
    public class ReportingManager
    {
        /// <summary>
        /// Create new instance of Extent report
        /// </summary>
        private static readonly ExtentReports _instance = new ExtentReports(_path, true);

        private static  string _path
        {
            get
            {
                string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
                string projectPath = new Uri(actualPath).LocalPath;

                //Append the html report file to current project path

                string reportPath = projectPath + "Reporting\\TestRunReport.html";
                return reportPath;
            }
        }
        static ReportingManager() { }
        private ReportingManager() { }

        /// <summary>
        /// Property to return the instance of the report.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static ExtentReports Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
