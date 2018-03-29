namespace WordpressTests.PostTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WordpressAutomation;
    using WordpressAutomation.Workflows;

    [TestClass]
    public class AllPostsTests : WordpressTest
    {
       // Added posts show up in all posts
       // Can activate excerpt mode
       // Can Add new post
       // 
       // Single post selections
       // 
       // Can select a post by title
       // Can select a post by Edir
       // Can select a post by QuickEdit
       // Can trash a post
       // 
       // 
       // 
       // 

        [TestMethod]
        public void Added_Posts_Show_Up()
        {
            ListPostPage.GoTo(PostType.Posts);
            ListPostPage.StoreCount();

            PostCreator.CreatePost();
            
            ListPostPage.GoTo(PostType.Posts);
            Assert.AreEqual(ListPostPage.PreviousPostCount + 1, ListPostPage.CurrentPostCount, "Count of posts does not increase");
            
            Assert.IsTrue(ListPostPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));

            ListPostPage.TrashPost(PostCreator.PreviousTitle);
            Assert.AreEqual(ListPostPage.PreviousPostCount, ListPostPage.CurrentPostCount, "Couldn't trash post");
        }

        [TestMethod]
        public void Can_Search_Posts()
        {
            PostCreator.CreatePost();

            ListPostPage.SearchForPost(PostCreator.PreviousTitle);

            Assert.IsTrue(ListPostPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));
        }

    }
}
