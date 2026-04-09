// ===================================
// PARTE 1: SOLUCIÓN REFACTORIZADA
// ===================================

using System;

class SolucionRefactorizada
{
    static int n;
    static int[] vectorOriginal;
    static int[] vectorIndices;

    static void Main(string[] args)
    {
        LeerDatos();
        GenerarVectorIndicesAscendente();
        ImprimirOrdenado("ASCENDENTE");
        GenerarVectorIndicesDescendente();
        ImprimirOrdenado("DESCENDENTE");
    }

    static void LeerDatos()
    {
        Console.Write("Ingrese el número de elementos: ");
        n = int.Parse(Console.ReadLine());
        vectorOriginal = new int[n];
        vectorIndices = new int[n];

        Console.WriteLine("Ingrese los elementos del vector:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Elemento [{i}]: ");
            vectorOriginal[i] = int.Parse(Console.ReadLine());
        }
    }

    // Inicializa el vector de índices con 0, 1, 2, ... n-1
    static void InicializarIndices()
    {
        for (int i = 0; i < n; i++)
        {
            vectorIndices[i] = i;
        }
    }

    // Ordena el vector de índices de forma que los elementos del vector original
    // queden en orden ASCENDENTE al acceder por esos índices (Selection Sort)
    static void GenerarVectorIndicesAscendente()
    {
        InicializarIndices();

        for (int i = 0; i < n - 1; i++)
        {
            int posMin = i;
            for (int j = i + 1; j < n; j++)
            {
                if (vectorOriginal[vectorIndices[j]] < vectorOriginal[vectorIndices[posMin]])
                {
                    posMin = j;
                }
            }
            // Intercambiar índices (NO elementos del vector original)
            int temp = vectorIndices[i];
            vectorIndices[i] = vectorIndices[posMin];
            vectorIndices[posMin] = temp;
        }
    }

    // Ordena el vector de índices de forma que los elementos del vector original
    // queden en orden DESCENDENTE al acceder por esos índices (Selection Sort)
    static void GenerarVectorIndicesDescendente()
    {
        InicializarIndices();

        for (int i = 0; i < n - 1; i++)
        {
            int posMax = i;
            for (int j = i + 1; j < n; j++)
            {
                if (vectorOriginal[vectorIndices[j]] > vectorOriginal[vectorIndices[posMax]])
                {
                    posMax = j;
                }
            }
            // Intercambiar índices (NO elementos del vector original)
            int temp = vectorIndices[i];
            vectorIndices[i] = vectorIndices[posMax];
            vectorIndices[posMax] = temp;
        }
    }

    // Imprime el vector original accediendo mediante el vector de índices
    static void ImprimirOrdenado(string tipo)
    {
        Console.Write($"\nVector ordenado {tipo}: ");
        for (int i = 0; i < n; i++)
        {
            Console.Write(vectorOriginal[vectorIndices[i]] + " ");
        }
        Console.WriteLine();

        Console.Write("Vector de índices:        ");
        for (int i = 0; i < n; i++)
        {
            Console.Write(vectorIndices[i] + " ");
        }
        Console.WriteLine();
    }
}


// ========================================
// PARTE 2: NUEVA SOLUCIÓN (ALGORITMO)
// ========================================

// Algoritmo alternativo: Insertion Sort sobre el vector de índices
// Lógica diferente: en lugar de buscar el mínimo/máximo (Selection Sort),
// se inserta cada índice en su posición correcta (Insertion Sort).

class NuevaSolucion
{
    static int n;
    static int[] vectorOriginal;
    static int[] vectorIndices;

    static void Main(string[] args)
    {
        LeerDatos();

        // --- Orden ASCENDENTE con Insertion Sort ---
        InicializarIndices();
        OrdenarIndicesInsertionSort(ascendente: true);
        Imprimir("ASCENDENTE (Insertion Sort)");

        // --- Orden DESCENDENTE con Insertion Sort ---
        InicializarIndices();
        OrdenarIndicesInsertionSort(ascendente: false);
        Imprimir("DESCENDENTE (Insertion Sort)");
    }

    static void LeerDatos()
    {
        Console.Write("Ingrese el número de elementos: ");
        n = int.Parse(Console.ReadLine());
        vectorOriginal = new int[n];
        vectorIndices = new int[n];

        Console.WriteLine("Ingrese los elementos del vector:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Elemento [{i}]: ");
            vectorOriginal[i] = int.Parse(Console.ReadLine());
        }
    }

    static void InicializarIndices()
    {
        for (int i = 0; i < n; i++)
        {
            vectorIndices[i] = i;
        }
    }

    // Insertion Sort sobre el vector de índices
    // Compara valores del vector original usando los índices almacenados
    static void OrdenarIndicesInsertionSort(bool ascendente)
    {
        for (int i = 1; i < n; i++)
        {
            int indiceActual = vectorIndices[i];
            int j = i - 1;

            // Desplazar índices mientras no se encuentre la posición correcta
            while (j >= 0 && Comparar(vectorOriginal[vectorIndices[j]], vectorOriginal[indiceActual], ascendente))
            {
                vectorIndices[j + 1] = vectorIndices[j];
                j--;
            }

            vectorIndices[j + 1] = indiceActual;
        }
    }

    static bool Comparar(int a, int b, bool ascendente)
    {
        return ascendente ? a > b : a < b;
    }

    static void Imprimir(string tipo)
    {
        Console.Write($"\nVector ordenado {tipo}: ");
        for (int i = 0; i < n; i++)
        {
            Console.Write(vectorOriginal[vectorIndices[i]] + " ");
        }
        Console.WriteLine();

        Console.Write("Vector de índices:               ");
        for (int i = 0; i < n; i++)
        {
            Console.Write(vectorIndices[i] + " ");
        }
        Console.WriteLine();
    }
}

// ==============================
// PARTE 3: JUSTIFICACIÓN
// ==============================
//
// 1. Cambios realizados respecto a la solución original:
// - Se separó la lógica en métodos con nombres descriptivos (LeerDatos,
//   InicializarIndices, GenerarVectorIndicesAscendente, etc.) para mejorar
//   la legibilidad y el principio de responsabilidad única.
// - Se evitó la duplicación de código: la inicialización del vector de índices
//   se centraliza en el método InicializarIndices(), reutilizado antes de cada
//   ordenamiento.
// - Se eliminaron "magic numbers" y variables poco descriptivas.
// - Se unificó la impresión en un solo método ImprimirOrdenado() parametrizado.
//
// 2. Decisiones de diseño:
// - Se usaron variables estáticas de clase para compartir estado entre métodos
//   sin pasar parámetros excesivos, manteniendo el código limpio para un programa
//   de consola de alcance reducido.
// - El vector original NUNCA se modifica: todo el ordenamiento se hace
//   exclusivamente sobre el vector de índices (vectorIndices), cumpliendo
//   estrictamente la restricción del enunciado.
// - No se realizaron copias del vector original ni por elemento ni en bloque.
// - Se usó Selection Sort en la parte 1 por su claridad conceptual: siempre
//   busca el mínimo/máximo entre los índices restantes y lo coloca en su posición.
//
// 3. Explicación del nuevo algoritmo (Insertion Sort - Parte 2):
// - Se utiliza Insertion Sort como estrategia alternativa de ordenamiento.
// - En lugar de buscar el mínimo (como Selection Sort), toma cada índice uno
//   por uno (desde la posición 1) y lo "inserta" en la posición correcta dentro
//   de la parte ya ordenada del vector de índices.
// - La comparación se hace entre los VALORES del vector original accedidos
//   mediante los índices: vectorOriginal[vectorIndices[j]] vs vectorOriginal[indiceActual].
// - Un método Comparar() con parámetro booleano permite reutilizar la misma
//   lógica para orden ascendente y descendente, evitando duplicación de código.
// - Este algoritmo es eficiente para arreglos casi ordenados (O(n) en el mejor
//   caso) y es estable, lo que lo diferencia conceptualmente del Selection Sort.
