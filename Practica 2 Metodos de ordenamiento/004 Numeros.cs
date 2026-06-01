
/*
    ==============================================
    Nombre: Abraham Marentes Ramirez
    Registro: 23310382
    Grupo: 6E

    Resumen:
    Esta clase sirve para guardar los números ingresados
    por el usuario y permitir su manejo mediante una
    estructura similar a un arreglo dinámico.
    ==============================================
*/

using System.Collections.Generic;          // Permite usar listas genéricas

namespace MetodosOrdenamiento             // Agrupa las clases del proyecto
{
    public class Numeros                   // Clase para almacenar números
    {
        private readonly List<int> valores = new List<int>(); // Lista interna de datos

        public int Count => valores.Count; // Devuelve la cantidad de números

        public void Agregar(int numero)    // Recibe un número nuevo
        {
            valores.Add(numero);           // Agrega el número a la lista
        }

        public int this[int posicion]      // Permite usar índice como arreglo
        {
            get => valores[posicion];      // Obtiene el valor indicado
            set => valores[posicion] = value; // Cambia el valor indicado
        }

        public int[] AArray()              // Convierte la lista en arreglo
        {
            return valores.ToArray();      // Devuelve los datos como int[]
        }
    }
}