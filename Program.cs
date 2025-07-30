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
            Console.WriteLine("Etapa 4: Manejo de errores en tareas asincrónicas\n");

            // Crea una lista de tareas simulando descargas
            var tareas = new[]
            {
                SimularDescargaConError("archivo7.zip"),
                SimularDescargaConError("fallido.zip"), // Ésta lanzará un error
                SimularDescargaConError("archivo8.zip")
            };

            try
            {
                // Espera a que todas las tareas terminen
                // Si alguna lanza excepción, se captura abajo
                await Task.WhenAll(tareas);
            }
            catch (Exception ex)
            {
                // Captura la excepción general
                Console.WriteLine($"\n❌ Se produjo un error durante las descargas: {ex.Message}");

                Console.ReadKey();
            }

            // Mensaje final (se ejecuta incluso si hubo errores)
            Console.WriteLine("\nProceso de descargas finalizado (con o sin errores).");

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

        // Simula una descarga, pero lanza excepción si el nombre es "fallido.zip"
        static async Task SimularDescargaConError(string nombreArchivo)
        {
            Console.WriteLine($"Iniciando descarga de {nombreArchivo}...");

            await Task.Delay(1000); // Simula descarga por 1 segundo

            if (nombreArchivo == "fallido.zip")
            {
                // Simula un error
                throw new Exception($"Error al descargar {nombreArchivo}");
            }

            Console.WriteLine($"{nombreArchivo} descargado correctamente.");
        }
    }
}
