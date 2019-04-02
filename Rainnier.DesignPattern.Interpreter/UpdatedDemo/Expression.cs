using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Interpreter
{
    /// <summary>
    /// 抽象表达式
    /// </summary>
    public abstract class UpdatedExpression
    {
        public abstract void Interpret(UpdatedContext context);

        public abstract double Execute();
    }

    /// <summary>
    /// 变量，终结符表达式
    /// </summary>
    public class MidExpression : UpdatedExpression
    {
        private List<UpdatedExpression> list = new List<UpdatedExpression>();
        public MidExpression(char key)
        {
            
        }

        public override double Execute()
        {
            throw new NotImplementedException();
        }

        public override void Interpret(UpdatedContext context)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 操作符，非终结符表达式
    /// </summary>
    //public abstract class UpdatedOperatorExpression : UpdatedExpression
    //{
    //    protected UpdatedExpression left;
    //    protected UpdatedExpression right;

    //    public UpdatedOperatorExpression(UpdatedExpression left, UpdatedExpression right)
    //    {
    //        this.left = left;
    //        this.right = right;
    //    }
    //}

    public class UpdatedAddExpression : UpdatedExpression
    {
        protected double left;
        protected double right;
        //public UpdatedAddExpression(UpdatedExpression left, UpdatedExpression right)
        //    : base(left, right)
        //{

        //}

        public override double Execute()
        {
            return left + right;
        }

        public override void Interpret(UpdatedContext context)
        {
            right = context.GetCurrentNumber();
        }
    }

    public class UpdatedSubExpression : UpdatedExpression
    {
        public override double Execute()
        {
            throw new NotImplementedException();
        }

        public override void Interpret(UpdatedContext context)
        {
        }
            
    }

    
}
