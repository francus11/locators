using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Collections.ObjectModel;

namespace locators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver webDriver = new EdgeDriver();
            string url = "https://www.bbc.com/sport";
            webDriver.Navigate().GoToUrl(url);

            // main BBC page link

            IWebElement mainPageLink = webDriver.FindElement(By.LinkText("BBC Homepage"));

            Console.WriteLine($"Full text - {mainPageLink.Text}");

            // main BBC page link partial link text


            IWebElement mainPagePartialLink = webDriver.FindElement(By.PartialLinkText("Homepage"));

            Console.WriteLine($"Partial text - {mainPagePartialLink.Text}");

            //tag name

            IWebElement tag = webDriver.FindElement(By.TagName("svg"));

            Console.WriteLine(tag.GetAttribute("xmlns"));

            //more menu button

            IWebElement moreInfoButton = webDriver.FindElement(By.Id("more-menu-button"));

            Console.WriteLine(moreInfoButton.Text);

            // Menu bar items

            IWebElement menuBar = webDriver.FindElement(By.CssSelector("ul.ssrcss-min3p3-StyledMenuList"));
            ReadOnlyCollection<IWebElement> menuBarItems = menuBar.FindElements(By.XPath(".//*[text()]"));

            foreach (IWebElement item in menuBarItems)
            {
                Console.Write($"{item.Text} ");
            }

            Console.WriteLine();
            Console.WriteLine();

            //Biggest article box title

            ReadOnlyCollection<IWebElement> articleTitles = webDriver.FindElements(By.ClassName("e1gp961v0"));

            foreach (IWebElement articleTitle in articleTitles) 
            {
                try
                {
                    Console.WriteLine(articleTitle.FindElement(By.XPath("./div/div/div/div/div/a/span/p/span")).Text);
                }
                catch(NoSuchElementException) { }
            }

            webDriver.Quit();
        }
    }
}