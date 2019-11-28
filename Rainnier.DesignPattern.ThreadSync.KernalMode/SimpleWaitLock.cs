using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.ThreadSync.KernalMode
{
    public class SimpleWaitLock : IDisposable
    {
        private readonly AutoResetEvent m_available;
        public SimpleWaitLock()
        {
            m_available = new AutoResetEvent(true);
        }

        public void Enter()
        {
            m_available.WaitOne();
        }

        public void Leave()
        {
            m_available.Set();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
