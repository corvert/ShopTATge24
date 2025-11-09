using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;



namespace SeleniumTesting
{
    internal class TestCase
    {
        private static void Main(string[] args)
        {
            TestSpaceShipAdd();
        }
        [Test]
        private static void TestSpaceShipAdd()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://localhost:7074";
            IWebElement idOfLinkElement = driver.FindElement(By.Id("spaceShip"));
            idOfLinkElement.Click();
            Thread.Sleep(1000);
            CreateTest(driver);
            Thread.Sleep(1000);
            //List<IWebElement> elementToCheck = driver.FindElements(By.TagName("td"));

            IWebElement idOfTestdata1 = driver.FindElement(By.Id("testIdName"));
            var testName = idOfTestdata1.Text;
            IWebElement idOfTestData2 = driver.FindElement(By.Id("testIdCal"));
            var testCal = idOfTestData2.Text;
            Assert.That(testName, Is.EqualTo("TestName"));
            Assert.That(testCal, Is.EqualTo("TestClassification"));
            Console.WriteLine("Test Passed");
            DetailsTest();
            //UpdateTest();
            //UpdateTestBack();
            //DeleteTest();

        }

        static void CreateTest(IWebDriver driver)
        {
         
            IWebElement idOfCreateBtn = driver.FindElement(By.Id("testIdCreate"));
            idOfCreateBtn.Click();
            Thread.Sleep(2000);
            IWebElement nameInput = driver.FindElement(By.Id("name"));
            nameInput.SendKeys("TestName");
            IWebElement classificationInput = driver.FindElement(By.Id("classification"));
            classificationInput.SendKeys("TestClassification");
            IWebElement dateInput = driver.FindElement(By.Id("buildDate"));
            dateInput.SendKeys("15/01/2024 15:33");
            IWebElement crewInput = driver.FindElement(By.Id("crew"));
            crewInput.SendKeys("150");
            IWebElement enginePowerInput = driver.FindElement(By.Id("enginePower"));
            enginePowerInput.SendKeys("5000");
            Thread.Sleep(2000);
            IWebElement createBtn = driver.FindElement(By.Id("createBtn"));
            createBtn.Click();




        }
        static void DetailsTest()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://localhost:7074";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement idOfLinkElement = driver.FindElement(By.Id("spaceShip"));

            idOfLinkElement.Click();

            IWebElement detailsBtn = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Details")));
            detailsBtn.Click();
            Thread.Sleep(2000);
            IWebElement backBtn = driver.FindElement(By.Id("backBtn"));
            backBtn.Click();


            // driver.Quit();
        }

        static void UpdateTest()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://localhost:7074";

            IWebElement idOfLinkElement = driver.FindElement(By.Id("spaceShip"));
            idOfLinkElement.Click();
            Thread.Sleep(2000);
            //driver.Navigate().Back();
            IWebElement idOfUpdateBtn = driver.FindElement(By.Id("update"));
            idOfUpdateBtn.Click();
            Thread.Sleep(2000);
            IWebElement nameInput = driver.FindElement(By.Id("name"));
            nameInput.Clear();
            nameInput.SendKeys("update name");
            IWebElement classificationInput = driver.FindElement(By.Id("classification"));
            classificationInput.Clear();
            classificationInput.SendKeys("Update Classification");
            IWebElement dateInput = driver.FindElement(By.Id("buildDate"));
            dateInput.Clear();
            dateInput.SendKeys("15/01/2025 15:33");
            IWebElement crewInput = driver.FindElement(By.Id("crew"));
            crewInput.Clear();
            crewInput.SendKeys("15");
            IWebElement enginePowerInput = driver.FindElement(By.Id("enginePower"));
            enginePowerInput.Clear();
            enginePowerInput.SendKeys("200");
            Thread.Sleep(2000);
            IWebElement createBtn = driver.FindElement(By.Id("updateBtn"));
            createBtn.Click();

        }
        static void UpdateTestBack()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://localhost:7074";

            IWebElement idOfLinkElement = driver.FindElement(By.Id("spaceShip"));
            idOfLinkElement.Click();
            Thread.Sleep(2000);
            //driver.Navigate().Back();
            IWebElement idOfUpdateBtn = driver.FindElement(By.Id("update"));
            idOfUpdateBtn.Click();
            Thread.Sleep(2000);
            IWebElement nameInput = driver.FindElement(By.Id("name"));
            nameInput.Clear();
            nameInput.SendKeys("update name");
            IWebElement classificationInput = driver.FindElement(By.Id("classification"));
            classificationInput.Clear();
            classificationInput.SendKeys("Update Classification");
            IWebElement dateInput = driver.FindElement(By.Id("buildDate"));
            dateInput.Clear();
            dateInput.SendKeys("15/01/2025 15:33");
            IWebElement crewInput = driver.FindElement(By.Id("crew"));
            crewInput.Clear();
            crewInput.SendKeys("15");
            IWebElement enginePowerInput = driver.FindElement(By.Id("enginePower"));
            enginePowerInput.Clear();
            enginePowerInput.SendKeys("200");
            Thread.Sleep(2000);
            IWebElement createBtn = driver.FindElement(By.Id("backBtn"));
            createBtn.Click();

        }


        static void DeleteTest()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://localhost:7074";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement idOfLinkElement = driver.FindElement(By.Id("spaceShip"));

            idOfLinkElement.Click();

            IWebElement deleteButton = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Delete")));
            deleteButton.Click();
            Thread.Sleep(2000);
            IWebElement pressDelete = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input[type='submit'][value='Delete']")));
            pressDelete.Click();
            
           // driver.Quit();
        }
    }
}
