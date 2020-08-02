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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        static int[,] intStartXY = new int[128, 3]; 
        static int numIdentfied = 0;   

        private void label1_Click(object sender, EventArgs e)
        {

        }
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
        static int BinaryWidthE = 4, BinaryHeightE = 11;    //e

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        static string stringByteF = "000000000111001001001000111110001000001000001000001000011110000000000000";
        static char[] charF = stringByteF.ToCharArray();
        static int BinaryWidthF = 5, BinaryHeightF = 11;    //f

        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
            try
          { 
            Bitmap m_Bitmap;
                button1.Enabled = true;
            OpenFileDialog openFileDialog = new OpenFileDialog();   
            openFileDialog.Filter = "Bitmap文件(*.bmp)|*.bmp|Jpeg文件(*.jpg)|*.jpg|所有合适文件(*.bmp/*.jpg)|*.bmp/*.jpg";
            openFileDialog.FilterIndex = 1;    
            openFileDialog.RestoreDirectory = true;    
            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                m_Bitmap = (Bitmap)Bitmap.FromFile(openFileDialog.FileName, false);    //(Bitmap)强制类型转换
                pictureBox1.Image = m_Bitmap;   
                AutoScroll = true;
                AutoScrollMinSize = new Size((int)(m_Bitmap.Width), (int)m_Bitmap.Height);
            }
        }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false; 
                this.button2.Select();
                numIdentfied = 0;    //计数归0
                Bitmap heibai = (Bitmap)pictureBox1.Image;//(bitmap)
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
                    textBox2.Text+= codeCache + "\r\n";
                    
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
                this.textBox1.Text += identifySort();    
                this.textBox1.SelectionStart = textBox1.TextLength;    //将光标移到最后面
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
            return stringLicense ; 
        }
    }
}
