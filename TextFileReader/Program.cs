using System;
using System.IO;
using TextFileReader.Data;

namespace TextFileReader
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Seleccione la de donde se procederan a leer los archivos: ");
            string route = Console.ReadLine();

            using (var fs = new FileStream(route, FileMode.Open, FileAccess.Read))
            using (StreamReader reader = new StreamReader(fs))
            {
                var tf = new Transformator();

                Archivo archivo =  tf.Transform(reader);
                archivo.FileName = fs.Name;
                var context = new FileReaderContext();

                context.Archivos.Add(archivo);
                context.SaveChanges();

                PrintInvoice(archivo);
            }

            Console.ReadLine();
        }

        private static void PrintInvoice(Archivo archivo)
        {
            Console.WriteLine("".PadRight(40, '='));
            Console.WriteLine($"RNC: {archivo.RNC}");
            Console.WriteLine($"Monto a pagar: {archivo.Roster:C0}");
            Console.WriteLine($"Fecha de pago: {archivo.PaymentDate:F}");
            Console.WriteLine("");
            Console.WriteLine("Detalle:");

            Console.WriteLine("".PadRight(40, '='));
            Console.WriteLine($"No. Cuenta\tMonto a pagar ");
            Console.WriteLine("".PadRight(40, '='));
            foreach (var detail in archivo.FileDetail)
            {
                Console.WriteLine($"{detail.AccountNumber}\t{detail.Salary:C0}");
            }


            Console.WriteLine("".PadRight(40, '='));
        }
    }
}
