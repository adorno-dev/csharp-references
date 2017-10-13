/*
 *    Filename: <socket.cs>
 *
 * Description: Socket
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

// Defining aliases
using io = System.Console;
using array = System.Array;

namespace CSharp.Networking
{
    public static class Utility
    {
        public static string Parse(this byte[] buffer)
        {
            return Encoding.ASCII.GetString(buffer);
        }

        public static byte[] Parse(this string chars)
        {
            return Encoding.ASCII.GetBytes(chars);
        }

        public static byte[] ToBuffer<T>(this T entry) where T : class
        {
            using (var ms = new MemoryStream())
            {
                var ft = new BinaryFormatter();
                ft.Serialize(ms, entry);
                return ms.ToArray();
            }
        }

        public static T ToEntry<T>(this byte[] buffer) where T : class
        {
            using (var ms = new MemoryStream())
            {
                var ft = new BinaryFormatter();
                ms.Write(buffer, 0, buffer.Length);
                ms.Seek(0, SeekOrigin.Begin);
                return (T) ft.Deserialize(ms);
            }
        }
    }

    class ServerSocket
    {
        private EndPoint _endpoint = null;
        private Socket _host = null;
        private IDictionary<String, Thread> _connections = null;

        public ServerSocket(int? port = 7777, string address = null)
        {
            _connections = new Dictionary<String, Thread>();
            _endpoint = new IPEndPoint(String.IsNullOrEmpty(address) ? IPAddress.Any : IPAddress.Parse(address), port.Value);
            _host = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
            io.WriteLine(" Server ");

            this.Init(); // Auto Init

            io.ReadLine();
        }

        private void Init(int? backlog = 0)
        {
            _host.Bind(_endpoint);
            _host.Listen(backlog.Value);

            do
            {
                var _request = _host.Accept();
                var _task = new Thread((socket) =>
                {
                    Socket active_socket = (Socket) socket;
                    Byte[] buffer = new Byte[active_socket.SendBufferSize];
                    Byte[] received = null;
                    String id = Thread.CurrentThread.Name.ToUpper();

                    active_socket.Send(string.Format("[Connected][Guid {0}]", id).Parse());

                    do
                    {
                        received = new byte[active_socket.Receive(buffer)];
                        if (received.Length > 0)
                        {
                            array.Copy(buffer, received, received.Length);
                            io.WriteLine("[From {0}]: {1}", id, received.Parse());
                        }

                        active_socket.Send(string.Format("[ACK]: {0}", received.Parse().ToUpper()).Parse());
                    }
                    while (received != null && received.Length > 0);

                    _connections.Remove(id); io.WriteLine("Disconnected.");
                });

                _task.Name = string.Format("{0}", Guid.NewGuid());
                _task.Start(_request);
                _connections.Add(_task.Name.ToUpper(), _task);

                io.WriteLine("[Connected][Guid: {0}]", _task.Name.ToUpper());
            }
            while (true);
        }
    }

    class ClientSocket
    {
        private Socket _host = null;

        public ClientSocket()
        {
            io.WriteLine(" Client ");
            this._host = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.TryConnect();
        }

        private void TryConnect(int? max_attempt = 10, int? port = 7777)
        {
            int attempt = 0;
            
            while (attempt++ < max_attempt.Value && !this._host.Connected)
                try { this._host.Connect(IPAddress.Loopback, port.Value); }
                catch (SocketException e)
                {
                    Console.WriteLine("[Attempt #{0}]: {1}", attempt, e.Message);
                    Thread.Sleep(1000);
                }
            
            if (this._host.Connected)
            {
                var src = new byte[1024];
                var dst = new byte[this._host.Receive(src)];

                array.Copy(src, dst, dst.Length);
                io.WriteLine(dst.Parse());
                this.RunCommand();
            }
        }

        private void RunCommand()
        {
            string cmd = string.Empty;

            while (!cmd.Equals("EXIT"))
            {
                io.Write("Command: ");

                cmd = Console.ReadLine().ToUpper();

                if (this._host.Send(cmd.Parse()) > 0)
                {
                    var src = new byte[1024];
                    var dst = new byte[this._host.Receive(src)];
                    
                    if (dst.Length > 0)
                    {
                        array.Copy(src, dst, dst.Length);
                        io.WriteLine("Response: {0}", dst.Parse());
                    }
                }
            }
        }
    }

    class Sockets
    {
        public Sockets(string[] args)
        {
            if (args.Length > 0)
                switch (args[0].ToLower())
                {
                    case "server": new ServerSocket(); break;
                    case "client": new ClientSocket(); break;
                }
            else
                new ServerSocket(); // Server starts by default
        }

        public static void Run(string[] args)
        {
            Console.Write("=> Sockets"); new Sockets(args);
            Console.WriteLine();
        }
    }
}