using System;
using System.Collections.Generic;

namespace TextFileReader.Data
{
    public sealed class Archivo
    {
        public int Id { get; set; }

        public string Period { get; set; }
        public char FileType { get; set; }
        public DateTime TransmissionDate { get; set; }

        public int EmployeeQuantity { get; set; }

        public string FileName { get; set; }

        public DateTime? PaymentDate { get; set; }

        public string AccountNumber { get; set; }

        public string RNC { get; set; }

        public decimal Roster { get; set; }

        public DateTime ProccesingDate { get; set; }

        public ISet<DetalleArchivo> FileDetail { get; set; } = new HashSet<DetalleArchivo>();
    }
}
