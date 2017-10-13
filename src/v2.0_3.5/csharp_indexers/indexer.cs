/*
 *    Filename: <indexer.cs>
 *
 * Description: Implementing index via interface
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
    struct Indexer // tipo customizado - struct (porque é mais leve)
    {
        private sbyte bits;

        public bool this [int index]
        {
            get { return (bits & (1 << index)) != 0; }
            set
            {
                if (value) // ativa ou desativa o bit
                    bits |= (sbyte) (1 << index);
                else
                    bits &= (sbyte) ~(1 << index);
            }
        }

        public Indexer(int value)
        {
            this.bits = (sbyte) value;
        }

        public override string ToString()
        {
            return ((byte)this.bits).ToString();
        }

        public static void Run()
        {
            var value = 62;             // 0b00111110
            var bits = new Indexer(value); 
            bool v6th = bits[6];        // 6ª posicao, verdadeiro
            bits[0] = true;             // 1ª posicao, verdadeiro (setar)
            bits[3] = false;            // 3ª posicao, falso (setar)

            Console.WriteLine("==> Indexer");
            Console.WriteLine("Initial: {0}", 62);
            Console.WriteLine("Final: {0}", bits);
        }
    }
}