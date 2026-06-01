/*
    ==============================================
    Nombre: Abraham Marentes Ramirez
    Registro: 23310382
    Grupo: 6E

    Resumen:
    El programa ordena un arreglo de números enteros
    buscando el valor menor dentro de la parte no ordenada
    y colocándolo en la posición que le corresponde.
    ==============================================
*/

namespace MetodosOrdenamiento // Agrupa las clases del proyecto
{
    public static class SelectionSort // Clase del método SelectionSort
    {
        public static void Orden(int[] a) // Método que recibe el arreglo
        {
            int n = a.Length; // Guarda la cantidad de elementos

            for (int i = 0; i < n - 1; i++) // Recorre hasta el penúltimo dato
            {
                int indiceMenor = i; // Supone que el menor está en i

                for (int j = i + 1; j < n; j++) // Busca en la parte restante
                {
                    if (a[j] < a[indiceMenor]) // Compara para encontrar el menor
                    {
                        indiceMenor = j; // Guarda la posición del menor
                    }
                }

                if (indiceMenor != i) // Verifica si se encontró otro menor
                {
                    int aux = a[i];             // Guarda el valor actual
                    a[i] = a[indiceMenor];      // Coloca el menor en su lugar
                    a[indiceMenor] = aux;       // Mueve el valor anterior
                }
            }
        }
    }
}