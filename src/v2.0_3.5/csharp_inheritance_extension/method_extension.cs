/*
 *    Filename: <method_extension.cs>
 *
 * Description: Extension methods
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
    // Extension methods requires a static class
    static class Features
    {
        // The method must be static too AND the first argument MUST BE this T where T receives this method.
        public static bool Boot(this Android os)
        {
            return true;
        }
    }

    public class Extension
    {
        public Extension()
        {
            Console.WriteLine("==> Extension Method");
            Android os = new Android();
            Console.WriteLine("Operating System: {0}", os.GetType().Name);
            Console.WriteLine("Booting System State: {0}", os.Boot());
            Console.WriteLine();
        }

        public static void Run()
        {
            var instance = new Extension();
        }
    }
}