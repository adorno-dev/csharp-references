/*
 *    Filename: <named.cs>
 *
 * Description: Named Parameters
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

using io = System.Console;

namespace CSharp.NamedAndOptionalParameters
{
    class Named
    {
        public Named()
        {
            // When you type the name of parameter(s), the order is irrelevant
            Receive(
                email: "sender@provider.net",
                nickname: "somebody"
            );

            Receive("somebody", "sender@provider.net");
        }

        public void Receive(string nickname, string email)
        {
            io.WriteLine("Received: Nickname {0}, Contact: {1}", nickname, email);
        }

        public static void Run()
        {
            io.WriteLine("=> Named"); new Named();
            io.WriteLine("");
        }
    }
}