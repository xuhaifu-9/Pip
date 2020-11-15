using System;
using System.IO ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Kwic
{
   public class Pipe
    {
       
        Queue<String> q1; //用Queue 来表示管道内的数据结构 ，存放字符串
        public Pipe()
        {
              //自己填写代码 实现 对 q1 初始化 即 分配空间，需要了解 Queue泛型类对象的创//建，可通过网络查询  
            q1 = new Queue<string>(); 
        }
        public void Write(String str1) //将str1写入 管道中
        {
             //自己编写代码，将 str1 加入q1队列中，进行入队操作 
            q1.Enqueue(str1);
        }
        public String Read() //从管道中读取 一个字符串
        {
            String st=null;
           //自己编写代码实现 当q1队列中元素个数>0时，调用q1的出队方法 将字符串存入st中
            if (q1.Count > 0)
            {
                st = q1.Dequeue();
            }

           return st;
        }
        public Boolean Empty() //判断管道是否为空，如果为空返回 true，否则 返回false
        {
            Boolean b = true;
            //自己编写代码 判断 q1队列是否为空
            if (q1.Count != 0)
            {
                b = false;
            }
            return b;
        }

        internal void Write()
        {
            throw new NotImplementedException();
        }
    }
}
/*C．完成 上面的代码后，建立 Filter.cs 类文件 并建立 Filter抽象类
Filter.cs文件内容如下：完成相关代码
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Kwic
{
   public abstract class Filter
    {
        protected Pipe inpipe;
        protected Pipe outpipe;
        public Filter()
        {
        }
        public Filter(Pipe pipeinput,Pipe pipeoutput) {
              //自己编写代码实现 构造函数对 inpipe和outpipe 初始化
    }

         public abstract void transform(); //抽象函数 完成过滤器的处理
    public void run() 
    {
    	try{
    	transform();
    	}catch(Exception ex){
    		Console.WriteLine(ex.Message);
    	}
    }

    }
}
D．建立Filter类的派生类 Input_Filter.cs文件，并建立派生类 Input_Filter
Input_Filter.cs 文件如下：
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Kwic
{
  public   class Input_Filter:Filter  //继承Filter
    {
        StreamReader Sr; //读取文件流
       public Input_Filter(FileStream fs, Pipe outpipe1):base(null,outpipe1 ) //初始化基类继承来的 //outpipe子对象
        {
                //自己写代码 实现：利用fs 创建StreamReader 文本读取流对象Sr
           
        }
       public override void transform() //转换 将Sr文本输入流对象读取的每行字符串 写到 outpipe管//道中
       {
           String st;
          //自己编程实现：通过循环不断从Sr流对象中，读取一行字符串存入st中， 并将st写入管
//道outpipe，直到Sr中读取的为null
         


          Sr.Close();
       }
    }
}
E.在Program.c文件中编写如下代码，测试 输入过滤器是否正常
将 Input.txt 文件 拷贝到D：\
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace Kwic
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fr = new FileStream("d:\\input.txt", FileMode.Open);
            Pipe in_cs,cs_al,al_ou;
            in_cs = new Pipe();
           Input_Filter input = new Input_Filter(fr, in_cs);// 装配Input_Filter过滤器输入fs，输出 管道//p1
           input.run();
          
            //输出in_cs管道数据 观察和input.txt文件内容是否一致
            String str;
            while((str=in_cs.Read())!=null)
            Console.WriteLine(str);
            Console.Read();
        }
    }
}*/

