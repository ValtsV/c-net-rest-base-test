using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncExamples
{
    public static class CalculadoraHipotecaSync
    {
        public static int ObtenerAnyosVidaLaboral()
        {
            Console.WriteLine("\nObteniendo anyos de vida laboral....");
            Task.Delay(5000).Wait();
            return new Random().Next(1, 35);
        }

        public static bool EsTipoContratoIndefinido()
        {
            Console.WriteLine("\nVerificando si el tipo de contrato es indefinido");
            Task.Delay(5000).Wait();
            return (new Random().Next(1, 10)) % 2 == 0;
        }

        public static int ObtenerSueldoNeto()
        {
            Console.WriteLine("\nObteniendo sueldo neto...");
            Task.Delay(5000).Wait();
            return new Random().Next(800, 6000);
        }

        public static int ObtenerGastosMensuales()
        {
            Console.WriteLine("\nObteniendo gastos mensuales del usuario....");
            Task.Delay(5000).Wait();
            return new Random().Next(200, 1000);
        }

        public static bool AnalizarInformacionParaConcederHipoteca(
            int anyosVidaLaboral,
            bool tipoContratoEsIndefinido,
            int sueldoNeto,
            int gastosMensuales,
            int cantidadSolicitada,
            int anyosPagar)
        {
            Console.WriteLine("\nAnalizando informacion para conceder hipotca....");

            if(anyosVidaLaboral < 2)
            {
                return false;
            }

            var cuota = (cantidadSolicitada / anyosPagar) / 12;

            if(cuota >= sueldoNeto || cuota > (sueldoNeto / 2))
            {
                return false;
            }

            var porcentajeGastosSobreSueldo = ((gastosMensuales * 100) / sueldoNeto);

            if(porcentajeGastosSobreSueldo > 30)
            {
                return false;
            }

            if (cuota + gastosMensuales >= sueldoNeto)
            {
                return false;
            }

            if(!tipoContratoEsIndefinido)
            {
                if((cuota + gastosMensuales) > (sueldoNeto / 3))
                {
                    return false;
                } else
                {
                    return true;
                }
            }

            return true;
        }
    }
}
