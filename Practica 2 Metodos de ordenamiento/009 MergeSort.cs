/*
    ==============================================
    Nombre: Abraham Marentes Ramirez
    Registro: 23310382
    Grupo: 6E

    Resumen:
    El programa ordena un arreglo de números enteros
    dividiendo los datos en partes más pequeñas.
    Después mezcla esas partes de forma ordenada
    hasta obtener el arreglo completo.
    ==============================================
*/

using System; // Permite usar funciones de arreglos

namespace MetodosOrdenamiento // Agrupa las clases del proyecto
{
    public static class MergeSort // Clase del método MergeSort
    {
        public static void Orden(int[] a) // Método que recibe el arreglo
        {
            if (a.Length <= 1) return; // Termina si ya está ordenado

            Dividir(a, 0, a.Length - 1); // Inicia la división
        }

        private static void Dividir(int[] a, int izquierda, int derecha) // Divide el arreglo
        {
            if (izquierda >= derecha) return; // Caso base

            int centro = (izquierda + derecha) / 2; // Calcula el punto medio

            Dividir(a, izquierda, centro); // Ordena la parte izquierda

            Dividir(a, centro + 1, derecha); // Ordena la parte derecha

            Mezclar(a, izquierda, centro, derecha); // Une las partes ordenadas
        }

        private static void Mezclar(int[] a, int izquierda, int centro, int derecha) // Mezcla datos
        {
            int tamIzquierdo = centro - izquierda + 1; // Tamaño izquierdo
            int tamDerecho = derecha - centro;         // Tamaño derecho

            int[] ladoIzquierdo = new int[tamIzquierdo]; // Arreglo auxiliar izquierdo
            int[] ladoDerecho = new int[tamDerecho];     // Arreglo auxiliar derecho

            Array.Copy(a, izquierda, ladoIzquierdo, 0, tamIzquierdo); // Copia izquierda

            Array.Copy(a, centro + 1, ladoDerecho, 0, tamDerecho); // Copia derecha

            int i = 0;          // Índice izquierdo
            int j = 0;          // Índice derecho
            int k = izquierda;  // Índice original

            while (i < tamIzquierdo && j < tamDerecho) // Compara ambos lados
            {
                if (ladoIzquierdo[i] <= ladoDerecho[j]) // Revisa el menor
                {
                    a[k] = ladoIzquierdo[i]; // Coloca dato izquierdo
                    i++;                     // Avanza izquierda
                }
                else // Si el derecho es menor
                {
                    a[k] = ladoDerecho[j]; // Coloca dato derecho
                    j++;                   // Avanza derecha
                }

                k++; // Avanza en el arreglo original
            }

            while (i < tamIzquierdo) // Copia sobrantes izquierdos
            {
                a[k] = ladoIzquierdo[i]; // Coloca dato restante
                i++;                     // Avanza izquierda
                k++;                     // Avanza original
            }

            while (j < tamDerecho) // Copia sobrantes derechos
            {
                a[k] = ladoDerecho[j]; // Coloca dato restante
                j++;                   // Avanza derecha
                k++;                   // Avanza original
            }
        }
    }
}