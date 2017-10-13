/*
 *    Filename: <composed.cs>
 *
 * Description: Composed
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

    partial struct Hour
    {
        private int value;

        public Hour(int initial)
        {
            this.value = initial;
        }

        // public static Hour operator++ (Hour hour)
        // {
        //     hour.value++;
        //     return hour;
        // }

        public static Hour operator++ (Hour hour)
        {
            return new Hour(hour.value + 1);
        }

        public override string ToString()
        {
            return this.value.ToString();
        }

        public override bool Equals(object instance)
        {
            return this == (Hour)instance;
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
    }

    class Composed
    {
        public Composed()
        {
            Hour hour = new Hour(12);
            Console.WriteLine("Clock: {0}hrs", hour);
            hour++;
            Console.WriteLine("Clock: {0}hrs", hour);

            Hour hour2 = new Hour(6);
            Console.WriteLine("Clock: Hours Is Equals: {0}", hour == hour2);
            Console.WriteLine("Clock: Hours Is Not Equals: {0}", hour != hour2);
        }

        public static void Run()
        {
            Console.WriteLine("=> Composed");
            new Composed();
            Console.WriteLine();
        }
    }
}