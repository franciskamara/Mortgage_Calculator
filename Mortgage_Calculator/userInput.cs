using System;
namespace Mortgage_Calculator
{
	public class UserInput
	{
		
		private int _amount;
		public int Amount
		{
			get { return _amount; }
			set { _amount = value; }
		}

		private int _term;
		public int Term
		{
			get { return _term; }
			set { _term = value; }
		}

		private mortgageType _type;
		public mortgageType Type
		{
			get { return _type; }
			set { _type = value; }
		}

		private double _interestRate;
		public double InterestRate
		{
			get { return _interestRate; }
			set { _interestRate = value; }
		}

		private double _deposit;
		public double Deposit
		{
			get { return _deposit; }
			set { _deposit = value; }
		}
	}
}
