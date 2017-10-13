/*
 *    Filename: <program.cs>
 *
 * Description: Sockets, Remoting
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.Networking
{
    class Program
    {
        static void Main(string[] args)
        {
            #if NET35

            RemotingTcp.Run(args);

            #else

            Sockets.Run(args);

            #endif
        }
    }
}
