using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.ObjectModel;
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

         //  DesiredCapabilities capabilities = DesiredCapabilities.Chrome();
         //  capabilities.SetCapability(CapabilityType.Platform, "Windows 10");
         //  capabilities.SetCapability(CapabilityType.Version, "");
         //  capabilities.SetCapability("name", "wordpress test");
         //  capabilities.SetCapability("username", "username");
         //  capabilities.SetCapability("accessKey", "1234");
         //
         //  Instance = new RemoteWebDriver(new Uri("http://saucelabs.com"), capabilities);

            TurnOnWait();

        }

        public static void Close()
        {
            Instance.Close();
        }

        public static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep((int) (timeSpan.TotalSeconds * 1000));
        }

        internal static void NoWait(Action action)
        {
            TurnOffWait();
            action();
            TurnOnWait();
        }

        private static void TurnOnWait()
        {
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        private static void TurnOffWait()
        {
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }
    }
}