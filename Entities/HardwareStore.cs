using System;
using System.Collections.Generic;
using TextFileGeneration.Enums;

namespace TextFileGeneration.Entities
{
    public class HardwareStore
    {
        public int Id { get; set; }

        public FileType FileType { get; set; }

        public DateTime Period { get; set; }

        public DateTime TransmitionDate { get; set; }

        public string RNC { get; set; }

        public int TotalTransactions { get; set; }

        public ISet<HardwareStoreEmployee> Employees { get; set; }
    }
}
