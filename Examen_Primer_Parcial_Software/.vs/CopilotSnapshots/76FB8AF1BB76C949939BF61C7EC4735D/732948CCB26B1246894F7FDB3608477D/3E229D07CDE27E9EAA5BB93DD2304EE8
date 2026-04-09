namespace Examen_Primer_Parcial_Software;


class Program
{
  static void Main(string[] args)
  {
    int n, i = 0, k = 0;

    Console.Write("Ingrese tamaño del vector: ");
    n = int.Parse(Console.ReadLine());

    int[] v = new int[n];
    int[] v2 = new int[n];
    bool[] b = new bool[n];

    // ingreso de datos
    while (i < n)
    {
      Console.Write("Ingrese valor [" + i + "]: ");
      v[i] = int.Parse(Console.ReadLine());
      i++;
    }

    // ORDENAMIENTO ASCENDENTE
    k = 0;
    while (k < n)
    {
      int m = 999999;
      int pos = -1;

      for (i = 0; i < n; i++)
      {
        if (b[i] == false)
        {
          if (v[i] < m)
          {
            m = v[i];
            pos = i;
          }
        }
      }

      v2[k] = pos;
      b[pos] = true;
      k++;
    }

    Console.WriteLine("\nVector ordenado ascendente:");
    for (i = 0; i < n; i++)
    {
      Console.WriteLine(v[v2[i]]);
    }

    // reiniciar marcas
    for (i = 0; i < n; i++)
    {
      b[i] = false;
    }

    // ORDENAMIENTO DESCENDENTE
    k = 0;
    while (k < n)
    {
      int m = -999999;
      int pos = -1;

      for (i = 0; i < n; i++)
      {
        if (b[i] == false)
        {
          if (v[i] > m)
          {
            m = v[i];
            pos = i;
          }
        }
      }

      v2[k] = pos;
      b[pos] = true;
      k++;
    }

    Console.WriteLine("\nVector ordenado descendente:");
    for (i = 0; i < n; i++)
    {
      Console.WriteLine(v[v2[i]]);
    }
  }
}

