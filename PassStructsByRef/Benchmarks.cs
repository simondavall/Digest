using BenchmarkDotNet.Attributes;

namespace PassStructsByRef;

[MemoryDiagnoser]
public class Benchmarks {

    [Benchmark]
    public int UsingNormalStruct() {
        var points = new MutablePoint[100];
        for (var i = 0; i < 10; i++) {
            for (var j = 0; j < 10; j++) {
                points[i + j] = new MutablePoint(i, j);
            }
        }
        var result = 0;
        for (var i = 0; i < points.Length; ++i) {
            result += GetNewX(points[i]);
        }
        return result;
    }

    [Benchmark]
    public int UsingReadonlyStruct() {
        var points = new ReadOnlyPoint[100];
        for (var i = 0; i < 10; i++) {
            for (var j = 0; j < 10; j++) {
                points[i + j] = new ReadOnlyPoint(i, j);
            }
        }
        var result = 0;
        for (var i = 0; i < points.Length; ++i) {
            result += GetNewX(points[i]);
        }
        return result;
    }
    
    [Benchmark]
    public int UsingReadonlyStructWithIn() {
        var points = new ReadOnlyPoint[100];
        for (var i = 0; i < 10; i++) {
            for (var j = 0; j < 10; j++) {
                points[i + j] = new ReadOnlyPoint(i, j);
            }
        }
        
        var result = 0;
        for (var i = 0; i < points.Length; ++i) {
            result += GetNewXWithIn(points[i]);
        }
        return result;
    }

    private int GetNewX(MutablePoint point) {
        return point.X + 1;
    }
    
    private int GetNewX(ReadOnlyPoint point) {
        return point.X + 1;
    }
    
    private int GetNewXWithIn(in ReadOnlyPoint point) {
        return point.X + 1;
    }
    
    private struct MutablePoint (int x, int y) {
        public int X = x;
        public int Y = y;
        public string Name = $"{x}, {y}";
    }
    
    private readonly struct ReadOnlyPoint (int x, int y) {
        public readonly int X = x;
        public readonly int Y = y;
        public readonly string Name = $"{x}, {y}";
    }
}