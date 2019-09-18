using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.ObserveMode.Rx
{
    internal class OrderHandler : IObserver<Order>
    {
        Dictionary<IObservable<Order>, IDisposable> dictionary = new Dictionary<IObservable<Order>, IDisposable>();
        public void Subscribe(IObservable<Order> observable)
        {
            dictionary[observable] = observable.Subscribe(this);
        }

        public void Unsubscribe(IObservable<Order> observable)
        {
            if (dictionary[observable] != null)
            {
                dictionary[observable].Dispose();
                dictionary.Remove(observable);
            }
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Order value)
        {
            throw new NotImplementedException();
        }

        public void OnNext(ConcurrentQueue<Order> queue)
        {
            throw new NotImplementedException();
        }
    }
}
 