namespace MortgageCalc.Selenium;

public class Tests
{
    private IWebDriver driver;
    private BlazorApp.Shared.MortgageCalculator _mortgageCalculator;
    private Mortgage_Calculator.UserInput _calculatorUserInput;
    
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();//Open Chrome browser 
        driver.Navigate().GoToUrl("http://localhost:5292/");//Navigate to page
        
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(300);//Wait time 
        
        var title = driver.Title;//Get page title 
        Console.WriteLine($"Page title: {title}");
    }

    [Test]
    public void ClickCalculatorButtonOnHomepage()
    {
        var clickForCalc = driver.FindElement(By.XPath("Click here to use the Calculator"));
        clickForCalc.Click();

        var calcMortgagePageTitleElement = driver.FindElement(By.Id("Mortgage Calculator"));
        Assert.Equals(calcMortgagePageTitleElement,"Mortgage Calculator");
    }
}