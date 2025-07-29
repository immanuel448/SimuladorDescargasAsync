// Importa los espacios de nombres necesarios
// System: funciones básicas como Console
// System.Threading.Tasks: para trabajar con Task, async y await
using System;
using System.Threading.Tasks;

namespace SimuladorDescargasAsync
{
    // Declaración de clase principal del programa
    class Program
    {
        // Método principal asincrónico del programa
        // La palabra clave 'async' permite usar 'await' dentro del método
        static async Task Main()
        {
            // Este mensaje se imprime inmediatamente al iniciar el programa
            Console.WriteLine("Inicio de la descarga...");

            // Llamamos a un método asincrónico que simula una descarga
            // El uso de 'await' indica que el programa esperará a que termine esa tarea
            await SimularDescarga("archivo1.zip");

            // Este mensaje se imprime solo después de que la descarga ha finalizado
            Console.WriteLine("Descarga finalizada.");
            Console.ReadKey();
        }

        // Método asincrónico que simula la descarga de un archivo
        // Toma como parámetro el nombre del archivo a "descargar"
        static async Task SimularDescarga(string nombreArchivo)
        {
            // Muestra mensaje de inicio de descarga
            Console.WriteLine($"Descargando {nombreArchivo}...");

            // Simula el tiempo de descarga con una espera de 2000 milisegundos (2 segundos)
            // Task.Delay es una tarea que simplemente espera sin bloquear el hilo actual
            await Task.Delay(2000);

            // Mensaje cuando la "descarga" termina
            Console.WriteLine($"{nombreArchivo} descargado.");
        }
    }
}
