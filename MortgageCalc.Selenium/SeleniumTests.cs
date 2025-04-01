namespace MortgageCalc.Selenium;

public class Tests
{
    private IWebDriver driver;
    private BlazorApp.Shared.MortgageCalculator _mortgageCalculator;
    private Mortgage_Calculator.UserInput _calculatorUserInput;

    [OneTimeSetUp]
    public void Setup()
    {
        driver = new ChromeDriver(); // Open Chrome browser
        driver.Navigate().GoToUrl("http://localhost:5292/"); // Navigate to page
        
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); // Allow elements to load

        Console.WriteLine($"Page title: {driver.Title}"); // Print page title
    }

    [Test, Order(1)]
    public void ClickCalculatorButtonOnHomepage() // Click the Calculator button on Homepage
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        
        IWebElement clickForCalc = driver.FindElement(By.Id("mortCalculatorButton")); // Update with actual button ID
        clickForCalc.Click();

        // Wait for navigation 
        wait.Until(d => d.Title == "Mortgage Calculator"); 

        // Validate the page title 
        Assert.That(driver.Title, Is.EqualTo("Mortgage Calculator"), "The page title does not match.");
        Console.WriteLine($"Page title after navigation: {driver.Title}");
    }
    
    [Test, Order(2)]
    public void ClickToCalculateSingleMortgage()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

        IWebElement clickSingleMortgage = wait.Until(d => d.FindElement(By.Id("singleMortClick")));
        clickSingleMortgage.Click();
        
        Console.WriteLine("Single Mortgage button clicked.");
        
        // Check Single mortgage form is displayed
        IWebElement singleFormTitle = wait.Until(d => d.FindElement(By.Id("singleMortFormTitle")));
        Assert.IsTrue(singleFormTitle.Displayed, "Single Mortgage calculation form is not displayed.");
    }

    [Test, Order(3)]
    public void LoanAmountInput()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

        IWebElement loanAmountInput = wait.Until(d => d.FindElement(By.Id("loanInputField")));
        loanAmountInput.Click();
        loanAmountInput.Clear();
        loanAmountInput.SendKeys(250000.ToString());
        
        Console.WriteLine($"Loan amount displayed? {loanAmountInput.Text}");
        Assert.IsTrue(loanAmountInput.Displayed);
        // Assert.IsTrue(loanAmountInput.Displayed, "Loan amount not inputted.");
    }
    
    [Test, Order(4)]
    public void MortgageTermInput()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

        IWebElement mortgageTermInput = wait.Until(d => d.FindElement(By.Id("termInputField")));
        mortgageTermInput.Click();
        mortgageTermInput.Clear();
        mortgageTermInput.SendKeys(20.ToString());
        
        Assert.That(mortgageTermInput.Displayed, Is.True);
    }

    [Test, Order(5)]
    public void MortgageTypeSelect()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    
        IWebElement mortgageTypeSelect = wait.Until(d => d.FindElement(By.Id("mTypeSelect")));
        mortgageTypeSelect.Click();
        mortgageTypeSelect.SendKeys("Standard");
        mortgageTypeSelect.Click();
       
        Assert.That(mortgageTypeSelect.Displayed, Is.True);
    }

    [Test, Order(6)]
    public void MortgageInterestRateInput()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    
        IWebElement mortgageIntRate = wait.Until(d => d.FindElement(By.Id("intRateInputField")));
        mortgageIntRate.Click();
        mortgageIntRate.Clear();
        mortgageIntRate.SendKeys(6.6.ToString());
        
        Assert.That(mortgageIntRate.Displayed, Is.True);
    }
    
    // [OneTimeTearDown]
    // public void Cleanup()
    // {
    //     driver.Quit(); // Close browser after tests
    // }
    
    
}
