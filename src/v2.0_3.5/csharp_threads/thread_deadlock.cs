/*
 *    Filename: <thread_deadlock.cs>
 *
 * Description: DeadLock
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

// Reference: http://csharp-video-tutorials.blogspot.com 

namespace CSharp.Threads
{
    class Customer
    {
        private int id;
        private double balance;

        public Customer(int id, double balance)
        {
            this.id = id;
            this.balance = balance;
        }

        public int Id { get { return this.id; } }

        public void Withdraw(double amount) { this.balance -= amount; }
        public void Deposit(double amount) { this.balance += amount; }
    }

    class TransactionManager
    {
        private Customer from, to; private double amount_transfer;

        public TransactionManager(Customer from, Customer to, double amount_transfer)
        {
            this.amount_transfer = amount_transfer;
            this.from = from; this.to = to;
        }

        public void Transfer()
        {
            // Solution #Begin

            object _lock1, _lock2;

            if (from.Id < to.Id)
            {
                _lock1 = from;
                _lock2 = to;
            }
            else
            {
                _lock1 = to;
                _lock2 = from;
            }

            // Solution #End

            // Console.WriteLine(string.Format("{0} trying to acquire lock on {1}", Thread.CurrentThread.Name, from.Id.ToString()));
            Console.WriteLine(string.Format("{0} trying to acquire lock on {1}", Thread.CurrentThread.Name, ((Customer)_lock1).Id.ToString()));

            // lock(from)
            lock(_lock1) // <-- Alternative
            {
                // Console.WriteLine(string.Format("{0} acquired lock on {1}", Thread.CurrentThread.Name, from.Id.ToString()));
                Console.WriteLine(string.Format("{0} acquired lock on {1}", Thread.CurrentThread.Name, ((Customer)_lock2).Id.ToString()));
                Console.WriteLine(string.Format("{0} suspended for 1 second", Thread.CurrentThread.Name));
                Thread.Sleep(1000);
                Console.WriteLine(string.Format("{0} back in action and trying to acquire lock on {1}", Thread.CurrentThread.Name, ((Customer)_lock2).Id.ToString()));

                // lock(to)
                lock(_lock2) // <-- Alternative
                {
                    // Console.WriteLine("This code will not be executed!");
                    Console.WriteLine(string.Format("{0} acquired lock on {1}", Thread.CurrentThread.Name, ((Customer)_lock2).Id.ToString()));

                    from.Withdraw(this.amount_transfer);
                    to.Deposit(amount_transfer);

                    Console.WriteLine(string.Format("{0} Transfered ${1} from {2} to {3}.", Thread.CurrentThread.Name, amount_transfer, from.Id, to.Id));
                }
            }
        }
    }

    class DeadLock
    {
        public DeadLock() 
        {
            Console.WriteLine("Main Thread Started");

            Customer from = new Customer(101, 5000);
            Customer to = new Customer(102, 3000);

            TransactionManager transaction1 = new TransactionManager(from, to, 1000);
            TransactionManager transaction2 = new TransactionManager(to, from, 2000);

            Thread thread_transaction1 = new Thread(transaction1.Transfer) { Name = "Transaction_1" };
            Thread thread_transaction2 = new Thread(transaction2.Transfer) { Name = "Transaction_2" };

            thread_transaction1.Start();
            thread_transaction2.Start();

            thread_transaction1.Join();
            thread_transaction2.Join();

            Console.WriteLine("Main Thread Completed");
        }

        public static void Run()
        {
            Console.WriteLine("==> DeadLock"); new DeadLock();
            Console.WriteLine();
        }
    }
}