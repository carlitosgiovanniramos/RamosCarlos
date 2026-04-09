namespace Examen_Primer_Parcial_Software;


class Program
{
    // ===================================
    // PARTE 1: SOLUCIÓN REFACTORIZADA
    // ===================================
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

    
    static void InicializarIndices()
    {
        for (int i = 0; i < n; i++)
        {
            vectorIndices[i] = i;
        }
    }


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
            int temp = vectorIndices[i];
            vectorIndices[i] = vectorIndices[posMin];
            vectorIndices[posMin] = temp;
        }
    }

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
            int temp = vectorIndices[i];
            vectorIndices[i] = vectorIndices[posMax];
            vectorIndices[posMax] = temp;
        }
    }

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