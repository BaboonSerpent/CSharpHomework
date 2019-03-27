using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    class Order:IComparable
    {
        public int Ono, Oamount;
        public double Ovalue;
        public string Oname;
        public string Oclient;
        public List<OrderDetails> goods;
        public Order(int ono,int oamount,double ovalue,String oclient)
        {
            Ono = ono;
            Oamount = oamount;
            Ovalue = ovalue;
            Oclient = oclient;
        }

       
        public override string ToString()
        {
            string result = "";
            result += $"OrderNO:{Ono}\n";
            result += $"OrderClient:{Oclient}\n";
            foreach (OrderDetails t in this.goods)
            {               
                result += t + "\n";
            }
            return result;
        }

        public double sum()
        {
            double result = 0;
            foreach (var i in goods)
                result += i.Ovalue * i.Oamount;
            return result;
        }



        public override bool Equals(object obj)
        {
            var two = obj as Order;
            return Ono == two.Ono;
        }


        public override int GetHashCode()
        {
            return -1281522980 + EqualityComparer<string>.Default.GetHashCode(Oname);
        }

        public int CompareTo(object obj)
        {
            var two = obj as Order;
            return Ono.CompareTo(two.Ono);
        }

    }
}
