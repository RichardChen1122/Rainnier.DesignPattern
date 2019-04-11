using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.AOP.Interception
{
    public sealed class MyAopHandler : IMessageSink
    {
        public IMessageSink NextSink { get; set; }

        public MyAopHandler(IMessageSink nextSink)
        {
            NextSink = nextSink;
        }

        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink) => null;


        public IMessage SyncProcessMessage(IMessage msg)
        {
            var call = msg as IMethodCallMessage;

            if (call == null || (Attribute.GetCustomAttribute(call.MethodBase, typeof(AOPMethodAttribute))) == null || call.MethodName != "add") return NextSink.SyncProcessMessage(msg);

            //判断第2个参数,如果是0,则强行返回100,不调用方法了
            if (((int)call.InArgs[1]) == 0) return new ReturnMessage(100, call.Args, call.ArgCount, call.LogicalCallContext, call);

            //判断第2个参数,如果是1,则参数强行改为50(失败了)
            //if (((int)call.InArgs[1]) == 1) call = new MyCall(call, call.Args[0], 50);//方法1  失败了
            //if (((int)call.InArgs[1]) == 1) call.MethodBase.Invoke(GetUnwrappedServer(), new object[] { call.Args[0], 50 });//方法2 (无法凑够参数)

            var retMsg = NextSink.SyncProcessMessage(call);

            //判断返回值,如果是5,则强行改为500
            if (((int)(retMsg as IMethodReturnMessage).ReturnValue) == 5) return new ReturnMessage(500, call.Args, call.ArgCount, call.LogicalCallContext, call);

            return retMsg;

        }
    }
}
