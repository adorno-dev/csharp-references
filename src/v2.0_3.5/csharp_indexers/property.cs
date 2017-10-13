/*
 *    Filename: <property.cs>
 *
 * Description: Indexed Property
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.Indexers
{
    struct Property
    {
        private int[] src;

        public int[] RefSource
        {
            get { return this.src; }
            set { this.src = value; }
        }

        public int[] ValSource
        {
            get { return (int[])this.src.Clone(); }
            set { this.src = (int[])value.Clone(); }
        }

        public Property(params int[] args)
        {
            this.src = args;

            this.RefSource[0]++;
            this.RefSource[1]++;
            this.RefSource[2]++;
            this.RefSource[3]++;
        }

        public static void Run()
        {
            new Property(1, 2, 3, 4);
        }
    }
}