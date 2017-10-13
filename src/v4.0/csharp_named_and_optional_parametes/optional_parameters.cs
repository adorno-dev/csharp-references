/*
 *    Filename: <optional.cs>
 *
 * Description: Optional Parameters
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
    class Optional
    {
        public Optional()
        {
            io.WriteLine("Command #1: "); Receive();
            io.WriteLine("Command #2: "); Receive("Anybody");
            io.WriteLine("Command #3: "); Receive("Anybody", "sender@provider.net");
            io.WriteLine("Command #3: "); Receive("Anybody", "sender@provider.net", false);
            io.WriteLine();
        }

        // Like an overload
        public void Receive(string nickname = null, string email = null, bool? is_active = null)
        {
            io.Write(string.IsNullOrEmpty(nickname) ? string.Empty : string.Format("Nickname: {0}\n", nickname));
            io.Write(string.IsNullOrEmpty(email) ? string.Empty : string.Format("Contact: {0}\n", email));
            io.Write(is_active == null ? string.Empty : string.Format("Active: {0}\n", email));
            io.WriteLine();
        }

        public static void Run()
        {
            io.WriteLine("=> Optional Parameters"); new Optional();
            io.WriteLine("");
        }
    }
}