using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lap4_21dh110017_Nguyen_Thanh_An
{
    class MyStack
    {
        private string[] stkArray;
        private int stkTop;
        private int stkMax;

        private int StkTop
        {
            get => stkTop;
            set => stkTop = value;
        }

        public int StkMax
        {
            get => stkMax;
            set => stkMax =value;
        }

        public string [] StkArray
        {
            get => stkArray;
            set => stkArray = value;
        }
        public MyStack (int maxItem = 0)
        {
            StkMax = maxItem;
            stkArray = new string[StkMax];
            StkTop = -1;
        }

        public MyStack (MyStack s)
        {
            this.stkArray = s.stkArray;
            this.stkMax = s.stkMax;
            this.stkTop = s.stkTop;
        }
        //methor
        public bool IsEmpty()
        {
            return StkTop == -1;
        }

        private bool IsFull()
        {
            return StkTop == StkMax - 1; 
        }

        public string this[int i]
        {
            get
            {
                return stkArray[i];
            }
            set
            {
                stkArray[i] = value;
            }
        }

        public void Push(string newitem) //Đưa phần tử vào Stack
        {
            if (IsFull())
            {
                Console.WriteLine("Stack is full");
                return;
            }
            StkTop++;
            StkArray[StkTop] = newitem;
        }
        public string Pop() //Lấy phần tử ra khỏi Stack
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty");
                return null;
            }
            else
            {
                string st = StkArray[StkTop];
                stkArray[stkTop] = "null";
                StkTop--;
                return st;
            }
        }
        public string Peek() //Xem giá trị phần tử tại đỉnh Stack mà không xoá khỏi stack
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty");
                return null;
            }
            return StkArray[StkTop];
        }
        public void Input()
        {
            string x;
            StkArray = new string[StkMax];
            Console.Write("nhap cac tu so (. de ket thuc)");
            do
            {
                x = Console.ReadLine();
                if (x == ".") break;
                Push(x);
            } while (true);
        }
        public void GetStack()
        {
            
                while (!IsEmpty())
                {
                    Console.WriteLine(StkArray[StkTop]);
                    StkTop--;
                }
            
        }
        public void Clear()
        {
            StkTop = -1;
        }
        public int Count() 
        {
            return StkTop + 1;
        }
        public bool Contains(string x)
        {
            if (IsEmpty())
            {
                for (int i = stkTop + 1; i < stkMax; i++)
                {
                    if (stkArray[i] == x) return true;
                }

            }
                return false;
        }
      
    }
}
