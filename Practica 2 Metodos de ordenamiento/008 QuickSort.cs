/*
    ==============================================
    Nombre: Abraham Marentes Ramirez
    Registro: 23310382
    Grupo: 6E

    Resumen:
    El programa ordena un arreglo de números enteros
    dividiendo los datos en partes más pequeñas.
    Usa un pivote para acomodar los valores menores
    y mayores hasta completar el ordenamiento.
    ==============================================
*/

namespace MetodosOrdenamiento // Agrupa las clases del proyecto
{
    public static class QuickSort // Clase del método QuickSort
    {
        public static void Orden(int[] a) // Método que recibe el arreglo
        {
            OrdenRapido(a, 0, a.Length - 1); // Inicia el ordenamiento
        }

        private static void OrdenRapido(int[] a, int inicio, int fin) // Método recursivo
        {
            if (inicio >= fin) return; // Termina si ya está ordenado

            int izquierda = inicio; // Índice izquierdo
            int derecha = fin;      // Índice derecho
            int pivote = a[(inicio + fin) / 2]; // Toma el valor central

            while (izquierda <= derecha) // Recorre ambos lados
            {
                while (a[izquierda] < pivote) izquierda++; // Busca valor mayor

                while (a[derecha] > pivote) derecha--; // Busca valor menor

                if (izquierda <= derecha) // Verifica si pueden cambiarse
                {
                    int aux = a[izquierda];       // Guarda el primer valor
                    a[izquierda] = a[derecha];    // Mueve el valor derecho
                    a[derecha] = aux;             // Coloca el valor guardado

                    izquierda++; // Avanza desde la izquierda
                    derecha--;   // Retrocede desde la derecha
                }
            }

            if (inicio < derecha) OrdenRapido(a, inicio, derecha); // Ordena parte izquierda

            if (izquierda < fin) OrdenRapido(a, izquierda, fin); // Ordena parte derecha
        }
    }
}