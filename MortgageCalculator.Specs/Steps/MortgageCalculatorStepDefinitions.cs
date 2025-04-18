﻿using BlazorApp.Shared;
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


    // Loan input validation 
    [Given("page object is initialized")] //Initialise program
    public void GivenPageObjectIsInitialized()
    {
        _mortgageCalculator =
            (BlazorApp.Shared.MortgageCalculator)Activator.CreateInstance(typeof(BlazorApp.Shared.MortgageCalculator));
        _calculatorUserInput = _mortgageCalculator.userInput;
        // Verify the object is initialized successfully
        if (_mortgageCalculator == null)
        {
            throw new InvalidOperationException("Failed to initialize MortgageCalculator object.");
        }

        Console.WriteLine("MortgageCalculator object initialized successfully.");
    }

    [When(@"the loan amount input is (.*)")] //Loan amount input 
    public void WhenTheLoanAmountInputIs(int amount)
    {
        _calculatorUserInput.Amount = amount;

        Console.WriteLine($"The Loam amount is: {amount}");
    }

    [When(@"the term input is (.*)")] //Term input 
    public void WhenTheTermInputIs(int termInput)
    {
        _calculatorUserInput.Term = termInput;

        Console.WriteLine($"Term input is {termInput}");
    }

    [When(@"the type is (.*)")] //Mortgage Type selection 
    public void WhenTheTypeIs(string type)
    {
        if (string.IsNullOrWhiteSpace(type))
        {
            throw new ArgumentException("The type parameter cannot be null or empty.");
        }

        switch (type.ToLower())
        {
            case "none":
                _calculatorUserInput.Type = MortgageType.None;
                break;

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

    [When("the interest rate is (.*)")] //Interest Rate input 
    public void WhenTheInterestRateIs(double intRate)
    {
        _calculatorUserInput.InterestRatePercentage = intRate;
        Console.WriteLine($"The interest rate is: {intRate}");
    }

    [When(@"the deposit amount is (.*)")] //Deposit input 
    public void WhenTheDepositAmountIs(int depAmount)
    {
        _calculatorUserInput.Deposit = depAmount;
        Console.WriteLine($"Deposit amount is {depAmount}");
    }

    //Process outputs
    [Then(@"the error message contains (.*)")] //Result: Error message display
    public void ThenTheErrorMessageContains(string expErrorMessage)
    {
        _mortgageCalculator.DisplayResults();
        string actualErrorMessage = _mortgageCalculator.errorMessage;
        Assert.Contains(expErrorMessage, actualErrorMessage);
    }

    [Then(@"the error message does not contain (.*)")]//Result: Negative error message
    public void ThenTheErrorMessageDoesNotContain(string expErrorMessage)
    {
        _mortgageCalculator.DisplayResults();
        string actualErrorMessage = _mortgageCalculator.errorMessage;
        Assert.DoesNotContain(expErrorMessage, actualErrorMessage);
    }
    
    [Then(@"the system displays for Mortgage Type (.+)")] //Result: Mortgage Type selection
    public void ThenTheSystemDisplaysForMortgageType(string expectedAction)
    {
        _mortgageCalculator.DisplayResults();
        string actualAction = string.Empty;

        switch (_calculatorUserInput.Type)
        {
            case MortgageType.None:
                actualAction = _mortgageCalculator.errorMessage; //Invalid selection, error message
                break;

            case MortgageType.Standard:
            case MortgageType.Interest_Only:
                actualAction = "valid"; //Valid selection
                break;
        }
        Assert.Contains(expectedAction, actualAction);
    }

    //Results outputs
    [Then(@"the results object contains (.*) paymentItems")]
    public void ThenTheResultsObjectContainsPaymentItems(int expNoOfItems)
    {
        Results result = LogicMethod.CalculateRepayments(_calculatorUserInput, _calculatorUserInput.Type);
        int actualPaymentItemsCount = result.PaymentItems.Count;
        Assert.Equal(expNoOfItems, actualPaymentItemsCount);
    }
    

    [Then(@"the results object contains (.*) for the final paymentItem")]
    public void ThenTheResultsObjectContainsForTheFinalPaymentItem(double expFinalAmount)
    {
        Results result = LogicMethod.CalculateRepayments(_calculatorUserInput, _calculatorUserInput.Type);
        double actualFinalPaymentItemAmount = result.PaymentItems.Last().RemainingAmount;
        Assert.Equal(expFinalAmount, actualFinalPaymentItemAmount);
    }

    [Then(@"the results object contains total amount (.*)")]
    public void ThenTheResultsObjectContainsTotalAmount(double expTotalAmount)
    {
        Results result = LogicMethod.CalculateRepayments(_calculatorUserInput, _calculatorUserInput.Type);
        double actualTotalAmount = result.TotalAmount;
        Assert.Equal(expTotalAmount, actualTotalAmount);
    }

    [Then(@"the results object contains (.*) repayment months")]
    public void ThenTheResultsObjectContainsRepaymentMonths(int expRepayMonthsCount)
    {
        Results result = LogicMethod.CalculateRepayments(_calculatorUserInput, _calculatorUserInput.Type);
        int actualRepayMonthsCount = result.MonthlyRepayments.Count;
        Assert.Equal(expRepayMonthsCount, actualRepayMonthsCount);
    }

}