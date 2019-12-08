using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using selenium_csharp.pageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace selenium_csharp.stepDefinitions
{
    [Binding]
    public class WeatherSearchSteps
    {
        private IWebDriver driver;
        WeatherDisplayPage weatherDisplayPage;
        String chosenHour,humidityForCurrent,humidityForTomorrow;
       
        [Given(@"user has selected a location '(.*)'")]
        public void user_has_selected_a_location(String location)
        {
            driver = new ChromeDriver(Environment.CurrentDirectory);
            driver.Navigate().GoToUrl("https://www.metoffice.gov.uk/");
            weatherDisplayPage = new WeatherDisplayPage(driver);
            weatherDisplayPage.searchLocation(location);
            weatherDisplayPage.clickInSuggestedList(location);
        }

        [When("user has chosen time next (.*) hour from now")]
        public void user_has_chosen_time_next_hour_from_now(int hour)
        {
            chosenHour = weatherDisplayPage.getAllDisplayedTime(0)[hour];
            humidityForCurrent = weatherDisplayPage.getHumidityForDay(0)[chosenHour];
            Console.WriteLine(humidityForCurrent);
              
        }

        [Then("the humidity for next day for the same chosen hour")]
        public void ThenTheResultShouldBe()
        {
            humidityForTomorrow = weatherDisplayPage.getHumidityForDay(1)[chosenHour];
            Console.WriteLine(humidityForTomorrow);
            Console.WriteLine("Difference ");
            Console.WriteLine(Int32.Parse(humidityForCurrent) - Int32.Parse(humidityForTomorrow)) ;
        }


    }
}
