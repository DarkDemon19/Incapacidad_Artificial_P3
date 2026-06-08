# ============================================================================
# Nombre: Abraham Marentes Ramirez
# Registro: 23310382
# Grupo: 6E
#
# Resumen:
# Este programa aplica el algoritmo de Kruskal para obtener
# el arbol de minimo coste y el arbol de maximo coste.
# Tambien muestra el proceso y guarda las imagenes finales.
# ============================================================================

import math
import matplotlib.pyplot as plt

INF = math.inf  # Representa que no existe conexion


def construir_aristas(matriz):
    aristas = []                  # Lista de aristas
    cantidad = len(matriz)        # Numero de nodos

    for origen in range(cantidad):              # Recorre filas
        for destino in range(origen + 1, cantidad): # Recorre columnas
            if matriz[origen][destino] != INF:  # Verifica conexion
                peso = matriz[origen][destino]  # Toma el peso
                aristas.append((peso, origen, destino)) # Guarda arista

    return aristas                # Devuelve aristas


def buscar(padres, nodo):
    if padres[nodo] != nodo:      # Revisa si tiene otro padre
        padres[nodo] = buscar(padres, padres[nodo]) # Ajusta camino

    return padres[nodo]           # Devuelve representante


def unir(padres, rangos, x, y):
    raiz_x = buscar(padres, x)     # Raiz de x
    raiz_y = buscar(padres, y)     # Raiz de y

    if raiz_x == raiz_y:           # Revisa si ya estan unidos
        return False               # No se puede unir

    if rangos[raiz_x] < rangos[raiz_y]: # Compara rangos
        padres[raiz_x] = raiz_y    # Une x con y

    elif rangos[raiz_x] > rangos[raiz_y]: # Compara rangos
        padres[raiz_y] = raiz_x    # Une y con x

    else:                          # Si tienen mismo rango
        padres[raiz_y] = raiz_x    # Une y con x
        rangos[raiz_x] += 1        # Aumenta rango

    return True                    # Union realizada


def kruskal(matriz, etiquetas, minimo=True):
    cantidad = len(matriz)         # Numero de nodos
    aristas = construir_aristas(matriz) # Crea lista de aristas

    aristas.sort(key=lambda x: x[0], reverse=not minimo) # Ordena aristas

    tipo = "MINIMO" if minimo else "MAXIMO" # Define tipo

    print(f"\n===== KRUSKAL {tipo} COSTE =====")
    print("Aristas ordenadas:")

    for peso, origen, destino in aristas: # Muestra aristas
        print(f"  {etiquetas[origen]} - {etiquetas[destino]} : {peso}")

    padres = list(range(cantidad))  # Padre inicial
    rangos = [0] * cantidad         # Rango inicial
    arbol = []                      # Aristas elegidas
    total = 0                       # Coste total

    print("\nProceso paso a paso:")

    for peso, origen, destino in aristas: # Recorre aristas
        print(f"Considerando arista {etiquetas[origen]} - {etiquetas[destino]} (peso {peso})...")

        if buscar(padres, origen) != buscar(padres, destino): # Evita ciclos
            unir(padres, rangos, origen, destino) # Une conjuntos
            arbol.append((origen, destino, peso)) # Agrega arista
            total += peso                         # Suma peso
            print(f"  -> ACEPTADA. Coste acumulado = {total}")

        else:
            print("  -> RECHAZADA porque forma ciclo.")

    print(f"\nAristas elegidas para el arbol de {tipo} coste:")

    for origen, destino, peso in arbol: # Muestra arbol
        print(f"  {etiquetas[origen]} -- {peso} --> {etiquetas[destino]}")

    print(f"Coste total del arbol de {tipo} coste: {total}\n")

    return arbol                    # Devuelve arbol


def dibujar_kruskal(etiquetas, aristas, nombre_archivo, titulo):
    cantidad = len(etiquetas)       # Numero de nodos

    angulos = [2 * math.pi * i / cantidad for i in range(cantidad)] # Angulos
    posiciones = {i: (math.cos(angulos[i]), math.sin(angulos[i])) for i in range(cantidad)} # Posiciones

    figura, eje = plt.subplots()    # Crea figura
    eje.set_aspect("equal")         # Mantiene proporcion
    eje.axis("off")                 # Oculta ejes

    for origen, destino, peso in aristas: # Dibuja aristas
        x1, y1 = posiciones[origen] # Posicion origen
        x2, y2 = posiciones[destino] # Posicion destino

        eje.plot([x1, x2], [y1, y2], linewidth=3) # Dibuja linea

        xm = (x1 + x2) / 2          # Punto medio x
        ym = (y1 + y2) / 2          # Punto medio y
        eje.text(xm, ym, str(peso), fontsize=9) # Muestra peso

    for i in range(cantidad):       # Dibuja nodos
        x, y = posiciones[i]        # Toma posicion
        eje.scatter([x], [y], s=300) # Dibuja nodo
        eje.text(x, y, etiquetas[i], ha="center", va="center", fontsize=12) # Muestra etiqueta

    plt.title(titulo)               # Titulo de grafica
    plt.savefig(nombre_archivo)     # Guarda imagen
    print(f"Imagen guardada como {nombre_archivo}")
    plt.show()                      # Muestra imagen


if __name__ == "__main__":

    etiquetas = ["α", "β", "γ", "δ", "ε", "ζ", "η"] # Etiquetas de nodos

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

    arbol_min = kruskal(matriz, etiquetas, minimo=True) # Arbol minimo
    dibujar_kruskal(etiquetas, arbol_min, "Minimum_Kruskal.png", "Arbol de Minimo Coste Kruskal")

    arbol_max = kruskal(matriz, etiquetas, minimo=False) # Arbol maximo
    dibujar_kruskal(etiquetas, arbol_max, "Maximum_Kruskal.png", "Arbol de Maximo Coste Kruskal")