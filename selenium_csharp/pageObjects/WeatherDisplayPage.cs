using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using selenium_csharp.stepDefinitions;
using selenium_csharp.Uitls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace selenium_csharp.pageObjects
{
    public class WeatherDisplayPage
    {
        private IWebDriver _driver;
        By searchInput = By.CssSelector("#location-search-input");
        By suggestedResultsList = By.CssSelector("#suggested-results");
        By suggestedResultsListItem = By.CssSelector("#suggested-results>li");
        By day0HeaderTable = By.XPath("//div[@aria-labelledby='day0Header']");
        By day1HeaderTable = By.XPath("//div[@aria-labelledby='day1Header']");

        private By closeBtnLocator = By.XPath("//button[text()='Close']");

        public WeatherDisplayPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void searchLocation(String location)
        {
            _driver.FindElement(searchInput).SendKeys(location);
        }

        public void clickInSuggestedList(String text)
        {
            //Helper.WaitAndFindElement(_driver, suggestedResultsList, 15);
            _driver.FindElement(suggestedResultsListItem, 15);
            var elements = _driver.FindElement(suggestedResultsList).FindElements(By.CssSelector("li"));
            var suggestedSearches = (from element in elements select element.GetAttribute("data-name")).ToList();
            int index = suggestedSearches.FindIndex(item => item == text);
            _driver.FindElement(suggestedResultsList).FindElements(By.CssSelector("li"))[index].Click();
        }

        public List<String> getAllDisplayedTime(int day)
        {

            var tableHeaders =
                _driver.FindElements(By.XPath("//div[@aria-labelledby='day" + day + "Header']//th[@scope='col']"));
            List<String> displayedTimes = (from element in tableHeaders select element.Text.Trim()).ToList();
            return displayedTimes;
        }

        public Dictionary<String, String> getHumidityForDay(int day)
        {
            var humidityelements = _driver.FindElements(By.XPath(
                "//div[@aria-labelledby='day" + day + "Header']" +
                "//tr[contains(@class,'step-humidity')]//span[@class='humidity']"));
            var humidityValues = (from element in humidityelements select element.GetAttribute("data-value")).ToList();
            var timesDisplayed = this.getAllDisplayedTime(day);
            return timesDisplayed.ToDictionary(x => x, x => humidityValues[timesDisplayed.IndexOf(x)]);
        }
    }
}