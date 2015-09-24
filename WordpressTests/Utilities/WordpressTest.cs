using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;
using WordpressTests.PostsTetst;

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
            LoginPage.LoginAs("admin").WithPassword("automation").Login();
            LoginPage.LoginAs("admin").WithPassword("automation").Login();
        }

        [TestCleanup]
        public void Cleanup()
        {
            PostCreator.Cleanup();
            Driver.Close();
        }
    }
}
