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

        OpenBookStore(driver);
        EnterSearchText(driver, "Selenium");

        driver.Quit();
    }

    private static IWebDriver InitialiseWebDriver()
    {
        var options = new ChromeOptions();

        options.AddArgument("--headless");
        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-dev-shm-usage");
        options.AddArgument("--disable-gpu");
        options.AddArgument("--window-size=1920,1080");

        IWebDriver driver = new ChromeDriver(options);

        driver.Manage().Timeouts().ImplicitWait =
            TimeSpan.FromSeconds(5);

        return driver;
    }

    private static void OpenBookStore(IWebDriver driver)
    {
        driver.Navigate().GoToUrl("https://automationbookstore.dev");

        var title = driver.Title;

        Assert.That(title,
            Is.EqualTo("Automation Bookstore"));
    }

    private static void EnterSearchText(
        IWebDriver driver,
        string text)
    {
        var searchField =
            driver.FindElement(By.Id("searchBar"));

        searchField.SendKeys(text);

        Assert.That(searchField.GetAttribute("value"),
            Is.EqualTo(text));
    }
}