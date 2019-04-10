using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Order
{
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
            Console.WriteLine("\n请输入商品名：");
            theOrder.Oname = Console.ReadLine();
            Console.WriteLine("\n请输入数量：");
            theOrder.Oamount = int.Parse(Console.ReadLine());
            Console.WriteLine("\n请输入客户名：");
            theOrder.Oclient = Console.ReadLine();
            Console.WriteLine("\n请输入单价：");
            theOrder.Ovalue = int.Parse(Console.ReadLine());
            return theOrder;
        }

        public void ShowOrderInfo(OrderDetails theOrder)
        {
            if (theOrder == null) return;
            Console.WriteLine("订单的信息是: ");
            Console.Write("订单号:{0}", theOrder.Ono);
            Console.Write("\n商品名: {0}", theOrder.Oname);
            Console.Write("\n数量: {0}", theOrder.Oamount);
            Console.Write("\n客户:{0}", theOrder.Oclient);
            Console.Write("\n单价: {0}", theOrder.Ovalue);
            double tvalue;
            tvalue = theOrder.Oamount * theOrder.Ovalue;
            Console.WriteLine("总价为：{0}", tvalue);
        }
        //改进后的以LINQ语言的查询算法
        public static OrderDetails Search(int Ono)
        {

            //for (int i = 0; i < Orders.Count; i++)
            //{
            //    if (Orders[i].Ono == Ono)
            //    {
            //        return Orders[i];
            //    }
            //}
            //return null;
            List<OrderDetails> result = new List<OrderDetails>();
            var query =
                from O in Orders
                where O.Ono == Ono
                select O;
            foreach (OrderDetails i in query)
            {
                Console.Write("", i);
            }
            return null;
        }

        public static OrderDetails[] Search(string Oname)
        {
            //    List<OrderDetails> orderList = new List<OrderDetails>();

            //    for (int i = 0; i < Orders.Count; i++)
            //    {
            //        if (Orders[i].Oname == Oname)
            //        {
            //            orderList.Add(Orders[i]);
            //        }
            //    }
            //    return orderList.ToArray();
            List<OrderDetails> result = new List<OrderDetails>();
            var query =
                from O in Orders
                where O.Oname == Oname
                select O;
            foreach (OrderDetails i in query)
            {
                Console.Write("", i);
            }
            return null;

        }
        public void Export(string fname)
        {
            FileStream fs = new FileStream(fname, FileMode.Create, FileAccess.ReadWrite);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<OrderDetails>));
            xmlSerializer.Serialize(fs, Orders);
            fs.Close();
        }

        public void Import(string fname)
        {
            FileStream fs = new FileStream(fname, FileMode.Open, FileAccess.Read);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<OrderDetails>));
            Orders = (List<OrderDetails>)xmlSerializer.Deserialize(fs);
            fs.Close();
        }

        public static void ADD(OrderDetails theOrder)
        {
            if (theOrder == null)
            {

                Console.WriteLine("你所输入的信息有误，请重新输入！");
            }
            else
                if (theOrder.Equals(Orders))
            {
                Console.WriteLine("订单重复！");
            }
            else
            {
                Orders.Add(theOrder);
                Console.WriteLine("我们现在有{0}份订单信息", Orders.Count);
            }
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

        

        public static void sort1()
        {
           // Orders.Sort(.Ono);
            showAll();
        }

        public static void sort2()
        {
            Orders.Sort(
                (a, b) => a.Osum().CompareTo(b.Osum())
                       );
            showAll();

        }

        public static void showAll()
        {
            if (Orders.Count == 0)
                throw new Exception("订单列表为空！");
            int count = 1;
            foreach (OrderDetails i in Orders)
            {
                Console.WriteLine((count++) + "号订单");
                //因为order类重载了toString方法，所以可以直接 Console.WriteLine(i);         
                Console.WriteLine(i);
                
            }

        }
    }
}
