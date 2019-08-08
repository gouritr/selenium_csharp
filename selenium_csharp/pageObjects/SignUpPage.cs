using OpenQA.Selenium;
using selenium_csharp.stepDefinitions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace selenium_csharp.pageObjects
{
    class SignUpPage
    {
        private IWebDriver _driver;
        By modalTitleLocator = By.CssSelector("h4.modal-title");
        By UserNameInput = By.CssSelector("input[name='username']");
            By emailInput = By.CssSelector("input[name='email']");
            By passwordInput = By.CssSelector("input[name='password']");
            By passwordConfirmInput = By.CssSelector("input[name='passwordConfirmation']");
            By signUpbtn = By.XPath("//button[text()='Sign up']");
        private By closeBtnLocator = By.XPath("//button[text()='Close']");

        public SignUpPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void signUpUser(User user)
        {
            string title = _driver.FindElement(modalTitleLocator).Text;
            var Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            //driver.FindElement(By.CssSelector("input[name='username']")).SendKeys(user.Username);
            string usernameText;
            if (user.Username != "")
            {
                 usernameText = user.Username + Timestamp;
            }
            else
            {
                usernameText = user.Username;
            }
            string userEmailText;
            if (user.Email != "")
            {
                string[] parts = user.Email.Split('@');
                userEmailText = parts[0] + Timestamp + '@' + parts[1];

            }
            else
            {
                userEmailText = user.Email;
            }

            //abc@gmail.com
            //abc122323@gmail.com
            //abc , gmail.com
            _driver.FindElements(UserNameInput)[1].SendKeys(usernameText);

            _driver.FindElements(emailInput)[1].SendKeys(userEmailText);
            _driver.FindElements(passwordInput)[1].SendKeys(user.Password);
            _driver.FindElements(passwordConfirmInput)[1].SendKeys(user.PasswordConfirmation);
            _driver.FindElements(signUpbtn)[1].Click();
            Thread.Sleep(2000);
        }

        public void clickCloseBtn()
        {
            _driver.FindElement(closeBtnLocator).Click();
        }
    }
}
