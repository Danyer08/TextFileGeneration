using System;
using System.Collections.Generic;
using System.Text;

namespace TextFileGeneration.Entities
{
    public class Student
    {
        public string Identification { get; set; }

        public string RegistrationNumber { get; set; }

        public int CreditsQuantity { get; set; }

        public double Amount { get; set; }

        public int CurrentStudentQuarter { get; set; }
    }
}
