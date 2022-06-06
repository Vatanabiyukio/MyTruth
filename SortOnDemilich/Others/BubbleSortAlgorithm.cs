using System.Diagnostics;

namespace SortOnDemilich.Others;

public static class BubbleSortAlgorithm
{
    public static long BubbleSort(int[] arr)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
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
        stopwatch.Stop();
        Console.WriteLine("[B] Elapsed Time is {0} tick", stopwatch.ElapsedTicks);
        return stopwatch.ElapsedTicks;
    }
}