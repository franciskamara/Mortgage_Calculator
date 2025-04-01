using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;

namespace MortgageCalculator.Selenium;

public class Tests
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://example.com");
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    // [TearDown]
    // public void Cleanup()
    // {
    //     driver.Quit(); // Close browser after tests
    // }
}