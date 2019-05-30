using System;
using System.IO;
using TextFileReader.Data;

namespace TextFileReader
{

    class Program
    {
        static void Main(string[] args)
        {
                    RunFileWatcher();
        }

        private static void PrintInvoice(Archivo archivo)
        {
            Console.WriteLine("".PadRight(70, '='));
            Console.WriteLine($"RNC: {archivo.RNC}");
            Console.WriteLine($"Monto a pagar: {archivo.EmployeeQuantity}");
            Console.WriteLine($"Fecha de pago: {archivo.TransmissionDate:F}");
            Console.WriteLine("");
            Console.WriteLine("Detalle:");

            Console.WriteLine("".PadRight(70, '='));
            Console.WriteLine($"Cedula \tMonto Infotep\t Monto cotizable\t Salario ISR ");
            Console.WriteLine("".PadRight(40, '='));
            foreach (var detail in archivo.FileDetail)
            {
                Console.WriteLine($"{detail.Identification}\t{detail.InfotepSalary:C0}\t {detail.CotizableSalary:C0}\t {detail.ISRSalary:C0}");
            }


            Console.WriteLine("".PadRight(70, '='));
        }

        private static void  RunFileWatcher()
        {
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = @"D:\Dummy-files\";

                watcher.NotifyFilter = NotifyFilters.LastAccess
                                       | NotifyFilters.LastWrite
                                       | NotifyFilters.FileName
                                       | NotifyFilters.DirectoryName;

                watcher.Filter = "*.json";

                watcher.Created += OnChangedJson;

                watcher.EnableRaisingEvents = true;


                Console.WriteLine("Presione 'q' para salir");
                while (Console.Read() != 'q') ;
            }
        }

        private static void OnChangedJson(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
            string rawJson = File.ReadAllText(e.FullPath);
            var tf = new Transformator();
           InterExchange   interExchange =  tf.TransformExchange(rawJson);
            var context = new FileReaderContext();

            context.InterExchanges.Add(interExchange);
            context.SaveChanges();

            PrintInterExchange(interExchange);
        }

        private static void PrintInterExchange(InterExchange interExchange)
        {
            Console.WriteLine("".PadRight(70, '='));
            Console.WriteLine($"Periodo: {interExchange.Period}");
            Console.WriteLine($"Cantidad de creditos: {interExchange.CreditsQuantity}");
            Console.WriteLine($"Fecha de transmision: {interExchange.TransmissionDate:F}");
            Console.WriteLine("");
            Console.WriteLine("Estudiantes:");

            Console.WriteLine("".PadRight(70, '='));
            Console.WriteLine($"Cedula \tMatricula\t Monto\t Cantidad de creditos ");
            Console.WriteLine("".PadRight(70, '='));
            foreach (var detail in interExchange.Students)
            {
                Console.WriteLine($"{detail.Identification}\t{detail.RegistrationNumber}\t {detail.Amount:C0}\t {detail.CreditsQuantity:C0}");
            }
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");

            using (var fs = new FileStream(e.FullPath, FileMode.Open, FileAccess.Read))
            using (StreamReader reader = new StreamReader(fs))
            {
                var tf = new Transformator();

                Archivo archivo = tf.Transform(reader);
                archivo.FileName = fs.Name;
                var context = new FileReaderContext();

                context.Archivos.Add(archivo);
                context.SaveChanges();

                PrintInvoice(archivo);
            }

        }
    }
}
