namespace OrderTracking
{
    partial class formNewExpense
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
            this.dgvNewExpense = new System.Windows.Forms.DataGridView();
            this.buttonDeleteNewExpense = new System.Windows.Forms.Button();
            this.buttonSaveNewExpense = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewExpense)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNewExpense
            // 
            this.dgvNewExpense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNewExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNewExpense.Location = new System.Drawing.Point(24, 45);
            this.dgvNewExpense.Name = "dgvNewExpense";
            this.dgvNewExpense.Size = new System.Drawing.Size(750, 201);
            this.dgvNewExpense.TabIndex = 0;
            this.dgvNewExpense.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNewExpense_CellClick);
            this.dgvNewExpense.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvNewExpense_ColumnWidthChanged);
            this.dgvNewExpense.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvNewExpense_Scroll);
            // 
            // buttonDeleteNewExpense
            // 
            this.buttonDeleteNewExpense.AllowDrop = true;
            this.buttonDeleteNewExpense.Location = new System.Drawing.Point(699, 12);
            this.buttonDeleteNewExpense.Name = "buttonDeleteNewExpense";
            this.buttonDeleteNewExpense.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteNewExpense.TabIndex = 1;
            this.buttonDeleteNewExpense.Text = "Delete";
            this.buttonDeleteNewExpense.UseVisualStyleBackColor = true;
            this.buttonDeleteNewExpense.Click += new System.EventHandler(this.buttonDeleteNewExpense_Click);
            // 
            // buttonSaveNewExpense
            // 
            this.buttonSaveNewExpense.Location = new System.Drawing.Point(699, 252);
            this.buttonSaveNewExpense.Name = "buttonSaveNewExpense";
            this.buttonSaveNewExpense.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveNewExpense.TabIndex = 2;
            this.buttonSaveNewExpense.Text = "Save";
            this.buttonSaveNewExpense.UseVisualStyleBackColor = true;
            this.buttonSaveNewExpense.Click += new System.EventHandler(this.buttonSaveNewExpense_Click);
            // 
            // formNewExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 289);
            this.Controls.Add(this.buttonSaveNewExpense);
            this.Controls.Add(this.buttonDeleteNewExpense);
            this.Controls.Add(this.dgvNewExpense);
            this.Name = "formNewExpense";
            this.Text = "formNewExpense";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewExpense)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNewExpense;
        private System.Windows.Forms.Button buttonDeleteNewExpense;
        private System.Windows.Forms.Button buttonSaveNewExpense;
    }
}