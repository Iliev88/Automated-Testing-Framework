namespace WordpressAutomation
{
    using OpenQA.Selenium;
    using System;

    public class NewPostPage
    {
        public static object Title
        {
            get
            {
                var title = Driver.Instance.FindElement(By.Id("title"));

                if (title != null)
                {
                    return title.GetAttribute("value");
                }
                else
                {
                    return String.Empty;
                }
            }
        }

        public static void GoTo()
        {
            LeftNavigation.Posts.AddNew.Select();



            
        }

        public static CreatePostCommand CreatePost(string title)
        {
            return new CreatePostCommand(title);
        }

        public static void GoToNewPost()
        {
            var message = Driver.Instance.FindElement(By.Id("message"));
            var newPostLink = message.FindElements(By.TagName("a"))[0];
            newPostLink.Click();
        }

        public static bool IsInEditMode()
        {
            return Driver.Instance.FindElement(By.XPath("//*[@id=\"wpbody-content\"]/div[3]/h1")) != null;
        }
    }

    public class CreatePostCommand
    {
        private readonly string title;
        private string body;

        public void Publish()
        {
            Driver.Instance.FindElement(By.Id("title")).SendKeys(title);

            Driver.Instance.SwitchTo().Frame("content_ifr");
            Driver.Instance.SwitchTo().ActiveElement().SendKeys(body);
            Driver.Instance.SwitchTo().DefaultContent();

            Driver.Wait(TimeSpan.FromSeconds(1));
            

            Driver.Instance.FindElement(By.Id("publish")).Click();
        }

        public CreatePostCommand WithBody(string body)
        {
            this.body = body;
            return this;
        }

        public CreatePostCommand(string title)
        {
            this.title = title;
        }
    }
}
