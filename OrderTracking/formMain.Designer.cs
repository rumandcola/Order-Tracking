namespace OrderTracking
{
    partial class formMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOrders = new System.Windows.Forms.Button();
            this.buttonExpenses = new System.Windows.Forms.Button();
            this.buttonRevenue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOrders
            // 
            this.buttonOrders.Location = new System.Drawing.Point(12, 73);
            this.buttonOrders.Name = "buttonOrders";
            this.buttonOrders.Size = new System.Drawing.Size(200, 170);
            this.buttonOrders.TabIndex = 0;
            this.buttonOrders.Text = "Orders";
            this.buttonOrders.UseVisualStyleBackColor = true;
            this.buttonOrders.Click += new System.EventHandler(this.buttonOrders_Click);
            // 
            // buttonExpenses
            // 
            this.buttonExpenses.Location = new System.Drawing.Point(240, 73);
            this.buttonExpenses.Name = "buttonExpenses";
            this.buttonExpenses.Size = new System.Drawing.Size(200, 170);
            this.buttonExpenses.TabIndex = 1;
            this.buttonExpenses.Text = "Expenses";
            this.buttonExpenses.UseVisualStyleBackColor = true;
            this.buttonExpenses.Click += new System.EventHandler(this.buttonExpenses_Click);
            // 
            // buttonRevenue
            // 
            this.buttonRevenue.Location = new System.Drawing.Point(466, 73);
            this.buttonRevenue.Name = "buttonRevenue";
            this.buttonRevenue.Size = new System.Drawing.Size(200, 170);
            this.buttonRevenue.TabIndex = 2;
            this.buttonRevenue.Text = "Revenue";
            this.buttonRevenue.UseVisualStyleBackColor = true;
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 262);
            this.Controls.Add(this.buttonRevenue);
            this.Controls.Add(this.buttonExpenses);
            this.Controls.Add(this.buttonOrders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "formMain";
            this.Text = "Order Tracking";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOrders;
        private System.Windows.Forms.Button buttonExpenses;
        private System.Windows.Forms.Button buttonRevenue;
    }
}

