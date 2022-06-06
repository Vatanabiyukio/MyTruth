using System.Diagnostics;

namespace SortOnDemilich.Others;

public static class HeapSortAlgorithm
{
    public static long HeapSort(int[] arr, int n)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        for (var i = n / 2 - 1; i >= 0; i--)
            Heapify(arr, n, i);
        for (var i = n - 1; i >= 0; i--)
        {
            (arr[0], arr[i]) = (arr[i], arr[0]);
            Heapify(arr, i, 0);
        }
        stopwatch.Stop();
        Console.WriteLine("[H] Elapsed Time is {0} tick", stopwatch.ElapsedTicks);
        return stopwatch.ElapsedTicks;
    }

    private static void Heapify(IList<int> arr, int n, int i)
    {
        while (true)
        {
            var largest = i;
            var left = 2 * i + 1;
            var right = 2 * i + 2;

            if (left < n && arr[left] > arr[largest]) largest = left;
            if (right < n && arr[right] > arr[largest]) largest = right;
            if (largest != i)
            {
                (arr[i], arr[largest]) = (arr[largest], arr[i]);
                i = largest;
                continue;
            }
            
            break;
        }
    }
}