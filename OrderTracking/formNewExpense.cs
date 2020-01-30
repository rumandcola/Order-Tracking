using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OrderTracking
{
    public partial class formNewExpense : Form
    {

        DateTimePicker dtp = new DateTimePicker();
        Rectangle _Rectangle;

        public formNewExpense()
        {
            InitializeComponent();

            dgvNewExpense.Columns.Add("item", "Item");            
            dgvNewExpense.Columns.Add("date", "Date");
            dgvNewExpense.Columns.Add("quantity", "Quantity");
            dgvNewExpense.Columns.Add("price", "Price");

            dgvNewExpense.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.TextChanged += new EventHandler(dtp_TextChange);

        }

        private void buttonDeleteNewExpense_Click(object sender, EventArgs e)
        {

        }

        private void buttonSaveNewExpense_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dgvNewExpense.Rows)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files\OrderTracking\orderdb.mdf;Integrated Security=True;Connect Timeout=30");
                string sql = "insert into expenses (item, date, quantity, price) values (@item, @date, @quantity, @price)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@item", dgvNewExpense.Columns[0].ToString());
                cmd.Parameters.AddWithValue("@date", dgvNewExpense.Columns[1].ToString());
                cmd.Parameters.AddWithValue("@quantity", int.Parse(dgvNewExpense.Rows[0].Cells["quantity"].Value.ToString()));
                cmd.Parameters.AddWithValue("@price", float.Parse(dgvNewExpense.Rows[0].Cells["price"].Value.ToString()));
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void dgvNewExpense_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch(dgvNewExpense.Columns[e.ColumnIndex].Name)
            {
                case "date":

                    _Rectangle = dgvNewExpense.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                    dtp.Location = new Point(_Rectangle.X, _Rectangle.Y);
                    dtp.Visible = true;

                    break;
            }
        }

        private void dtp_TextChange(object sender, EventArgs e)
        {
            dgvNewExpense.CurrentCell.Value = dtp.Text.ToString();
        }

        private void dgvNewExpense_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dtp.Visible = false;
        }

        private void dgvNewExpense_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
        }
    }
}
