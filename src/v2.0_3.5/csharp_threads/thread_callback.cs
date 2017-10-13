/*
 *    Filename: <thread_callback.cs>
 *
 * Description: Callbacks
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
using System.Collections.Generic;

namespace CSharp.Threads
{
    class Api
    {
        private IList<string> db = new List<string>();

        public delegate void postback(string message);
        public postback on_postback = null;

        public Api(postback on_postback)
        {
            this.on_postback = on_postback;
        }

        public void Post(object subscribe)
        {
            db.Add(subscribe.ToString());

            if (this.on_postback != null)
                this.on_postback.Invoke(string.Format("Subscribe: {0} inserted with successfully!", subscribe));
        }
    }

    class ThreadCallback
    {
        public ThreadCallback() {}

        public void UpdateList(string message)
        {
            Console.WriteLine(message);
        }
        public static void Run()
        {
            var app = new ThreadCallback();
            var api = new Api(app.UpdateList);

            var post1 = new System.Threading.Thread(api.Post);
            var post2 = new System.Threading.Thread(api.Post);
            var post3 = new System.Threading.Thread(api.Post);
        
            post1.Start("Subscriber #1");
            post2.Start("Subscriber #2");
            post3.Start("Subscriber #3");
        }
    }
}