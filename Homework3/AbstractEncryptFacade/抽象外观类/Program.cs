using System;
using System.Configuration;
using System.Reflection;
namespace FacadeSample
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractEncryptFacade ef; //针对抽象外观类编程
                                      //读取配置文件
            string facadestring = Configurationmanager.Appsettings["facade"];
            ///反射生成对象
            ef = (AbstractEncryptFacade)Assembly.Load("FacadeSample").CreateInstance(facadeString);
            ef.FileEncrypt("src.txt", "des.txt");
            Console.Read();
        }
    }
}