using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.ObserveMode.Rx
{
    internal class OrderQueue : IObservable<Order>
    {
        ConcurrentQueue<Order> queue = new ConcurrentQueue<Order>();
        List<IObserver<Order>> observers = new List<IObserver<Order>>();
        public IDisposable Subscribe(IObserver<Order> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }

            return new unsubscribe(observer, observers);
        }

        private class unsubscribe : IDisposable
        {
            private List<IObserver<Order>> _observers;
            private IObserver<Order> _observer;
            public unsubscribe(IObserver<Order> observer, List<IObserver<Order>> observers)
            {
                _observer = observer;
                _observers = observers;
            }
            public void Dispose()
            {
                if (this._observers != null && this._observers.Contains(this._observer))
                {
                    this._observers.Remove(this._observer);
                }
            }
        }
    }
}
