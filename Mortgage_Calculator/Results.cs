using System;
using System.Reflection.Metadata.Ecma335;

namespace Mortgage_Calculator
{
	public class Results
	{
		public List<PaymentItem> PaymentItems;

		public double TotalAmount
		{
			get
			{
				double sum = 0;
				foreach(var pi in PaymentItems)
				{
					sum = sum + pi.Amount;
				}

				return sum;
				//return PaymentItems.Sum(p => p.Amount);
			}
		}

		private MonthlyAmount _monthlyRepaymentAmount;
		public MonthlyAmount MonthlyRepaymentAmount
		{
			get { return _monthlyRepaymentAmount; }
			set { _monthlyRepaymentAmount = value; }
		}
	}
}

