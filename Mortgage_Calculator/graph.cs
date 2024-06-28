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
            if (paymentItems != null)
            {
                _paymentItems.AddRange(_paymentItems);
            }
        }

        public static void RemainingAmountDisplay(PaymentItem pi)//Display the Total amount
        {
            double amount = pi.RemainingAmount;
            Console.WriteLine($"Remaining mortgage amount: {amount}");
        }

        public void GraphDisplay()
        {
            foreach (var item in PaymentItems)
            {
                Console.WriteLine($"Date: {item.Year.AddMonths}, Amount: {item.Amount}");
            }
        }

        public void ThreePercentWarningIndicator(PaymentItem item)
        {
            Console.WriteLine(item.WarningIndicator);
        }


    }
}



