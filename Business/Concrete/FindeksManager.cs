using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FindeksManager : IFindeksService
    {
        public IDataResult<int> CalculateFindeksRating()
        {
            Findeks findeks = new Findeks
            {
                CreditProductRepayments = new Random().Next(666), // 665
                CurrentAccountsAndDebts = new Random().Next(666), // 665
                LoanUsageIntensity = new Random().Next(191),      // 190
                NewLoansTaken = new Random().Next(210),           // 209
                OtherFactors = new Random().Next(172),            // 171
                                                                  // Equal to 1900 (1900 is max value of findeks rating)
            };

            int creditProductRepayments = findeks.CreditProductRepayments;
            int currentAccountsAndDebts = findeks.CurrentAccountsAndDebts;
            int loanUsageIntensity = findeks.LoanUsageIntensity;
            int newLoansTaken = findeks.NewLoansTaken;
            int otherFactors = findeks.OtherFactors;

            int findeksRating = creditProductRepayments + currentAccountsAndDebts + loanUsageIntensity + newLoansTaken + otherFactors;

            findeks.MinimumFindeksRating = findeksRating;

            return new SuccessDataResult<int>(findeksRating, Messages.FindeksRatingCalculated);
        }
    }
}
