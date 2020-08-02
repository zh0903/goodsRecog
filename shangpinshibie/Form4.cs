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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }
        string _tu;
        Bitmap _Bitmap;
        private void button1_Click(object sender, EventArgs e)
        {
            string strconn = @"data source=LENOVO-PC\SQLEXPRESS;Initial Catalog =goods;Integrated Security =SSPI ";
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                int i = 0;
                conn.Open();
                string name = textBox4.Text;
                string id = textBox5.Text;
                float _r = Convert.ToSingle(textBox1.Text);
                float _g= Convert.ToSingle(textBox2.Text);
                float _b = Convert.ToSingle(textBox3.Text);
                SqlCommand dbquery = new SqlCommand();
                dbquery.CommandText = "insert into sp (name,R,G,B,id)values('" + name + "','" + _r + "','" + _g + "','" + _b + "','" + id + "')";
                dbquery.Connection = conn;
                i = dbquery.ExecuteNonQuery();
                MessageBox.Show("成功插入" + i + "条记录");
            }
            }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            Bitmap _bitmap = new Bitmap(100, 100);
            float allPixels =100*100;
            float redPixels = 0f;
            float greenPixels = 0f;
            float bluePixels = 0f;
            Image img = this.pictureBox1.Image;
            _bitmap = new Bitmap(img,100,100);
            var rRangeR = Enumerable.Range(170, 255);
            var gRangeR = Enumerable.Range(0, 120);
            var bRangeR = Enumerable.Range(50, 120);
            var rRangeB = Enumerable.Range(0, 50);
            var gRangeB = Enumerable.Range(0, 140);
            var bRangeB = Enumerable.Range(150, 255);
            var rRangeG = Enumerable.Range(0, 120);
            var gRangeG = Enumerable.Range(170, 255);
            var bRangeG = Enumerable.Range(0, 87);
            for (int i = 1; i < 100; i++)
            {
                for (int j = 1; j <100; j++)
                {
                    var pixel = _bitmap.GetPixel(i, j);
                    if (rRangeR.Contains(pixel.R) && gRangeR.Contains(pixel.G) && bRangeR.Contains(pixel.B))
                    {
                        redPixels++;
                    }
                    if (rRangeG.Contains(pixel.R) && gRangeG.Contains(pixel.G) && bRangeG.Contains(pixel.B))
                    {
                        greenPixels++;
                    }
                    if (rRangeB.Contains(pixel.R) && gRangeB.Contains(pixel.G) && bRangeB.Contains(pixel.B))
                    {
                        bluePixels++;
                    }
                }
                textBox1.Text = Convert.ToString(redPixels / allPixels);
                textBox2.Text = Convert.ToString(greenPixels / allPixels);
                textBox3.Text = Convert.ToString(bluePixels / allPixels);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "所有图片文件(*.bmp/*.jpg/*.gif)|*.*|Jpeg文件(*.jpg)|*.jpg|Bitmap文件(*.bmp)|*.bmp|gif文件(*.gif)|*.gif";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                _tu = openFileDialog1.FileName;
                pictureBox1.Image = Bitmap.FromFile(_tu, false);
                _Bitmap = (Bitmap)Image.FromFile(_tu);
                Invalidate();
            }
        }
    }
}
