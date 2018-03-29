namespace WordpressAutomation
{
    using OpenQA.Selenium;
    using System;

    public class PostPage
    {
        public static string Title
        {
            get
            {
                var title = Driver.Instance.FindElement(By.ClassName("entry-title"));
                if (title != null)
                {
                    return title.Text;
                }
                else
                {
                    return String.Empty;
                }
            }
        }
    }
}
