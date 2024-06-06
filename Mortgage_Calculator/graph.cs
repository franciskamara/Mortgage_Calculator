using System;
namespace Mortgage_Calculator
{
	public class Graph
	{
		private DateTime _startDate;
		public DateTime StartDate
		{
			get { return _startDate; }
			set { _startDate = value; }
		}

		private DateTime _endDate;
		public DateTime EndDate
		{
			get { return _endDate; }
			set { _endDate = value; }
		}

		private List<paymentItem> PaymentItems;

	}
}

