using System.Collections.Generic;
using System;

namespace ProyectoFDP
{
    
    public static class ModuloSalida
    {
        public static void MostrarCriptograma(int[] criptograma)
        {
            Console.WriteLine("Criptograma generado: ");

            foreach (int valor in criptograma)
            {
                Console.Write(valor + " ");
            }

            Console.WriteLine();
        }

        public static void MostrarMensaje(string mensaje)
        {
            Console.WriteLine("Mensaje recuperado: " + mensaje);
        }

        public static void MostrarError(string tipoError)
        {
            Console.WriteLine("Error: " + tipoError);
        }
    }
}