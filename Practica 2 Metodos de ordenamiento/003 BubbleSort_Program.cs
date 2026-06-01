/*
    ==============================================
    Nombre: Abraham Marentes Ramirez
    Registro: 23310382
    Grupo: 6E

    Resumen:
    Este archivo contiene el punto de inicio del proyecto.
    Desde aquí se configura la aplicación y se abre el
    formulario principal utilizado para el método Burbuja.
    ==============================================
*/

using System;                     // Permite usar funciones generales de C#
using System.Windows.Forms;       // Permite trabajar con Windows Forms

namespace MetodosOrdenamiento     // Agrupa las clases del proyecto
{
    internal static class Program  // Clase principal del programa
    {
        [STAThread]                // Define el modelo de hilo de la aplicación
        static void Main()         // Método donde inicia el programa
        {
            Application.EnableVisualStyles();                    // Activa estilos visuales
            Application.SetCompatibleTextRenderingDefault(false); // Configura renderizado de texto
            Application.Run(new Burbuja());                      // Abre el formulario Burbuja
        }
    }
}

