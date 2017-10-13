/*
 *    Filename: <program.cs>
 *
 * Description: LINQ Queries
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.LinqQueries
{
    class Program
    {
        static void Main(string[] args)
        {
            Select.Run();
            Where.Run();
            OrderBy.Run();
            GroupBy.Run();
            Join.Run();
            SelectOperator.Run();
        }
    }
}
