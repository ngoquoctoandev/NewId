``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1265/22H2/2022Update/SunValley2)
13th Gen Intel Core i9-13900K, 1 CPU, 32 logical and 24 physical cores
.NET SDK=7.0.200
  [Host]     : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2 [AttachedDebugger]
  Job-JNBMWJ : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2

Runtime=.NET 7.0  Force=True  Server=True  

```
|             Method |      Mean |     Error |    StdDev | Ratio | Allocated | Alloc Ratio |
|------------------- |----------:|----------:|----------:|------:|----------:|------------:|
|               Next | 28.819 ns | 0.0391 ns | 0.0346 ns |  1.00 |         - |          NA |
|        Next(batch) |  2.560 ns | 0.0484 ns | 0.0908 ns |  0.09 |      16 B |          NA |
|           NextGuid | 29.028 ns | 0.0161 ns | 0.0125 ns |  1.01 |         - |          NA |
| NextSequentialGuid | 28.758 ns | 0.0117 ns | 0.0097 ns |  1.00 |         - |          NA |
