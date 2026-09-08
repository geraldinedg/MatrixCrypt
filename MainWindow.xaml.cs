using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ProyectoFDP
{
    public partial class MainWindow : Window
    {
        // Misma matriz clave que se usaba en Program.cs original
        private static readonly double[,] ClaveA =
        {
            { 1, -2, 2 },
            { -1, 1, 3 },
            { 1, -1, -4 }
        };

        private double[,] _claveInversa = null!;


        private bool _ventanaLista = false; 
        public MainWindow()
        {
            InitializeComponent();
            InicializarClave();
            _ventanaLista = true;
        }

        private void InicializarClave()
        {
            double determinante = ModuloMatematico.CalcularDeterminante(ClaveA);

            if (!ModuloMatematico.VerificarInversa(determinante))
            {
                MessageBox.Show(
                    "La matriz clave configurada no es invertible. Revisa ClaveA en MainWindow.xaml.cs.",
                    "Error de configuración",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            _claveInversa = ModuloMatematico.CalcularMatrizInversa(ClaveA);
        }

        // ============ Barra de titulo personalizada ============
        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void Minimizar_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        private void Cerrar_Click(object sender, RoutedEventArgs e) => Close();

        
        private void Nav_Click(object sender, RoutedEventArgs e)
        {
            if (!_ventanaLista) return;
            if (sender is not RadioButton rb) return;

            PanelInicio.Visibility = Visibility.Collapsed;
            PanelEncriptar.Visibility = Visibility.Collapsed;
            PanelDesencriptar.Visibility = Visibility.Collapsed;
            PanelVerificar.Visibility = Visibility.Collapsed;

            switch (rb.Tag as string)
            {
                case "Inicio":
                    PanelInicio.Visibility = Visibility.Visible;
                    break;
                case "Encriptar":
                    PanelEncriptar.Visibility = Visibility.Visible;
                    break;
                case "Desencriptar":
                    PanelDesencriptar.Visibility = Visibility.Visible;
                    break;
                case "Verificar":
                    PanelVerificar.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void Encriptar_Click(object sender, RoutedEventArgs e)
        {
            string mensaje = MensajeInput.Text;

            if (string.IsNullOrWhiteSpace(mensaje))
            {
                CriptogramaOutput.Text = "Escriba un mensaje primero.";
                return;
            }

            int[] criptograma = EncriptarMensaje(mensaje);
            CriptogramaOutput.Text = string.Join(" ", criptograma);
        }

        // Reutiliza exactamente la misma logica que estaba en Program.cs (case 1)
        private int[] EncriptarMensaje(string mensaje)
        {
            int[] codigo = ModuloProcesamientoTexto.TextoMatriz(mensaje);
            int[] matrizCompleta = ModuloProcesamientoTexto.CompletarCeros(codigo);
            int[,] matrices = ModuloProcesamientoTexto.AgrupacionMatriz(matrizCompleta);

            int cantidadFilas = matrices.GetLength(0);
            int[,] matricesCodificadas = new int[cantidadFilas, 3];

            for (int fila = 0; fila < cantidadFilas; fila++)
            {
                double[] x = { matrices[fila, 0], matrices[fila, 1], matrices[fila, 2] };
                double[] y = ModuloMatematico.MultiplicarMatrices(x, ClaveA);

                matricesCodificadas[fila, 0] = (int)Math.Round(y[0]);
                matricesCodificadas[fila, 1] = (int)Math.Round(y[1]);
                matricesCodificadas[fila, 2] = (int)Math.Round(y[2]);
            }

            return ModuloRecuperacion.UnirMatrices(matricesCodificadas);
        }

        // ============ Desencriptar ============
        private void Desencriptar_Click(object sender, RoutedEventArgs e)
        {
            string[] numerosTexto = CriptogramaInput.Text
                .Split(new[] { ' ', ',', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            if (numerosTexto.Length == 0 || numerosTexto.Length % 3 != 0)
            {
                MensajeOutput.Text = "Ingrese números separados por espacio (la cantidad debe ser múltiplo de 3).";
                return;
            }

            int[] criptograma;
            try
            {
                criptograma = numerosTexto.Select(int.Parse).ToArray();
            }
            catch (FormatException)
            {
                MensajeOutput.Text = "El criptograma solo debe contener números enteros.";
                return;
            }

            MensajeOutput.Text = DesencriptarCriptograma(criptograma);
        }

        // Reutiliza exactamente la misma logica que estaba en Program.cs (case 2)
        private string DesencriptarCriptograma(int[] criptograma)
        {
            int[,] matrices = ModuloProcesamientoTexto.AgrupacionMatriz(criptograma);
            int cantidadFilas = matrices.GetLength(0);
            int[,] matricesDescodificadas = new int[cantidadFilas, 3];

            for (int fila = 0; fila < cantidadFilas; fila++)
            {
                double[] y = { matrices[fila, 0], matrices[fila, 1], matrices[fila, 2] };
                double[] x = ModuloMatematico.MultiplicarMatrices(y, _claveInversa);

                matricesDescodificadas[fila, 0] = (int)Math.Round(x[0]);
                matricesDescodificadas[fila, 1] = (int)Math.Round(x[1]);
                matricesDescodificadas[fila, 2] = (int)Math.Round(x[2]);
            }

            return ModuloRecuperacion.MatricesTexto(matricesDescodificadas);
        }

        // ============ Verificar ida y vuelta ============
        private void Verificar_Click(object sender, RoutedEventArgs e)
        {
            string mensaje = MensajeVerificarInput.Text;

            if (string.IsNullOrWhiteSpace(mensaje))
            {
                BadgeVerificacion.Text = "Escriba un mensaje primero.";
                BadgeVerificacion.Foreground = new SolidColorBrush(Color.FromRgb(0xFF, 0x6B, 0x6B));
                return;
            }

            int[] criptograma = EncriptarMensaje(mensaje);
            CriptogramaVerificarOutput.Text = string.Join(" ", criptograma);

            string recuperado = DesencriptarCriptograma(criptograma);
            MensajeRecuperadoOutput.Text = recuperado;

            bool coincide = recuperado.Trim().ToUpper() == mensaje.Trim().ToUpper();

            BadgeVerificacion.Text = coincide
                ? "✓ El mensaje coincide con el original"
                : "✗ El mensaje NO coincide con el original";

            BadgeVerificacion.Foreground = coincide
                ? new SolidColorBrush(Color.FromRgb(0x4C, 0xE0, 0x99))
                : new SolidColorBrush(Color.FromRgb(0xFF, 0x6B, 0x6B));
        }
    }
}
