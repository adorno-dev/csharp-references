/*
 *    Filename: <autoproperty.cs>
 *
 * Description: Auto Property
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.FieldsAndProperties
{
    struct Resolution
    {
        public int H { get; private set; }
        public int W { get; private set; }

        public Resolution(int H, int W)
        {
            this.H = H;
            this.W = W;
        }
    }

    public class AutoProperty
    {
        public AutoProperty()
        {
            Console.WriteLine("==> AutoProperty");

            Resolution r = new Resolution(768, 1024);
            
            // private set - so pode ser escrito dentro da propria classe
            // r.H = 600;
            // r.W = 800;
        }

        public static void Run()
        {
            var instance = new AutoProperty();
        }
    }
}