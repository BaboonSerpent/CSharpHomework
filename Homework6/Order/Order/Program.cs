using System;
using System.Collections.Generic;
using System.Text;

namespace Order
{
    class Operate//用户操作类
    {
        public void Check()
        {
            do
            {
                Console.WriteLine
                ("请选择所要操作的种类：\n1、添加订单信息 \n2、删除订单信息 \n3、查询订单总数 \n4、查询订单信息（按订单名）\n5、按订单号排序\n6、按订单总金额排序");
                int number = int.Parse(Console.ReadLine());
                if (number > 6 || number < 1)
                    Console.WriteLine("你的输入有误，请重新输入！");
                OrderService theOrderService = new OrderService();
                
                switch (number)
                {

                    case 1:
                        OrderDetails Order = OrderService.Information();
                        OrderService.ADD(Order);
                        theOrderService.ShowOrderInfo(Order);
                        break;
                    case 2:
                        Console.WriteLine("请输入你要删除的订单信息：");
                        Console.WriteLine("请输入订单号：");
                        int Ono = int.Parse(Console.ReadLine());
                        OrderService.Search(Ono);
                        OrderService.Delete(Ono);
                        break;
                    case 3:
                        OrderService.Volume();
                        break;
                    case 4:
                        Console.WriteLine("请输入你要查询的订单信息：");
                        Console.WriteLine("请输入订单名：");
                        string Oname = Console.ReadLine();
                        OrderDetails[] orderList = OrderService.Search(Oname);
                        for (int i = 0; i < orderList.Length; i++)
                        {
                            theOrderService.ShowOrderInfo(orderList[i]);
                        }
                        break;
                    case 5:
                        OrderService.sort1();
                        break;
                    case 6:
                        OrderService.sort2();
                        break;
                    
                }
                Console.Write("Do you want to continue?(y/n)");
                if (Console.ReadLine() != "y")
                    break;

            } while (true);

        }

    }
    class Program
    {

        public static void Main(string[] args)
        {
            Operate myOperate = new Operate();
            myOperate.Check();
        }

    }
}