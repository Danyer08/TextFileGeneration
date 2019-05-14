using System;
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

            Institution institution = new Institution();
            institution.PaymentDate = DateTime.Now;
            institution.RNC = "0017894213";

            using (StreamWriter file = File.AppendText(path))
            {
                file.WriteLine(institution.AccountNumber + ",");
                file.WriteLine(institution.PaymentDate + ",");
                file.WriteLine(institution.RNC + ",");
                file.WriteLine(institution.TransmitionDate + ",");
                file.WriteLine(institution.EmployeesNumber + ",");

            }
        }
    }
}
