using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Order;



namespace OrderService
{
    //主窗口（负责增加订单、删除订单、修改订单）
    public partial class Form1 : Form
    {
        List<OrderDetails> orders = new List<OrderDetails>();

        // 订单号，商品名，客户名
        OrderDetails order1 = new OrderDetails(1001, "A", "SHJ");
        
        //订单号，购买个数，单价
        OrderDetails details1 = new OrderDetails(1, 1, 6999);
        
        public int Keyword { get; set; }

        RadioButton search, build, modify, delete;
        public Form1()
        {
            InitializeComponent();
            order1.Add(details1);
           
            OrderService.Add(order1);
        


            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void search_menu_CheckedChanged(object sender, EventArgs e)
        {
            if (search.Checked)
            {
                search = search.order;
                
                grid.ReadOnly = true;
            }

        }



        private void build_menu_CheckedChanged(object sender, EventArgs e)
        {
            Order neworder = new Order();
            Form2 dialog1 = new Form2(neworder);
            if (build_menu.Checked)
            {
                build = build_menu;
                TextInput.ReadOnly = true;
                dialog1.Visible = false;
                dialog1.ShowDialog();
                order_bs.ResetBindings(false);
            }

        }

       

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {

        }

        private void delete_menu_CheckedChanged(object sender, EventArgs e)
        {
            if (delete_menu.Checked)
            {
                Refresh();
                delete = deleteorders;
                TextInput.ReadOnly = true;
                grid.ReadOnly = false;
                order_bs.ResetBindings(false);
            }
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (Keyword.ToString() == null || Keyword.ToString() == "")
                Orders.DataSource = orderlist;
            else
            {
                Orders.DataSource = orderlist.Where(s => s.no == Keyword);
            }
        }
    }
}