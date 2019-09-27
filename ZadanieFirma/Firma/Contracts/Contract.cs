using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieFirma.Firma
{
    public class Contract
    {
        public int MonthlySalary;
        public int Overtime;

        public Contract() { }

        public Contract(int monthlySalary)
        {
            MonthlySalary = monthlySalary;
        }

        public virtual int Salary()
        {
            return MonthlySalary;
        }
    }
}
