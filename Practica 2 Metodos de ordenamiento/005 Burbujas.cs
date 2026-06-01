/*
    ==============================================
    Nombre: Abraham Marentes Ramirez
    Registro: 23310382
    Grupo: 6E

    Resumen:
    Este formulario permite ingresar números enteros,
    mostrarlos como botones y visualizar el proceso
    de ordenamiento mediante el método Burbuja.
    ==============================================
*/

using System;                 // Permite usar clases básicas
using System.Drawing;         // Permite usar puntos y medidas
using System.Threading;       // Permite usar pausas
using System.Windows.Forms;   // Permite usar Windows Forms

namespace MetodosOrdenamiento // Agrupa las clases del proyecto
{
    public partial class Burbuja : Form // Formulario del método Burbuja
    {
        private Numeros enteros = new Numeros(); // Guarda los números ingresados

        public Burbuja() // Constructor del formulario
        {
            InitializeComponent(); // Inicializa los controles
            this.Text = "Método Burbuja"; // Cambia el título
        }

        private void Burbuja_Load(object sender, EventArgs e) // Evento de carga
        {
            // Evento disponible para iniciar datos
        }

        private void btnAgregar_Click(object sender, EventArgs e) // Botón Agregar
        {
            if (int.TryParse(txtNumero.Text, out int numero)) // Valida el número
            {
                enteros.Agregar(numero); // Agrega el número
                txtNumero.Clear();       // Limpia la caja
                txtNumero.Focus();       // Regresa el cursor
                Dibujar_Arreglo();       // Muestra los datos
            }
            else // Si el dato no es válido
            {
                MessageBox.Show("Ingrese un número entero válido."); // Muestra aviso
            }
        }

        private void btnOrdenar_Click(object sender, EventArgs e) // Botón Ordenar
        {
            if (enteros.Count <= 1) // Verifica cantidad mínima
            {
                MessageBox.Show("Ingrese al menos dos números."); // Muestra aviso
                return; // Detiene el proceso
            }

            BubbleSortVisual(); // Inicia el ordenamiento
        }

        private void Dibujar_Arreglo() // Dibuja los números
        {
            tabPage1.Controls.Clear(); // Limpia el área

            int x = 10;       // Posición horizontal
            int y = 20;       // Posición vertical
            int ancho = 50;   // Ancho del botón
            int alto = 40;    // Alto del botón
            int espacio = 10; // Separación entre botones

            for (int i = 0; i < enteros.Count; i++) // Recorre los datos
            {
                Button boton = new Button(); // Crea un botón
                boton.Width = ancho;         // Asigna ancho
                boton.Height = alto;         // Asigna alto
                boton.Location = new Point(x, y); // Coloca el botón
                boton.Text = enteros[i].ToString(); // Muestra el número
                boton.Enabled = false;       // Bloquea interacción
                tabPage1.Controls.Add(boton); // Agrega el botón

                x += ancho + espacio; // Avanza la posición
            }
        }

        private void BubbleSortVisual() // Ordena con Burbuja
        {
            int n = enteros.Count; // Guarda la cantidad

            for (int i = 0; i < n; i++) // Repite recorridos
            {
                for (int j = 0; j < n - 1; j++) // Compara vecinos
                {
                    if (enteros[j] > enteros[j + 1]) // Revisa el orden
                    {
                        int aux = enteros[j];        // Guarda temporal
                        enteros[j] = enteros[j + 1]; // Mueve el menor
                        enteros[j + 1] = aux;        // Mueve el mayor

                        Intercambio(j, j + 1); // Muestra el cambio
                    }
                }
            }
        }

        private void Intercambio(int primero, int segundo) // Anima intercambio
        {
            Thread.Sleep(200);      // Pausa breve
            Dibujar_Arreglo();      // Redibuja datos
            tabPage1.Refresh();     // Actualiza pantalla
            Application.DoEvents(); // Procesa eventos
        }
    }
}