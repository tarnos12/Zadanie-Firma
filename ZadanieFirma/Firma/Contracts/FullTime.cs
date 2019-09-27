using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieFirma.Firma.Contracts
{
    class FullTime : Contract
    {
        public FullTime(int monthlySalary = 3500, int overtime = 0) : base(monthlySalary)
        {
            MonthlySalary = monthlySalary;
            Overtime = overtime;
        }

        public override int Salary()
        {
            return MonthlySalary + (Overtime * (MonthlySalary / 60));
        }
    }
}
