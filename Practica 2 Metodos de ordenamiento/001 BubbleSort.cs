/*
    ==============================================
    Nombre: Abraham Marentes Ramirez
    Registro: 23310382
    Grupo: 6E

    Resumen:
    El programa organiza un arreglo de números enteros
    comparando posiciones consecutivas e intercambiándolas
    cuando el valor de la izquierda es mayor que el de la derecha.
    ==============================================
*/

using System;                         // Permite usar funciones básicas de C#

public static class OrdenamientoBurbuja // Clase para el método burbuja
{
    public static void Orden(int[] arreglo) // Método que recibe el arreglo
    {
        int cantidad = arreglo.Length;        // Guarda el total de elementos

        for (int i = 0; i < cantidad; i++)    // Recorre el arreglo varias veces
        {
            for (int j = 0; j < cantidad - 1; j++) // Compara elementos vecinos
            {
                if (arreglo[j] > arreglo[j + 1])   // Verifica si están desordenados
                {
                    int temporal = arreglo[j];     // Guarda el valor actual
                    arreglo[j] = arreglo[j + 1];   // Coloca el menor a la izquierda
                    arreglo[j + 1] = temporal;     // Coloca el mayor a la derecha
                }
            }
        }
    }
}