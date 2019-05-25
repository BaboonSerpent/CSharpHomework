using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    class OrderDetails//订单明细类
    {
        public static List<OrderDetails> Orders;
        public int Ono, Oamount;
        public double Ovalue;
        public string Oname;
        public string Oclient;


        public double Osum()
        {
            double result = 0;
            foreach (OrderDetails i in Orders)
                result += i.Ovalue * i.Oamount;
            return result;
        }

        public override bool Equals(object obj)
        {
            var detail = obj as OrderDetails;
            return detail != null &&
                Ono == detail.Ono &&
                Oname==detail.Oname&&
                Oamount== detail.Oamount;
        }

        public override int GetHashCode()//自动生成
        {
            var hashCode = 1276681454;
            hashCode = hashCode * -1521134295 + Ono.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Oname);
            hashCode = hashCode * -1521134295 + Oamount.GetHashCode();
            return hashCode;
        }

        public override string ToString()

        {
            string result = "";
            result += $"Name:{Oname}, Value:{Ovalue}, quantity:{Oamount}";
            return result;
        }
    }
}
