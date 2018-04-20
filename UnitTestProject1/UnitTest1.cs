using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Threading;
using NUnit.Framework;

     



namespace GoogleTest
{
    [TestClass]
    public class UnitTest1
    {
        static IWebDriver Browser;
        static  WebDriverWait wait;

        [SetUp]
        public void start()
        {
            Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            Browser.Manage().Window.Maximize();
            wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(10));
        }

        public bool IsElementExists(By iClassName)
        {

            try
            {
                Browser.FindElement(iClassName);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        [Test]
        public void TestMethod1()
        {
            Browser.Navigate().GoToUrl("http://localhost/litecart/admin/login.php");
            if ((IsElementExists(By.Name("username")) == true) && (IsElementExists(By.Name("password")) == true))
            {
                    IWebElement LohinInput = Browser.FindElement(By.Name("username"));
                    IWebElement PasswordInput = Browser.FindElement(By.Name("password"));
                    LohinInput.SendKeys("admin");
                    PasswordInput.SendKeys("admin1" + OpenQA.Selenium.Keys.Enter);

                    Thread.Sleep(3000);
                    if (IsElementExists(By.Id("notices")) == true)
                    {
                        IWebElement PasswordInput1 = Browser.FindElement(By.Name("password"));
                        PasswordInput1.SendKeys("admin" + OpenQA.Selenium.Keys.Enter);
                    }
                else
                {
                    throw new ArgumentException("Нет свдения об ошибки");
                }
            }
            else
            {
                throw new ArgumentException("Нет полей для ввода");
            }
        }
            

        [TearDown]
        public void stop()
        {
            Browser.Quit();
            Browser = null;
        }

    }
}
