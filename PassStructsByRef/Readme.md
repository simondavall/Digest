## Pass Structs By Ref ##

Benchmarking to compare various different methods of passing structs and the effect on performance.

Despite various attempts, I cannot seem to get a perf difference passing by ref and not. I think I
must be doing something wrong.

Will revisit this at some point.

| Method                    | Mean     | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |---------:|----------:|----------:|-------:|-------:|----------:|
| UsingNormalStruct         | 3.047 us | 0.0509 us | 0.0425 us | 0.7668 | 0.0038 |   4.71 KB |
| UsingReadonlyStruct       | 3.033 us | 0.0387 us | 0.0302 us | 0.7668 | 0.0038 |   4.71 KB |
| UsingReadonlyStructWithIn | 3.025 us | 0.0351 us | 0.0311 us | 0.7668 | 0.0038 |   4.71 KB |
