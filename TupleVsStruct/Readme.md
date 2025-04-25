## Tuple vs Struct ##

Benchmarks to see the difference between using a Point struct and an (int x, int y) tuple. This was a curiosity
raised when solving Advent Of Code problems.

The benchmarks show that there is no difference between using either. However, if size permits, (i.e. no stack
overflow) using stackalloc is faster with no memory allocation.

| Method                   | Mean     | Error    | StdDev   | Median   | Gen0   | Allocated |
|------------------------- |---------:|---------:|---------:|---------:|-------:|----------:|
| GetPointsStruct          | 82.50 ns | 1.666 ns | 1.711 ns | 82.28 ns | 0.1312 |     824 B |
| GetPointsTuple           | 83.26 ns | 1.635 ns | 2.008 ns | 82.61 ns | 0.1312 |     824 B |
| GetPointsStackAllocTuple | 59.98 ns | 1.240 ns | 2.037 ns | 61.20 ns |      - |         - |

Note// Because of the size restriction for the use of stackalloc, it will only be useful for repeated small
allocations. Advent of Code usually requires the allocation of many points in a Dykstra's formula.