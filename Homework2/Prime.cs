using System;

class Prime
{
    static void Main(string[] args)
    {
        string a;
        int num;
        Console.WriteLine("输入一个正整数：");
        a = Console.ReadLine();
        num = int.Parse(a);
        Console.WriteLine("素数因子：");
        prime(num);
        Console.ReadKey();
    }
    private static void prime(int num)
    {
        int n = num;
        for(int i=2;i<=num;i++)
        {
            if (n % i == 0)
            {
                n = n / i;
                Console.WriteLine(i);
                i--;
            }
            
        }
    }

}

