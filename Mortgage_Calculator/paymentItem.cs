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


	}
}
