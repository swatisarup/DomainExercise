using Domain.Reporting;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tests
{
    [TestFixture]
    public abstract class TestBase
    {

        internal static ReportingTasks _reportingTasks;

        /// <summary>
        /// Begin execution of tests
        /// </summary>
        public static void BeginExecution()
        {
            ExtentReports extentReports = ReportingManager.Instance;
            extentReports.LoadConfig(Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.FullName + "\\extent-config.xml");
            
            _reportingTasks = new ReportingTasks(extentReports);

        }

        /// <summary>
        /// Finish Execution of tests
        /// </summary>
        public static void ExitExecution()
        {

            _reportingTasks.CleanUpReporting();
        }
    }
}
