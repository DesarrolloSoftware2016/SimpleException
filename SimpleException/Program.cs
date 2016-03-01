using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Agregar la directiva para la utilización de diccionarios
using System.Collections;

namespace SimpleException
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Manejo Simple de Excepciones *****");
            Console.WriteLine("=> ¡Creando un vehículo y acelerarlo a fondo!");

            Vehiculo miVehiculo = new Vehiculo("cucarachita", 20);
            miVehiculo.UtilizarRadio(true);

            try
            {
                for (int i = 0; i < 10; i++)
                    miVehiculo.Acelerar(10);
            }
            catch (Exception e)
            {
                Console.WriteLine("\n*** ¡Error! ***");
                Console.WriteLine("Método: {0}", e.TargetSite);
                Console.WriteLine("Mensaje: {0}", e.Message);
                Console.WriteLine("Fuente: {0}", e.Source);
                Console.WriteLine("Para mayor soporte visite: {0}", e.HelpLink);

                // Mostrar el rastro de ejecución del programa
                Console.WriteLine("Stacktrace: {0}", e.StackTrace);

                // Por defecto, Data (Diccionario) es null, por lo tanto verificarlo.
                if (e.Data != null)
                {
                    foreach (DictionaryEntry de in e.Data)
                        Console.WriteLine("-> {0}: {1}", de.Key, de.Value);
                }
            }

            Console.WriteLine("\n***** Fuera de la lógica de la excepción *****");
            Console.ReadLine();
        }
    }
}
