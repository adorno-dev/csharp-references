/*
 *    Filename: <remoting_tcp.cs>
 *
 * Description: .NET Remoting
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

#if NET35

using System;
using System.Net;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace CSharp.Networking
{
    public interface IRemotingService 
    {
        String Run(string text);
        String Run2(string text);
    }

    public class RemotingService : MarshalByRefObject, IRemotingService
    {
        public string Run(string text)
        {
            return string.Format("Hello: {0}", text);
        }

        public string Run2(string text)
        {
            return string.Format("From Run #2: {0}", text);
        }
    }

    class ServerRemoting
    {
        private IRemotingService _service = null;
        private IChannel _channel = null;

        public ServerRemoting(int? port = 8080)
        {
            _service = new RemotingService();
            _channel = new TcpChannel(port.Value);

            this.Init();
        }

        private void Init()
        {
            ChannelServices.RegisterChannel(_channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemotingService), "endpoint", WellKnownObjectMode.Singleton);
            Console.WriteLine("Remoting Started @ {0}", DateTime.Now.ToLongTimeString());
            Console.ReadLine();
        }
    }

    class ClientRemoting<T> where T : IRemotingService
    {
        private T _service;

        public ClientRemoting(string host = "localhost", int? port = 8080)
        {
            _service = (T) Activator.GetObject(typeof(T), string.Format("tcp://{0}:{1}/endpoint", host, port.Value));

            Console.Write("Write: ");
            Invoke();
        }

        public void Invoke()
        {
            Console.WriteLine(_service.Run2(Console.ReadLine()));
        }
    }

    class RemotingTcp
    {
        public RemotingTcp(string[] args)
        {
            if (args.Length > 0)
                switch (args[0].ToLower())
                {
                    case "server": new ServerRemoting(); break;
                    case "client": new ClientRemoting<IRemotingService>(); break;
                }
            else
                new ServerRemoting(); // Server starts by default
        }

        public static void Run(string[] args)
        {
            Console.WriteLine("=> RemotingTCP"); new RemotingTcp(args);
            Console.WriteLine();
        }
    }
}

#endif