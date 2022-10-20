using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Lap4_21dh110017_Nguyen_Thanh_An
{
    internal class MyExpression
    {
        private string bieuThuc;
        private List<string> postfix;
        private MyStack opStack;
        public string BieuThuc
        {
            get
            {
                return bieuThuc;
            }
            set
            {
                bieuThuc = value;
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
        public MyExpression()
        {

        }
        public MyExpression(string bieuthuc)
        {
            BieuThuc = bieuthuc;
        }
        public string ChuanHoaBieuThuc(string bieuthuc)
        {
            string chuanHoa = String.Copy(bieuthuc);
            chuanHoa = chuanHoa.Replace(" ", "");
            chuanHoa = Regex.Replace(chuanHoa, @"\+|\-|\*|\/|\%|\(|\)", delegate (Match match)
            {
                return System.String.Format(" {0} ", match.Value);
            });
            chuanHoa = chuanHoa.Replace("  ", " ");
            chuanHoa = chuanHoa.Trim();
            return chuanHoa;
        }
        public List<string> TaoListInfix(string bieuthuc)
        {
            string[] chuanhoa = bieuthuc.Split(' ');
            List<string> token = new List<string>();
            for (int i = 0; i < chuanhoa.Length; i++)
            {
                token.Add(chuanhoa[i]);
            }
            return token;
        }
        public int DoUuTien(string s)
        {
            if (s == "+" || s == "-")
            {
                return 1;
            }
            else if (s == "*" || s == "/" || s == "%")
            {
                return 2;
            }
            else return -1;
        }
        public bool LaToanTu(string token)
        {
            return Regex.Match(token, @"\+|\-|\*|\/|\%|").Success;
        }
        public bool LaToanHang(string token)
        {
            return Regex.Match(token, @"^\d+$|^[a-z]|[A-Z]$").Success;
        }
        public List<string> Infix2Postfix(List<string> Token)
        {
            Postfix = new List<string>();
            opStack = new MyStack(Token.Count);
            for (int i = 0; i < Token.Count; i++)
            {
                if (LaToanHang(Token[i]))
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
                    while (opStack.Count() > 0 && DoUuTien(Token[i]) <= DoUuTien(opStack.Peek()))
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
                        int s = a + b;
                        opStack.Push(s.ToString());
                    }
                    else if (Postfix[i] == "-")
                    {
                        int s = a - b;
                        opStack.Push(s.ToString());
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
                    else
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











