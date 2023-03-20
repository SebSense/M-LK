``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2728/22H2/2022Update)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2 DEBUG
  DefaultJob : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2


```
|                      Method |      Mean |    Error |    StdDev |    Median | Allocated |
|---------------------------- |----------:|---------:|----------:|----------:|----------:|
|       String_array_for_loop |  41.62 μs | 1.091 μs |  3.111 μs |  40.31 μs |         - |
| String_array_for_loop_novar |  38.83 μs | 0.772 μs |  2.112 μs |  38.14 μs |         - |
|   String_array_foreach_loop |  41.58 μs | 1.720 μs |  4.990 μs |  39.78 μs |         - |
| String_array_ForEach_method | 241.09 μs | 6.891 μs | 19.882 μs | 231.67 μs |         - |
