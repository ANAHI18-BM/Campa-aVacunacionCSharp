using System;

namespace CampañaVacunacionCovid_19CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var procesador = new ProcesadorVacunas();
            procesador.EjecutarProcesamiento();

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
