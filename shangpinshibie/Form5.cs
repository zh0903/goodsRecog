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

namespace shangpinshibie
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“goodsDataSet.sp”中。您可以根据需要移动或删除它。
            this.spTableAdapter.Fill(this.goodsDataSet.sp);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strconn = @"data source=LENOVO-PC\SQLEXPRESS;Initial Catalog =goods;Integrated Security =SSPI";
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                int i = 0;
                conn.Open();
                string s1 = textBox1.Text;             
                SqlCommand dbquery = new SqlCommand();
                dbquery.Connection = conn;
                string order1 = "delete from sp where name like '%" + s1 + "%'";
                dbquery.CommandText = order1;
                i = dbquery.ExecuteNonQuery();
                MessageBox.Show("成功删除" + i + "条记录");
            }
            this.spTableAdapter.Fill(this.goodsDataSet.sp);
        }
    }
}
