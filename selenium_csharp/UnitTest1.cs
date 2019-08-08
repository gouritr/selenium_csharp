using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Tests
{
    public class Tests
    { private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
         driver = new ChromeDriver(Environment.CurrentDirectory);
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://www.google.com/intl/en-GB/gmail/about/#");

            driver.FindElement(By.CssSelector("a[title='Create an account']")).Click();

            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;
            driver.SwitchTo().Window(windowHandles[1]);
            driver.FindElement(By.CssSelector("#firstName")).SendKeys("Gouri");
            Thread.Sleep(2000);

        }

        [TearDown]
        public void TearDown()
        {
            //driver.Quit();
        }
    }
}