using System;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace WordpressAutomation
{
    public class ListPostPage
    {
        private static int lastCount;

        public static int PreviousPostCount
        {
            get
            {
                return lastCount;
            }
        }

        public static object CurrentPostCount
        {
            get
            {
                return GetPostCount();
            }
        }

        public static void GoTo(PostType postType)
        {
            switch(postType)
            {
                case PostType.Page:
                    LeftNavigation.Pages.AllPages.Select();
                    break;

                case PostType.Posts:
                    LeftNavigation.Posts.AllPosts.Select();

                    if (!IsAt)
                    {
                        Error.Log("Did not navigate to all posts!");
                    }

                    break;
            }
        }

        public static void SelectPost(string title)
        {
            var postLink = Driver.Instance.FindElement(By.LinkText("Sample Page"));
            postLink.Click();
        }

        public static void StoreCount()
        {
            lastCount = GetPostCount();
        }

        private static int GetPostCount()
        {
            var countText = Driver.Instance.FindElement(By.ClassName("displaying-num")).Text;
            return int.Parse(countText.Split(' ')[0]);
        }

        public static bool DoesPostExistWithTitle(string title)
        {
            return Driver.Instance.FindElements(By.LinkText(title)).Any();
        }

        public static void TrashPost(string title)
        {
            var rows = Driver.Instance.FindElements(By.TagName("tr"));
            foreach (var row in rows)
            {
                ReadOnlyCollection<IWebElement> links = null;
                Driver.NoWait(() => links = row.FindElements(By.LinkText(title)));

                if (links.Count > 0)
                {
                    Actions action = new Actions(Driver.Instance);
                    action.MoveToElement(links[0]);
                    action.Perform();
                    row.FindElement(By.ClassName("submitdelete")).Click();
                    return;
                }
            }
            
        }

        public static void SearchForPost(string searchString)
        {
            if (!IsAt)
            {
                GoTo(PostType.Posts);
            }

            var searchBox = Driver.Instance.FindElement(By.Id("post-search-input"));
            searchBox.SendKeys(searchString);

            var searchButton = Driver.Instance.FindElement(By.Id("search-submit"));
            searchButton.Click();
        }

        protected static bool IsAt
        {
            get
            {
                var h1s = Driver.Instance.FindElements(By.TagName("h1"));

                if (h1s.Count > 0)
                {
                    return h1s[0].Text == "Posts";

                }
                else
                {
                    return false;
                }
            }
        }
    }

    internal class Error
    {
        internal static void Log(string v)
        {
            throw new NotImplementedException();
        }
    }

    public enum PostType
    {
        Page,
        Posts
    }
}
