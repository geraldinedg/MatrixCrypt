
using System; 

namespace ProyectoFDP
{
    public static class ModuloMatematico
    {
        public static double CalcularDeterminante (double[,]a) 
        {
            double det = 
                 a[0, 0] * (a[1, 1] * a[2, 2] - a[1, 2] * a[2, 1])
                - a[0, 1] * (a[1, 0] * a[2, 2] - a[1, 2] * a[2, 0])
                + a[0, 2] * (a[1, 0] * a[2, 1] - a[1, 1] * a[2, 0]);
            return det;
        }

        public static bool VerificarInversa(double determinante)
        {
            if (  determinante==0) 
            {
                return false; //no tiene inversa

            }
            else
            {
                return true; //si tiene inversa
            }

        }

        public static double[,] CalcularMatrizInversa(double[,] a)
        {
            double det = CalcularDeterminante(a); 

            double[,] adjunta = new double[3,3];

             adjunta[0, 0] = (a[1, 1] * a[2, 2] - a[1, 2] * a[2, 1]);
            adjunta[0, 1] = -(a[0, 1] * a[2, 2] - a[0, 2] * a[2, 1]);
            adjunta[0, 2] = (a[0, 1] * a[1, 2] - a[0, 2] * a[1, 1]);
            adjunta[1, 0] = -(a[1, 0] * a[2, 2] - a[1, 2] * a[2, 0]);
            adjunta[1, 1] = (a[0, 0] * a[2, 2] - a[0, 2] * a[2, 0]);
            adjunta[1, 2] = -(a[0, 0] * a[1, 2] - a[0, 2] * a[1, 0]);
            adjunta[2, 0] = (a[1, 0] * a[2, 1] - a[1, 1] * a[2, 0]);
            adjunta[2, 1] = -(a[0, 0] * a[2, 1] - a[0, 1] * a[2, 0]);
            adjunta[2, 2] = (a[0, 0] * a[1, 1] - a[0, 1] * a[1, 0]);

            double[,]aInversa = new double[3,3] ;

            for (int i = 0; i< 3;i++)
            {
                    for (int j=0; j<3; j++)
                {
                    aInversa[i,j] = adjunta[i,j] / det;
                }
            
            }
            return aInversa;
        }

        public static double [] MultiplicarMatrices(double[] x, double[,] A)
        {
            double[] y = new double[3];

            for(int j = 0; j < 3; j++)
            {
                double suma = 0; 

                for (int k =0; k<3; k++)
                {
                    suma += x[k] * A[k,j];
                }
                y[j] = suma;
            }
            return y;
        }
    }
}
