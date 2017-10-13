/*
 *    Filename: <symmetrical.cs>
 *
 * Description: Symmetrical Operators
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

    struct Second
    {
        private int value;

        public Second(int initial)
        {
            this.value = initial;
        }

        public static Second operator+ (Second left, Second right)
        {
            return new Second(left.value + right.value);
        }

        public static Second operator+ (Second left, int right)
        {
            return left + new Second(right);
        }

        public static Second operator+ (int left, Second right)
        {
            return new Second(left) + right;
        }

        public override string ToString()
        {
            return this.value.ToString();
        }
    }

    class Symmetrical
    {
        public Symmetrical()
        {
            Second sum1 = new Second(5) + new Second(2);
            Console.WriteLine("Sum Seconds (Second + Second): {0}", sum1);

            Second sum2 = new Second(3) + 2;
            Console.WriteLine("Sum Seconds (Second + Int32): {0}", sum2);

            Second sum3 = 12 + new Second(2);
            Console.WriteLine("Sum Seconds (Int32 + Second): {0}", sum3);
        }

        public static void Run()
        {
            Console.WriteLine("=> Symmetrical");
            new Symmetrical();
            Console.WriteLine();
        }
    }
}