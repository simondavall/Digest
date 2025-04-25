using System.Drawing;
using BenchmarkDotNet.Attributes;
using Bogus;

namespace TupleVsStruct;

[MemoryDiagnoser]
public class Benchmarks {
    
    [Benchmark]
    public Point GetPointsStruct() {
        var points = new Point[100];
        for (var i = 0; i < 10; i++) {
            for (var j = 0; j < 10; j++) {
                points[i] = new Point { X = i, Y = j };
            }
        }
        return points[40];
    }

    [Benchmark]
    public (int, int) GetPointsTuple() {
        var points = new (int x, int y)[100];
        for (var i = 0; i < 10; i++) {
            for (var j = 0; j < 10; j++) {
                points[i] = new ValueTuple<int, int>(i, j);
            }
        }
        return points[40];
    }
    
    [Benchmark]
    public (int, int) GetPointsStackAllocTuple() {
        Span<(int, int)> points = stackalloc (int x, int y)[100];
        for (var i = 0; i < 10; i++) {
            for (var j = 0; j < 10; j++) {
                points[i] = new ValueTuple<int, int>(i, j);
            }
        }
        return points[40];
    }
}