using BenchmarkDotNet.Attributes;
using Bogus;

namespace NoHeapAllocation;

[MemoryDiagnoser]
public class Benchmarks {

    [Benchmark]
    public int GetUsingList() {
        var arr = new List<int>();
        
        for (var i = 0; i < 100; i++) {
            arr.Add(i);
        }
        
        return arr[26];
    }
    
    [Benchmark]
    public int GetUsingArray() {
        int[] arr = new int[100];
        
        for (var i = 0; i < 100; i++) {
            arr[i] = i;
        }
        
        return arr[26];
    }

    [Benchmark]
    public int GetUsingStackAlloc() {
        Span<int> data = stackalloc int[100];

        for (var i = 0; i < 100; i++) {
            data[i] = i;
        }
        
        return data[26];
    }
}