using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.ObserveMode.Common
{
    class Person : IObserver<Article>
    {
        String name;
        //保存订阅的新闻站点，方便以后取消订阅
        Dictionary<IObservable<Article>, IDisposable> sbscribes = new Dictionary<IObservable<Article>, IDisposable>();


        public Person(String name)
        {
            this.name = name;
        }

        public void Subscribe(IObservable<Article> news)
        {
            IDisposable unsub = news.Subscribe(this);
            sbscribes[news] = unsub;
        }

        public void UnSubscribe(IObservable<Article> news)
        {
            if (sbscribes.ContainsKey(news))
            {
                sbscribes[news].Dispose();
                sbscribes.Remove(news);
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

        public void OnNext(Article value)
        {
            Console.WriteLine("One News: {0} to {1}", value.Title, name);
        }
    }
}
