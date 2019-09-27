using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZadanieFirma.Firma.Contracts;

namespace ZadanieFirma.Firma
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Contract Contract { get; set; }

        public Employee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Contract = new Intership();
        }
        
        public void ChangeContract(Contract contract)
        {
            Contract = contract;
        }

        public int Salary()
        {
            return Contract.Salary();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {Salary()}";
        }

    }
}
