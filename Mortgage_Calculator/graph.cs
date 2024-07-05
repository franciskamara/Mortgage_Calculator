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

        private List<PaymentItem> _paymentItems;
        public List<PaymentItem> PaymentItems
        {
            get { return _paymentItems; }
            set { _paymentItems = value; }
        }

        public void AddPaymentItemsToGraph(List<PaymentItem> paymentItems)
        {

            _paymentItems = paymentItems;
     //       if (paymentItems != null)
      //      {
     //           _paymentItems.AddRange(_paymentItems);
      //      }
        }

        public static void RemainingAmountDisplay(PaymentItem pi)//Display the Total amount
        {
            double amount = pi.RemainingAmount;
            Console.WriteLine($"Remaining mortgage amount: {amount}");
        }

        public void GraphDisplay()//Display graph, with Months and Amount 
        {
            foreach (var item in PaymentItems)
            {
                Console.WriteLine($"Date: {item.Year.AddMonths}, Amount: {item.Amount}");
            }
        }

        public static void ThreePercentWarningIndicator(PaymentItem item)//Display warning message of 3% increase
        {
            Console.WriteLine(item.WarningIndicator);
        }


    }
}



