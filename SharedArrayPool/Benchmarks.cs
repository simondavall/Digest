using System.Buffers;
using BenchmarkDotNet.Attributes;
using Bogus;

namespace SharedArrayPool;

[MemoryDiagnoser]
public class Benchmarks {
    private static readonly int _bufferSize = 1024;

    [Benchmark]
    public int UsingNormalArray() {
        byte[] buffer = new byte[_bufferSize];

        for (int i = 0; i < _bufferSize; i++) {
            buffer[i] = 42;
        }

        int sum = 0;
        for (int i = 0; i < _bufferSize; i++) {
            sum += buffer[i];
        }

        return sum;
    }

    [Benchmark]
    public int UsingArrayPool() {
        var buffer = ArrayPool<int>.Shared.Rent(_bufferSize);

        try {        
            for (int i = 0; i < _bufferSize; i++) {
                buffer[i] = 42;
            }

            int sum = 0;
            for (int i = 0; i < _bufferSize; i++) {
                sum += buffer[i];
                
            } 
            return sum;
        }
        finally {
            ArrayPool<int>.Shared.Return(buffer);
        }
    }
}