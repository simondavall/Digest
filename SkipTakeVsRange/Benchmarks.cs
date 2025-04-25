using BenchmarkDotNet.Attributes;
using Bogus;

namespace SkipTakeVsRange;

[MemoryDiagnoser]
public class Benchmarks {

    private static readonly List<string> TestData = GetTestData(10);

    [Benchmark]
    public List<string> GetLastNamesSkipTake() {
        return TestData.Skip(2).Take(5).ToList();
    }
    
    [Benchmark]
    public List<string> GetLastNamesRange() {
        return TestData.Take(2..7).ToList();
    }
    
    private static List<string> GetTestData(int n) {
        var data = new List<string>();

        //Set the randomizer seed if you wish to generate repeatable data sets.
        Randomizer.Seed = new Random(42069);

        var faker = new Faker();
        for (var i = 0; i < n; i++) {
            data.Add(faker.Name.LastName());
        }
        return data;
    }
}