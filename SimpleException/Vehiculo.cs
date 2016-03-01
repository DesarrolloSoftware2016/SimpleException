using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleException
{
    class Vehiculo
    {
        // Constante para la velocidad máxima
        public const int velocidadMaxima = 100;
        // ¿El vehículo es funcional?
        private bool vehiculoMuerto;

        // Propiedades del vehículo
        public int VelocidadActual { get; set; }
        public string Apodo { get; set; }

        // Constructores
        public Vehiculo() { }

        public Vehiculo(string apodo, int velocidad)
        {
            VelocidadActual = velocidad;
            Apodo = apodo;
        }

        // Métodos

        public void Acelerar(int delta)
        {
            if (vehiculoMuerto)
                Console.WriteLine("{0} está fuera de servicio...", Apodo);
            else
            {
                VelocidadActual += delta;
                if (VelocidadActual > velocidadMaxima)
                {
                    VelocidadActual = 0;
                    vehiculoMuerto = true;

                    // Utilizar la palabra reservada "throw" para lanzar una excepción
                    Exception ex = new Exception(string.Format("¡{0} se está sobrecalentando!", Apodo));
                    ex.HelpLink = "http://desarrollodesoftware.edu";

                    // Añadir más información acerca del error
                    ex.Data.Add("TimeStamp", string.Format("El vehículo explotó a las {0}", DateTime.Now));
                    ex.Data.Add("Causa", "Porque no dejaste de acelerarlo...");
                    throw ex;
                }
                else
                    Console.WriteLine("=> Velocidad actual = {0}", VelocidadActual);
            }
        }

        // El vehículo "tiene un" Radio
        private Radio elRadio = new Radio();

        public void UtilizarRadio(bool estado)
        {
            // Delegar el funcionamiento al objeto interno elRadio(Radio)
            elRadio.Encender(estado);
        }
    }
}
