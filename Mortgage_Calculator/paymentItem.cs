﻿using System;
namespace Mortgage_Calculator
{
	public class PaymentItem
	{
		private double _amount;
		public double Amount
		{
			get { return _amount; }
			set { _amount = value; }
		}

		private DateTime _year;
		public DateTime Year
		{
			get { return _year; }
			set { _year = value; }
		}

		private double _remainingAmount;
		public double RemainingAmount
		{
			get { return _remainingAmount; }
			set { _remainingAmount = value; }
		}

		private string _warningIndicator;
        internal static object _paymentItems;

        public string WarningIndicator
		{
			get { return _warningIndicator; }
			set { _warningIndicator = value; }
		}

        public static explicit operator PaymentItem(int v)
        {
            throw new NotImplementedException();
        }
    }
}

