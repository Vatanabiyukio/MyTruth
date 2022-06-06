using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FloorOnDemilich;
using Microsoft.VisualBasic.CompilerServices;

var random = new Random();
var listaInicial = new List<int>();
// var vetorInicial = Enumerable.Range(0, random.Next(1, (int)Math.Pow(10, 1))).Select(_ => random.Next(1000)).Distinct().ToList();
var stopwatch = new Stopwatch();
stopwatch.Start();
var vetorInicial = Enumerable.Range(0, (int)Math.Pow(10, 4)).Select(_ => random.Next((int)Math.Pow(10, 6))).Distinct().ToList();
stopwatch.Stop();

Console.WriteLine("[B] Elapsed Time is {0} Milliseconds", stopwatch.ElapsedMilliseconds);

stopwatch.Start();

/*foreach (var item in vetorInicial)
{
    SqrtSort.InsertNode(listaInicial, item);
}*/

var tamanhoMáximoCadaParte = (int)Math.Truncate(Math.Sqrt(vetorInicial.Count));
try
{
    var listaQuebrada = vetorInicial.Chunk(tamanhoMáximoCadaParte).ToList();
    var listaOrdenada = new List<int>();
    while (true)
    {
        // listaQuebrada = listaQuebrada.Select(SqrtSort.BubbleSort).ToList();
        var peixe = listaQuebrada.Select(item => SqrtSort.MakeHeap(item)).ToList();
        listaQuebrada = peixe;
        // var valorMáximoDisponível = listaQuebrada.Select(lista => lista.Max()).Max();
        var valorMáximoDisponível = listaQuebrada.Select(lista => lista.Last()).Max();
        var listaTemporária2 = new List<int[]>();
        var listaTemporária = new List<int>();
        /*foreach (var listaExterna in listaQuebrada)
        {
            if (!listaExterna.Contains(valorMáximoDisponível))
            {
                listaTemporária2.Add(listaExterna);
                continue;
            }
        
            listaTemporária.AddRange(listaExterna.Where(listaInterna => listaInterna != valorMáximoDisponível));
            listaTemporária2.Add(listaTemporária.ToArray());
        }
        listaQuebrada = listaTemporária2.Where(x => x.Any()).ToList();
        listaOrdenada.Add(valorMáximoDisponível);
        if (!listaQuebrada.Any())
        {
            stopwatch.Stop();
            
            foreach (var item in listaOrdenada)
            {
                Console.WriteLine(item);
            }
            break;
        }*/
    }
    Console.WriteLine("[O] Elapsed Time is {0} Milliseconds", stopwatch.ElapsedMilliseconds);
}
catch (Exception e)
{
    Console.WriteLine(e);
}

namespace FloorOnDemilich
{
    internal static class SqrtSort
    {
        private static IEnumerable<int> RangePython(int start, int stop, int step = 1)
        {
            if (step == 0)
                throw new ArgumentException("Parameter step cannot equal zero.");

            if (start < stop && step > 0)
            {
                for (var i = start; i < stop; i += step)
                {
                    yield return i;
                }
            }
            else if (start > stop && step < 0)
            {
                for (var i = start; i > stop; i += step)
                {
                    yield return i;
                }
            }
        }

        private static List<int> Heapify(List<int> arr, int size, int element)
        {
            while (true)
            {
                var largest = element;
                var left = 2 * element + 1;
                var right = 2 * element + 2;

                if (left < size && arr[element] < arr[left]) largest = left;
                if (right < size && arr[largest] < arr[right]) largest = right;
                if (largest != element)
                {
                    (arr[element], arr[largest]) = (arr[largest], arr[element]);
                    element = largest;
                    continue;
                }

                break;
            }
            return arr;
        }

        public static void InsertNode(List<int> arr, int newElement)
        {
            arr.Add(newElement);
            foreach (var element in RangePython((arr.Count - 1) / 2 - 1, -1, -1))
            {
                Heapify(arr, arr.Count, element);
            }
        }

        public static int[] MakeHeap(int[] arr)
        {
            var peixe = new List<int>();
            foreach (var item in arr)
            {
                InsertNode(peixe, item);
            }
            return peixe.ToArray();
        }

        public static List<int> RemoveNode(List<int> arr, int remElement)
        {
            var i = Enumerable.Range(0, arr.Count).TakeWhile(index => remElement != arr[index]).Count();
            (arr[i], arr[^1]) = (arr[^1], arr[i]);

            arr.Remove(remElement);

            foreach (var index in RangePython(arr.Count / 2 - 1, -1, -1))
            {
                Heapify(arr, arr.Count, index);
            }

            return arr;
        }

        public static bool CheckMaxHeap(List<int> nums)
        {
            for (var i = 0; i < nums.Count; ++i)
            {
                if (2 * i + 1 < nums.Count && nums[i] < nums[i * 2 + 1])
                {
                    return false;
                }

                if (2 * i + 2 < nums.Count && nums[i] < nums[i * 2 + 2])
                {
                    return false;
                }
            }

            return true;
        }

        public static List<int> BubbleSort(List<int> arr)
        {
            for (var j = 0; j <= arr.Count - 2; j++)
            {
                for (var i = 0; i <= arr.Count - 2; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        (arr[i + 1], arr[i]) = (arr[i], arr[i + 1]);
                    }
                }
            }

            return arr;
        }
    }
}