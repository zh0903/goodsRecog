namespace shangpinshibie
{
    partial class Form5
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.goodsDataSet = new shangpinshibie.goodsDataSet();
            this.spTableAdapter = new shangpinshibie.goodsDataSetTableAdapters.spTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.rDataGridViewTextBoxColumn,
            this.gDataGridViewTextBoxColumn,
            this.bDataGridViewTextBoxColumn,
            this.idDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.spBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(57, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(548, 198);
            this.dataGridView1.TabIndex = 0;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // rDataGridViewTextBoxColumn
            // 
            this.rDataGridViewTextBoxColumn.DataPropertyName = "R";
            this.rDataGridViewTextBoxColumn.HeaderText = "R";
            this.rDataGridViewTextBoxColumn.Name = "rDataGridViewTextBoxColumn";
            // 
            // gDataGridViewTextBoxColumn
            // 
            this.gDataGridViewTextBoxColumn.DataPropertyName = "G";
            this.gDataGridViewTextBoxColumn.HeaderText = "G";
            this.gDataGridViewTextBoxColumn.Name = "gDataGridViewTextBoxColumn";
            // 
            // bDataGridViewTextBoxColumn
            // 
            this.bDataGridViewTextBoxColumn.DataPropertyName = "B";
            this.bDataGridViewTextBoxColumn.HeaderText = "B";
            this.bDataGridViewTextBoxColumn.Name = "bDataGridViewTextBoxColumn";
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // spBindingSource
            // 
            this.spBindingSource.DataMember = "sp";
            this.spBindingSource.DataSource = this.goodsDataSet;
            // 
            // goodsDataSet
            // 
            this.goodsDataSet.DataSetName = "goodsDataSet";
            this.goodsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spTableAdapter
            // 
            this.spTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(364, 273);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 53);
            this.button1.TabIndex = 1;
            this.button1.Text = "删除";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(173, 273);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(128, 25);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "商品名称";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 351);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private goodsDataSet goodsDataSet;
        private System.Windows.Forms.BindingSource spBindingSource;
        private goodsDataSetTableAdapters.spTableAdapter spTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}