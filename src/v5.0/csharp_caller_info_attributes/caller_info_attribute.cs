using System;
using System.Runtime.CompilerServices;

using io = System.Console;

namespace CSharp.CallerInfoAttributes
{
    public class CallerInfo
    {
        public CallerInfo(
            [CallerMemberName] string caller = null,
            [CallerFilePath] string source = null,
            [CallerLineNumber] int line = -1) 
        {
            io.WriteLine("[From Caller Info]");
            io.WriteLine("Caller: {0}", caller ?? "Unknwon");
            io.WriteLine("Filename: {0}", source ?? "Unknown");
            io.WriteLine("Line Number: {0}", line);
            io.WriteLine();
        }

        public static void Run(
            [CallerMemberName] string caller = null,
            [CallerFilePath] string source = null,
            [CallerLineNumber] int line = -1)
        {
            io.WriteLine("[From Entry Point]");
            io.WriteLine("Caller: {0}", caller ?? "Unknwon");
            io.WriteLine("Filename: {0}", source ?? "Unknown");
            io.WriteLine("Line Number: {0}", line);
            io.WriteLine();

            io.WriteLine("=> Caller Info Attributes"); new CallerInfo();
            io.WriteLine();
        }
    }
}