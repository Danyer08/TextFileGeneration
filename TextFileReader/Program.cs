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

        private static void  RunFileWatcher()
        {
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = @"D:\Dummy-files\";
                // Watch for changes in LastAccess and LastWrite times, and
                // the renaming of files or directories.
                watcher.NotifyFilter = NotifyFilters.LastAccess
                                       | NotifyFilters.LastWrite
                                       | NotifyFilters.FileName
                                       | NotifyFilters.DirectoryName;
                // Only watch text files.
                watcher.Filter = "*.txt";

                // Add event handlers.
                watcher.Created += OnChanged;

                // Begin watching.
                watcher.EnableRaisingEvents = true;

                // Wait for the user to quit the program.
                Console.WriteLine("Presione 'q' para salir");
                while (Console.Read() != 'q') ;
            }
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
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
