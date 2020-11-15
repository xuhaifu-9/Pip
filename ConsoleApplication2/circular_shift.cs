using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
namespace Kwic
{
    class Circular_shift : Filter //Filter类 将继承输入管道inpipe和输出管道 outpipe
    {
        public Circular_shift(Pipe input, Pipe output) : base(input, output) //初始化 基类 管道
        {


        }
        public override void transform()
        {
            String str1;
            ArrayList al = new ArrayList(); //将每行分离的单词 放入al中
            StringBuilder sb = new StringBuilder();//重新构造字符串 单词间只包含一个空格
            String[] words= { };
            while ((str1 = inpipe.Read()) != null) //对从输入管道中 读取每处理行进行，将移位后的//字符串 写入outpipe 管道中 
            {
                sb.Remove(0, sb.Length);
                int n = 0;
                words = str1.Split(' ');
                words = words.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                foreach (string str2 in words)
                {
                    n++;
                }
                for (int i = 0;i<n ; i++)
                {
                    for (int j = i; j < n+i; j++)
                    {
                        sb.Append(words[(j)%n]);
                        sb.Append(" ");
                    }
                    sb.Append("\n");
                    outpipe.Write(sb.ToString());
                    sb.Remove(0, sb.Length);
                }
            }
        }
    }
}
