using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TextFileGeneration.Data;
using TextFileGeneration.Entities;

namespace TextFileGeneration
{
    class Program
    {
        public static DataContext _context;

        public Program(DataContext context)
        {
            _context = context;
        }

        static void Main(string[] args)
        {
            string filePath = "C:/Files/EmployersList.txt";

            FileGeneration(filePath);
        }

        public static void FileGeneration(string path)
        {
            if (File.Exists(path))    
            {    
                File.Delete(path);    
            }

            Institution institution = new Institution()
            {
                AccountNumber = 1,
                PaymentDate = DateTime.Now,
                RNC = "345457234",
                TransmitionDate = DateTime.Now,
                EmployeesNumber = 19,
                TotalAmount = 113213234.123,
                Employees = new HashSet<Employee>
                {
                    new Employee
                    {
                        AccountNumber = "00145511",
                        InstitutionId = 1,
                        EmployeeCode = "EM009",
                        Salary = 11478.58,
                        Id = "00179846214"
                    },
                    new Employee
                    {
                        AccountNumber = "00145513",
                        InstitutionId = 1,
                        EmployeeCode = "EM010",
                        Salary = 11478.58,
                        Id = "00179845544"
                    }
                }
            };

            using (StreamWriter file = File.AppendText(path))
            {
                file.WriteLine("#Encabezado");
                file.WriteLine($"{institution.AccountNumber},{institution.PaymentDate},{institution.RNC}," +
                    $"{institution.TransmitionDate},{institution.TotalAmount}");
                file.WriteLine("#Detalle");
                foreach (Employee employee in institution.Employees)
                {
                    file.WriteLine($"{employee.AccountNumber},{employee.Salary},{employee.InstitutionId},{employee.EmployeeCode}");
                }
                file.WriteLine("#Sumario");
                file.WriteLine($"{institution.EmployeesNumber}");
            }
        }
    }
}
