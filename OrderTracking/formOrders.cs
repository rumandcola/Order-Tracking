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
    public partial class formOrders : Form
    {

        public string ordernumber;
        public formOrders()
        {
            InitializeComponent();
            dgvLoad();
        }

        public void dgvLoad()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files\Order Tracking\orderdb.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                //open the connection and assign query as string variable
                conn1.Open();
                string query1 = "select ordernumber, " +
                    "                   firstname, " +
                    "                   lastname, " +
                    "                   phone," +
                    "                   email," +
                    "                   convert(date,orderdate) as orderdate," +
                    "                   (select count(itemnumber) from invoiceitems where ordernumber = a.ordernumber) as item_count," +
                    "                   total from invoices as a where [status] = '1'";

                using (SqlCommand cmd1 = new SqlCommand { CommandText = query1, Connection = conn1 })
                {
                    //load query results into a databale to check for ordernumbers in if statement
                    dt.Load(cmd1.ExecuteReader());                                               
                }
            }
            dataGridViewOrders.DataSource = dt;

            DateTime today = DateTime.Today;

            foreach (DataGridViewRow row in dataGridViewOrders.Rows)
            {
                if (Convert.ToDateTime(row.Cells[5].Value) < today.AddDays(-14))
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                if (Convert.ToDateTime(row.Cells[5].Value) < today.AddDays(-21))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void buttonNewOrder_Click(object sender, EventArgs e)
        {
            //opens new instance of New Order form
            Form neworder = new formNewOrder(this);
            neworder.Show();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            dgvLoad();
        }

        private void dataGridViewOrders_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ordernumber = dataGridViewOrders.SelectedRows[0].Cells[0].Value.ToString();
            Form vieworder = new formViewOrder(ordernumber); 
            vieworder.Show();
        }
    }
}
