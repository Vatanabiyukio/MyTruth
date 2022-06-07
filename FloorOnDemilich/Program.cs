using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using FloorOnDemilich;


var random = new Random();

for (var j = 0; j < 3; j++)
{
    for (var i = 0; i < 7; i++)
    {
        var vetorInicial = Enumerable.Range(0, (int)Math.Pow(10, i))
            .Select(_ => random.Next((int)Math.Pow(10, 8))).Distinct().ToList();
        Console.WriteLine($"#=#=#=#=#=#= Método HEAP {i} #=#=#=#=#=#=");
        SqrtSort.ExecuçãoHeap(vetorInicial);
        Console.WriteLine("#=#=#=#=##=#=#=#=##=#=#=#=#=#=#=#=#=#\n");
        Console.WriteLine($"#=#=#=#=# Método QUADRÁTICO {i} #=#=#=#=#");
        SqrtSort.ExecuçãoMétodoQuadrático(vetorInicial);
        Console.WriteLine("#=#=#=#=##=#=#=#=##=#=#=#=#=#=#=#=#=#\n");
    }

    j++;
}

GC.Collect();
GC.WaitForPendingFinalizers();

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
        
        public static void PrintArray(List<int> arr, int n=0)
        {
            if (n == 0)
                n = arr.Count;
            for (var i = 0; i < n; i++)
                Console.WriteLine(arr[i] + " ");
        }

        private static List<int> Heapify(List<int> arr, int size, int element)
        {
            while (true)
            {
                var largest = element;
                var left = 2 * element + 1;
                var right = 2 * element + 2;

                if (left < size && arr[largest] < arr[left]) largest = left;
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

        private static void InsertNode(List<int> arr, int newElement)
        {
            
            arr.Add(newElement);
            foreach (var element in RangePython((arr.Count) / 2 - 1, -1, -1))
            {
                Heapify(arr, arr.Count, element);
            }
        }

        public static List<int> MakeHeap(IEnumerable<int> arr)
        {
            var peixe = new List<int>();
            foreach (var item in arr)
            {
                InsertNode(peixe, item);
            }

            return peixe;
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

        public static void RemoveRootNode(List<int> arr)
        {
            arr[0] = arr[^1];
            arr.RemoveAt(arr.Count-1);
            Heapify(arr, arr.Count, 0);
        }

        public static bool CheckMaxHeap(List<int> nums)
        {
            var n = nums.Count;
            foreach (var i in Enumerable.Range(0, n))
            {
                var m = i * 2;
                var num = nums.ElementAt(i);
                if (m + 1 < n)
                {
                    if (num < nums.ElementAt(m + 1))
                    {
                        return false;
                    }
                }

                if (m + 2 < n)
                {
                    if (num < nums.ElementAt(m + 2))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /*public static bool CheckMaxHeap(List<int> nums)
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
        }*/

        private static int[] BubbleSort(int[] arr)
        {
            for (var j = 0; j <= arr.Length - 2; j++)
            {
                for (var i = 0; i <= arr.Length - 2; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        (arr[i + 1], arr[i]) = (arr[i], arr[i + 1]);
                    }
                }
            }

            return arr;
        }

        [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
        public static void ExecuçãoHeap(List<int> vetorInicial)
        {
            var random = new Random();
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
            var tamanhoMáximoCadaParte = (int)Math.Truncate(Math.Sqrt(vetorInicial.Count));
            var listaQuebrada = vetorInicial.Chunk(tamanhoMáximoCadaParte).Select(MakeHeap).ToList();
            var listaVerificar = listaQuebrada.Any(x => CheckMaxHeap(x.ToList()));
            stopwatch.Stop();
            if (!listaVerificar)
                return;
            
            Console.WriteLine($"[*] Tempo de criação de sub-listas e ordenação: {stopwatch.ElapsedMilliseconds} Milissegundos");
            
            stopwatch.Start();
            var listaOrdenada = new List<int>();
            while (true)
            {
                try
                {
                    var maiorElementoSubHeaps = listaQuebrada.Select((heap, index) => heap.First()).Max();
                    listaOrdenada.Add(maiorElementoSubHeaps);
                    var listaTemporáriaExterna = new List<List<int>>();
                    foreach (var heap in listaQuebrada)
                    {
                        if (heap.First() == maiorElementoSubHeaps)
                        {
                            RemoveRootNode(heap);
                        }
                        listaTemporáriaExterna.Add(heap);
                    }

                    listaTemporáriaExterna = listaTemporáriaExterna.Where(fim => fim.Any()).ToList();
                    listaQuebrada = listaTemporáriaExterna;
                    if (listaQuebrada.Any()) continue;
                    stopwatch.Stop();
                        
                    Console.WriteLine("[*] Tempo de execução do Sqrt sort: {0} Milissegundos", stopwatch.ElapsedMilliseconds);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    break;
                }
            }
        }

        [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
        public static void ExecuçãoMétodoQuadrático(List<int> vetorInicial)
        {
            var random = new Random();
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
            var tamanhoMáximoCadaParte = (int)Math.Truncate(Math.Sqrt(vetorInicial.Count));
            var listaQuebrada = vetorInicial.Chunk(tamanhoMáximoCadaParte).Select(BubbleSort).ToList();
            stopwatch.Stop();

            Console.WriteLine(
                $"[*] Tempo de criação de sub-listas e ordenação: {stopwatch.ElapsedMilliseconds} Milissegundos");

            stopwatch.Start();
            var listaOrdenada = new List<int>();
            while (true)
            {
                try
                {
                    listaOrdenada.Add(listaQuebrada.Select(lista => lista.Last()).Max());
                    var listaTemporáriaExterna = new List<int[]>();
                    foreach (var listaInterna in listaQuebrada)
                    {
                        var listaTemporáriaInterna = new List<int>();
                        if (listaInterna.Contains(listaOrdenada.Last()))
                        {
                            listaTemporáriaInterna.AddRange(listaInterna.Where(itemInterno =>
                                itemInterno != listaOrdenada.Last()));
                        }
                        else
                        {
                            listaTemporáriaExterna.Add(listaInterna);
                        }

                        listaTemporáriaExterna.Add(listaTemporáriaInterna.ToArray());
                    }

                    listaTemporáriaExterna = listaTemporáriaExterna.Where(fim => fim.Any()).ToList();
                    listaQuebrada = listaTemporáriaExterna;
                    if (listaQuebrada.Any()) continue;
                    stopwatch.Stop();

                    Console.WriteLine("[*] Tempo de execução do Sqrt sort: {0} Milissegundos",
                        stopwatch.ElapsedMilliseconds);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    break;
                }
            }
            /*foreach (var itemOrdenado in listaOrdenada)
            {
                Console.WriteLine(itemOrdenado);
            }*/
        }
    }
}