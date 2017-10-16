using io = System.Console;

namespace CSharp.Features
{
    class LocalFunctions
    {
        public LocalFunctions()
        {
            int[] numbers = { 0b1, 0b10 , 0b100, 0b1000, 0b1_0000, 0b10_0000 };

            var t = Tally(numbers);
            // io.WriteLine($"Sum: {t.Item1}, Count: {t.Item2}");
            io.WriteLine($"Sum: {t.sum}, Count: {t.count}");
        }

        // (int, int) Tally(int[] values)
        (int sum, int count) Tally(int[] values)
        {
            // var r = (0, 0)
            
            var r = (s:0, c:0);

            foreach (var v in values)
            {
                Add(v, 1);
            }

            return r;

            void Add(int s, int c) { r.s += s; r.c += c; }
        }
    }
}