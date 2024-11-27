using BlazorApp.Shared;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MortgageCalculator.Specs.Steps;

[Binding]
public sealed class MortgageCalculatorStepDefinitions
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

    private readonly ScenarioContext _scenarioContext;

    private readonly BlazorApp.Shared.MortgageCalculator _mortgageCalculator;

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

    //Mortgage Calculator homepage
    [Given("the user is on the homepage")]
    public void TheUserIsOnTheHomepage()
    {
        _scenarioContext.Pending();
        //homepage
    }

    [When("the user clicks the button 'Click here to use the Calculator'")]
    public void TheUserClicksTheButtonClickHereToUseTheCalculator()
    {
        _scenarioContext.Pending();
    }

    [Then("the Mortgage Calculator navigation is displayed")]
    public void TheMortgageCalculatorNavigationIsDisplayed()
    {
        _scenarioContext.Pending();
    }
}