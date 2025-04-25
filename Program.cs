using System;
using System.Diagnostics;
using System.Runtime;

class Program
{
    static void Main()
    {
        Console.WriteLine("===== GC Performance Test =====");
        Console.WriteLine($"GC-läge: {(GCSettings.IsServerGC ? "Server GC" : "Workstation GC")}");
        Console.WriteLine($"Process-ID (för dotnet-counters): {Environment.ProcessId}");
        Console.WriteLine();

        RunSmallObjectTest();
        Console.WriteLine();
        RunLargeObjectTest();

        Console.WriteLine("\nTesterna är slutförda.");
    }

    static void RunSmallObjectTest()
    {
        Console.WriteLine("== Test: Små objekt ==");

        GC.Collect();
        var sw = Stopwatch.StartNew();

        for (int i = 0; i < 1_000_000; i++)
        {
            var obj = new object();
        }

        sw.Stop();
        Console.WriteLine($"Exekveringstid (små objekt): {sw.ElapsedMilliseconds} ms");
        Console.WriteLine($"Minnesanvändning: {GC.GetTotalMemory(false) / (1024 * 1024)} MB");
    }

    static void RunLargeObjectTest()
    {
        Console.WriteLine("== Test: Stora objekt (LOH) ==");

        GC.Collect();
        var sw = Stopwatch.StartNew();

        for (int i = 0; i < 5000; i++)
        {
            var buffer = new byte[100_000]; // >85 KB → LOH
        }

        sw.Stop();
        Console.WriteLine($"Exekveringstid (stora objekt): {sw.ElapsedMilliseconds} ms");
        Console.WriteLine($"Minnesanvändning: {GC.GetTotalMemory(false) / (1024 * 1024)} MB");
    }
}
