using System;
using System.IO;
using TextFileReader.Data;

namespace TextFileReader
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Seleccione la de donde se procederan a leer los archivos");
            string route = Console.ReadLine();

            using (var fs = new FileStream(route, FileMode.Open, FileAccess.Read))
            using (StreamReader reader = new StreamReader(fs))
            {
                Transformator tf = new Transformator();

                Archivo archivo =  tf.Transform(reader);
                archivo.FileName = fs.Name;
                var context = new FileReaderContext();

                context.Archivos.Add(archivo);
                context.SaveChanges();
            }

            Console.WriteLine($"Archivo leido correctamente");
            Console.ReadLine();
        }

    }
}
