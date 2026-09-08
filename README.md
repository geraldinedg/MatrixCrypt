MatrixCrypt -- Cifrado de mensajes Hill Cipher

-Descripción
MatrixCrypt es una aplicación de escritorio que implementa el cifrado de Hill (Hill Cipher), un método de criptografía clásica basado en álgebra lineal.
El proyecto permite encriptar mensajes de texto, desencriptarlos y verificar que el proceso de ida y vuelta recupere exactamente el mensaje original.

-Lógica matemática — Álgebra lineal (matrices)

Conversión de texto a vectores numéricos, asignando un valor entero a cada carácter.
Agrupación en matrices de 3x3, sobre las que se aplican las operaciones de cifrado.
Multiplicación de matrices entre el mensaje (en forma numérica) y una matriz clave previamente definida.
Cálculo de determinante e inversa de la matriz clave, condición necesaria para poder descifrar el mensaje: la matriz clave debe ser invertible, y por eso se valida automáticamente al iniciar la aplicación.
Multiplicación por la matriz inversa para revertir el proceso y recuperar el mensaje original a partir del criptograma.

-Modularización — Diversificación de procesos

Un módulo dedicado exclusivamente a las operaciones matemáticas con matrices (determinante, inversa, multiplicación).
Un módulo para el procesamiento de texto (conversión de caracteres a números y relleno de matrices incompletas).
Un módulo de recuperación, encargado de reconstruir el texto a partir de las matrices ya descifradas.
Un módulo de interacción y otro de salida, heredados de la lógica original de consola.

Esta separación por módulos permite que la lógica matemática esté desacoplada de la interfaz gráfica, facilitando su prueba, mantenimiento y reutilización.

-Tecnologías utilizadas
C#
WPF (Windows Presentation Foundation)
.NET 10

-Funcionalidades

Inicio — pantalla de bienvenida.
Encriptar — convierte un mensaje de texto en un criptograma (secuencia de números enteros).
Desencriptar — a partir de un criptograma (números separados por espacios), recupera el mensaje original.
Verificar — encripta y desencripta un mismo mensaje en un solo paso, y confirma si el mensaje recuperado coincide exactamente con el original.
Ejecución

//Requisitos

Windows (WPF no es compatible con macOS/Linux)
.NET SDK 10.0 o superior
Visual Studio 2022 (o posterior) con la carga de trabajo ".NET desktop development"


//Estructuración 
bash
dotnet build
dotnet run
Estructura del proyecto
ProyectoFinal/
├── App.xaml / App.xaml.cs              # Punto de entrada de la aplicación WPF
├── MainWindow.xaml                     # Interfaz gráfica (paneles, estilos, controles)
├── MainWindow.xaml.cs                  # Lógica de la interfaz y navegación
├── ModuloMatematico.cs                 # Operaciones con matrices (determinante, inversa, multiplicación)
├── ModuloProcesamientoTexto.cs         # Conversión de texto a números y relleno de matrices
├── ModuloRecuperacion.cs               # Conversión de matrices descifradas de vuelta a texto
├── ModuloSalida.cs                     # Utilidades de salida (heredadas de la versión de consola)
├── ModuloInteraccion.cs                # Utilidades de interacción con el usuario
└── ProyectoFinal.csproj                # Configuración del proyecto (.NET, WPF)


//Capturas
<img width="739" height="419" alt="image" src="https://github.com/user-attachments/assets/80cbf1e6-7db5-49ee-bdf4-2f573ed4d889" />

<img width="677" height="438" alt="image" src="https://github.com/user-attachments/assets/ac2c82a2-01bb-4554-9ba0-e5c5ade333e9" />

<img width="676" height="403" alt="image" src="https://github.com/user-attachments/assets/34f1eb42-962c-4267-a78c-fd617244d57c" />

<img width="703" height="373" alt="image" src="https://github.com/user-attachments/assets/b94979e4-8d78-4ce0-8f31-47cb1576519c" />



Geraldine De Oleo Galvan | www.linkedin.com/in/geraldinedeoleogalvan

LinkedIn

(Próximamente)
