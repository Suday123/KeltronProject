using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCuraSelenium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://katalon-demo-cura.herokuapp.com/");

            IWebElement element = driver.FindElement(By.Id("menu-toggle"));
            element.Click();

            IWebElement link = driver.FindElement(By.LinkText("Login"));
            link.Click();

            //Login Details
            driver.FindElement(By.XPath("//input[@id='txt-username']")).SendKeys("John Doe");
            driver.FindElement(By.XPath("//input[@id='txt-password']")).SendKeys("ThisIsNotAPassword");
            driver.FindElement(By.TagName("button")).Click();

            //Appointment Selection
            driver.FindElement(By.Name("visit_date")).Click();
            driver.FindElement(By.XPath("//td[@class='day'][normalize-space()='15']")).Click();
            driver.FindElement(By.TagName("textarea")).SendKeys("Backpain");
            driver.FindElement(By.XPath("//button[@id='btn-book-appointment']")).Click();

            //Screenshot of Appointment Confirmation
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            //Directory should be adjusted accordingly
            screenshot.SaveAsFile("C:\\tmp\\screenshot.png");

            Console.WriteLine("Screenshot taken and saved as screenshot.png");

            driver.Quit();
        }
    }
}
