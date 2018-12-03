using System;
using System.Linq;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("input.txt");
            var logic = new Logic();
            Console.WriteLine($"Result: {logic.GetResult(lines)}");
            foreach (var result in logic.GetCommon(lines))
            {
                Console.WriteLine($"Result Compare: {result}");
            }
        }
    }

    public class Logic
    {
        public int? GetResult(string[] input)
        {
            if (input.Count() == 1 && string.IsNullOrEmpty(input[0]))
                return null;

            var result = input
                .Select(i => i.GroupBy(c => c));

            var count2 = result.Count(w => w.Any(w2 => w2.Count() == 2));
            var count3 = result.Count(w => w.Any(w2 => w2.Count() == 3));

            return count2 * count3;
        }

        public string[] GetCommon(string[] input)
        {
            foreach (var boxId in input)
            {
                foreach (var compareId in input.Where(w => boxId.Length == w.Length))
                {
                    var mismatch = 0;
                    for (int i = 0; i < boxId.Length; i++)
                    {
                        if (boxId[i] == compareId[i])
                            continue;
                        if (mismatch == 1)
                        {
                            mismatch++;
                            break;
                        }
                        mismatch += 1;
                    }
                    if (mismatch == 1)
                    return new [] { boxId, compareId};
                }
            }
            return null;
        }
    }
}
