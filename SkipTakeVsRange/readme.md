## Skip Take vs Range ##

Provides a set of benchmarks to compare the use of skip/take vs a range.

The Range parameter was slightly faster and used a bit less memory, but this is negligible so use either according to taste.

| Method               | N   | Mean     | Error    | StdDev   | Median   | Gen0   | Allocated |
|--------------------- |---- |---------:|---------:|---------:|---------:|-------:|----------:|
| GetLastNamesSkipTake | 10  | 71.04 ns | 1.483 ns | 3.582 ns | 73.41 ns | 0.0305 |     192 B |
| GetLastNamesRange    | 10  | 64.54 ns | 1.344 ns | 3.371 ns | 66.50 ns | 0.0229 |     144 B |
| GetLastNamesSkipTake | 100 | 72.23 ns | 1.501 ns | 3.507 ns | 73.63 ns | 0.0305 |     192 B |
| GetLastNamesRange    | 100 | 65.71 ns | 1.373 ns | 3.235 ns | 67.37 ns | 0.0229 |     144 B |

