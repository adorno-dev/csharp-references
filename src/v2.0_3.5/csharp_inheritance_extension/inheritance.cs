/*
 *    Filename: <inheritance.cs>
 *
 * Description: Inheritance examples
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.InheritanceExtension
{
    class BaseClass // Base Class
    {
        public BaseClass(string reference) {} // Base Constructor

        public void MethodFromBaseClass1() {}
        public void MethodFromBaseClass2() {}
    }

    class BaseClass2 // Base Class
    {
        public BaseClass2() {} // Base Constructor
    }

    class DerivativeClass : BaseClass // <-- Inheritance
    {
        public DerivativeClass(string id) 
            : base(id) { } // <- Constructor receives arguments on derived class constructor

        public void MethodFromDerivativeClassClass1() {}
        public void MethodFromDerivativeClassClass2() {}
    }

    class DerivativeClassClass2 : BaseClass2 // <-- Other example
    { }

    public class Inheritance
    {
        public Inheritance()
        {
            Console.WriteLine("==> Inheritance");

            DerivativeClass d1 = new DerivativeClass("Ted");
            BaseClass b1 = d1; // Valid assignment!

            BaseClass b2 = new BaseClass("Unknwon");
            b2.MethodFromBaseClass1();
            b2.MethodFromBaseClass2();            
            
            DerivativeClass d2 = new DerivativeClass("Unknown");
            d2.MethodFromBaseClass1();
            d2.MethodFromDerivativeClassClass1();
        }

        public static void Run()
        {
            var instance = new Inheritance();
        }
    }
}