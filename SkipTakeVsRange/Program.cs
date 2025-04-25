// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using SkipTakeVsRange;

BenchmarkRunner.Run<Benchmarks>();

//
// using SkipTakeVsRange;
//
// var benchmarks = new Benchmarks();
//
// var result1 = benchmarks.GetLastNamesSkipTake();
// Console.WriteLine(string.Join(',', result1));
// var result2 = benchmarks.GetLastNamesRange();
// Console.WriteLine(string.Join(',', result2));