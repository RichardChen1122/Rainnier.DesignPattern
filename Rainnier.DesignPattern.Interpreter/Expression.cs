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
    public abstract class Expression
    {
        public abstract double Interpret(Context context);
    }

    /// <summary>
    /// 变量，终结符表达式
    /// </summary>
    public class VariableExpression : Expression
    {
        private char key;
        public VariableExpression(char key)
        {
            this.key = key;
        }

        public override double Interpret(Context context)
        {
            return context.Variable[this.key];
        }
    }

    /// <summary>
    /// 操作符，非终结符表达式
    /// </summary>
    public abstract class OperatorExpression : Expression
    {
        protected Expression left;
        protected Expression right;

        public OperatorExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }
    }

    public class AddExpression : OperatorExpression
    {
        public AddExpression(Expression left, Expression right)
            : base(left, right)
        {

        }

        public override double Interpret(Context context)
        {
            return this.left.Interpret(context) + this.right.Interpret(context);
        }
    }

    public class SubExpression : OperatorExpression
    {
        public SubExpression(Expression left, Expression right)
            : base(left, right)
        {

        }

        public override double Interpret(Context context)
        {
            return this.left.Interpret(context) - this.right.Interpret(context);
        }
    }

    public class MulExpression : OperatorExpression
    {
        public MulExpression(Expression left, Expression right)
            : base(left, right)
        {

        }

        public override double Interpret(Context context)
        {
            return this.left.Interpret(context) * this.right.Interpret(context);
        }
    }

    public class DivExpression : OperatorExpression
    {
        public DivExpression(Expression left, Expression right)
            : base(left, right)
        {

        }

        public override double Interpret(Context context)
        {
            return this.left.Interpret(context) / this.right.Interpret(context);
        }
    }
}
