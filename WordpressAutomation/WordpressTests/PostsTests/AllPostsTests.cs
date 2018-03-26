using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordpressAutomation;

namespace WordpressTests.PostTests
{
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
            // Go to posts, get post count, store\
            ListPostPage.GoTo(PostType.Posts);
            ListPostPage.StoreCount();

            // Add a new post
            NewPostPage.GoTo();
            NewPostPage.CreatePost("Added posts show up, title").WithBody("Added posts show up, body").Publish();

            // Go to post, get new post count
            ListPostPage.GoTo(PostType.Posts);
            Assert.AreEqual(ListPostPage.PreviousPostCount + 1, ListPostPage.CurrentPostCount, "Count of posts does not increase");
            
            // Check for added post
            Assert.IsTrue(ListPostPage.DoesPostExistWithTitle("Added posts show up, title"));

            // Trash post (clean up)
            ListPostPage.TrashPost("Added posts show up, title");
            Assert.AreEqual(ListPostPage.PreviousPostCount, ListPostPage.CurrentPostCount, "Couldn't trash post");
        }

    }
}
