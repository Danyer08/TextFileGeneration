namespace TextFileGeneration.Entities
{
    public class Employee
    {
        public string Id { get; set; }

        public string AccountNumber { get; set; }

        public string Identification { get; set; }

        public double Salary { get; set; }

        public decimal CotizableSalary { get; set; }

        public decimal VoluntaryAport { get; set; }

        public decimal OtherRemuneration { get; set; }

        public decimal InfotepSalary { get; set; }

        public decimal ISRSalary { get; set; }

        public string EmployeeCode { get; set; }

        public int InstitutionId { get; set; }

        public Institution Institution { get; set; }
    }
}
