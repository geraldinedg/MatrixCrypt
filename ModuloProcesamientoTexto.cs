using System; 

namespace ProyectoFDP
{
    public static class ModuloProcesamientoTexto
    {
        public static int TextoCodigo(char c) //Funcion que convierte las letras a codigo
        {
            c= char.ToUpper(c); //convertir letras en mayuscula 

            if (c==' ')
            { 
            return 0;
            }

            if ( c=='Ñ')
            { 
            return 27; 
            } 

            return (c-'A' + 1);  //Posiciona la letra en su numero de la tabla de codigos

        }

        public static int[] TextoMatriz (string mensaje) 
        {
            int n=mensaje.Length;
            int [] matriz = new int[mensaje.Length];

            for (int i = 0; i<n; i++) 
            {
                matriz[i] = TextoCodigo(mensaje[i]);
            }

            return matriz;
        }

        

        public static int[] CompletarCeros(int[] Matriz) 
        {
            int [] MatrizCompleta;
            int Resto = Matriz.Length % 3; 
            if (Resto==0) 
             {   
                 MatrizCompleta= Matriz;
             } 
            else 
            {
               int faltantes=3 - Resto; 
               int nuevotamano = Matriz.Length  + faltantes; 
               MatrizCompleta = new int [nuevotamano];

               for (int i=0; i <Matriz.Length; i++)
               {
                MatrizCompleta[i]=Matriz[i];
               }     
            }
            return MatrizCompleta;
        }

      public static int[,] AgrupacionMatriz(int[] MatrizCompleta)
{
    int cantidadFilas = MatrizCompleta.Length / 3;
    int[,] Matrices = new int[cantidadFilas, 3];

    int posicion = 0;

    for (int fila = 0; fila < cantidadFilas; fila++)
    {
        for (int columna = 0; columna < 3; columna++)
        {
            Matrices[fila, columna] = MatrizCompleta[posicion];
            posicion = posicion + 1;
        }
    }

    return Matrices;
}
    }
}
