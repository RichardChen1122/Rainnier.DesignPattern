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
        Dictionary<IObserver<Order>, Action<Order>> oderHandlerDic = new Dictionary<IObserver<Order>, Action<Order>>();
        public IDisposable Subscribe(IObserver<Order> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }

            return new unsubscribe(observer, observers);
        }

        public IDisposable Subscribe(IObserver<Order> observer, Action<Order> orderHandler)
        {
            IDisposable unsub = Subscribe(observer);
            observers.Add(observer);

            oderHandlerDic[observer] = orderHandler;

            return unsub;
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

        private void Notify(Order order)
        {
            foreach (var item in this.observers)
            {
                item.OnNext(order);
                oderHandlerDic[item](order) ;
            }
        }
        

        //进来新订单，加入队列并通知订阅者
        public void AddOrder(Order order)
        {
            this.queue.Enqueue(order);
            this.Notify(order);
        }
    }
}
