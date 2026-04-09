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

    // Retorna true si se debe desplazar (el elemento está fuera de lugar)
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

