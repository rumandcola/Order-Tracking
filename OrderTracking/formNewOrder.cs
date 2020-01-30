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
    public partial class formNewOrder : Form
    {

        public int shipping;
        public int subtotal;
        public int total;
        public int price;
        public long itemid;
        public string dataDirectory;
        public string newid;

        public formOrders orders1;

        public formNewOrder(formOrders orders)
        {
            InitializeComponent();

            orders1 = orders;

            total = shipping + subtotal;

            //generates order number based on date and last order in database
            using (SqlConnection conn1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files\Order Tracking\orderdb.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                //open the connection and assign query as string variable
                conn1.Open();                
                string query1 = "select max(ordernumber) as ordernumber from invoices where substring(ordernumber,1,8) = convert(varchar(8),getdate(),112)";

                using (SqlCommand cmd1 = new SqlCommand{ CommandText = query1, Connection = conn1 })
                {     
                    //load query results into a databale to check for ordernumbers in if statement
                    DataTable dt = new DataTable();
                    dt.Load(cmd1.ExecuteReader());
                    
                    if ( dt.Rows[0]["ordernumber"] is DBNull)
                    {
                        //table is empty or no orders yet for the day, generate first number of the day
                        newid = DateTime.Today.ToString("yyyyMMdd") + "0001";
                        labelOrderNumberGenerated.Text = newid;
                    }
                    else
                    {
                        //grab last order number and increment it by 1, assign to id variable
                        long data = Convert.ToInt64(dt.Rows[0]["ordernumber"]);
                        data++;
                        long newid = data;
                        labelOrderNumberGenerated.Text = newid.ToString();               
                    }
                }
                conn1.Close();
            }

            //add columns to datagridview for order items
            dataGridViewOrderItemsNewOrder.Columns.Add("itemnumber", "ItemNumber");
            this.dataGridViewOrderItemsNewOrder.Columns["ItemNumber"].Visible = false;
            dataGridViewOrderItemsNewOrder.Columns.Add("style", "Style");
            dataGridViewOrderItemsNewOrder.Columns.Add("design", "Design");
            dataGridViewOrderItemsNewOrder.Columns.Add("decal", "Decal");
            dataGridViewOrderItemsNewOrder.Columns.Add("quantity", "Quantity");
            dataGridViewOrderItemsNewOrder.Columns.Add("price", "Price");
            this.dataGridViewOrderItemsNewOrder.Columns["Price"].Visible = false;
            dataGridViewOrderItemsNewOrder.Columns.Add("total", "Total");

            //populate Style combobox from styles table in local db
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files\Order Tracking\orderdb.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                try
                {
                    string query = "select * from state";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "States");
                    comboBoxStateNewOrder.DisplayMember = "stateCode";
                    comboBoxStateNewOrder.ValueMember = "stateCode";
                    comboBoxStateNewOrder.DataSource = ds.Tables["states"];
                }
                catch
                {
                    MessageBox.Show("Couldn't populate States from database!");
                }
            }

            //populate Style combobox from styles table in local db
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files\Order Tracking\orderdb.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                try
                {
                    string query = "select * from styles where status = 1";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Styles");
                    comboBoxStyleNewOrder.DisplayMember = "style";
                    comboBoxStyleNewOrder.ValueMember = "id";
                    comboBoxStyleNewOrder.DataSource = ds.Tables["styles"];
                }
                catch
                {
                    MessageBox.Show("Couldn't populate styles from database!");
                }
            }

            //populate Designs combobox from styles table in local db
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files\Order Tracking\orderdb.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                try
                {
                    string query = "select id, design from designs where status = 1";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Designs");
                    comboBoxDesignOrder.DisplayMember = "design";
                    comboBoxDesignOrder.ValueMember = "id";
                    comboBoxDesignOrder.DataSource = ds.Tables["designs"];
                }
                catch
                {
                    MessageBox.Show("Couldn't populate designs from database!");
                }
            }

            //populate Decals combobox from styles table in local db
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files\Order Tracking\orderdb.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                try
                {
                    string query = "select id, decal from decals where status = 1";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Decals");
                    comboBoxDecalNewOrder.DisplayMember = "decal";
                    comboBoxDecalNewOrder.ValueMember = "id";
                    comboBoxDecalNewOrder.DataSource = ds.Tables["decals"];
                }
                catch
                {
                    MessageBox.Show("Couldn't populate decals from database!");
                }
            }

            comboBoxQuantityNewOrder.Items.Add("1");
            comboBoxQuantityNewOrder.Items.Add("2");
            comboBoxQuantityNewOrder.Items.Add("3");
            comboBoxQuantityNewOrder.Items.Add("4");
            comboBoxQuantityNewOrder.Items.Add("5");
            comboBoxQuantityNewOrder.Items.Add("6");
            comboBoxQuantityNewOrder.Items.Add("7");
            comboBoxQuantityNewOrder.Items.Add("8");
            comboBoxQuantityNewOrder.Items.Add("9");

            comboBoxDeliveryNewOrder.Items.Add("Pick Up");
            comboBoxDeliveryNewOrder.Items.Add("Shipping");

            textBoxSubTotalNewOrder.Text = subtotal.ToString();
            textBoxTotalNewOrder.Text = total.ToString();

            comboBoxQuantityNewOrder.SelectedIndex = 0;
            comboBoxDeliveryNewOrder.SelectedIndex = 0;
        }

        public void ButtonAddNewOrder_Click(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files\Order Tracking\orderdb.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                var sql = String.Format("select price from styles where status = 1 and id = @Style");
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@Style", SqlDbType.Int).Value = Int32.Parse(comboBoxStyleNewOrder.SelectedItem.ToString());
                    conn.Open();
                    price = (int)cmd.ExecuteScalar();                    
                }
            }

                if (comboBoxQuantityNewOrder.SelectedItem == null || comboBoxQuantityNewOrder.SelectedItem.ToString() == "0")
                {
                    MessageBox.Show("Quantity cannot be empty.");
                }
                else if (comboBoxDecalNewOrder.SelectedItem == null || comboBoxDesignOrder.SelectedItem == null || comboBoxStyleNewOrder.SelectedItem == null)
                {
                    MessageBox.Show("Style, Design, or Decal cannot be empty.");
                }
                else
                {                   
                    if (dataGridViewOrderItemsNewOrder.RowCount < 5)
                    {
                    var index = dataGridViewOrderItemsNewOrder.Rows.Add();
                    if (dataGridViewOrderItemsNewOrder.RowCount > 1)
                    {
                        itemid = dataGridViewOrderItemsNewOrder.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["itemnumber"].Value));
                        itemid++;
                        dataGridViewOrderItemsNewOrder.Rows[index].Cells["ItemNumber"].Value = itemid;
                    }
                    else
                    {
                        //generates order number based on date and last order in database
                        using (SqlConnection conn1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files\Order Tracking\orderdb.mdf;Integrated Security=True;Connect Timeout=30"))
                        {
                            //open the connection and assign query as string variable
                            conn1.Open();
                            string query1 = "select max(itemnumber) as itemnumber from invoiceitems";

                            using (SqlCommand cmd1 = new SqlCommand { CommandText = query1, Connection = conn1 })
                            {
                                //load query results into a databale to check for ordernumbers in if statement
                                DataTable dt = new DataTable();
                                dt.Load(cmd1.ExecuteReader());

                                if (dt.Rows[0]["itemnumber"] is DBNull)
                                {
                                    //table is empty or no orders yet for the day, generate first number of the day
                                    itemid = 00001;
                                    dataGridViewOrderItemsNewOrder.Rows[index].Cells["ItemNumber"].Value = itemid;
                                }
                                else
                                {
                                    //grab last order number and increment it by 1, assign to id variable
                                    long data = Convert.ToInt64(dt.Rows[0]["itemnumber"]);
                                    data++;
                                    itemid = data;
                                    dataGridViewOrderItemsNewOrder.Rows[index].Cells["ItemNumber"].Value = itemid;
                                }
                            }
                            conn1.Close();
                        }
                    }
                    dataGridViewOrderItemsNewOrder.Rows[index].Cells["Style"].Value = comboBoxStyleNewOrder.GetItemText(comboBoxStyleNewOrder.SelectedItem);
                    dataGridViewOrderItemsNewOrder.Rows[index].Cells["Design"].Value = comboBoxDesignOrder.GetItemText(comboBoxDesignOrder.SelectedItem);
                    dataGridViewOrderItemsNewOrder.Rows[index].Cells["Decal"].Value = comboBoxDecalNewOrder.GetItemText(comboBoxDecalNewOrder.SelectedItem);
                    dataGridViewOrderItemsNewOrder.Rows[index].Cells["Quantity"].Value = comboBoxQuantityNewOrder.GetItemText(comboBoxQuantityNewOrder.SelectedItem);
                    dataGridViewOrderItemsNewOrder.Rows[index].Cells["Price"].Value = price;
                    dataGridViewOrderItemsNewOrder.Rows[index].Cells["Total"].Value = int.Parse(comboBoxQuantityNewOrder.GetItemText(comboBoxQuantityNewOrder.SelectedItem)) * price;
                    }
                    else
                    {
                        MessageBox.Show("Maximum invoice items reached.");
                    }
                }

            UpdateSubtotal();
            UpdateTotal();

        }

        private void ButtonDeleteNewOrder_Click(object sender, EventArgs e)
        {
            if(dataGridViewOrderItemsNewOrder.SelectedRows == null)
            {
                MessageBox.Show("Please select a row");
            }
            else
            {
                foreach (DataGridViewRow item in this.dataGridViewOrderItemsNewOrder.SelectedRows)
                {
                    dataGridViewOrderItemsNewOrder.Rows.RemoveAt(item.Index);
                }

                UpdateSubtotal();
                UpdateTotal();
            }
        }

        private void ComboBoxDeliveryNewOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDeliveryNewOrder.SelectedIndex == 0)
            {
                shipping = 0;
                textBoxShippingNewOrder.Text = shipping.ToString();
            }
            else
            {
                shipping = 25;
                textBoxShippingNewOrder.Text = shipping.ToString();
            }

            UpdateTotal();

        }

        public void UpdateTotal()
        {
            total = shipping + subtotal;
            textBoxTotalNewOrder.Text = total.ToString();
        }

        public void UpdateSubtotal()
        {
            subtotal = 0;

            foreach (DataGridViewRow row in dataGridViewOrderItemsNewOrder.Rows)
            {
                if (row.Cells[6] != null && row.Cells[6].Value != null)
                    subtotal += Convert.ToInt32(row.Cells[6].Value);
            }

            textBoxSubTotalNewOrder.Text = subtotal.ToString();
        }

        private void formNewOrder_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'orderdbDataSet.styles' table. You can move, or remove it, as needed.
            //this.stylesTableAdapter.Fill(this.orderdbDataSet.styles);

        }

        private void labelStreetNewOrder_Click(object sender, EventArgs e)
        {

        }

        private void buttonSaveNewOrder_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files\Order Tracking\orderdb.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                foreach(TextBox textbox in this.Controls.OfType<TextBox>())
                {
                    if (string.IsNullOrWhiteSpace(textbox.Text))
                    {
                        MessageBox.Show( "Text boxes cannot be blank.");
                        return;
                    }
                }

                conn.Open();

                var sql = string.Format(@"insert into invoices (ordernumber,
                                                                orderdate,  
                                                                firstname,
                                                                lastname,
                                                                street,
                                                                city,
                                                                state,
                                                                zip,
                                                                phone,
                                                                email,
                                                                item1,
                                                                item2,
                                                                item3,
                                                                item4,
                                                                item5,
                                                                shipping,
                                                                subtotal,
                                                                total)
                                                        values (@ordernumber,
                                                                @orderdate,
                                                                @firstname,
                                                                @lastname,
                                                                @street,
                                                                @city,
                                                                @state,
                                                                @zip,
                                                                @phone,
                                                                @email,
                                                                @item1id,
                                                                @item2id,
                                                                @item3id,
                                                                @item4id,
                                                                @item5id,
                                                                @shipping,
                                                                @subtotal,
                                                                @total)");
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@ordernumber", SqlDbType.VarChar, 12).Value = labelOrderNumberGenerated.Text;
                    cmd.Parameters.Add("@orderdate", SqlDbType.VarChar, 12).Value = dateTimePickerNewOrder.Value.ToString("yyyyMMdd");
                    cmd.Parameters.Add("@firstname", SqlDbType.VarChar, 255).Value = textBoxFirstNameNewOrder.Text;
                    cmd.Parameters.Add("@lastname", SqlDbType.VarChar, 255).Value = textBoxLastNameNewOrder.Text;
                    cmd.Parameters.Add("@street", SqlDbType.VarChar, 255).Value = textBoxStreetNewOrder.Text;
                    cmd.Parameters.Add("@city", SqlDbType.VarChar, 255).Value = textBoxCityNewOrder.Text;
                    cmd.Parameters.Add("@state", SqlDbType.VarChar, 255).Value = comboBoxStateNewOrder.Text;
                    cmd.Parameters.Add("@zip", SqlDbType.VarChar, 255).Value = textBoxZipNewOrder.Text;
                    cmd.Parameters.Add("@phone", SqlDbType.VarChar, 255).Value = textBoxPhoneNewOrder.Text;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar, 255).Value = textBoxEmailNewOrder.Text;
                    cmd.Parameters.Add("@item1id", SqlDbType.VarChar, 255).Value = dataGridViewOrderItemsNewOrder.Rows[0].Cells["ItemNumber"].Value.ToString();
                    if (dataGridViewOrderItemsNewOrder.Rows.Count > 1)
                        cmd.Parameters.Add("@item2id", SqlDbType.NVarChar, 255).Value = dataGridViewOrderItemsNewOrder.Rows[1].Cells["ItemNumber"].Value.ToString();
                    else
                        cmd.Parameters.Add("@item2id", DBNull.Value);
                    if (dataGridViewOrderItemsNewOrder.Rows.Count > 2)
                        cmd.Parameters.Add("@item3id", SqlDbType.NVarChar, 255).Value = dataGridViewOrderItemsNewOrder.Rows[2].Cells["ItemNumber"].Value.ToString();
                    else
                        cmd.Parameters.Add("@item3id", DBNull.Value);
                    if (dataGridViewOrderItemsNewOrder.Rows.Count > 3)
                        cmd.Parameters.Add("@item4id", SqlDbType.NVarChar, 255).Value = dataGridViewOrderItemsNewOrder.Rows[3].Cells["ItemNumber"].Value.ToString();
                    else
                        cmd.Parameters.Add("@item4id", DBNull.Value);
                    if (dataGridViewOrderItemsNewOrder.Rows.Count > 4)
                        cmd.Parameters.Add("@item5id", SqlDbType.NVarChar, 255).Value = dataGridViewOrderItemsNewOrder.Rows[4].Cells["ItemNumber"].Value.ToString();
                    else
                        cmd.Parameters.Add("@item5id", DBNull.Value);
                    cmd.Parameters.Add("@shipping", SqlDbType.VarChar, 255).Value = textBoxShippingNewOrder.Text;
                    cmd.Parameters.Add("@subtotal", SqlDbType.VarChar, 255).Value = textBoxSubTotalNewOrder.Text;
                    cmd.Parameters.Add("@total", SqlDbType.VarChar, 4).Value = textBoxTotalNewOrder.Text;

                    foreach (DataGridViewRow row in dataGridViewOrderItemsNewOrder.Rows)
                    {
                        var sql2 = String.Format(@"insert into invoiceitems
                                            values (@itemnumber,
                                                    @ordernumber,
                                                    @style,
                                                    @design,
                                                    @decal,
                                                    @price,
                                                    @quantity)");
                        using (var cmd2 = new SqlCommand(sql2, conn))
                        {
                            cmd2.Parameters.Add("@itemnumber", SqlDbType.VarChar, 12).Value = row.Cells["ItemNumber"].Value.ToString();
                            cmd2.Parameters.Add("@ordernumber", SqlDbType.VarChar, 12).Value = labelOrderNumberGenerated.Text;
                            cmd2.Parameters.Add("@style", SqlDbType.VarChar, 255).Value = row.Cells["Style"].Value.ToString();
                            cmd2.Parameters.Add("@design", SqlDbType.VarChar, 255).Value = row.Cells["Design"].Value.ToString();
                            cmd2.Parameters.Add("@decal", SqlDbType.VarChar, 255).Value = row.Cells["Decal"].Value.ToString();
                            cmd2.Parameters.Add("@price", SqlDbType.VarChar, 255).Value = row.Cells["Price"].Value.ToString();
                            cmd2.Parameters.Add("@quantity", SqlDbType.VarChar, 255).Value = row.Cells["Quantity"].Value.ToString();
                            cmd2.ExecuteNonQuery();
                        }
                    }

                    if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("Order saved.");
                }
                conn.Close();
            }

            orders1.dgvLoad();

            this.Close();
        }
    }
}

