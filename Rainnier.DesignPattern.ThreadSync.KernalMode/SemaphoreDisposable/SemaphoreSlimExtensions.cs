using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.ThreadSync.KernalMode.SemaphoreDisposable
{
    //挺好用的一个code snippet
    public static class SemaphoreSlimExtensions
    {
        /// <summary>
        /// Additional method that implements a IDisposable interface for a SemaphoreSlim object.
        /// </summary>
        /// <param name="semaphore">The instance of SemaphoreSlim that the method is being called on.</param>
        /// <param name="cancelToken">A cancellation token to pass to the wait on the semaphore.</param>
        /// <returns>A IDisposable object that will release the semaphore when it's done.</returns>
        public static async Task<IDisposable> UseWaitAsync(this SemaphoreSlim semaphore, CancellationToken cancelToken = default(CancellationToken))
        {
            await semaphore.WaitAsync(cancelToken).ConfigureAwait(false);
            return new ReleaseWrapper(semaphore);
        }

        private class ReleaseWrapper : IDisposable
        {
            private readonly SemaphoreSlim semaphore;

            private bool isDisposed;

            public ReleaseWrapper(SemaphoreSlim semaphore)
            {
                this.semaphore = semaphore;
            }

            public void Dispose()
            {
                if (this.isDisposed)
                {
                    return;
                }

                this.semaphore.Release();
                this.isDisposed = true;
            }
        }
    }
}
