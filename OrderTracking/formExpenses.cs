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
    public partial class formExpenses : Form
    {
        public formExpenses()
        {
            InitializeComponent();
        }

        private void buttonNewExpense_Click(object sender, EventArgs e)
        {
            formNewExpense fne = new formNewExpense();
            fne.Show();
        }
    }
}
