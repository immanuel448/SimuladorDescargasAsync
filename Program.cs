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
            // INICIO: DESCARGAS EN SERIE
            Console.WriteLine("Inicio de descargas (en serie):");

            // Aquí se espera a que termine la primera descarga ANTES de comenzar la segunda
            await SimularDescarga("archivo1.zip");
            await SimularDescarga("archivo2.zip");

            // Ambas descargas se hacen una después de otra, no al mismo tiempo

            Console.WriteLine("\nInicio de descargas (en paralelo):");

            // Creamos las tareas SIN usar await aún.
            // Esto lanza ambas tareas "al mismo tiempo" (es decir, sin esperar una antes que otra)
            var tarea1 = SimularDescarga("archivo3.zip");
            var tarea2 = SimularDescarga("archivo4.zip");

            // Aquí esperamos a que ambas tareas terminen.
            // Si cada una tarda 2 segundos, todo esto dura alrededor de 2 segundos en total, no 4.
            await Task.WhenAll(tarea1, tarea2);

            // Este mensaje se muestra cuando ambas descargas paralelas terminan
            Console.WriteLine("Todas las descargas completadas.");
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
