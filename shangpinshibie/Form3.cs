using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shangpinshibie
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 add = new Form4();
            add.Text = "添加商品";
            add.StartPosition = FormStartPosition.CenterScreen;
            add.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 delete= new Form5();
            delete.Text = "移除商品";
            delete.StartPosition = FormStartPosition.CenterScreen;
            delete.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 recognize = new Form1();
            recognize.Text = "识别商品";
            recognize.StartPosition = FormStartPosition.CenterScreen;
            recognize.ShowDialog();
        }
    }
}
