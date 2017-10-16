using io = String.Console;

namespace CSharp.Features
{
    class PatternMatching
    {
        public void PrintStarts(object o)
        {
            if (o is null) return;      // constant pattern "null"

            if (!(o is int )) return;   // type pattern "int i"

            io.WriteLine(new string('*', i));

            switch (shape)              // switch on anything
            {
                case Rectangle s when (s.Length == s.Height): 
                    io.WriteLine($"{s.Length} x {s.Height} square");
                    break;
                case Rectangle r:
                    io.WriteLine($"{r.Length} x {r.Height} rectangle");
                    break;
                case Circle c:
                    io.WriteLine($"circle with radius {c.Radius}");
                    break;
                case null:
                    throw new ArgumentNullException(nameof(shape));
                default:
                    io.WriteLine("<unknown shape>");
                    break;
            }
        }
    }
}