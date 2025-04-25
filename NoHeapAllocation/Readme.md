## No Heap Allocation ##

Provides a set of benchmarks using three types of collection
List<int>
int[]
Span<int>
The span is stack allocated.

The benchmarks show the span to be quicker and use less (zero) heap memory.
This results in no garbage collection activity.

The List with .Add() is the worst performer by far.

| Method             | Mean      | Error    | StdDev   | Median    | Gen0   | Gen1   | Allocated |
|------------------- |----------:|---------:|---------:|----------:|-------:|-------:|----------:|
| GetUsingList       | 266.92 ns | 5.283 ns | 9.922 ns | 273.10 ns | 0.1884 | 0.0005 |    1184 B |
| GetUsingArray      |  51.08 ns | 0.660 ns | 0.617 ns |  50.80 ns | 0.0675 |      - |     424 B |
| GetUsingStackAlloc |  37.14 ns | 0.404 ns | 0.378 ns |  37.22 ns |      - |      - |         - |
