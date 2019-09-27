using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieFirma.Firma.Contracts
{
    class Intership : Contract
    {
        public Intership(int monthlySalary = 1500) : base(monthlySalary)
        {
            MonthlySalary = monthlySalary;
        }

        public override int Salary()
        {
            return MonthlySalary;
        }
    }
}
