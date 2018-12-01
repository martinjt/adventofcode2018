using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace day1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var lines = await File.ReadAllLinesAsync("input.txt");
            var logic = new Logic();
            Console.WriteLine($"Frequency is {logic.GetResult(lines)}");
            Console.WriteLine($"Repeated Frequency is {logic.GetRepeatedResult(lines)}");
        }
    }

    public class Logic
    {
        public int GetResult(string[] input)
        {
            var start = 0;
            var intArray = input.Select(i => Convert.ToInt32(i));
            foreach (var frequency in intArray)
            {
                start += frequency;
            }
            return start;
        }

        public int? GetRepeatedResult(string[] input)
        {
            var start = 0;
            var results = new HashSet<int>() { 0 };
            var intArray = input.Select(i => Convert.ToInt32(i));
            for (int i = 0; i < 1000; i++)
            {
                foreach (var frequency in intArray)
                {
                    start += frequency;
                    if (results.Contains(start))
                        return start;
                    
                    results.Add(start);
                }
            }
            Console.WriteLine(string.Join(',', results));
            return null;
        }
    }
}
