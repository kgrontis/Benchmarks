using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

namespace Benchmarks;

[MemoryDiagnoser]
[HardwareCounters(
        HardwareCounter.BranchMispredictions,
        HardwareCounter.BranchInstructions)]
[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net70, baseline: true)]
[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net60)]
public class SumBenchmark
{
    int[] arr = null!;
    [Params(5, 10, 25)]
    public int ArraySize { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        arr = new int[ArraySize];
        for (var i = 0; i < arr.Length; i++)
        {
            arr[i] = Random.Shared.Next(1, 10);
        }
    }

    [Benchmark(Baseline = true)]
    public int SumWithForLoop()
    {
        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum;
    }

    [Benchmark]
    public int SumWithWhileLoop()
    {
        int sum = 0;
        int counter = 0;
        while (counter < arr.Length)
        {
            sum = arr[counter];
            counter++;
        }
        return sum;
    }

    [Benchmark]
    public int SumWithLinqSum()
    {
        return arr.Sum();
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        // cleanup logic
        arr = Array.Empty<int>();
    }
}