using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMHDTVPlotTool
{
    class Stack
    {
        int maxsize;        //顺序栈的容量
        object[] data;      //数组，用于存储栈中的数据
        int top;            //指示栈顶

        public object this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }
        //栈容量属性
        public int Maxsize
        {
            get
            {
                return maxsize;
            }
            set
            {
                maxsize = value;
            }
        }
        //获得栈顶的属性
        public int Top
        {
            get
            {
                return top;
            }
        }
        //使用构造器初始化栈
        public Stack(int size)
        {
            data = new object[size];
            maxsize = size;
            top = -1;
        }
        //求栈的长度（栈中的元素个数）
        public int StackLength()
        {
            return top + 1;
        }
        //清空顺序栈
        public void ClearStack()
        {
            top = -1;
        }
        //判断顺序栈是否为空
        public bool IsEmpty()
        {
            if (top == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //判断顺序栈是否为满
        public bool IsFull()
        {
            if (top == maxsize - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //入栈操作
        public void Push(object e)
        {
            if (IsFull())
            {
                Console.WriteLine("栈已满！");
                return;
            }
            data[++top] = e;
        }
        //出栈操作，并返回出栈的元素
        public object Pop()
        {
            object temp = null;
            if (IsEmpty())
            {
                Console.WriteLine("栈为空！");
                return temp;
            }
            temp = data[top];
            top--;
            return temp;
        }
        //获取栈顶数据元素
        public object GetTop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("栈为空！");
                return null;
            }
            return data[top];
        }
    }
}
