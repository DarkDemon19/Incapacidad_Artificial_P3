/*
    ==============================================
    Nombre: Abraham Marentes Ramirez
    Registro: 23310382
    Grupo: 6E

    Resumen:
    El programa acomoda un arreglo de números enteros
    tomando cada valor y colocándolo en la posición
    correcta dentro de la parte previamente ordenada.
    ==============================================
*/

public static class InsertionSort // Clase del método InsertionSort
{
    public static void Orden(int[] array) // Método que recibe el arreglo
    {
        for (int i = 0; i < array.Length; i++) // Recorre el arreglo
        {
            int temp = array[i];        // Guarda el valor actual
            int j = i - 1;              // Toma la posición anterior

            while (j >= 0 && array[j] > temp) // Compara hacia atrás
            {
                array[j + 1] = array[j]; // Mueve el valor mayor
                j--;                     // Retrocede una posición
            }

            array[j + 1] = temp;        // Inserta el valor correcto
        }
    }
}