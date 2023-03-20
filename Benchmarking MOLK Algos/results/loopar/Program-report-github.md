``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2604/22H2/2022Update)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2 DEBUG
  DefaultJob : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2


```
|                      Method |           Mean |         Error |         StdDev |         Median | Allocated |
|---------------------------- |---------------:|--------------:|---------------:|---------------:|----------:|
|         Bool_array_for_loop |  33,454.030 ns |   665.4212 ns |  1,832.7634 ns |  32,793.500 ns |         - |
|   Bool_array_for_loop_novar |  31,909.607 ns |   507.9431 ns |    424.1555 ns |  32,127.820 ns |         - |
|     Bool_array_foreach_loop |  35,158.557 ns | 1,692.6355 ns |  4,990.7739 ns |  32,400.488 ns |         - |
|   Bool_array_ForEach_method | 224,365.551 ns | 2,523.7815 ns |  2,107.4718 ns | 225,170.520 ns |         - |
|          Bool_list_for_loop |  32,061.220 ns |   520.1242 ns |    434.3272 ns |  32,214.752 ns |         - |
|    Bool_list_for_loop_novar |  31,927.662 ns |   610.8195 ns |    678.9243 ns |  31,598.123 ns |         - |
|      Bool_list_foreach_loop | 155,916.033 ns | 3,057.4397 ns |  2,859.9310 ns | 154,483.557 ns |         - |
|    Bool_list_ForEach_method | 222,952.921 ns | 3,246.8031 ns |  2,878.2064 ns | 223,290.417 ns |         - |
|          Int_array_for_loop |  31,933.091 ns |   409.3070 ns |  1,026.8713 ns |  31,594.849 ns |         - |
|    Int_array_for_loop_novar |  31,843.448 ns |   628.3149 ns |    860.0446 ns |  31,482.251 ns |         - |
|      Int_array_foreach_loop |  36,343.861 ns | 1,922.5814 ns |  5,668.7746 ns |  32,578.275 ns |         - |
|    Int_array_ForEach_method | 193,376.750 ns | 3,715.9227 ns |  4,130.2382 ns | 194,005.664 ns |         - |
|           Int_list_for_loop |  32,158.996 ns |   485.2169 ns |    823.9352 ns |  32,127.032 ns |         - |
|     Int_list_for_loop_novar |  31,972.721 ns |   630.9666 ns |    675.1271 ns |  32,057.886 ns |         - |
|       Int_list_foreach_loop | 114,300.926 ns | 1,561.8278 ns |  1,384.5197 ns | 113,715.900 ns |         - |
|     Int_list_ForEach_method | 223,632.481 ns | 2,858.3238 ns |  2,386.8298 ns | 222,402.063 ns |         - |
|       String_array_for_loop |  31,967.353 ns |   620.8862 ns |    762.5040 ns |  31,894.061 ns |         - |
| String_array_for_loop_novar |  34,943.674 ns | 1,718.7153 ns |  5,040.6946 ns |  32,353.598 ns |         - |
|   String_array_foreach_loop |  31,849.494 ns |   627.8734 ns |    616.6556 ns |  31,571.600 ns |         - |
| String_array_ForEach_method | 225,283.739 ns | 2,264.3398 ns |  2,223.8845 ns | 224,358.911 ns |         - |
|        String_list_for_loop |  31,816.219 ns |   612.8944 ns |    629.3974 ns |  31,500.226 ns |         - |
|  String_list_for_loop_novar |  31,674.006 ns |   469.4698 ns |    439.1423 ns |  31,405.908 ns |         - |
|    String_list_foreach_loop | 155,373.317 ns | 2,192.2539 ns |  1,943.3760 ns | 154,579.333 ns |         - |
|  String_list_ForEach_method | 266,610.569 ns | 5,205.5409 ns | 12,963.6032 ns | 262,751.538 ns |         - |
|       Object_array_for_loop |  32,201.766 ns |   642.2304 ns |    961.2603 ns |  32,207.382 ns |         - |
| Object_array_for_loop_novar |  32,157.553 ns |   466.6114 ns |    413.6389 ns |  32,190.854 ns |         - |
|   Object_array_foreach_loop |  32,194.856 ns |   638.9860 ns |  1,347.8384 ns |  31,983.646 ns |         - |
| Object_array_ForEach_method | 225,135.949 ns | 3,851.7124 ns |  3,216.3543 ns | 225,007.324 ns |         - |
|        Object_list_for_loop |  31,811.244 ns |   622.5513 ns |    764.5489 ns |  31,493.530 ns |         - |
|  Object_list_for_loop_novar |  31,647.510 ns |   460.3966 ns |    511.7296 ns |  31,429.620 ns |         - |
|    Object_list_foreach_loop | 153,815.273 ns | 3,067.4140 ns |  2,719.1826 ns | 155,007.117 ns |         - |
|  Object_list_ForEach_method | 224,677.912 ns | 3,166.6512 ns |  2,644.2971 ns | 223,132.483 ns |         - |
|         Wordstring_for_loop |       3.325 ns |     0.0974 ns |      0.0957 ns |       3.276 ns |         - |
|   Wordstring_for_loop_novar |       3.366 ns |     0.1004 ns |      0.0986 ns |       3.315 ns |         - |
|     Wordstring_foreach_loop |       3.375 ns |     0.1022 ns |      0.1049 ns |       3.313 ns |         - |
|        Shortstring_for_loop |      49.184 ns |     0.8388 ns |      1.5337 ns |      48.670 ns |         - |
|  Shortstring_for_loop_novar |      48.829 ns |     0.9962 ns |      1.0230 ns |      49.204 ns |         - |
|                             |                |               |                |                |         - |
|         Longstring_for_loop |  92,190.367 ns | 1,830.6021 ns |  2,443.8013 ns |  90,939.130 ns |         - |
|   Longstring_for_loop_novar |  91,858.463 ns | 1,828.2228 ns |  1,956.1779 ns |  90,650.037 ns |         - |
|     Longstring_foreach_loop |  92,428.178 ns | 1,521.0076 ns |  1,422.7515 ns |  92,998.749 ns |         - |
