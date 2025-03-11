namespace MortgageCalc.Selenium;

public class Tests
{
    private IWebDriver driver;
    private BlazorApp.Shared.MortgageCalculator _mortgageCalculator;
    private Mortgage_Calculator.UserInput _calculatorUserInput;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver(); // Open Chrome browser
        driver.Navigate().GoToUrl("http://localhost:5292/"); // Navigate to page
        
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); // Allow elements to load

        Console.WriteLine($"Page title: {driver.Title}"); // Print page title
    }

    [Test]
    public void ClickCalculatorButtonOnHomepage()
    {
        var clickForCalc = driver.FindElement(By.Id("mortCalculatorButton")); // Update with actual button ID
        clickForCalc.Click();

        // Wait for navigation 
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(d => d.Title == "Mortgage Calculator"); // Page title updates

        // Validate the page title (case-sensitive check)
        Assert.That(driver.Title, Is.EqualTo("Mortgage Calculator"), "The page title does not match.");

        Console.WriteLine($"Page title after navigation: {driver.Title}");

        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }
    
    // [TearDown]
    // public void Cleanup()
    // {
    //     driver.Quit(); // Close browser after tests
    // }
}