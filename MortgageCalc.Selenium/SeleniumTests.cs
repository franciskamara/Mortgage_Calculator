namespace MortgageCalc.Selenium;

public class Tests
{
    private IWebDriver driver;
    
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("http://localhost:5292/");
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}