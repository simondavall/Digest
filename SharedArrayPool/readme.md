## Shared Array Pool ##

Provides a set of benchmarks to compare a normal array to a shared array pool.

The array pool is slightly faster, and allocates no heap memory.

| Method           | Mean     | Error   | StdDev  | Gen0   | Allocated |
|----------------- |---------:|--------:|--------:|-------:|----------:|
| UsingNormalArray | 677.4 ns | 5.70 ns | 5.33 ns | 0.1669 |    1048 B |
| UsingArrayPool   | 604.1 ns | 4.57 ns | 4.05 ns |      - |         - |
