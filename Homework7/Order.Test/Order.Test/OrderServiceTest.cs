using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Order.Test
{
    [TestClass()]
    public class OrderServiceTest
    {
        [TestMethod]
        public void AddOrderTest()
        {
            OrderService orderService = new OrderService();
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");

            theOrder milk = new theOrder(1, "Milk", 69.9f);
            theOrder apple = new theOrder(3, "apple", 5.59f);

            Order order1 = new Order(1, customer1);
            order1.AddDetails(new OrderDetail(apple, 8));
            Order order2 = new Order(2, customer2);
            order2.AddDetails(new OrderDetail(milk, 10));
            order2.AddDetails(new OrderDetail(apple, 8));

            orderService.AddOrder(order1);
            Assert.IsTrue(1 == orderService.QueryAll().Count());

            orderService.AddOrder(order2);
            Assert.IsTrue(2 == orderService.QueryAll().Count());

            try
            {
                orderService.AddOrder(order1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.IsTrue("the orderList contains an order with ID 1 !" == e.Message);
            }
        }

        [TestMethod()]
        public void UpdateTest()
        {
            OrderService orderService = new OrderService();
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");

            Goods milk = new Goods(1, "Milk", 69.9f);
            Goods apple = new Goods(3, "apple", 5.59f);

            Order order1 = new Order(1, customer1);
            order1.AddDetails(new OrderDetail(apple, 8));


            orderService.AddOrder(order1);
            Order order1_change = new Order(1, customer1);

            order1_change.AddDetails(new OrderDetail(apple, 8));
            order1_change.AddDetails(new OrderDetail(milk, 10));
            orderService.Update(order1_change);
            Assert.AreEqual(order1_change, orderService.QueryAll()[0]);

        }

        [TestMethod()]
        public void GetByIdTest()
        {
            OrderService orderService = new OrderService();
            Customer customer1 = new Customer(1, "Customer1");
            Goods apple = new Goods(3, "apple", 5.59f);
            Order order1 = new Order(1, customer1);
            order1.AddDetails(new OrderDetail(apple, 8));
            orderService.AddOrder(order1);
            Assert.AreEqual(order1, orderService.GetById(1));
            Assert.IsNull(orderService.GetById(2));

        }

        [TestMethod()]
        public void DelOrderTest()
        {
            OrderService orderService = new OrderService();

            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");

            Goods milk = new Goods(1, "Milk", 69.9f);
            Goods apple = new Goods(3, "apple", 5.59f);

            Order order1 = new Order(1, customer1);
            order1.AddDetails(new OrderDetail(apple, 8));
            Order order2 = new Order(2, customer2);
            order2.AddDetails(new OrderDetail(milk, 10));
            order2.AddDetails(new OrderDetail(apple, 8));

            orderService.AddOrder(order1);
            orderService.AddOrder(order2);

            orderService.RemoveOrder(1);
            Assert.AreEqual(order2, orderService.QueryAll()[0]);




        }

        [TestMethod()]
        public void QueryAllTest()
        {
            OrderService orderService = new OrderService();

            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");

            Goods milk = new Goods(1, "Milk", 69.9f);
            Goods apple = new Goods(3, "apple", 5.59f);

            Order order1 = new Order(1, customer1);
            order1.AddDetails(new OrderDetail(apple, 8));
            Order order2 = new Order(2, customer2);
            order2.AddDetails(new OrderDetail(milk, 10));
            order2.AddDetails(new OrderDetail(apple, 8));

            orderService.AddOrder(order1);
            orderService.AddOrder(order2);



            Assert.AreEqual(order1, orderService.QueryAll()[0]);
            Assert.AreEqual(order2, orderService.QueryAll()[1]);

        }

        [TestMethod()]
        public void QueryByAmountTest()
        {
            OrderService orderService = new OrderService();
            Customer customer1 = new Customer(1, "Customer1");
            Goods apple = new Goods(3, "apple", 6f);
            Order order1 = new Order(1, customer1);
            order1.AddDetails(new OrderDetail(apple, 8));
            orderService.AddOrder(order1);
            Assert.AreEqual(order1, orderService.QueryByTotalAmount(48)[0]);
            Assert.IsTrue(0 == orderService.QueryByTotalAmount(49).Count());
        }

        [TestMethod()]
        public void SortTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");

            Goods milk = new Goods(1, "Milk", 69.9f);
            Goods eggs = new Goods(2, "eggs", 4.99f);
            Goods apple = new Goods(3, "apple", 5.59f);

            Order order1 = new Order(1, customer1);
            order1.AddDetails(new OrderDetail(apple, 8));
            order1.AddDetails(new OrderDetail(eggs, 10));
            // order1.AddDetails(new OrderDetail(eggs, 8));
            order1.AddDetails(new OrderDetail(milk, 10));

            Order order2 = new Order(2, customer2);
            order2.AddDetails(new OrderDetail(eggs, 10));
            order2.AddDetails(new OrderDetail(milk, 10));

            Order order3 = new Order(3, customer2);
            order3.AddDetails(new OrderDetail(milk, 100));

            OrderService orderService = new OrderService();

            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            orderService.AddOrder(order3);
            orderService.Sort(
          (o1, o2) => o2.TotalAmount.CompareTo(o1.TotalAmount));
            Assert.AreEqual(order3, orderService.QueryAll()[0]);
            Assert.AreEqual(order1, orderService.QueryAll()[1]);
            Assert.AreEqual(order2, orderService.QueryAll()[2]);
        }

        [TestMethod()]
        public void ExportTest()
        {
            OrderService orderService = new OrderService();

            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");

            Goods milk = new Goods(1, "Milk", 69.9f);
            Goods apple = new Goods(3, "apple", 5.59f);

            Order order1 = new Order(1, customer1);
            order1.AddDetails(new OrderDetail(apple, 8));
            Order order2 = new Order(2, customer2);
            order2.AddDetails(new OrderDetail(milk, 10));
            order2.AddDetails(new OrderDetail(apple, 8));
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            orderService.Export(@".\order.xml");
            List<Order> importedOrders = orderService.Import(@".\order.xml");
            Assert.AreEqual(order1, importedOrders[0]);
            Assert.AreEqual(order2, importedOrders[1]);

        }

        [TestMethod()]
        public void ImportTest()
        {
            OrderService orderService = new OrderService();

            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");

            Goods milk = new Goods(1, "Milk", 69.9f);
            Goods apple = new Goods(3, "apple", 5.59f);

            Order order1 = new Order(1, customer1);
            order1.AddDetails(new OrderDetail(apple, 8));
            Order order2 = new Order(2, customer2);
            order2.AddDetails(new OrderDetail(milk, 10));
            order2.AddDetails(new OrderDetail(apple, 8));
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            orderService.Export(@".\order.xml");
            List<Order> importedOrders = orderService.Import(@".\order.xml");
            Assert.AreEqual(order1, importedOrders[0]);
            Assert.AreEqual(order2, importedOrders[1]);
        }
    }


}
    