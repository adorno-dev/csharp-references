/*
 *    Filename: <async_await.cs>
 *
 * Description: Async and Await Keywords
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;
using System.Threading;
using System.Threading.Tasks;
using io = System.Console;

namespace CSharp.AsynchronousProgramming
{
    public class AsyncAwait
    {
		private CancellationTokenSource cancellation_source = null;

        public AsyncAwait() 
        {
            this.StartConsoleUI();
        }

		/// <summary>
		/// Console Simulator
		/// </summary>
        public void StartConsoleUI()
        {
            string[] command = new [] { "", "" };

            while (!command[0].ToLower().Equals("exit"))
            {
                io.Write("Prompt: ");
                command = io.ReadLine().Split(' ');

                switch (command[0].Trim().ToLower())
                {
                    case "ping":
                        int value = -1;
                        if (command.Length.Equals(2) && int.TryParse(command[1], out value))
                        {
							try
							{
								cancellation_source = new CancellationTokenSource();

								this.PingCommandAsync(value, cancellation_source.Token).ContinueWith((arg) =>
								{
									if (arg.IsCanceled)
									{
										io.WriteLine(" [Ping was aborted!");
										io.Write("Prompt: ");
									} else if (arg.IsCompleted)
									{
										io.WriteLine(" [Ping complete with successfully!");
										io.Write("Prompt: ");
									}
								});
							}
							catch (Exception ex)
							{
								io.WriteLine(ex.Message);
							}
                        }
                        else
                            io.WriteLine("PING requires the milliseconds. Eg: ping <1000>");
                        break;
					case "cancel":
						this.cancellation_source.Cancel();
						break;
                    case "exit":
                        io.WriteLine("Bye!"); break;
                    default: 
                        io.WriteLine("Unreconized command!"); break;
                }
            }
        }

		/// <summary>
		/// Simple Ping
		/// </summary>
		/// <param name="value">Interval in milliseconds</param>
		/// <returns></returns>
        public async Task<bool> PingCommandAsync(int value)
        {
			await Task.Delay(value); 
			return true;
        }

		/// <summary>
		/// Simple Ping
		/// </summary>
		/// <param name="value">Interval in milliseconds</param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<bool> PingCommandAsync(int value, CancellationToken cancellationToken)
		{
			var wait_until = DateTime.Now.AddMilliseconds(value).Ticks;

			io.WriteLine("Ping was requested. Type \"cancel\" to abort the ping!");

			while (DateTime.Now.Ticks < wait_until)
			{
				await Task.Delay(100);
				cancellationToken.ThrowIfCancellationRequested();
			}

			return true;
		}

		public static void Run()
        {
            io.WriteLine("=> Async Await"); 
			var answer = new AsyncAwait();

            io.WriteLine();
        }
    }
}