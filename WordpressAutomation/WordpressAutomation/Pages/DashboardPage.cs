namespace WordpressAutomation
{
    using OpenQA.Selenium;

    public class DashboardPage
    {
        public static bool IsAt
        {
            get
            {
                // Refactor: Can we create a generilized IsAt for all pages?
                var h1s = Driver.Instance.FindElements(By.TagName("h1"));

                if (h1s.Count > 0)
                {
                    return h1s[0].Text == "Dashboard";

                }
                else
                {
                    return false;
                }
            }
        }
    }
}
