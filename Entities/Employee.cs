namespace TextFileGeneration.Entities
{
    public class Employee
    {
        public string Id { get; set; }

        public string AccountNumber { get; set; }

        public double Salary { get; set; }

        public string EmployeeCode { get; set; }

        public int InstitutionId { get; set; }

        public Institution Institution { get; set; }
    }
}
