
using System;

namespace ProyectoFDP
{
   
    public static class ModuloRecuperacion
    {
        public static char CodigoTexto(int codigo)
        {
            if (codigo == 0) 
            { 
               return ' ';  
            }
                

            if (codigo == 27)
            { 
                return 'Ñ';
            }

            return (char)('A' + codigo - 1);
        }

        public static string MatricesTexto(int[,] matrices) { 

        string texto = "";
        int cantidadFilas = matrices.GetLength(0); // cantidad de filas de la matriz

        for (int fila = 0; fila < cantidadFilas; fila++)
        {
            for (int columna = 0; columna < 3; columna++)
            {
                int codigo = matrices[fila, columna];
                char letra = CodigoTexto(codigo);
                texto = texto + letra;
            }
         }

    return texto;}



        public static int[] UnirMatrices(int[,] matrices)
{
    int cantidadFilas = matrices.GetLength(0);
    int totalNumeros = cantidadFilas * 3;

    int[] criptograma = new int[totalNumeros];
    int posicion = 0;

    for (int fila = 0; fila < cantidadFilas; fila++)
    {
        for (int columna = 0; columna < 3; columna++)
        {
            criptograma[posicion] = matrices[fila, columna];
            posicion = posicion + 1;
        }
    }

    return criptograma;
}
    }
}
