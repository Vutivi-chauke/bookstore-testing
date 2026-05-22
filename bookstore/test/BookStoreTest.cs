using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace test;

public class GoogleTestSearch
{
    [Test]
    public void UserJourney()
    {
        IWebDriver driver = InitialiseWebDriver(); 

        OpenGoogleSearchPage(driver); 
        EnterSearchText(driver, "Selenium"); 
        ClickSearchButton(driver); 
        ViewSearchResultsPage(driver, "Selenium"); 

        driver.Quit(); 
    }

    private static IWebDriver InitialiseWebDriver()
    {
        IWebDriver driver = new ChromeDriver(); 
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500); 
        return driver;
    }

    private static void OpenBookStore(IWebDriver driver)
    {
        driver.Navigate().GoToUrl("automationbookstore.dev"); 
        var title = driver.Title; 
        Assert.That(title, Is.EqualTo("Automation Bookstore")); 
    }

    
}