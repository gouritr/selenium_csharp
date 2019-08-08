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
    public sealed class SignupSteps

    {
        private IWebDriver driver;
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        public SignupSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"Uesr is on SignUp Page")]
        public void GivenUesrIsOnSignUpPage()
        {
            driver = new ChromeDriver(Environment.CurrentDirectory);
            driver.Navigate().GoToUrl("http://35.207.124.2:3000");
            driver.FindElement(By.CssSelector("a[href='/signup']")).Click();
        }

        [When(@"User Enters valid credentials as below")]
        public void WhenUserEntersValidCredentialsAsBelow(Table table)
        {
            User user = table.CreateInstance<User>();
            Console.WriteLine(user.Username);
            Thread.Sleep(1000);
            SignUpPage signUpPage = new SignUpPage(driver);
            signUpPage.signUpUser(user);

        }

        private void signUpUser(User user)
        {
            throw new NotImplementedException();
        }

        [Then(@"User should be able to LoginSuccessfully")]
        public void ThenUserShouldBeAbleToLoginSuccessfully()
        {
            //div.alert-success
            string successMsg = driver.FindElement(By.CssSelector("div.alert-success")).Text;
            //Assert.That(successMsg,Text.Contains("You signed up successfully. Welcome!"));
            StringAssert.Contains("You signed up successfully. Welcome!",successMsg);
        }

        [Given(@"User is on SignUp page")]
        public void GivenUserIsOnSignUpPage()
        {
            driver = new ChromeDriver(Environment.CurrentDirectory);
            driver.Navigate().GoToUrl("http://35.207.124.2:3000");
            driver.FindElement(By.CssSelector("a[href='/signup']")).Click();
        }

        [When(@"User tries to signwith Blank fields")]
        public void WhenUserTriesToSignwithBlankFields(Table table)
        {
            User user = table.CreateInstance<User>();
            SignUpPage signUpPage = new SignUpPage(driver);
            signUpPage.signUpUser(user);

        }


        [Then(@"User should not be able to SignUp Successfully with msg (.*)")]
        public void ThenUserShouldNotBeAbleToSignUpSuccessfully_(string expectedMsg)
        {
            string msg = driver.FindElement(By.CssSelector("span.help-block")).Text;
            StringAssert.AreEqualIgnoringCase(expectedMsg, msg);
        }

    }

    class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
 
    }
}
