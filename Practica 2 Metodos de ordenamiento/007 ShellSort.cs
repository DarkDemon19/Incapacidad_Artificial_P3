/*
    ==============================================
    Nombre: Abraham Marentes Ramirez
    Registro: 23310382
    Grupo: 6E

    Resumen:
    El programa ordena un arreglo de números enteros
    comparando elementos separados por intervalos.
    Después reduce esos intervalos hasta ordenar
    los datos de forma completa.
    ==============================================
*/

namespace MetodosOrdenamiento // Agrupa las clases del proyecto
{
    public static class ShellSort // Clase del método ShellSort
    {
        public static void Orden(int[] a) // Método que recibe el arreglo
        {
            int n = a.Length; // Guarda el tamaño del arreglo
            int salto = n / 2; // Define el intervalo inicial

            while (salto > 0) // Repite mientras exista intervalo
            {
                for (int i = salto; i < n; i++) // Recorre desde el salto
                {
                    int temp = a[i]; // Guarda el valor actual
                    int j = i;       // Guarda la posición actual

                    while (j >= salto && a[j - salto] > temp) // Compara con salto
                    {
                        a[j] = a[j - salto]; // Mueve el valor mayor
                        j -= salto;          // Retrocede según el salto
                    }

                    a[j] = temp; // Inserta el valor correcto
                }

                salto /= 2; // Reduce el intervalo
            }
        }
    }
}