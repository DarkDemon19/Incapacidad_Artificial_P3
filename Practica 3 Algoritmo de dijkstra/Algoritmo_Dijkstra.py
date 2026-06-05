# ==========================================================
# Nombre: Abraham Marentes Ramirez
# Registro: 23310382
# Grupo: 6E
#
# Resumen:
# Este programa aplica el algoritmo de Dijkstra para calcular
# las distancias mínimas desde un nodo inicial hacia los demás.
# Además, muestra el avance del proceso y representa el grafo.
# ==========================================================

import heapq                 # Usa una cola de prioridad
import networkx as nx        # Permite trabajar con grafos
import matplotlib.pyplot as plt # Permite mostrar la gráfica

# Grafo representado con nodos, conexiones y pesos
red = {
    'A': {'B': 2, 'D': 5},
    'B': {'C': 7, 'E': 1},
    'C': {},
    'D': {'E': 1},
    'E': {'C': 3}
}

ORIGEN = 'A'                 # Nodo de inicio

def dijkstra_con_pasos(red, origen):
    dist = {nodo: float('inf') for nodo in red}   # Distancias iniciales
    previo = {nodo: None for nodo in red}         # Guarda el nodo anterior
    dist[origen] = 0                              # Distancia inicial
    revisados = set()                             # Nodos procesados
    pendientes = [(0, origen)]                    # Cola de prioridad

    print("=== ALGORITMO DE DIJKSTRA ===")
    print(f"Nodo inicial: {origen}\n")

    while pendientes:                             # Mientras existan nodos
        distancia_actual, actual = heapq.heappop(pendientes) # Toma el menor

        if actual in revisados:                   # Evita repetir nodos
            continue

        revisados.add(actual)                     # Marca como revisado

        print(f"Nodo actual: {actual} (distancia = {distancia_actual})")
        print(f"Nodos revisados: {sorted(revisados)}")
        print("Tabla de distancias:")

        for nodo in sorted(red.keys()):           # Muestra cada distancia
            valor = dist[nodo]
            print(f"  {nodo}: {valor if valor != float('inf') else 'INF'}")

        print()

        for vecino, peso in red[actual].items():  # Revisa conexiones
            if vecino in revisados:               # Omite revisados
                continue

            nueva = distancia_actual + peso       # Calcula nueva distancia

            if nueva < dist[vecino]:              # Verifica si mejora
                print(f"  Actualización {vecino}: {dist[vecino]} -> {nueva}")
                dist[vecino] = nueva              # Guarda nueva distancia
                previo[vecino] = actual           # Guarda procedencia
                heapq.heappush(pendientes, (nueva, vecino)) # Agrega a la cola

        print()

    return dist, previo                           # Regresa resultados

def dibujar_grafo(red, previo):
    grafo = nx.DiGraph()                          # Crea grafo dirigido

    for nodo in red:
        for vecino, peso in red[nodo].items():    # Recorre conexiones
            grafo.add_edge(nodo, vecino, weight=peso) # Agrega arista

    posicion = nx.spring_layout(grafo, seed=42)   # Define distribución

    plt.figure(figsize=(10, 7))                   # Tamaño de ventana
    nx.draw_networkx_nodes(grafo, posicion, node_size=700) # Dibuja nodos
    nx.draw_networkx_edges(grafo, posicion, arrowstyle="->", arrowsize=20) # Dibuja flechas
    nx.draw_networkx_labels(grafo, posicion, font_size=12, font_weight="bold") # Dibuja etiquetas

    pesos = nx.get_edge_attributes(grafo, 'weight') # Obtiene pesos
    nx.draw_networkx_edge_labels(grafo, posicion, edge_labels=pesos) # Muestra pesos

    caminos = [(anterior, nodo) for nodo, anterior in previo.items() if anterior is not None] # Caminos mínimos

    nx.draw_networkx_edges(
        grafo,
        posicion,
        edgelist=caminos,
        width=3,
        edge_color="red",
        arrowstyle="->",
        arrowsize=25
    )

    plt.title("Dijkstra - Rutas mínimas encontradas") # Título
    plt.axis("off")                                   # Oculta ejes
    plt.tight_layout()                                # Ajusta elementos
    plt.show()                                        # Muestra gráfica

if __name__ == "__main__":
    distancias, recorrido = dijkstra_con_pasos(red, ORIGEN) # Ejecuta algoritmo

    print("Distancias finales:")

    for nodo, distancia in distancias.items():        # Muestra resultados
        print(f"  {nodo}: {distancia if distancia != float('inf') else 'INF'}")

    dibujar_grafo(red, recorrido)                     # Grafica resultados