using System;
using System.Collections.Generic;
using System.Text;

namespace Order
{
    class OrderDetails//订单明细类
    {
        public int Ono, Oamount;
        public string Oname;
        public string Oclient;

    }

    class OrderService//订单服务类
    {

        public static List<OrderDetails> Orders;
        public static int Count
        {
            get
            {
                return Orders.Count;
            }
        }

        static OrderService()
        {
            Orders = new List<OrderDetails>();
        }

        public static OrderDetails Information()
        {
            OrderDetails theOrder = new OrderDetails();
            Console.WriteLine("请输入要添加的订单信息：");
            Console.WriteLine("\n请输入订单号：");
            theOrder.Ono = int.Parse(Console.ReadLine());
            Console.WriteLine("\n请输入订单名：");
            theOrder.Oname = Console.ReadLine();
            Console.WriteLine("\n请输入数量：");
            theOrder.Oamount = int.Parse(Console.ReadLine());
            Console.WriteLine("\n请输入客户名：");
            theOrder.Oclient = Console.ReadLine();
           

            return theOrder;

        }
        public void  ShowOrderInfo(OrderDetails theOrder)
        {
            if (theOrder == null) return;
            Console.WriteLine("订单的信息是: ");
            Console.Write("订单号:{0}", theOrder.Ono);
            Console.Write("\n商品名: {0}", theOrder.Oname);
            Console.Write("\n数量: {0}", theOrder.Oamount);
            Console.Write("\n:{0}", theOrder.Oclient);
            Console.WriteLine();
        }
        public static OrderDetails Search(int Sno)
        {

            for (int i = 0; i < Orders.Count; i++)
            {
                if (Orders[i].Ono == Sno)
                {
                    return Orders[i];
                }
            }
            return null;

        }

        public static void ADD(OrderDetails theOrder)
        {
            if (theOrder != null)
            {
                Orders.Add(theOrder);
                Console.WriteLine("我们现在有{0}份订单信息", Orders.Count);
            }
            else
                Console.WriteLine("你所输入的信息有误，请重新输入！");

        }

        public static void Delete(int Ono)
        {
            OrderDetails Order = Search(Ono);
            if (Order != null)
            {
                Orders.Remove(Order);
                Console.WriteLine("已经删除订单号为{0}的订单", Ono);
                Console.WriteLine("现在还有{0}份订单信息", Orders.Count);
            }
            else
                Console.WriteLine("未找到要删除的订单，请重新输入！");
        }

        public static void Volume()
        {
            Console.WriteLine("查询到订单的总数为{0}", Orders.Count);
        }

        public static OrderDetails[] Search(string Oname)
        {
            List<OrderDetails> orderList = new List<OrderDetails>();

            for (int i = 0; i < Orders.Count; i++)
            {
                if (Orders[i].Oname == Oname)
                {
                    orderList.Add(Orders[i]);
                }
            }

            return orderList.ToArray();
        }
    }
    class Operate//用户操作类
    {
        public void Check()
        {
            do
            {
                Console.WriteLine
                ("请选择所要操作的种类：\n1、添加订单信息 \n2、删除订单信息 \n3、查询订单总数 \n4、查询订单信息（按订单名）");
                int number = int.Parse(Console.ReadLine());
                if (number > 4 || number < 1)
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