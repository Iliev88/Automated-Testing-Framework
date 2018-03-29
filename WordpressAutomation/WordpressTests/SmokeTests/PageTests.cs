namespace WordpressTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WordpressAutomation;

    [TestClass]
    public class PageTests : WordpressTest
    {
        [TestMethod]
        public void Can_Edit_A_Page()
        {
            ListPostPage.GoTo(PostType.Page);
            ListPostPage.SelectPost("Sample Page");

            Assert.IsTrue(NewPostPage.IsInEditMode(), "Wasn't in edit mode");
            Assert.AreEqual("Sample Page", NewPostPage.Title, "Title did not match");
        }
    }
}
