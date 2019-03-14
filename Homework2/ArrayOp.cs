using System;

namespace ArrayOp
{
    class ArrayOp
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 0, 1, 3, 4, 6, 7, 9, 11 };
            int max, min, sum;
            double avr;
            max = Max(arr);
            min = Min(arr);
            sum = Sum(arr);
            avr = Avr(arr);
            Console.WriteLine("数组为：");
            foreach(int i in arr)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("数组最大值为：" + max);
            Console.WriteLine("数组最小值为：" + min);
            Console.WriteLine("数组和为：" + sum);
            Console.WriteLine("数组平均值为：" + avr);
            Console.ReadKey();
        }
        private static int Max(int [] arr)
        {
            int max;
            max = arr[0];
            foreach(int i in arr)
            {
                if (i >= max)
                    max = i;
            }
            return max;
        }
        private static int Min(int[] arr)
        {
            int min;
            min = arr[0];
            foreach (int i in arr)
            {
                if (i <= min)
                    min = i;
            }
            return min;
        }
        private static int Sum(int[] arr)
        {
            int sum = 0;
            foreach (int i in arr)
            {
                sum = sum + i;
            }
            return sum;
        }
        private static double Avr(int[] arr)
        {
            double  sum = 0;
            double Avr;
            foreach (int i in arr)
            {
                sum = sum + i;
            }
            Avr = sum / arr.Length;
            return Avr;
        }

    }
}
