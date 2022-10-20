using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lap4_21dh110017_Nguyen_Thanh_An
{
    class MyExpressionTmp
    {
        private string[] token;
        private List<string> postfix;
        private MyStack opStack;
        public string[] Token
        {
            get
            {
                return token;
            }
            set
            {
                token = value;
            }
        }
        public List<string> Postfix
        {
            get
            {
                return postfix;
            }
            set
            {
                postfix = value;
            }
        }
        internal MyStack OpStack
        {
            get
            {
                return opStack;
            }
            set
            {
                opStack = value;
            }
        }
        public MyExpressionTmp() { }


        // khai báo data list kí tự

        public MyExpressionTmp(string[] t)
        {
            int n = t.Length;
            token = new string[n];
            for (int i = 0; i < n; i++)
            {
                token[i] = t[i];
            }
        }
        //xét độ ưu tiên 
        public int Pre(string t)
        {
            if (t == "*" || t == "/" || t == "%")
            {
                return 2;

            }
            if (t == "+" || t == "-")
            {
                return 1;
            }
            return 0;
        }
     

        public void outputPost()
        {
            foreach (var s in postfix)
                Console.Write(s); ;
            Console.WriteLine();

        }
        public List<string> ToInfix()
        {
            Postfix = new List<string>();
            opStack = new MyStack(Token.Length);
            for (int i = 0; i < Token.Length; i++)
            {
                if (char.IsLetterOrDigit(Token[i], 0))
                {
                    Postfix.Add(Token[i]);
                }
                else if (Token[i] == "(")
                {
                    opStack.Push(Token[i]);
                }
                else if (Token[i] == ")")
                {
                    while (opStack.Peek() != "(" && opStack.Count() > 0)
                    {
                        Postfix.Add(opStack.Pop());
                    }
                    opStack.Pop();
                }
                else
                {
                    while (opStack.Count() > 0 && Pre(Token[i]) <= Pre(opStack.Peek()))
                    {
                        Postfix.Add(opStack.Pop());
                    }
                    opStack.Push(Token[i]);
                }
            }
            while (opStack.Count() > 0)
            {
                Postfix.Add(opStack.Pop());
            }
            return Postfix;
        }

        public string ValuePostfix()
        {
            opStack = new MyStack(Postfix.Count());
            for (int i = 0; i < Postfix.Count(); i++)
            {
                if (char.IsLetterOrDigit(Postfix[i], 0))
                {
                    opStack.Push(Postfix[i]);
                }
                else
                {
                    int b = int.Parse(opStack.Pop());
                    int a = int.Parse(opStack.Pop());
                    
                    if (Postfix[i] == "+")
                    {
                        int sum = a + b;
                        opStack.Push(sum.ToString());
                    }
                    else if (Postfix[i] == "-")
                    {
                        int sum = a - b;
                        opStack.Push(sum.ToString());
                    }
                    else if (Postfix[i] == "/")
                    {
                        int s = a / b;
                        opStack.Push(s.ToString());
                    }
                    else if (Postfix[i] == "*")
                    {
                        int s = a * b;
                        opStack.Push(s.ToString());
                    }
                    else if (Postfix[i] == "%")
                    {
                        int s = a % b;
                        opStack.Push(s.ToString());
                    }
                }
            }
            return opStack.Pop();
        }
    }
}

    




    

