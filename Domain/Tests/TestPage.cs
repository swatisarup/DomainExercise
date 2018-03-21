using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tests
{

    [SetUpFixture]
    public class TestSetup
    {
        /// <summary>
        /// Run Method Only Once before tests
        /// </summary>
        [OneTimeSetUp]
        public void Start()
        {
            TestBase.BeginExecution();
        }
        /// <summary>
        /// Run Method Only Once After tests
        /// </summary>
        [OneTimeTearDown]
        public void End()
        {
            TestBase.ExitExecution();
        }
    }
}