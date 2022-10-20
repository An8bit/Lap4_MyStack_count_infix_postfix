using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lap4_21dh110017_Nguyen_Thanh_An
{
    class Program
    {
        static void Main(string[] args)
        {
            TestMyExpressionTmp();

            TestMyExpression();
            Console.ReadKey();

        }
        static void TestContens(string x)
        {
            MyStack ssss = new MyStack(100);
            ssss.Input();
            ssss.GetStack();
            if (ssss.Contains(x) == true)
            {
                Console.WriteLine("{0} ton tai trong stack", x);
            }
            else
            {
                Console.WriteLine("{0} khong ton tai trong stack", x);
            }

        }

        static void TestClear()
        {
            MyStack ssss = new MyStack(100);
            ssss.Input();
            ssss.GetStack();
            ssss.Clear();
            Console.WriteLine("CLEAR");
            ssss.GetStack();
        }

        static void TestMyExpressionTmp()
        {
            string[] token = { "(", "(", "10", "+", "4", ")", "*", "2",
                               "+", "(", "20", "/", "5", "-",
                                 "3", ")", ")", "%", "3"  };
            MyExpressionTmp myExp = new MyExpressionTmp(token);
            myExp.ToInfix();
            myExp.outputPost();
            Console.WriteLine("Postfix "+ myExp.ValuePostfix());
          
        }

        static void TestMyExpression()
        {
            string b = " ((10+4)*2+          (20/5-3))%3";
            MyExpression my = new MyExpression();
            string s = my.ChuanHoaBieuThuc(b);
            List<string> ab = new List<string>();
            ab = my.TaoListInfix(s);
            my.Infix2Postfix(ab);
            Console.WriteLine("Infix to Postfix");
            foreach (var item in my.Infix2Postfix(ab))
            {
                Console.Write(item);
            }
            Console.WriteLine("PostFix: " + my.ValuePostfix());
        }
        
    }
}
        
