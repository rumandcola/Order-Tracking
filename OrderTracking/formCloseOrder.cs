using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderTracking
{
    public partial class formCloseOrder : Form
    {
        public string closeorderid;
        public formCloseOrder(string orderid)
        {
            InitializeComponent();

            closeorderid = orderid;

            comboBoxReasonCloseOrder.Items.Add("Fulfilled");
            comboBoxReasonCloseOrder.Items.Add("Cancelled");

            

        }

        private void buttonCloseFormCloseOrder_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files\OrderTracking\orderdb.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                string sql = "update invoices set status = @status where ordernumber = @ordernumber";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@ordernumber", DbType.String).Value = closeorderid.ToString();
                if ((string)comboBoxReasonCloseOrder.SelectedItem == "Fulfilled")
                {
                    cmd.Parameters.Add("@status", DbType.Int32).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add("@status", DbType.Int32).Value = 2;
                }
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("Order status updated.");
                conn.Close();
            }
            formViewOrder fvo = (formViewOrder)Application.OpenForms["formViewOrder"];
            formOrders fo = (formOrders)Application.OpenForms["formOrders"];
            fo.dgvLoad();
            fvo.Close();
            this.Close();
        }
    }
}
