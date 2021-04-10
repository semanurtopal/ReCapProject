using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Findeks : IEntity
    {
        public int CreditProductRepayments { get; set; }
        public int CurrentAccountsAndDebts { get; set; }
        public int LoanUsageIntensity { get; set; }
        public int NewLoansTaken { get; set; }
        public int OtherFactors { get; set; }
        public int MinimumFindeksRating { get; set; }
    }
}
