/*
    ==============================================
    Nombre: Abraham Marentes Ramirez
    Registro: 23310382
    Grupo: 6E

    Resumen:
    El programa ordena un arreglo de números enteros
    no negativos revisando sus dígitos por posiciones.
    Primero organiza unidades, después decenas y continúa
    hasta completar todos los valores.
    ==============================================
*/

namespace MetodosOrdenamiento // Agrupa las clases del proyecto
{
    public static class RadixSort // Clase del método RadixSort
    {
        public static void Orden(int[] a) // Método que recibe el arreglo
        {
            int mayor = 0; // Guarda el número mayor

            foreach (int numero in a) // Recorre cada número
            {
                if (numero > mayor) // Compara con el mayor actual
                {
                    mayor = numero; // Actualiza el mayor
                }
            }

            for (int exp = 1; mayor / exp > 0; exp *= 10) // Recorre cada dígito
            {
                OrdenarPorDigito(a, exp); // Ordena según la posición
            }
        }

        private static void OrdenarPorDigito(int[] a, int exp) // Ordena por dígito
        {
            int n = a.Length;          // Guarda el tamaño
            int[] salida = new int[n]; // Arreglo auxiliar
            int[] conteo = new int[10]; // Cuenta dígitos del 0 al 9

            for (int i = 0; i < n; i++) // Recorre los datos
            {
                int indice = (a[i] / exp) % 10; // Obtiene el dígito
                conteo[indice]++;              // Aumenta el conteo
            }

            for (int i = 1; i < 10; i++) // Recorre los conteos
            {
                conteo[i] += conteo[i - 1]; // Acumula posiciones
            }

            for (int i = n - 1; i >= 0; i--) // Recorre de derecha a izquierda
            {
                int indice = (a[i] / exp) % 10;   // Obtiene el dígito
                salida[conteo[indice] - 1] = a[i]; // Coloca el número
                conteo[indice]--;                 // Reduce la posición
            }

            for (int i = 0; i < n; i++) // Recorre el arreglo
            {
                a[i] = salida[i]; // Copia el resultado
            }
        }
    }
}