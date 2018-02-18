using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LearningLibrary.Implementation
{
    public abstract class TaskClass: IDisposable
    {
        /// <summary>
        /// Used normaly for private declaration of variables
        /// </summary>
        private CancellationTokenSource _source = null;

        /// <summary>
        /// Can be used with or without variable. Primary used for 
        /// Datamanipulation and in use of Databinding. 
        /// </summary>
        public CancellationTokenSource Source
        {
            get
            {
                return _source;
            }
            private set
            {
                _source = value;
            }
        }

        /// <summary>
        /// Create Cancellation Source
        /// </summary>
        public TaskClass()
        {
            _source = new CancellationTokenSource();
        }

        public void Dispose()
        {
            CancelAll();
        }

        /// <summary>
        /// Cancel all Tasks
        /// </summary>
        public void CancelAll()
        {
            _source.Cancel();
        }

        /// <summary>
        /// Is Canceled
        /// </summary>
        /// <returns></returns>
        public bool IsCanceled()
        {
            return _source.IsCancellationRequested;
        }

        /// <summary>
        /// Writes a line.
        /// </summary>
        /// <returns></returns>
        internal Task Write(string name)
        {
            // An Action is like a delegate without return value ...
            var action = new Action(() =>
            {
                var counter = 0;
                while (counter < 100)
                {
                    Random rnd = new Random();
                    Console.WriteLine(name + counter.ToString());
                    counter++;
                    Task.Delay(rnd.Next(100, 200)).Wait();
                }
                return;
            });

            // ... so lets return a action!
            return Task.Factory.StartNew(action);                
        }

        /// <summary>
        /// Writes a line and returns an result
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Zero</returns>
        internal Task<int> WriteWithResult(string name)
        {
            // A Function is actualy the same as a delegate with return value ...
            var function = new Func<int>(() =>
            {
                var counter = 0;
                while (counter < 100)
                {
                    Random rnd = new Random();
                    Console.WriteLine(name + counter.ToString());
                    counter++;
                    Task.Delay(rnd.Next(100, 200)).Wait();
                }
                return 0;
            });

            // ... so lets return some function!
            return Task.Factory.StartNew(function);
        }

        /// <summary>
        /// Starts a delay task
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal async Task WriteAsync(string name)
        {
            var counter = 0;
            while (counter < 100)
            {
                Random rnd = new Random();
                Console.WriteLine(name + counter.ToString());
                counter++;
                await Task.Delay(rnd.Next(100, 200));
            }
        }

        /// <summary>
        /// Writes output with 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal async Task<int> WriteWithResultAsync(string name)
        {
            var counter = 0;
            while (counter < 100)
            {
                Random rnd = new Random();
                Console.WriteLine(name + counter.ToString());
                counter++;
                await Task.Delay(rnd.Next(100, 200));
            }
            return 0;
        }
    }
}
