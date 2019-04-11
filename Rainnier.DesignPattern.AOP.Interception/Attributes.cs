using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.AOP.Interception
{
    /// <summary>
    /// 贴在方法上的标签
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public sealed class AOPMethodAttribute : Attribute { }

    /// <summary>
    /// 贴在类上的标签
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class AOPAttribute : ContextAttribute, IContributeObjectSink
    {
        public AOPAttribute() : base("AOP") { }

        /// <summary>
        /// 实现消息接收器接口
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink next) => new MyAopHandler(next);
    }
}
