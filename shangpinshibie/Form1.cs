﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Data.SqlClient;

namespace shangpinshibie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string currentImageFile;
        string xz;
        Bitmap sourceBitmap;
        static int[,] intStartXY = new int[128, 3];
        static int numIdentfied = 0;

        #region 字库
        static string stringByte0 = "000000111010001100011000110001100011000110001011100000000000";
        static char[] char0 = stringByte0.ToCharArray();
        static int BinaryWidth0 = 4, BinaryHeight0 = 11;    //0

        static string stringByte1 = "000000010001100001000010000100001000010000100011100000000000";
        static char[] char1 = stringByte1.ToCharArray();
        static int BinaryWidth1 = 4, BinaryHeight1 = 11;    //1

        static string stringByte2 = "000000111010001100010000100010001000100010001111110000000000";
        static char[] char2 = stringByte2.ToCharArray();
        static int BinaryWidth2 = 4, BinaryHeight2 = 11;    //2

        static string stringByte3 = "000000111010001000010000100110000010000110001011100000000000";
        static char[] char3 = stringByte3.ToCharArray();
        static int BinaryWidth3 = 4, BinaryHeight3 = 11;    //3

        static string stringByte4 = "000000001000010001100101001010100101111100010001110000000000";
        static char[] char4 = stringByte4.ToCharArray();
        static int BinaryWidth4 = 4, BinaryHeight4 = 11;    //4

        static string stringByte5 = "000001111110000100001111010001000011000110001011100000000000";
        static char[] char5 = stringByte5.ToCharArray();
        static int BinaryWidth5 = 4, BinaryHeight5 = 11;    //5

        static string stringByte6 = "000000011001001100001011011001100011000110001011100000000000";
        static char[] char6 = stringByte6.ToCharArray();
        static int BinaryWidth6 = 4, BinaryHeight6 = 11;    //6

        static string stringByte7 = "000001111110001000100001000010001000010000100001000000000000";
        static char[] char7 = stringByte7.ToCharArray();
        static int BinaryWidth7 = 4, BinaryHeight7 = 11;    //7

        static string stringByte8 = "000000111010001100011000101110100011000110001011100000000000";
        static char[] char8 = stringByte8.ToCharArray();
        static int BinaryWidth8 = 4, BinaryHeight8 = 11;    //8

        static string stringByte9 = "000000111010001100011000110011011010000110010011000000000000";
        static char[] char9 = stringByte9.ToCharArray();
        static int BinaryWidth9 = 4, BinaryHeight9 = 11;    //9

        static string stringByteA = "000000000000000000000000011100100010001110010010100010011111000000000000";
        static char[] charA = stringByteA.ToCharArray();
        static int BinaryWidthA = 5, BinaryHeightA = 11;    //a

        static string stringByteB = "000000110000010000010000011110010001010001010001010001011110000000000000";
        static char[] charB = stringByteB.ToCharArray();
        static int BinaryWidthB = 5, BinaryHeightB = 11;    //b

        static string stringByteC = "000000000000000000000111110001100001000010001011100000000000";
        static char[] charC = stringByteC.ToCharArray();
        static int BinaryWidthC = 4, BinaryHeightC = 11;    //c

        static string stringByteD = "000000000110000010000010011110100010100010100010100010011111000000000000";
        static char[] charD = stringByteD.ToCharArray();
        static int BinaryWidthD = 5, BinaryHeightD = 11;    //d

        static string stringByteE = "000000000000000000000111010001111111000010001011100000000000";
        static char[] charE = stringByteE.ToCharArray();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        static int BinaryWidthE = 4, BinaryHeightE = 11;    //e
        static string stringByteF = "000000000111001001001000111110001000001000001000001000011110000000000000";
        static char[] charF = stringByteF.ToCharArray();
        static int BinaryWidthF = 5, BinaryHeightF = 11;    //f
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.spTableAdapter.Fill(this.goodsDataSet1.sp);// TODO: 这行代码将数据加载到表“goodsDataSet1.sp”中
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Bitmap文件(*.bmp)|*.bmp|Jpeg文件(*.jpg)|*.jpg|所有合适文件(*.bmp/*.jpg)|*.bmp/*.jpg";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            textBox2.Clear();
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                currentImageFile = openFileDialog1.FileName;
                pictureBox1.Image = Bitmap.FromFile(currentImageFile, false);
                sourceBitmap = (Bitmap)Image.FromFile(currentImageFile);
                Invalidate();
                Bitmap bit = new Bitmap(90, 30);
                using (Graphics g = Graphics.FromImage(bit))
                {
                    g.DrawImage(pictureBox1.Image, new Rectangle(0, 0, 90, 30), new Rectangle(0, 0, 90, 30), GraphicsUnit.Pixel);
                    Bitmap bianma = bit;
                    g.Dispose();
                }
                pictureBox2.Image = bit;
                AutoScroll = true;
                AutoScrollMinSize = new Size((int)(bit.Width), (int)bit.Height);
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (sourceBitmap != null)
            {
                g.DrawImage(sourceBitmap, 450, 12, 370, 300);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sourceBitmap = Edge(sourceBitmap);
            Invalidate();
            try
            {
                this.button2.Select();
                numIdentfied = 0;    //计数归0
                Bitmap heibai = (Bitmap)pictureBox2.Image;//(bitmap)
                int iw = heibai.Width;
                int ih = heibai.Height;
                for (int i = 0; i < iw; i++)//二值化
                {
                    for (int j = 0; j < ih; j++)
                    {
                        Color c = heibai.GetPixel(i, j);
                        int luma = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);    //将颜色转换为数值体现  
                        heibai.SetPixel(i, j, Color.FromArgb(luma, luma, luma));    //将这一点进行灰度处理,非白色的部分变黑
                    }
                }
                generateLicense(heibai);    //通过该方法进行提取字符
            }
            catch { }
            Image img = this.pictureBox1.Image;
            Bitmap _Bitmap = new Bitmap(img,100,100);
            float allPixels = 100*100;
            float redPixels = 0f;
            float greenPixels = 0f;
            float bluePixels = 0f;
            float yellowPixels = 0f;
            var red = Color.Red;
            var rRangeR = Enumerable.Range(170, 255);
            var gRangeR= Enumerable.Range(0,120);
            var bRangeR = Enumerable.Range(50, 120);
            var rRangeB = Enumerable.Range(0, 50);
            var gRangeB = Enumerable.Range(0, 140);
            var bRangeB = Enumerable.Range(150,255);
            var rRangeG = Enumerable.Range(0, 120);
            var gRangeG = Enumerable.Range(170, 255);
            var bRangeG = Enumerable.Range(0,87);
            var rRangeY = Enumerable.Range(150, 255);
            var gRangeY = Enumerable.Range(170, 255);
            var bRangeY = Enumerable.Range(0, 100);
            for (int i = 1; i < 100; i++)
            {
                for (int j = 1; j <100; j++)
                {
                    var pixel = _Bitmap.GetPixel(i, j);
                    if (red.R == pixel.R && red.G == pixel.G && red.B == pixel.B)
                    {
                        redPixels++;
                    }
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
                    if (rRangeY.Contains(pixel.R) && gRangeY.Contains(pixel.G) && bRangeY.Contains(pixel.B))
                    {
                        yellowPixels++;
                    }
                }
                if (redPixels / allPixels > 0.06 && bluePixels / allPixels < 0.1 && greenPixels / allPixels < 0.1)
                {
                    xz = "171112";
                    if (redPixels / allPixels > 0.5 && bluePixels / allPixels < 0.1 && greenPixels / allPixels < 0.1)
                    xz = "1701a";
                }
                else if (redPixels / allPixels < 0.1 && bluePixels / allPixels > 0.2 && greenPixels / allPixels < 0.1)
                    xz = "1703c";
                else if (redPixels / allPixels < 0.1 && bluePixels / allPixels < 0.1 && yellowPixels / allPixels > 0.1)
                    xz = "1702b";
                string strconn = @"data source=LENOVO-PC\SQLEXPRESS;Initial Catalog =goods;Integrated Security =SSPI";
                using (SqlConnection conn = new SqlConnection(strconn))
                {
                    string _slct;
                    _slct= "select name,id from sp where id='"+xz+"'";
                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(_slct, conn);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    conn.Close();
                }

            }

        }
        public void generateLicense(Bitmap singlepic)
        {
            try
            {
                char[,] charArray = new char[singlepic.Height, singlepic.Width];    //记录像素
                int imageWidth = 0;
                int imageHeight = 0;
                int dgGrayValue = 128;
                Color piexl;
                for (int posy = 0; posy < singlepic.Height; posy++)
                {

                    string codeCache = "";    //存储每行的像素的0/1
                    for (int posx = 0; posx < singlepic.Width; posx++)
                    {//从左到右
                        piexl = singlepic.GetPixel(posx, posy);
                        if (piexl.R < dgGrayValue)
                        {
                            codeCache = codeCache + "1";
                        }
                        else
                        {
                            codeCache = codeCache + "0";
                        }
                    }
                    char[] array = codeCache.ToCharArray();    //每行的0/1的值用数字保存,以便于进行循环处理

                    for (imageWidth = 0; imageWidth < array.Length; imageWidth++)
                        charArray[imageHeight, imageWidth] = array[imageWidth];    //通过循环将每行值转存到二维数组中
                    imageHeight++;
                }

                findWord(charArray, char0, imageHeight, imageWidth, BinaryWidth0, BinaryHeight0, '0');
                findWord(charArray, char1, imageHeight, imageWidth, BinaryWidth1, BinaryHeight1, '1');
                findWord(charArray, char2, imageHeight, imageWidth, BinaryWidth2, BinaryHeight2, '2');
                findWord(charArray, char3, imageHeight, imageWidth, BinaryWidth3, BinaryHeight3, '3');
                findWord(charArray, char4, imageHeight, imageWidth, BinaryWidth4, BinaryHeight4, '4');
                findWord(charArray, char5, imageHeight, imageWidth, BinaryWidth5, BinaryHeight5, '5');
                findWord(charArray, char6, imageHeight, imageWidth, BinaryWidth6, BinaryHeight6, '6');
                findWord(charArray, char7, imageHeight, imageWidth, BinaryWidth7, BinaryHeight7, '7');
                findWord(charArray, char8, imageHeight, imageWidth, BinaryWidth8, BinaryHeight8, '8');
                findWord(charArray, char9, imageHeight, imageWidth, BinaryWidth9, BinaryHeight9, '9');
                findWord(charArray, charA, imageHeight, imageWidth, BinaryWidthA, BinaryHeightA, 'a');
                findWord(charArray, charB, imageHeight, imageWidth, BinaryWidthB, BinaryHeightB, 'b');
                findWord(charArray, charC, imageHeight, imageWidth, BinaryWidthC, BinaryHeightC, 'c');
                findWord(charArray, charD, imageHeight, imageWidth, BinaryWidthD, BinaryHeightD, 'd');
                findWord(charArray, charE, imageHeight, imageWidth, BinaryWidthE, BinaryHeightE, 'e');
                findWord(charArray, charF, imageHeight, imageWidth, BinaryWidthF, BinaryHeightF, 'f');
                this.textBox2.Text += identifySort();
                this.textBox2.SelectionStart = textBox2.TextLength;    //将光标移到最后面
            }
            catch { }
        }
        public void findWord(char[,] charArray, char[] charNum, int imageHeight, int imageWidth, int binaryWidth, int binaryHeight, char stringChar)
        {
            try
            {
                int upLeftX, upLeftY, x, y;
                for (y = 0; y < imageHeight - binaryHeight; y++)//从图片的每行开始
                {
                    for (x = 0; x < imageWidth - binaryWidth; x++)//从当前行的第一格开始
                    {
                        bool isIdentified = false;    //是否匹配标志
                        int count = 0;
                        for (upLeftY = 0; upLeftY <= binaryHeight; upLeftY++)//从图片中取出一块进行对比，从的每行开始
                        {
                            for (upLeftX = 0; upLeftX <= binaryWidth; upLeftX++)//从这一块当前行的第一格开始
                            {
                                //下面进行每格的对比，大数字去除的“块”是二维数组，小数组是一维数组
                                if (charArray[y + upLeftY, x + upLeftX] == charNum[upLeftY * (binaryWidth + 1) + upLeftX])
                                {
                                    isIdentified = true;    //记录像素点是否比对成功
                                    count++;
                                    if (count == (binaryWidth + 1) * (binaryHeight + 1))//判断是否对比到了最后一个像素点
                                    {
                                        intStartXY[numIdentfied, 0] = y;    //记录字库中该字符在图片中出现的Y值
                                        intStartXY[numIdentfied, 1] = x;    //记录字库中该字符在图片中出现的X值
                                        intStartXY[numIdentfied, 2] = Convert.ToInt32(stringChar);
                                        numIdentfied++;
                                        break;
                                    }
                                }
                                else
                                {
                                    isIdentified = false;
                                    break;
                                }
                            }
                            if (!isIdentified)//如果一个不符就向后退一格，同时小数组的比对又需要从第一格开始
                                break;
                        }
                    }
                }
            }
            catch { }
        }
        public string identifySort()
        {
            string stringLicense = "";    //存储该结果
            try
            {
                int intTemp = 0;
                for (int a = 0; a < numIdentfied; a++)
                {
                    for (int b = 0; b < numIdentfied; b++)
                    {
                        if (intStartXY[a, 0] < intStartXY[b, 0])
                        {//通过Y坐标判断那个字符在上面,并进行对调
                            for (int c = 0; c < 3; c++)
                            {
                                intTemp = intStartXY[a, c];
                                intStartXY[a, c] = intStartXY[b, c];
                                intStartXY[b, c] = intTemp;
                            }
                        }
                        if (intStartXY[a, 0] == intStartXY[b, 0] && intStartXY[a, 1] < intStartXY[b, 1])
                        {//通过X坐标判断那个字符在左面,并进行对调
                            for (int c = 0; c < 3; c++)
                            {
                                intTemp = intStartXY[a, c];
                                intStartXY[a, c] = intStartXY[b, c];
                                intStartXY[b, c] = intTemp;
                            }
                        }
                    }
                }

                for (int h = 0; h < numIdentfied; h++)
                {
                    stringLicense += Convert.ToChar(intStartXY[h, 2]);
                }
            }
            catch { }
            return stringLicense;
        }
        public static Bitmap Edge(Bitmap b)
        {
            if (b == null)
            {
                MessageBox.Show("无图像可处理。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            int w = b.Width;
            int h = b.Height;

            try
            {
                Bitmap bmpRtn = new Bitmap(w, h, PixelFormat.Format24bppRgb);

                BitmapData srcData = b.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData dstData = bmpRtn.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

                unsafe
                {
                    byte* pIn = (byte*)srcData.Scan0.ToPointer();
                    byte* pOut = (byte*)dstData.Scan0.ToPointer();
                    int stride = srcData.Stride;
                    byte* p;

                    for (int y = 0; y < h; y++)
                    {
                        for (int x = 0; x < w; x++)
                        {
                            if (x == 0 || x == w - 1 || y == 0 || y == h - 1)
                            {
                                //图边不做处理
                                pOut[0] = pIn[0];
                                pOut[1] = pIn[1];
                                pOut[2] = pIn[2];
                            }
                            else
                            {
                                int r1, r2, r3, r4;
                                int g1, g2, g3, g4;
                                int b1, b2, b3, b4;

                                float vR, vG, vB;

                                //当前像素点
                                p = pIn;
                                r1 = p[2];
                                g1 = p[1];
                                b1 = p[0];
                                //右侧
                                p = pIn + 3;
                                r2 = p[2];
                                g2 = p[1];
                                b2 = p[0];
                                //正下
                                p = pIn + stride;
                                r3 = p[2];
                                g3 = p[1];
                                b3 = p[0];
                                //右下
                                p = pIn + stride + 3;
                                r4 = p[2];
                                g4 = p[1];
                                b4 = p[0];
                                vR = Math.Abs((float)(r1 - r4)) + Math.Abs((float)(r2 - r3));
                                vG = Math.Abs((float)(g1 - g4)) + Math.Abs((float)(g2 - g3));
                                vB = Math.Abs((float)(b1 - b4)) + Math.Abs((float)(b2 - b3));

                                if (vR > 0)
                                {
                                    vR = Math.Min(255, vR);
                                }
                                else
                                {
                                    vR = Math.Max(0, vR);
                                }

                                if (vG > 0)
                                {
                                    vG = Math.Min(255, vG);
                                }
                                else
                                {
                                    vG = Math.Max(0, vG);
                                }

                                if (vB > 0)
                                {
                                    vB = Math.Min(255, vB);
                                }
                                else
                                {
                                    vB = Math.Max(0, vB);
                                }

                                pOut[0] = (byte)vB;
                                pOut[1] = (byte)vG;
                                pOut[2] = (byte)vR;

                            }

                            pIn += 3;
                            pOut += 3;
                        }

                        pIn += srcData.Stride - w * 3;
                        pOut += srcData.Stride - w * 3;
                    }
                }

                b.UnlockBits(srcData);
                bmpRtn.UnlockBits(dstData);
                return bmpRtn;
            }
            catch
            {
                return null;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 check = new Form2();
            check.Text = "编码识别";
            check.StartPosition = FormStartPosition.CenterScreen;
            check.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
