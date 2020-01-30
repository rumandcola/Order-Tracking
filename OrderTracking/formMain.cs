using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderTracking
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        private void buttonOrders_Click(object sender, EventArgs e)
        {
            //opens new instance of Orders form
            Form orders = new formOrders();
            orders.Show();
        }

        private void buttonExpenses_Click(object sender, EventArgs e)
        {
            //opens new instance of Expenses form
            Form expenses = new formExpenses();
            expenses.Show();
        }
    }
}
