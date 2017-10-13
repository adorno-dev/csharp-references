/*
 *    Filename: <pairs.cs>
 *
 * Description: Comparation Of Pairs
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
    partial struct Hour
    {
        public static bool operator==(Hour left, Hour right)
        {
            return left.value == right.value;
        }

        public static bool operator!=(Hour left, Hour right)
        {
            return left.value != right.value;
        }
    }
}