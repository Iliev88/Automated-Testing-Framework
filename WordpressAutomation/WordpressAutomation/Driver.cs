using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace WordpressAutomation
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static string BaseAddress
        {
            get
            {
                return "https://s1.demo.opensourcecms.com/wordpress";
            }
        }

        public static void Initialize()
        {
            Instance = new FirefoxDriver();
            //Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

        }

        public static void Close()
        {
            Instance.Close();
        }

        public static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep((int) (timeSpan.TotalSeconds * 1000));
        }
    }
}