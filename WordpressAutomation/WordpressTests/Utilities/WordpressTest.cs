using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordpressAutomation;
using WordpressAutomation.Workflows;

namespace WordpressTests
{
    public class WordpressTest
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
            PostCreator.Initialize();

            LoginPage.GoTo();
            LoginPage.LoginAs("opensourcecms").WithPassword("opensourcecms").Login();
        }

        [TestCleanup]
        public void Cleanup()
        {
            PostCreator.Cleanup();
            Driver.Close();
        }
    }
}
