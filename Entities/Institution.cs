using System;
using System.Collections.Generic;

namespace TextFileGeneration.Entities
{
    public class Institution
    {
        public int AccountNumber { get; set; }

        public DateTime PaymentDate { get; set; }

        public DateTime TransmitionDate { get; set; }

        public string RNC { get; set; }

        public int EmployeesNumber { get; set; }

        public double TotalAmount { get; set; }

        public ISet<Employee> Employees { get; set; }
    }
}
