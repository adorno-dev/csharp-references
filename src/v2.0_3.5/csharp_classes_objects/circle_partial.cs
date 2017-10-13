/*
 *    Filename: <point_partial.cs>
 *
 * Description: Illustrates circle object (partial classes)
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.ClassesAndObjects
{
    public partial class Circle
    {
        // construtor padrao
        public Circle() 
        {
            radius = 0;
            circles++;
        }

        // construtor sobrecarregado
        public Circle(int initialRadius)
        {
            radius = initialRadius;
            circles++;
        }

        public void SetRadius(int radius)
        {
            this.radius = radius;
        }

        public override string ToString()
        {
            return this.radius.ToString();
        }
    }
}