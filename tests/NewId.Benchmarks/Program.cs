using BenchmarkDotNet.Running;

namespace MassTransit.Benchmarks;

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<Benchmarker>();
    }
}
