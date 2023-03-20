``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2604/22H2/2022Update)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2 DEBUG
  DefaultJob : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2


```
|                                               Method |      Mean |     Error |    StdDev |    Median | Allocated |
|----------------------------------------------------- |----------:|----------:|----------:|----------:|----------:|
|                                BM_SumEvens_Iterative |  7.002 ms | 0.1612 ms | 0.4493 ms |  6.794 ms |       5 B |
|                BM_SumEvens_Iterative_no_len_variable |  6.738 ms | 0.0921 ms | 0.0816 ms |  6.701 ms |       5 B |
|                                BM_SumEvens_Recursive |  5.795 ms | 0.0588 ms | 0.0491 ms |  5.775 ms |       5 B |
|                BM_SumEvens_Recursive_no_len_variable |  6.424 ms | 0.3132 ms | 0.9234 ms |  5.927 ms |       5 B |
| BM_SumEvens_Recursive_no_accumulator_no_len_variable | 12.918 ms | 0.2407 ms | 0.2471 ms | 12.893 ms |      10 B |
|                             BM_SumInverses_Iterative | 10.332 ms | 0.1249 ms | 0.2017 ms | 10.295 ms |      10 B |
|             BM_SumInverses_Iterative_no_len_variable | 10.217 ms | 0.0689 ms | 0.0575 ms | 10.200 ms |      10 B |
|                             BM_SumInverses_Recursive | 10.308 ms | 0.1461 ms | 0.1296 ms | 10.315 ms |      10 B |
|             BM_SumInverses_Recursive_no_len_variable | 10.284 ms | 0.1544 ms | 0.1289 ms | 10.208 ms |      10 B |
