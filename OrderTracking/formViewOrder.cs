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
using System.Globalization;

namespace OrderTracking
{
    public partial class formViewOrder : Form
    {

        public string orderid;

        public formViewOrder(string ordernumber)
        {
            InitializeComponent();

            string orderid = ordernumber;

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files\OrderTracking\orderdb.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                string sql = "select ordernumber," +
                    "                convert(date,orderdate) as orderdate," +
                    "                firstname," +
                    "                lastname," +
                    "                street," +
                    "                city," +
                    "                state," +
                    "                zip," +
                    "                phone," +
                    "                email," +
                    "                item1," +
                    "                item2," +
                    "                item3," +
                    "                item4," +
                    "                item5," +
                    "                shipping," +
                    "                subtotal," +
                    "                total" +
                    " from invoices where ordernumber = @orderid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@orderid", orderid);
                conn.Open();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
            }

            labelOrderNumberGenerated.Text = orderid.ToString();
            dateTimePickerViewOrder.Value = Convert.ToDateTime(dt.Rows[0][1]);
            textBoxFirstNameViewOrder.Text = dt.Rows[0][2].ToString();
            textBoxLastNameViewOrder.Text = dt.Rows[0][3].ToString();
            textBoxStreetViewOrder.Text = dt.Rows[0][4].ToString();
            textBoxCityViewOrder.Text = dt.Rows[0][5].ToString();
            textBoxStateViewOrder.Text = dt.Rows[0][6].ToString();
            textBoxZipViewOrder.Text = dt.Rows[0][7].ToString();
            textBoxPhoneViewOrder.Text = dt.Rows[0][8].ToString();
            textBoxEmailViewOrder.Text = dt.Rows[0][9].ToString();
            if (dt.Rows[0][15].ToString() == "25")
            {
                textBoxDeliveryMethodViewOrder.Text = "Shipping";
            }
            else
            {
                textBoxDeliveryMethodViewOrder.Text = "Pick Up";
            }
            textBoxShippingViewOrder.Text = dt.Rows[0][15].ToString();
            textBoxSubTotalViewOrder.Text = dt.Rows[0][16].ToString();
            textBoxTotalViewOrder.Text = dt.Rows[0][17].ToString();
        }

        private void buttonCloseOrder_Click(object sender, EventArgs e)
        {
            orderid = labelOrderNumberGenerated.Text;
            formCloseOrder fco = new formCloseOrder(orderid);
            fco.Show();
        }
    }
}

