using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.ObserveMode.Common
{
    internal class News : IObservable<Article>
    {
        private List<Article> articles = new List<Article>();
        private List<IObserver<Article>> observers = new List<IObserver<Article>>();
        public IDisposable Subscribe(IObserver<Article> observer)
        {
            if (!this.observers.Contains(observer))
            {
                observers.Add(observer);
            }

            return new unsubscribe(observers, observer);
        }

        private class unsubscribe : IDisposable
        {
            private IObserver<Article> _observer;
            private List<IObserver<Article>> _observers;

            public unsubscribe(List<IObserver<Article>> observers, IObserver<Article> observer)
            {
                this._observer = observer;
                this._observers = observers;
            }

            public void Dispose()
            {
                if (this._observers != null && this._observers.Contains(this._observer))
                {
                    this._observers.Remove(this._observer);
                }
            }
        }

        //向订阅者发送通知
        private void Notify(Article article)
        {
            foreach (var item in this.observers)
            {
                item.OnNext(article);
            }
        }
        //当有新的文章发布时通知订阅者
        public void AddArticle(Article article)
        {
            this.articles.Add(article);
            this.Notify(article);
        }
    }
}
