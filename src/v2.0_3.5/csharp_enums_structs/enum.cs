/*
 *    Filename: <enum.cs>
 *
 * Description: Enum usage
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
    public enum Season { Spring, Summer, Fall, Winter }

    public enum Season2 : short { Spring = 1, Summer, Fall, Winter }

    public enum Month : short { January = 1, February, March, April, May, June, July, August, September, October, November, December }

    public class Enum
    {
        private Season2 current_season;
        public void Receive(Season param)
        {
            Console.WriteLine("=> Enum.Receive()");

            Season local_variable = param;
            Console.WriteLine(local_variable); // write received value
            Console.WriteLine();
            Console.WriteLine("=> [Inner Receive()]");

            Season colorful = Season.Winter;
            Console.WriteLine(colorful); // writes Winter
            Console.WriteLine();

            this.current_season = (Season2)new Random().Next(4);
            Console.WriteLine("=> [Randomized]");
            Console.WriteLine("Text: {0}, Value: {1}", this.current_season, (int)this.current_season);
            Console.WriteLine();
        }

        public void ShowMonth()
        {
            Console.WriteLine("=> Enum.ShowMonth()");

            int.TryParse("1", out int index);
            while (index <= 12)
                Console.WriteLine("Text: {0}, Value: {1}", (Month)index, index++);
            
            Console.WriteLine();
        }

        public static void Run()
        {
            var instance = new Enum();
            instance.Receive(Season.Spring);
            instance.ShowMonth();
        }
    }
}