/*
 *    Filename: <collection.cs>
 *
 * Description: Using collection as example
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;
using System.Collections;
using System.Collections.Generic;
using io = System.Console;

namespace CSharp.CovarianceAndContravariance
{
    class Covariance
    {
        public Covariance()
        {
            var values = new string[] { "Covariance", "And", "Contravariance" };

            IEnumerable<string> cool = values;
            IList<string> again = values; // <-- Here
            IEnumerator<string> reader = again.GetEnumerator();
            
            while (reader.MoveNext())
                io.WriteLine(string.Format(" => {0}", reader.Current));
        }

        public static void Run()
        {
            io.WriteLine("=> Covariance - Contravariance"); new Covariance();
            io.WriteLine();
        }
    }
}