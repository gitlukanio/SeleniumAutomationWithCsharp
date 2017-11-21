using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace SeleniumAutomationWithCsharpConsole
{
    class Program
    {
        public static IWebDriver driver;

        static void Main(string[] args)
        {
            // Create the reference for our browser
            //IWebDriver driver = new FirefoxDriver();
            Initialize();
            Execute();
            CleanUp();

        }

        public static void Initialize()
        {
            driver = new InternetExplorerDriver();
        }

        public static void Execute()
        {
            //Navigate to Google page
            driver.Navigate().GoToUrl("http://www.google.com/");
            // IWebElement webelement = driver.FindElement(By.Name("q"));
            // webelement.SendKeys("Testowe zapytanie z selenium");
            // webelement.Submit();
            SeleniumSetMethods.EnterText(driver, "q", "Jakiś tekst do wpisania", "Name");
            SeleniumSetMethods.Click(driver, "btnK", "Name");




        }

        public static void CleanUp()
        {
            Thread.Sleep(2000);
            driver.Close();
            driver.Quit();
        }



    }












    public class SeleniumSetMethods
    {


        // Enter text
        public static void EnterText(IWebDriver driver, string element, string text, string elementtype)
        {
            if (elementtype == "Id")
                driver.FindElement(By.Id(element)).SendKeys(text);
            if (elementtype == "Name")
                driver.FindElement(By.Name(element)).SendKeys(text);
        }

        // Click into a botton, checkbox option etc.
        public static void Click(IWebDriver driver, string element, string elementtype)
        {
            if (elementtype == "Id")
                driver.FindElement(By.Id(element)).Click();
            if (elementtype == "Name")
                driver.FindElement(By.Name(element)).Click();
        }

        // Selecting a drop down control
        public static void SelectDropDown(IWebDriver driver, string element, string text, string elementtype)
        {
            //SelectElement selectElement = new SelectElement();
            if (elementtype == "Id")
                new SelectElement(driver.FindElement(By.Id(element))).SelectByText(text);
            if (elementtype == "Name")
                new SelectElement(driver.FindElement(By.Name(element))).SelectByText(text);



        }




    }



}
