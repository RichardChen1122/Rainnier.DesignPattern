using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Asynchronous
{
    public static class IOCancellation
    {
        private struct Void { }

        private static async Task<TResult> WithCancellation<TResult>(this Task<TResult> originTask,CancellationToken ct)
        {
            var cancelTask = new TaskCompletionSource<Void>();

            using (ct.Register(t => ((TaskCompletionSource<Void>)t).TrySetResult(new Void()),cancelTask))
            {
                Task any = await Task.WhenAny(originTask, cancelTask.Task);

                if (any == cancelTask.Task) ct.ThrowIfCancellationRequested();
            }

            return await originTask;
        }

        
    }

    public class DemoIO
    {
        public static async Task Go()
        {
            var cts = new CancellationTokenSource(5000);

            var ct = cts.Token;

            try
            {
                //await Task.Delay(10000).WithCancellation(ct);
                Console.WriteLine("Task completed");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Task cancelled");
                throw;
            }
        }
    }
}
