using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Interpreter
{
    public class UpdatedContext
    {
        private int index = -1;
        private List<string> tokens = new List<string>();
        private string currentToken;

        public UpdatedContext(string expression)
        {
            string temp = string.Empty;
            while (!string.IsNullOrEmpty(expression))
            {
                if (expression.Substring(0, 1) != "+" && expression.Substring(0, 1) != "-" &&
                    expression.Substring(0, 1) != "*" && expression.Substring(0, 1) != "/")
                {
                    temp = temp + expression.Substring(0, 1);
                }
                else
                {
                    tokens.Add(temp);
                    tokens.Add(expression.Substring(0, 1));
                    temp = string.Empty;
                }

                expression = expression.Substring(1);
            }

            if (temp != string.Empty)
            {
                tokens.Add(temp);
            }
        }

        public void NextToken()
        {

        }

        public void GetCurrentToken()
        {

        }

        public void SkipToken()
        {

        }

        public double GetCurrentNumber()
        {
            double number = 0;
            try
            {
                // 将字符串转换为数
                number = Convert.ToDouble(currentToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine("错误提示：{0}", ex.Message);
            }

            return number;
        }
    }
}
