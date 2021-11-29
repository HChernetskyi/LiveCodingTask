using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;

namespace LiveCodingTask
{
    public class Tests
    {
        /* Write test to find all links on the page. Check that there is no links with spaces at the beginning. */
        /* <a> Some text</a>  - bad link */
        /* <a>Some text</a>  - good link */
        string linkToNavigate = "some link to navigate...";
        string linkText = "Some text";
        string driverPath = "some driver path...";
        [Test, Description("Check for a link with space at the beginning")]
        public void FindLink()
        {
            WebDriver driver = new ChromeDriver(driverPath);
            driver.Navigate().GoToUrl(linkToNavigate);
            WebElement webElement = (WebElement)driver.FindElement(By.PartialLinkText(linkText));
            string result = webElement.Text;
            driver.Quit();
            Assert.AreNotEqual(" ", result[0], "There is a link with space at the beginning.");
        }
        [Test, Description("Check for links with space(s) at the beginning")]
        public void FindLinks()
        {
            WebDriver driver = new ChromeDriver(driverPath);
            int countOfSpacedLinks = 0;
            driver.Url = linkToNavigate;
            List<IWebElement> listOfSpecifiedLinkElements = driver.FindElements(By.PartialLinkText(linkText)).ToList();
            foreach (var elementOfList in listOfSpecifiedLinkElements)
            {
                if (elementOfList.Text[0] == ' ')
                {
                    countOfSpacedLinks++;
                }
            }
            driver.Quit();
            Assert.AreEqual(0, countOfSpacedLinks, "There are links with space(s) at the begining.");
        }
    }
}