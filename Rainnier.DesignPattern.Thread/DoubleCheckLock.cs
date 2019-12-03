using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Thread
{
    public sealed class DoubleCheckLock
    {
        private static object m_lock = new Object();

        private static DoubleCheckLock s_value = null;

        private DoubleCheckLock()
        {

        }

        public static DoubleCheckLock GetInstance()
        {
            if (s_value != null) return s_value;

            Monitor.Enter(m_lock);
            if (s_value == null)
            {
                DoubleCheckLock temp = new DoubleCheckLock();
                Interlocked.Exchange(ref s_value, temp);
            }

            Monitor.Exit(m_lock);

            return s_value;
        }
    }
}
