using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using FloorOnDemilich;


var random = new Random();
var stopwatch = new Stopwatch();
const int potência = 3;
var vetorInicial = Enumerable.Range(0, (int)Math.Pow(10, 7))
        .Select(_ => random.Next((int)Math.Pow(10, 9))).Distinct().ToList();    // θ(?)
vetorInicial.Sort();
vetorInicial.Reverse();
var tempo = 0;
foreach (var j in Enumerable.Range(0, 10))
{
    var vetor = vetorInicial.Take((int) Math.Pow(10, potência)).ToList();
    stopwatch.Start();
    stopwatch.Stop();
    Console.Write($"{vetor.Count}");
    // Console.WriteLine($"[#] Quantidade de unidades distintas no vetor: {vetor.Count}");
    // Console.WriteLine(
    //     $"[*] Tempo de geração da lista aleatória distinta: {stopwatch.ElapsedMilliseconds} Milissegundos\n");
    // Console.WriteLine($"#=#=#=#=#=#= Método HEAP {j} #=#=#=#=#=#=");
    tempo += SqrtSort.ExecuçãoHeap(vetor);    // θ(n √n)
    // Console.WriteLine("#=#=#=#=##=#=#=#=##=#=#=#=#=#=#=#=#=#\n");
    
    // Console.WriteLine($"#=#=#=#=# Método QUADRÁTICO {j} #=#=#=#=#");
    // tempo += SqrtSort.ExecuçãoMétodoQuadrático(vetorInicial);    // θ(n^2)
    // Console.WriteLine("#=#=#=#=##=#=#=#=##=#=#=#=#=#=#=#=#=#\n");
}
Console.WriteLine(tempo / 10);
GC.Collect();
GC.WaitForPendingFinalizers();

namespace FloorOnDemilich
{
    internal static class SqrtSort
    {
        private static IEnumerable<int> RangePython(int start, int stop, int step = 1)  // θ(start)
        {
            if (step == 0)  // θ(1)
                throw new ArgumentException("Parameter step cannot equal zero.");

            if (start < stop && step > 0)   // θ(1) + θ(start) === θ(start)
            {
                for (var i = start; i < stop; i += step)    // θ(start)
                {
                    yield return i;
                }
            }
            else if (start > stop && step < 0)  // θ(start)
            {
                for (var i = start; i > stop; i += step)
                {
                    yield return i;
                }
            }
        }

        public static void PrintArray(List<int> arr, int n = 0) // θ(n)
        {
            if (n == 0)
                n = arr.Count;
            for (var i = 0; i < n; i++)
                Console.WriteLine(arr[i] + " ");
        }

        private static void Heapify(IList<int> arr, int size, int element)  // θ(log n)
        {
            while (true) // θ(log n)
            {
                var largest = element;  // θ(1)
                var left = 2 * element + 1; // θ(1)
                var right = 2 * element + 2;// θ(1)

                if (left < size && arr[largest] < arr[left]) largest = left;    // θ(1)
                if (right < size && arr[largest] < arr[right]) largest = right; // θ(1)
                if (largest != element) // θ(1)
                {
                    (arr[element], arr[largest]) = (arr[largest], arr[element]);    // θ(1)
                    element = largest;  // θ(1)
                    continue;
                }

                break;
            }
        }

        private static void InsertNode(IList<int> arr, int newElement)  // θ(log n)
        {
            arr.Add(newElement);    // θ(1)
            foreach (var element in RangePython((arr.Count) / 2 - 1, -1, -1))   // θ(log n)
            {
                Heapify(arr, arr.Count, element);   // θ(log n)
            }
        }

        private static List<int> GenerateHeap(IEnumerable<int> arr) // θ(n log n)
        {
            var peixe = new List<int>();
            foreach (var item in arr)   // θ(n)
            {
                InsertNode(peixe, item);    // θ(log n)
            }

            return peixe;
        }

        public static List<int> RemoveNode(List<int> arr, int remElement)   // θ(?)
        {
            var i = Enumerable.Range(0, arr.Count).TakeWhile(index => remElement != arr[index]).Count();    // θ(?)
            (arr[i], arr[^1]) = (arr[^1], arr[i]);  // θ(1)

            arr.Remove(remElement); // θ(1)

            foreach (var index in RangePython(arr.Count / 2 - 1, -1, -1)) // θ(log n)
            {
                Heapify(arr, arr.Count, index); // θ(log n)
            }

            return arr;
        }

        private static void RemoveRootNode(List<int> arr)   // θ(1)
        {
            arr[0] = arr[^1];   // θ(1)
            arr.RemoveAt(arr.Count - 1);    // θ(1)
            Heapify(arr, arr.Count, 0); // θ(log n) se element != 0 senão θ(1)
        }

        private static bool CheckMaxHeap(IReadOnlyList<int> nums)
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

        private static int[] BubbleSort(int[] arr)  // θ(n^2)
        {
            for (var j = 0; j <= arr.Length - 2; j++)   // θ(n)
            {
                for (var i = 0; i <= arr.Length - 2; i++)   // θ(n)
                {
                    if (arr[i] > arr[i + 1])    // θ(1)
                    {
                        (arr[i + 1], arr[i]) = (arr[i], arr[i + 1]);    // θ(1)
                    }
                }
            }

            return arr;
        }

        [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
        public static int ExecuçãoHeap(List<int> vetorInicial)    // θ(n log n) + θ(n √n) === θ(n √n)
        {
            var stopwatch = new Stopwatch();

            // stopwatch.Start();
            // var vetorInicial = Enumerable.Range(0, (int)Math.Pow(10, potência))
            //     .Select(_ => random.Next((int)Math.Pow(10, potência + 2)))
            //     .Distinct().ToList();
            // stopwatch.Stop();
            //
            // Console.WriteLine($"[#] Quantidade de unidades distintas no vetor: {vetorInicial.Count}");
            // Console.WriteLine(
            //     $"[*] Tempo de geração da lista aleatória distinta: {stopwatch.ElapsedMilliseconds} Milissegundos");

            stopwatch.Start();
            var tamanhoMáximoCadaParte = (int)Math.Truncate(Math.Sqrt(vetorInicial.Count)); // θ(1)
            var listaQuebrada = vetorInicial.Chunk(tamanhoMáximoCadaParte).Select(GenerateHeap).ToList();   // θ(n) + θ(n / ⎣√n⎦) * θ(n log n) === θ(n log n)
            stopwatch.Stop();
            // var listaVerificar = listaQuebrada.Any(x => CheckMaxHeap(x.ToList()));
            // if (!listaVerificar)
            //     return;
            var tempo1 = stopwatch.ElapsedMilliseconds;
            // Console.WriteLine(
            //     $"[*] Tempo de criação de sub-listas e ordenação: {stopwatch.ElapsedMilliseconds} Milissegundos");

            stopwatch.Start();
            var listaOrdenada = new List<int>(); // θ(1)
            while (true)    // ( θ(n / ⎣√n⎦) + θ(n / ⎣√n⎦) ) * θ(n) === θ(n^2 / ⎣√n⎦) === θ(n √n)
            {
                try
                {
                    var maiorElementoSubHeaps = listaQuebrada.Select(heap => heap.First()).Max();   // θ(n / ⎣√n⎦) + θ(1) + θ(n / ⎣√n⎦) === θ(n / ⎣√n⎦) === θ(√n)
                    listaOrdenada.Add(maiorElementoSubHeaps);   // θ(1)
                    var listaTemporáriaExterna = new List<List<int>>(); // θ(1)
                    foreach (var heap in listaQuebrada) // θ(n / ⎣√n⎦) * θ(1) === θ(n / ⎣√n⎦) === θ(√n)
                    {
                        if (heap.First() == maiorElementoSubHeaps)  // θ(1)
                        {
                            RemoveRootNode(heap);   // θ(1)
                        }

                        if (heap.Any())
                        {
                            listaTemporáriaExterna.Add(heap); // θ(1)
                        }
                    }

                    listaQuebrada = listaTemporáriaExterna; // θ(1)
                    if (listaQuebrada.Any()) continue;  // θ(1)
                    stopwatch.Stop();

                    // Console.WriteLine("[*] Tempo de execução do Sqrt sort: {0} Milissegundos",
                    //     stopwatch.ElapsedMilliseconds);
                    // Console.WriteLine($"[!] Lista Ordenada: {CheckMaxHeap(listaOrdenada)}");
                    var tempo2 = stopwatch.ElapsedMilliseconds;
                    Console.Write($", {tempo1}, {tempo2}\n");
                    return (int)tempo2 + (int)tempo1;
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    break;
                }
            }

            return 0;
        }

        [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
        public static int ExecuçãoMétodoQuadrático(List<int> vetorInicial) // θ(n^2)
        {
            var stopwatch = new Stopwatch();

            // stopwatch.Start();
            // var vetorInicial = Enumerable.Range(0, (int)Math.Pow(10, potência))
            //     .Select(_ => random.Next((int)Math.Pow(10, potência + 2)))
            //     .Distinct().ToList();
            // stopwatch.Stop();
            //
            // Console.WriteLine($"[#] Quantidade de unidades distintas no vetor: {vetorInicial.Count}");
            // Console.WriteLine(
            //     $"[*] Tempo de geração da lista aleatória distinta: {stopwatch.ElapsedMilliseconds} Milissegundos");

            stopwatch.Start();
            var tamanhoMáximoCadaParte = (int)Math.Truncate(Math.Sqrt(vetorInicial.Count)); // θ(1)
            var listaQuebrada = vetorInicial.Chunk(tamanhoMáximoCadaParte).Select(BubbleSort).ToList(); // θ(n) + θ(n / √n) * θ(n^2) === θ(n^2)
            stopwatch.Stop();
            var tempo1 = stopwatch.ElapsedMilliseconds;
            Console.Write($", {tempo1}, ");
            // Console.WriteLine(
            //     $"[*] Tempo de criação de sub-listas e ordenação: {stopwatch.ElapsedMilliseconds} Milissegundos");

            stopwatch.Start();
            var listaOrdenada = new List<int>();    // θ(1)
            while (true)    // ( θ(n / √n) + θ(n) + θ(n / √n) ) * θ(n) == θ(n^2)
            {
                try
                {
                    listaOrdenada.Add(listaQuebrada.Select(lista => lista.Last()).Max());   // θ(n / √n) + θ(1) + θ(n / √n) + θ(1) == θ(n / √n)
                    var listaTemporáriaExterna = new List<int[]>(); // θ(1)
                    foreach (var listaInterna in listaQuebrada) // θ(n / √n) * θ(√n) === θ(n)
                    {
                        var listaTemporáriaInterna = new List<int>();   // θ(1)
                        if (listaInterna.Contains(listaOrdenada.Last()))    // θ(1)
                        {
                            listaTemporáriaInterna.AddRange(listaInterna.Where(itemInterno =>
                                itemInterno != listaOrdenada.Last()));  // θ(√n) + θ(1) + θ(1) === θ(√n)
                            listaTemporáriaExterna.Add(listaTemporáriaInterna.ToArray()); // θ(1)
                        }
                        else
                        {
                            listaTemporáriaExterna.Add(listaInterna); // θ(1)
                        }
                    }

                    listaTemporáriaExterna = listaTemporáriaExterna.Where(fim => fim.Any()).ToList(); // θ(n / √n)
                    listaQuebrada = listaTemporáriaExterna;
                    if (listaQuebrada.Any()) continue;
                    stopwatch.Stop();
                    var tempo2 = stopwatch.ElapsedMilliseconds;
                    Console.Write($"{tempo2}\n");
                    return (int)tempo1 + (int)tempo2;
                    // Console.WriteLine("[*] Tempo de execução do Sqrt sort: {0} Milissegundos",
                    //     stopwatch.ElapsedMilliseconds);
                    // Console.WriteLine($"[!] Lista Ordenada: {CheckMaxHeap(listaOrdenada)}");
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    break;
                }
            }

            return 0;
        }
    }
}