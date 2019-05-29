namespace TextFileReader.Data
{
    public sealed class DetalleArchivo
    {
        public int Id { get; set; }
        public string Identification { get; set; }

        public string AccountNumber { get; set; }

        public decimal Salary { get; set; }

        public string EmployeeCode { get; set; }

        public Archivo Archivo { get; set; }

        public int ArchivoId { get; set; }

        public decimal CotizableSalary { get; set; }

        public decimal VoluntaryAport { get; set; }

        public decimal OtherRemuneration { get; set; }

        public decimal InfotepSalary { get; set; }

        public decimal ISRSalary { get; set; }
    }
}
