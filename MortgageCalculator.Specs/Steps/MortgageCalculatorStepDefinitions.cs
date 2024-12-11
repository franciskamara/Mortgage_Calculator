using BlazorApp.Shared;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mortgage_Calculator;
using Xunit;

namespace MortgageCalculator.Specs.Steps;

[Binding]
public sealed class MortgageCalculatorStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;

    private BlazorApp.Shared.MortgageCalculator _mortgageCalculator;
    private Mortgage_Calculator.UserInput _calculatorUserInput;

    public MortgageCalculatorStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    // [Given("the first number is (.*)")]
    // public void GivenTheFirstNumberIs(int number)
    // {
    //     //TODO: implement arrange (precondition) logic
    //     // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
    //     // To use the multiline text or the table argument of the scenario,
    //     // additional string/Table parameters can be defined on the step definition
    //     // method. 
    //
    //     _scenarioContext.Pending();
    // }
    //
    // [Given("the second number is (.*)")]
    // public void GivenTheSecondNumberIs(int number)
    // {
    //     //TODO: implement arrange (precondition) logic
    //     // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
    //     // To use the multiline text or the table argument of the scenario,
    //     // additional string/Table parameters can be defined on the step definition
    //     // method. 
    //
    //     _scenarioContext.Pending();
    // }
    //
    // [When("the two numbers are added")]
    // public void WhenTheTwoNumbersAreAdded()
    // {
    //     //TODO: implement act (action) logic
    //
    //     _scenarioContext.Pending();
    // }
    //
    // [Then("the result should be (.*)")]
    // public void ThenTheResultShouldBe(int result)
    // {
    //     //TODO: implement assert (verification) logic
    //
    //     _scenarioContext.Pending();
    // }

    // Loan input validation 
    [Given("page object is initialized")]
    public void GivenPageObjectIsInitialized()
    {
        _mortgageCalculator = (BlazorApp.Shared.MortgageCalculator)Activator.CreateInstance(typeof(BlazorApp.Shared.MortgageCalculator));
        _calculatorUserInput = new();
        // Verify the object is initialized successfully
        if (_mortgageCalculator == null)
        {
            throw new InvalidOperationException("Failed to initialize MortgageCalculator object.");
        }

        Console.WriteLine("MortgageCalculator object initialized successfully.");
    }
    
    [When(@"the loan amount input is (.*)")]
    public void WhenTheLoanAmountInputIs (int amount)
    {
       
        _calculatorUserInput.Amount = amount;

    }
        
    [When(@"the deposit amount is (.*)")]
    public void WhenTheDepositAmountIs(int depAmount)
    {
        _calculatorUserInput.Deposit = depAmount;
        // _scenarioContext.Pending();
    }
        
    [Then(@"the error message contains (.*)")]
    public void ThenTheErrorMessageContains(string expectedErrorMessage)
    {
        _mortgageCalculator.DisplayResults();
        Assert.Contains(expectedErrorMessage, _mortgageCalculator.errorMessage);
        
    }
    
    [When(@"the term input is (.*)")]//Term input 
    public void WhenTheTermInputIs (int termInput)
    {
        _calculatorUserInput.Term = termInput;

        Console.WriteLine($"Term input is {termInput}");
    }
    
    [When(@"the type is (.*)")]//Mortgage Type selection 
    public void WhenTheTypeIs(string type)
    {
        if (string.IsNullOrWhiteSpace(type))
        {
            throw new ArgumentException("The type parameter cannot be null or empty.");
        }

        switch (type.ToLower())
        {
            case "standard":
                _calculatorUserInput.Type = MortgageType.Standard;
                break;

            case "interest":
                _calculatorUserInput.Type = MortgageType.Interest_Only;
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(type), $"Invalid mortgage type: {type}");
        }
    
        Console.WriteLine($"Mortgage type set to: {_calculatorUserInput.Type}");
    }
    
    [Then(@"the system displays for Mortgage Type (.+)")] //Result: Mortgage Type selection
    public void ThenTheSystemDisplaysForMortgageType(string expectedAction)
    {
        string actualAction = string.Empty;

        switch (_calculatorUserInput.Type)
        {
            case MortgageType.None:
                actualAction = "Select a valid mortgage Type."; //Invalid selection, error message
                break;

            case MortgageType.Standard:
            case MortgageType.Interest_Only:
                actualAction = "valid"; //Valid selection
                break;
        }
        
        Assert.Equal(expectedAction, actualAction);
    }

    [When("the interest rate is (.*)")]//Interest Rate input 
    public void WhenTheInterestRateIs(double intRate)
    {
        _calculatorUserInput.InterestRatePercentage = intRate;

        Console.WriteLine($"The interest rate is: {intRate}");
    }
    
    [Then(@"the error message for Interest rate (.*)")]
    public void ThenTheErrorMessageForInterestRate(string expectedErrorMessage)
    {
        _mortgageCalculator.DisplayResults();
        
        string actualErrorMessage = _mortgageCalculator.errorMessage;
        
        Assert.Contains(expectedErrorMessage, actualErrorMessage);
    }
    
    [Then(@"the error message for Deposit input displays ""(.*)""")]
    public void ThenTheErrorMessageForDepositInputDisplays(string expectedErrorMessage)
    {
        _mortgageCalculator.DisplayResults();

        string actualErrorMessage = _mortgageCalculator.errorMessage;
        
        Assert.Contains(expectedErrorMessage, actualErrorMessage);
    }
}