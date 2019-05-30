using Microsoft.EntityFrameworkCore;
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
        static void Main(string[] args)
        {
            Console.Write("Escribe la ruta final donde quiere que se imprima el archivo: ");
            string filePath = Console.ReadLine();

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            TssFileGeneration(filePath);
        }

        public static void ApapFileGeneration(string path)
        {
            using (StreamWriter file = File.CreateText($@"{path}\arhivo.txt"))
            {
                using (var context = new FileGenerationContext())
                {
                    Institution foudInstitution = context.Institutions.Include(institution => institution.Employees)
                        .FirstOrDefault(institution => institution.Id == 1);

                    file.WriteLine("#Encabezado");
                    file.WriteLine($"M,{foudInstitution.PaymentDate:MMyyyy},{foudInstitution.TransmitionDate:ddMMyyyy}," +
                        $"{foudInstitution.RNC},{foudInstitution.Employees.Count}");
                    file.WriteLine("#Detalle");
                    foreach (Employee employee in foudInstitution.Employees)
                    {
                        file.WriteLine($"{employee.Identification},{employee.CotizableSalary},{employee.VoluntaryAport},{employee.OtherRemuneration}," +
                                       $"{employee.OtherRemuneration},{employee.InfotepSalary},{employee.ISRSalary}");
                    }
                    file.WriteLine("#Sumario");
                    file.WriteLine($"{foudInstitution.Employees.Count}");
                }

            }

            File.Move($@"{path}\arhivo.txt", $@"D:\Dummy-files\{Guid.NewGuid()}.txt");
            File.Delete($@"{path}\arhivo.txt");

            Console.WriteLine("El archivo fue generado con exito");

            Console.ReadLine();
        }

        public static void TssFileGeneration(string path)
        {
            using (StreamWriter file = File.CreateText($@"{path}\archivoTss.txt"))
            {
                using (var context = new FileGenerationContext())
                {
                    HardwareStore foundStore = context.HardwareStores.Include(store => store.Employees)
                        .FirstOrDefault(store => store.Id == 1);

                    file.WriteLine("#Encabezado");
                    file.WriteLine($"{foundStore.FileType},{foundStore.Period},{foundStore.TransmitionDate}," +
                        $"{foundStore.RNC},{foundStore.TotalTransactions}");
                    file.WriteLine("#Detalle");
                    foreach (HardwareStoreEmployee employee in foundStore.Employees)
                    {
                        file.WriteLine($"{employee.Id},{employee.Salary},{employee.VoluntaryContribution},{employee.OthersRemunerations},{employee.InfotepSalay},{employee.IsrSalary}");
                    }
                    file.WriteLine("#Sumario");
                    file.WriteLine($"{foundStore.Employees.Count()}");
                }

            }

            File.Move($@"{path}\arhivo.txt", $@"D:\Dummy-files\{Guid.NewGuid()}.txt");
            File.Delete($@"{path}\arhivoTss.txt");

            Console.WriteLine("El archivo fue generado con exito");

            Console.ReadLine();
        }
    }
}
