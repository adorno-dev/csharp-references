/*
 *    Filename: <struct.cs>
 *
 * Description: Structs usage
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.EnumsAndStructs
{
    public struct Time
    {
        public int hours, minutes, seconds;

        // public Time() {} // Error on compile

        public Time(int hours, int minutes, int seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            // this.seconds; // Error on compile, seconds doesn't initialized
            this.seconds = seconds;
        }

        public int Hours()
        {
            return this.hours;
        }

        public static void Run()
        {
            Console.WriteLine("=> Struct => Time");

            Time current_time; // hours = ?, minutes = ?, seconds = ?           
            current_time = new Time(23, 59, 59); // hours = 23, minutes = 59, seconds = 59
            
            Console.WriteLine("Hour Defined: {0}", current_time.Hours());
            Console.WriteLine("Time: {0}:{1}:{2}", current_time.hours, current_time.minutes, current_time.seconds);
            Console.WriteLine();
        }
    }

    public struct Date
    {
        private int year, day;
        private Month month;

        public Date(int year, Month month, int day)
        {
            this.year = year - 1900;
            this.month = month;
            this.day = day - 1;

            Console.WriteLine("=> Struct => Date");
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}\n", this.month, this.day + 1, this.year + 1900);
        }

        public static void Run()
        {
            var instance = new Date(2017, Month.September, 27);
            Console.WriteLine(instance);
        }
    }
}