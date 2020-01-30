namespace OrderTracking
{
    partial class formCloseOrder
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
            this.comboBoxReasonCloseOrder = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCloseFormCloseOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxReasonCloseOrder
            // 
            this.comboBoxReasonCloseOrder.FormattingEnabled = true;
            this.comboBoxReasonCloseOrder.Location = new System.Drawing.Point(133, 62);
            this.comboBoxReasonCloseOrder.Name = "comboBoxReasonCloseOrder";
            this.comboBoxReasonCloseOrder.Size = new System.Drawing.Size(121, 21);
            this.comboBoxReasonCloseOrder.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Close Reason:";
            // 
            // buttonCloseFormCloseOrder
            // 
            this.buttonCloseFormCloseOrder.Location = new System.Drawing.Point(120, 89);
            this.buttonCloseFormCloseOrder.Name = "buttonCloseFormCloseOrder";
            this.buttonCloseFormCloseOrder.Size = new System.Drawing.Size(75, 23);
            this.buttonCloseFormCloseOrder.TabIndex = 2;
            this.buttonCloseFormCloseOrder.Text = "Close";
            this.buttonCloseFormCloseOrder.UseVisualStyleBackColor = true;
            this.buttonCloseFormCloseOrder.Click += new System.EventHandler(this.buttonCloseFormCloseOrder_Click);
            // 
            // formCloseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 185);
            this.Controls.Add(this.buttonCloseFormCloseOrder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxReasonCloseOrder);
            this.Name = "formCloseOrder";
            this.Text = "formCloseOrder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxReasonCloseOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCloseFormCloseOrder;
    }
}