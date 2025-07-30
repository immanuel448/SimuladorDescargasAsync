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
            // Título de esta etapa
            Console.WriteLine("Etapa 3: Descargas en paralelo con progreso individual\n");

            // Inicia dos tareas que simulan la descarga de archivos, mostrando el progreso de cada una
            var tarea1 = SimularDescargaConProgreso("archivo5.zip");
            var tarea2 = SimularDescargaConProgreso("archivo6.zip");

            // Espera a que ambas tareas terminen
            await Task.WhenAll(tarea1, tarea2);

            // Mensaje final cuando todas las descargas han concluido
            Console.WriteLine("\nTodas las descargas completadas.");

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

        // Método asincrónico que simula la descarga de un archivo con progreso visible
        static async Task SimularDescargaConProgreso(string nombreArchivo)
        {
            // Número de pasos para simular el progreso (por ejemplo, 5 pasos del 20%)
            int pasos = 5;

            // Tiempo de espera entre cada paso (en milisegundos)
            int esperaPorPaso = 400;

            // Bucle que simula el progreso de descarga
            for (int i = 1; i <= pasos; i++)
            {
                // Calcula el porcentaje actual
                int porcentaje = i * 100 / pasos;

                // Muestra el progreso en consola
                Console.WriteLine($"{nombreArchivo}: {porcentaje}% completado");

                // Espera un poco antes de mostrar el siguiente porcentaje
                // Esto simula que el archivo se está descargando por partes
                await Task.Delay(esperaPorPaso);
            }

            // Cuando el bucle termina, muestra mensaje de descarga finalizada
            Console.WriteLine($"{nombreArchivo} descargado.");
        }
    }
}
