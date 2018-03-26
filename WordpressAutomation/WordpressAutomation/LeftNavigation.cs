using OpenQA.Selenium;

namespace WordpressAutomation
{
    public class LeftNavigation
    {
        public class Posts
        {
            public class AddNew
            {
                public static void Select()
                {
                    var menuPosts = Driver.Instance.FindElement(By.Id("menu-posts"));
                    menuPosts.Click();

                    var addNew = Driver.Instance.FindElement(By.LinkText("Add New"));
                    addNew.Click();
                }
            }
        }

        public class Pages
        {
            public class AllPages
            {
                public static void Select()
                {
                    Driver.Instance.FindElement(By.Id("menu-pages")).Click();
                    Driver.Instance.FindElement(By.LinkText("All Pages")).Click();
                }
            }
        }
    }
}
