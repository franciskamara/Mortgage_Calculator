using BlazorApp.Shared;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MortgageCalculator.Specs.Steps;

[Binding]
public sealed class MortgageCalculatorStepDefinitions
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

    private readonly ScenarioContext _scenarioContext;

    private readonly BlazorApp.Shared.MortgageCalculator _mortgageCalculator;
    private readonly Mortgage_Calculator.UserInput _calculatorUserInput;

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
    [Given("the user is on the Loan amount field")]
    public void TheUserIsOnTheLoanAmountField()
    {
        _scenarioContext.Pending();
    }
    
    [When(@"the user enters a loan amount of (.*)")]
    public void WhenTheUserEntersALoanAmountOf(int p0)
    {
        _scenarioContext.Pending();
    }
        
    [When(@"the deposit amount is (.*)")]
    public void WhenTheDepositAmountIs(int p0)
    {
        _scenarioContext.Pending();
    }
        
    [When(@"all other inputs are valid")]
    public void WhenAllOtherInputsAreValid()
    {
        _scenarioContext.Pending();
    }
    
    [Then(@"the system displays Result display")]
    public void ThenTheSystemDisplaysResultDisplay()
    {
        _scenarioContext.Pending();
    }
        
    [Then(@"the system displays errorMessage: amount input")]
    public void ThenTheSystemDisplaysErrorMessageAmountInput()
    {
        _scenarioContext.Pending();
    }
    
    [Then(@"the system displays errorMessage: Deposit has be less than Loan amount")]
    public void ThenTheSystemDisplaysErrorMessageDepositHasBeLessThanLoanAmount()
    {
        _scenarioContext.Pending();
    }
    
    [Then(@"additionally errorMessage: Deposit has be less than Loan amount")]
    public void ThenAdditionallyErrorMessageDepositHasBeLessThenLoanAmount()
    {
        _scenarioContext.Pending();
    }
    
    [Then(@"additionally none")]
    public void ThenAdditionallyNone()
    {
        _scenarioContext.Pending();
    }
    
    //Mortgage Term validation 
    [Given(@"the user is on the term field")]
    public void GivenTheUserIsOnTheTermField()
    {
        _scenarioContext.Pending();
    }
        
    [When(@"the user enters a term input of (.*)")]
    public void WhenTheUserEntersATermInputOf(int p0)
    {
        _scenarioContext.Pending();
    }
        
    [Then(@"the system displays errorMessage: Term input is needed")]
    public void ThenTheSystemDisplaysErrorMessageTermInputIsNeeded()
    {
        _scenarioContext.Pending();
    }
    
}