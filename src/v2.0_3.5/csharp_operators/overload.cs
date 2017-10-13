/*
 *    Filename: <overload.cs>
 *
 * Description: Overloading
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.Operators
{
    // Operators Must Be
    //  - Public
    //  - Static
    //  - Can't Polymorphic
    //  - Can't Use Virtal, Abstract, Override Or Sealed Etc...

    struct Minute
    {
        private int value;

        public Minute(int initial)
        {
            this.value = initial;
        }

        public static Minute operator+ (Minute left, Minute right)
        {
            return new Minute(left.value + right.value);
        }

        public override string ToString()
        {
            return this.value.ToString();
        }
    }

    class Overload
    {
        public Overload()
        {
            Minute sum = new Minute(5) + new Minute(2);
            Console.WriteLine("Sum Minutes: {0}", sum);
        }

        public static void Run()
        {
            Console.WriteLine("=> Overload");
            new Overload();
            Console.WriteLine();
        }
    }
}