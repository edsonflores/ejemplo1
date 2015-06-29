using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using SeleniumCalculatorTest;

namespace SeleniumTests
{
    [TestFixture]
    public class CalcTest
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com.bo/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test, TestCaseSource("GetDataFromCSV")]
        public void TheCalcTest(string operation, string answer)
        {
            driver.Navigate().GoToUrl(baseURL + "/search?q=0%2B0&ie=utf-8&oe=utf-8"); //Abrir el navegador
            foreach(char c in operation)
            {
                #region SearchSymbol
                switch (c)
                {
                    case '0':
                        driver.FindElement(By.XPath("//div[@id='cwbt43']/div/span")).Click();
                        break;
                    case '1':
                        driver.FindElement(By.XPath("//div[@id='cwbt33']/div/span")).Click();
                        break;
                    case '2':
                        driver.FindElement(By.XPath("//div[@id='cwbt34']/div/span")).Click();
                        break;
                    case '3':
                        driver.FindElement(By.XPath("//div[@id='cwbt35']/div/span")).Click();
                        break;
                    case '4':
                        driver.FindElement(By.XPath("//div[@id='cwbt23']/div/span")).Click();
                        break;
                    case '5':
                        driver.FindElement(By.XPath("//div[@id='cwbt24']/div/span")).Click();
                        break;
                    case '6':
                        driver.FindElement(By.XPath("//div[@id='cwbt25']/div/span")).Click();
                        break;
                    case '7':
                        driver.FindElement(By.XPath("//div[@id='cwbt13']/div/span")).Click();
                        break;
                    case '8':
                        driver.FindElement(By.XPath("//div[@id='cwbt14']/div/span")).Click();
                        break;
                    case '9':
                        driver.FindElement(By.XPath("//div[@id='cwbt15']/div/span")).Click();
                        break;
                    case '+':
                        driver.FindElement(By.XPath("//div[@id='cwbt46']/div/span")).Click();
                        break;
                    case '-':
                        driver.FindElement(By.XPath("//div[@id='cwbt36']/div/span")).Click();
                        break;
                    case '*':
                        driver.FindElement(By.XPath("//div[@id='cwbt26']/div/span")).Click();
                        break;
                    case '/':
                        driver.FindElement(By.XPath("//div[@id='cwbt16']/div/span")).Click();
                        break;
                    case '(':
                        driver.FindElement(By.XPath("//div[@id='cwbt03']/div/span")).Click();
                        break;
                    case ')':
                        driver.FindElement(By.XPath("//div[@id='cwbt04']/div/span")).Click();
                        break;
                    case '!':
                        driver.FindElement(By.XPath("//div[@id='cwbt02']/div/span")).Click();
                        break;
                    case '.':
                        driver.FindElement(By.XPath("//div[@id='cwbt44']/div/span")).Click();
                        break;
                    case '%':
                        driver.FindElement(By.XPath("//div[@id='cwbt05']/div/span")).Click();
                        break;
                    case '^':
                        driver.FindElement(By.XPath("//div[@id='cwbt42']/div/span")).Click();
                        break;
                    case 'π':
                        driver.FindElement(By.XPath("//div[@id='cwbt20']/div/span")).Click();
                        break;
                    case '√':
                        driver.FindElement(By.XPath("//div[@id='cwbt32']/div/span")).Click();
                        break;

                    default:
                        driver.FindElement(By.XPath("//div[@id='cwbt06']/div/span")).Click();
                        break;
                    

                } 
                #endregion
            }
            driver.FindElement(By.XPath("//div[@id='cwbt45']/div/span")).Click(); // Click en el boton =
            string res = driver.FindElement(By.XPath("//div[@id='cwtltblr']/div/span")).Text; // Obtener valor de la caja de texto del resultado
            Assert.AreEqual(answer, res); 

        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() 
        {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
        //Load data from a Csv File
        private IEnumerable<string[]> GetDataFromCSV()
        {
            CsvReader reader = new CsvReader("dataTestSet.csv");
            while (reader.Next())
            {
                string operation = reader[0];
                string res = reader[1];
                yield return new string[] { operation, res };
            }
        }
    }
}
