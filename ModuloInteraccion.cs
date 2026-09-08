using System; 

namespace ProyectoFDP
{
    public static class ModuloInteraccion
    {
        public static void MostrarMenu()  //Funcion que muestra el menu 
        {
            Console.WriteLine("1.Encriptar mensaje"); 
            Console.WriteLine("2.Desencriptar mensaje"); 
            Console.WriteLine("3.Encriptar y desencriptar mensaje");
            Console.WriteLine("4.Salir");
        }

        public static int LeerOpcion() //Funcion que lee la opcion
        {
            
            Console.WriteLine("Ingrese una opcion (1-4)"); 
            int opcion=int.Parse(Console.ReadLine()!); 

            return opcion;
        }

        public static string MensajeEncriptar()  //Funcion para solicitar mensaje a encriptar
        {
            Console.WriteLine("Escriba el mensaje que desea encriptar");
           string mensaje=Console.ReadLine()!;

           return mensaje; 
        }


        public static int[] CriptogramaDesencriptar() //Funcion para solicitar criptograma
        {
            Console.WriteLine("Cuantos numeros tiene el Criptograma?"); 

            int cantidad=int.Parse(Console.ReadLine()); 

            int[] criptograma= new int[cantidad];  //Se crea una lista dependiendo de la cantidad de numeros

            for(int i = 0 ; i<cantidad; i++)
            {
                Console.WriteLine("Ingrese el numero" + (i+1) + ":");

                criptograma[i]=int.Parse(Console.ReadLine()!);
            }
            return criptograma;
        }

        

    }
    

}
