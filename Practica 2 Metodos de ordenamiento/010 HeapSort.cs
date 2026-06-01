/*
    ==============================================
    Nombre: Abraham Marentes Ramirez
    Registro: 23310382
    Grupo: 6E

    Resumen:
    El programa ordena un arreglo de números enteros
    formando un montículo máximo. Después coloca el
    valor mayor al final y reorganiza los datos hasta
    completar el ordenamiento.
    ==============================================
*/

namespace MetodosOrdenamiento // Agrupa las clases del proyecto
{
    public static class HeapSort // Clase del método HeapSort
    {
        public static void Orden(int[] a) // Método que recibe el arreglo
        {
            int n = a.Length; // Guarda la cantidad de elementos

            for (int i = n / 2 - 1; i >= 0; i--) // Construye el montículo
            {
                CrearMonticulo(a, n, i); // Ajusta cada subárbol
            }

            for (int i = n - 1; i >= 0; i--) // Extrae valores uno por uno
            {
                int temp = a[0]; // Guarda la raíz
                a[0] = a[i];    // Mueve el último a la raíz
                a[i] = temp;    // Coloca el mayor al final

                CrearMonticulo(a, i, 0); // Reorganiza el montículo
            }
        }

        private static void CrearMonticulo(int[] a, int n, int i) // Ajusta el montículo
        {
            int mayor = i;       // Supone que la raíz es mayor
            int izquierdo = 2 * i + 1; // Calcula hijo izquierdo
            int derecho = 2 * i + 2;   // Calcula hijo derecho

            if (izquierdo < n && a[izquierdo] > a[mayor]) // Compara hijo izquierdo
            {
                mayor = izquierdo; // Actualiza el mayor
            }

            if (derecho < n && a[derecho] > a[mayor]) // Compara hijo derecho
            {
                mayor = derecho; // Actualiza el mayor
            }

            if (mayor != i) // Verifica si debe cambiar
            {
                int aux = a[i];      // Guarda la raíz
                a[i] = a[mayor];     // Coloca el mayor en raíz
                a[mayor] = aux;      // Mueve el valor anterior

                CrearMonticulo(a, n, mayor); // Ajusta el subárbol
            }
        }
    }
}