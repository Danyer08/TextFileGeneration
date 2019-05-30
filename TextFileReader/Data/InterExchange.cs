﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TextFileReader.Data
{
    public sealed class InterExchange
    {
        public int Id { get; set; }

        public int CreditsQuantity { get; set; }

        public int StudentsQuantity { get; set; }

        public double TotalAmount { get; set; }

        public DateTime TransmissionDate { get; set; }

        public DateTime Period { get; set; }

        public QuarterType Year { get; set; }

        public ISet<Student> Students { get; set; }
    }
}
