using System;
using System.Reflection.Metadata.Ecma335;

namespace Mortgage_Calculator
{
    public class Results
    {
        public List<PaymentItem> _paymentItems;
        private List<PaymentItem> PaymentItems
        {
            get { return _paymentItems; }
            set { _paymentItems = value; }
        }

        private double _totalAmount;
        public double TotalAmount
        {
            get
            {
                foreach (PaymentItem pi in PaymentItems)
                {
                    _totalAmount = _totalAmount + pi.Amount;
                }
                return _totalAmount;
                // return PaymentItems.Sum(pi => pi.Amount);
                //Each payment item is added and Summed up
            }
            set { _totalAmount = value; }//Set the sum
        }

        private List<double> _monthlyRepayments;
        public List<double> MonthlyRepayments
        {
            get { return _monthlyRepayments; }
            set { _monthlyRepayments = value; }
        }
    }
}

