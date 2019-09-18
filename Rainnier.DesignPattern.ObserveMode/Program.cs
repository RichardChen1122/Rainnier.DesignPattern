using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rainnier.DesignPattern.ObserveMode.Common;

namespace Rainnier.DesignPattern.ObserveMode
{
    class Program
    {
        static void Main(string[] args)
        {
            News ChinaNews = new News();
            News EuropeNews = new News();
            Person person1 = new Person("heqichang");
            Person person2 = new Person("Jim");

            //我自己订阅了中国新闻和欧洲新闻
            person1.Subscribe(ChinaNews);
            person1.Subscribe(EuropeNews);
            //Jim订阅了欧洲新闻
            person2.Subscribe(EuropeNews);

            EuropeNews.AddArticle(new Article()
            {
                Title = "New title",
                Date = DateTime.Now.Date,
                Author = "heqichang",
                Content = "New content"
            });

            Console.ReadKey();
        }
    }
}
