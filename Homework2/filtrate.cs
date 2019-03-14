using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Filtrate
    {
        static void Main(string[] args)
        {
        Console.WriteLine("埃式筛法求2~100内的素数：");
        filtrate();
        Console.ReadKey();
        }
        private static void filtrate()
        {
        int[] arr = new int[99];
            for(int i=0;i<arr.Length;i++)
            {
            arr[i] = i + 2;
            }
            //将数组每一位定为2~99
            for(int j=2;j<=Math.Sqrt(arr.Length);j++)
            {
                for(int m=0;m<arr.Length;m++)
                {
                if(arr[m] % j == 0 && arr[m]/j != 1)
                    arr[m] = -1;
                }
            }
            foreach(int i in arr)
            {
            if (i != -1)
                Console.WriteLine(i);
            }
        }
    }

