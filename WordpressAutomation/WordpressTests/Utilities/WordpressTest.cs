namespace WordpressTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WordpressAutomation;
    using WordpressAutomation.Workflows;
    
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
