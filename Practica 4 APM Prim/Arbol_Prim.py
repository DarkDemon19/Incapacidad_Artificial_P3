# ============================================================================
# Nombre: Abraham Marentes Ramirez
# Registro: 23310382
# Grupo: 6E
#
# Resumen:
# Este programa aplica el algoritmo de Prim para obtener
# el arbol parcial minimo de un grafo ponderado.
# Tambien muestra el proceso y guarda la imagen final.
# ============================================================================

import math
import matplotlib.pyplot as plt

INF = math.inf  # Representa que no existe conexion


# ALGORITMO DE PRIM
def prim(matriz, etiquetas, inicio=0):
    cantidad = len(matriz)         # Numero de nodos
    clave = [INF] * cantidad       # Costos minimos
    padre = [None] * cantidad      # Padre de cada nodo
    en_arbol = [False] * cantidad  # Nodos dentro del arbol
    clave[inicio] = 0              # Nodo inicial

    print(f"Iniciando Prim en {etiquetas[inicio]}:\n")

    for paso in range(cantidad):   # Repite por cada nodo
        actual = None              # Nodo seleccionado
        minimo = INF               # Valor minimo inicial

        # Busca el nodo con menor clave
        for i in range(cantidad):
            if not en_arbol[i] and clave[i] < minimo:
                minimo = clave[i]
                actual = i

        if actual is None:
            break

        en_arbol[actual] = True    # Agrega nodo al arbol

        # Muestra el estado actual
        print(f"Iteracion {paso + 1}: elijo {etiquetas[actual]} (key={minimo})")
        print("  key   :", [f"{k:.1f}" if k != INF else "INF" for k in clave])
        print("  padre :", [etiquetas[p] if p is not None else "-" for p in padre])

        # Revisa vecinos del nodo actual
        for vecino in range(cantidad):
            peso = matriz[actual][vecino]

            if peso != INF and not en_arbol[vecino] and peso < clave[vecino]:
                print(f"    actualizo {etiquetas[vecino]}: {clave[vecino]} -> {peso}, padre -> {etiquetas[actual]}")
                clave[vecino] = peso
                padre[vecino] = actual

        print()

    # Muestra el arbol final
    print("Arbol Parcial Minimo:")
    total = 0

    for i in range(cantidad):
        if padre[i] is not None:
            peso = matriz[i][padre[i]]
            print(f"  {etiquetas[padre[i]]} -- {peso} --> {etiquetas[i]}")
            total += peso

    print("Peso total:", total)

    return padre


# DIBUJAR EL ARBOL
def dibujar_arbol(matriz, etiquetas, padre):
    cantidad = len(matriz)  # Numero de nodos

    # Define posiciones circulares
    angulos = [2 * math.pi * i / cantidad for i in range(cantidad)]
    posiciones = {i: (math.cos(angulos[i]), math.sin(angulos[i])) for i in range(cantidad)}

    figura, eje = plt.subplots()
    eje.set_aspect("equal")
    eje.axis("off")

    # Dibuja todas las aristas
    for i in range(cantidad):
        for j in range(i + 1, cantidad):
            if matriz[i][j] != INF:
                x1, y1 = posiciones[i]
                x2, y2 = posiciones[j]
                eje.plot([x1, x2], [y1, y2])  # Linea normal

    # Dibuja las aristas del arbol minimo
    for i in range(cantidad):
        anterior = padre[i]

        if anterior is not None:
            x1, y1 = posiciones[anterior]
            x2, y2 = posiciones[i]
            eje.plot([x1, x2], [y1, y2], linewidth=3)  # Linea marcada
            xm, ym = (x1 + x2) / 2, (y1 + y2) / 2
            eje.text(xm, ym, str(matriz[anterior][i]), fontsize=9)  # Peso

    # Dibuja los nodos
    for i in range(cantidad):
        x, y = posiciones[i]
        eje.scatter([x], [y], s=300)  # Nodo
        eje.text(x, y, etiquetas[i], ha="center", va="center", fontsize=12)  # Nombre

    plt.title("Arbol Parcial Minimo (Prim)")
    plt.savefig("Arbol_Resultante.png")  # Guarda la imagen
    print("\nImagen guardada como Arbol_Resultante.png")
    plt.show()  # Muestra la imagen


# PROGRAMA PRINCIPAL
if __name__ == "__main__":

    # Etiquetas de los nodos
    etiquetas = ["α", "β", "γ", "δ", "ε", "ζ", "η"]

    # Matriz de adyacencia
    matriz = [
        # α    β    γ    δ    ε    ζ    η
        [INF, INF, 5,   2,   INF, 8,   INF],  # α
        [INF, INF, 7,   INF, 3,   INF, 6],    # β
        [5,   7,   INF, INF, 4,   INF, 9],    # γ
        [2,   INF, INF, INF, 1,   6,   INF],  # δ
        [INF, 3,   4,   1,   INF, INF, 5],    # ε
        [8,   INF, INF, 6,   INF, INF, 2],    # ζ
        [INF, 6,   9,   INF, 5,   2,   INF]   # η
    ]

    padres = prim(matriz, etiquetas)          # Ejecuta Prim
    dibujar_arbol(matriz, etiquetas, padres)  # Dibuja el resultado

