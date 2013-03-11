using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;
using System.IO;
namespace BMHDTVPlotTool
{
    public partial class Form1 : Form
    {

        CData fData;
        CPlot fPlot;
        CFileBase fInput;
        Bitmap fbitMapReal;
        Bitmap fbitMapImag;
        Bitmap fbitMapFFT;
        Bitmap fbitMapDFT;
        Bitmap fbitMapHis;
        Bitmap fbitMapConstellation;

        int fStatusPos = 0;
        string fStatusStr = "就绪";
        bool fReal=true;
        bool fImage=true;
        bool fFFT=true;
        bool fDFT = false;
        bool fHis = true;


        bool bMove;
        int nStart = 0;

        bool bZoomIn = false;
        bool bFinished = false;

        Stack<int> fStack;


        private delegate void SetState(string x);


        public Form1()
        {
            InitializeComponent();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            fStack = new Stack<int>();
            fInput = new CFileBase();

            bMove = false;

            fData = new CData();
            fData.configureData(this);
            fData.setInputFile(fInput);
            //fData.createData();

            fbitMapReal = new Bitmap(1000, 250);
            fbitMapImag = new Bitmap(1000, 250);
            fbitMapFFT = new Bitmap(1000, 500);
            fbitMapDFT = new Bitmap(1000, 500);
            fbitMapHis = new Bitmap(1000, 500);
            fbitMapConstellation = new Bitmap(1000,500);
            fPlot = new CPlot();
            //fData.processData();


            fPlot.configureCPlot(fbitMapReal, fbitMapImag, fbitMapFFT, fbitMapDFT, fbitMapHis, fData, this, fbitMapConstellation);
            realPicBox.Image = fbitMapReal;
            imagPixBox.Image = fbitMapImag;
            fftPicBox.Image = fbitMapFFT;
            dftPicBox.Image = fbitMapDFT;
            hisPicBox.Image = fbitMapHis;
            picConstellation.Image = fbitMapConstellation;
            statusTimer.Start();
            //自适应FFT点数
            //checkBox2.Checked = true;


            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 50000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 200;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.button5, "读取下一部分数据");
            toolTip1.SetToolTip(this.button8, "选择缩放或者移动数据");
            toolTip1.SetToolTip(this.button2, "返回上一次操作的数据");
            toolTip1.SetToolTip(this.button6, "显示全部数据");
            toolTip1.SetToolTip(this.button4, "显示一个数据");





        }

        /// <summary>
        /// 实部虚部同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                fData.RealImagSync = true;
            else
                fData.RealImagSync = false;

            updateAll();
        }


        /// <summary>
        /// 使用20*log10坐标体系
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
                fData.UsingLogXY = true;
            else
                fData.UsingLogXY = false;

            updateAll();
        }


        /// <summary>
        /// 处理线程
        /// </summary>
        private void updateThread()
        {


           

            fData.processData(fReal, fImage, fFFT, fDFT, fHis);

            fStatusStr = "正在绘制图像";

            fPlot.processPlot();

            fStatusStr = "所有数据处理完成";
            realPicBox.Image = fbitMapReal;
            imagPixBox.Image = fbitMapImag;
            fftPicBox.Image = fbitMapFFT;
            dftPicBox.Image = fbitMapDFT;
            hisPicBox.Image = fbitMapHis;
            picConstellation.Image = fbitMapConstellation;
            fReal = true;
            fImage = true;
            fFFT = true;
            fDFT = false;
            fHis = true;
            bZoomIn = true;
            bFinished = true;



        }



        private void updateRealAndImage(bool bReal = true, bool bImage = true)
        {
            fReal = bReal;
            fImage = bImage;
            fPlot.drawRealPic();
            fPlot.drawImagPic();
            realPicBox.Image = fbitMapReal;
            imagPixBox.Image = fbitMapImag;
        }




        private void updateAll(bool bReal=true,bool bImage=true,bool bFFT=true,bool bDFT=false,bool bHis=true)
        {
            fReal = bReal;
            fImage = bImage;
            fFFT = bFFT;
            fDFT = bDFT;
            fHis = bHis;

            


            Thread t = new Thread(updateThread);
            t.Start();

            
        }





        public void updateFileFormatLabel(string formatStr)
        {
            label1.Text = formatStr;
        }



        /// <summary>
        /// 更新状态栏的代理函数
        /// </summary>
        /// <param name="value">进度条</param>
        /// <param name="statusStr">状态栏文字</param>
        public void updatePross(int value,string statusStr,bool zoomIn=false,bool finished=false)
        {
           // this.ProgressBar.Value = value;
          //  this.statusLabel.Text = statusStr;
            fStatusPos = value;
            fStatusStr = statusStr;
            bZoomIn = zoomIn;
            bFinished = finished;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updateAll();
            /*
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = @"html文件(*.html)|*.html|htm文件(*.htm)|*.htm";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            if (DialogResult.OK == saveFileDialog.ShowDialog())
            {
                if (!Directory.Exists("d:\\img\\"))
                {
                    Directory.CreateDirectory("d:\\img\\");
                }

                string str="<html><body><p style=\"text-align:center;\"><strong><span style=\"font-size:24px;\">数字信号处理报表</span></strong></p><p style=\"text-align:right;\"><strong><span style=\"font-size:24px;\"><span style=\"font-size:12px;\">时间：2013-02-21</span></span></strong></p><p style=\"text-align:left;\"><strong><span style=\"font-size:24px;\"><span style=\"font-size:12px;\">原始数据来源：</span></span></strong></p><p style=\"text-align:left;\"><strong><span style=\"font-size:24px;\"><span style=\"font-size:12px;\">c:\\XXX\\xxx.116</span></span></strong></p><p style=\"text-align:left;\"><strong><span style=\"font-size:24px;\"><span style=\"font-size:12px;\">原始数据实部图像(最大值：2 &nbsp; 最小值：2 &nbsp;数据长度：100)</span><br /></span></strong></p><p style=\"text-align:left;\"><strong><span style=\"font-size:24px;\"><span style=\"font-size:12px;\"><img src=\"\\img\\real.jpg\" width=\"1000\" height=\"250\" title=\"实部图像\" alt=\"实部图像\" /><br /></span></span></strong></p><p style=\"text-align:left;\"><strong><span style=\"font-size:24px;\"><span style=\"font-size:12px;\"><strong>原始数据虚部图像(最大值：2 &nbsp; 最小值：2 &nbsp;数据长度：100)</strong><br /></span></span></strong></p><p style=\"text-align:left;\"><strong><span style=\"font-size:24px;\"><span style=\"font-size:12px;\"><img src=\"http://a.com/a.jpg\" width=\"1000\" height=\"500\" title=\"虚部图像\" alt=\"虚部图像\" /><br /></span></span></strong></p><p style=\"text-align:left;\"><strong><span style=\"font-size:24px;\"><span style=\"font-size:12px;\"><br /></span></span></strong></p><p style=\"text-align:left;\"><strong><span style=\"font-size:24px;\"><span style=\"font-size:12px;\"><br /></span></span></strong></p></body></html>";
                FileStream fs = new FileStream("d:\\test.htm", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(str);
                sw.Flush();
                sw.Close();
                fs.Close();
            }*/




        }


       


        /// <summary>
        /// 修改FFT点数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
                fData.FFTCount = 0;
            else
                fData.FFTCount = Int32.Parse(comboBox3.SelectedItem.ToString());

            updateAll(true,true,true,false,false);
            
        }


        /// <summary>
        /// 导入实部文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog nOpenDlg = new OpenFileDialog();
            nOpenDlg.Filter = @"108文件(*.108)|*.108|216文件(*.216)|*.216|116文件(*.116)|*.116|112文件(*.112)|*.112|212文件(*.212)|*.212|所有文件(*.*)|*.*";
            nOpenDlg.FilterIndex = 1;
            if (nOpenDlg.ShowDialog() == DialogResult.OK)
            {
                //fData = new CData(nOpenDlg.FileName);
                bZoomIn = false;
                fInput.MaxNumCount = Convert.ToInt32(textBox1.Text);
        //        fInput.DataWidth = Convert.ToInt32(textBox2.Text);
        //        fInput.Sigh = checkBox9.Checked;
                fInput.FileName = nOpenDlg.FileName;
                fInput.FilePos = 0;
                statusLabel.Text = "正在读取数据文件,请稍后...";
                fData.dataRedy = false;
                button5.Enabled = false;
                fData.readData();
                statusLabel.Text = "正在进行数据分析，请稍后...";
                updateAll();
                //updateRealAndImage();
            }
        }


        /// <summary>
        /// 状态栏更新定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void statusTimer_Tick(object sender, EventArgs e)
        {
            statusLabel.Text = fStatusStr;
            ProgressBar.Value =fStatusPos;
            if(bFinished==true)
                button5.Enabled = true;
        }


        /// <summary>
        /// 最大数据长度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                fInput.MaxNumCount = Convert.ToInt32(textBox1.Text);

                if (Convert.ToInt32(textBox1.Text) > 10000000)
                    textBox1.Text = "10000000";
            }
           
        }


        /// <summary>
        /// 数据最大长度只能是数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9')) e.Handled = true;
            if (e.KeyChar == '\b' || e.KeyChar == '.') e.Handled = false;
        }


        /// <summary>
        /// 输入文件数据位宽只能是数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9')) e.Handled = true;
            if (e.KeyChar == '\b' || e.KeyChar == '.') e.Handled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void realPicBox_MouseEnter(object sender, EventArgs e)
        {
            if (bMove == false)
                this.Cursor = System.Windows.Forms.Cursors.Cross;
            else
                this.Cursor = System.Windows.Forms.Cursors.SizeAll;
        }

        private void realPicBox_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
        }

        private void imagPixBox_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Cross;
        }

        private void imagPixBox_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
        }


        /// <summary>
        /// 实部图像中鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void realPicBox_MouseMove(object sender, MouseEventArgs e)
        {
            /*
            if (isMove == true)
            {
                if (lastX > e.Location.X)
                {
                    fData.InputStart++;
                    fData.InputEnd++;
                }
                else
                {
                    fData.InputStart--;
                    fData.InputEnd--;
                    
                }
                lastX = e.Location.X;
            }
             * */
            
        }
        int lastX;
        int step;
        bool isMove = false;
        private void realPicBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (bMove == false)
            {
                if (fData.InputEnd > 0 && bZoomIn == true)
                {
                    fStack.Push(fData.InputStart);
                    fStack.Push(fData.InputEnd);
                    nStart = (int)(e.Location.X / ((float)1000 / (fData.InputEnd - fData.InputStart))) + fData.InputStart;
                    //realLabel.Text = "实部图像：" + "起始坐标:" + nStart.ToString() + "  截止坐标:" + fData.InputEnd.ToString();
                    //imagLabel.Text = "虚部图像：" + "起始坐标:" + nStart.ToString() + "  截止坐标:" + fData.InputEnd.ToString();

                }
            }
            else
            {
                fStack.Push(fData.InputStart);
                fStack.Push(fData.InputEnd);
                step = (fData.InputEnd - fData.InputStart) / 1000;
                if (step == 0)
                    step = 1;
                //nStart = fData.InputStart;
                lastX = e.Location.X;
                isMove = true;
            }
            
            
        }

        private void realPicBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (bMove == false)
            {
                int nEnd = 0;
                if (fData.InputEnd > 0 && bZoomIn == true)
                {
                    nEnd = (int)(e.Location.X / ((float)1000 / (fData.InputEnd - fData.InputStart))) + fData.InputStart;
                    fData.InputStart = nStart;
                    fData.InputEnd = nEnd;
                    
                    //fPlot.drawRealPic(nStart, nEnd);
                    //fPlot.drawImagPic(nStart,nEnd);
                    //realPicBox.Image = fbitMapReal;
                    //imagPixBox.Image = fbitMapImag;
                    if (nEnd - nStart > 1)
                        updateAll();
                    else
                    {
                        fData.InputEnd = fStack.Pop();
                        fData.InputStart = fStack.Pop();
                    }
                }
            }else
                {
                    if (lastX > e.Location.X)
                    {
                        fData.InputStart = fData.InputStart + step * (lastX - e.Location.X);
                        
                        fData.InputEnd = fData.InputEnd + step * (lastX - e.Location.X);
                        if (fData.InputEnd > fData.fInputNum.Count)
                            fData.InputEnd = fData.fInputNum.Count;
                    }
                    else
                    {
                        fData.InputStart = fData.InputStart - step * (e.Location.X - lastX);
                        fData.InputEnd = fData.InputEnd - step * ( e.Location.X - lastX);
                        if (fData.InputStart < 0)
                            fData.InputStart = 0;
                       
                    }
                    updateAll();
                    isMove = false;
                }

            realLabel.Text = "实部图像：" + "起始坐标:" + fData.InputStart.ToString() + "  截止坐标:" + fData.InputEnd.ToString() + "  数据点数：" + (fData.InputEnd - fData.InputStart).ToString();
            imagLabel.Text = "虚部图像：" + "起始坐标:" + fData.InputStart.ToString() + "  截止坐标:" + fData.InputEnd.ToString() + "  数据点数：" + (fData.InputEnd - fData.InputStart).ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fStack.Count > 1)
            {
                fData.InputEnd = fStack.Pop();
                fData.InputStart = fStack.Pop();
                updateAll();
                realLabel.Text = "实部图像：" + "起始坐标:" + fData.InputStart.ToString() + "  截止坐标:" + fData.InputEnd.ToString() + "  数据点数：" + (fData.InputEnd - fData.InputStart).ToString();
                imagLabel.Text = "虚部图像：" + "起始坐标:" + fData.InputStart.ToString() + "  截止坐标:" + fData.InputEnd.ToString() + "  数据点数：" + (fData.InputEnd - fData.InputStart).ToString();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fStack.Push(fData.InputStart);
            fStack.Push(fData.InputEnd);
            fData.InputEnd = fData.fInputNum.Count;
            fData.InputStart = 0;
            updateAll();
            realLabel.Text = "实部图像：" + "起始坐标:" + fData.InputStart.ToString() + "  截止坐标:" + fData.InputEnd.ToString() + "  数据点数：" + (fData.InputEnd - fData.InputStart).ToString();
            imagLabel.Text = "虚部图像：" + "起始坐标:" + fData.InputStart.ToString() + "  截止坐标:" + fData.InputEnd.ToString() + "  数据点数：" + (fData.InputEnd - fData.InputStart).ToString();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            fStack.Push(fData.InputStart);
            fStack.Push(fData.InputEnd);
            fData.InputEnd = fData.fInputNum.Count / 2+2;
            fData.InputStart = fData.fInputNum.Count/2;
            updateAll();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "正在读取数据文件,请稍后...";
            button5.Enabled = false;
            fData.dataRedy = false;
            fData.readData();
            statusLabel.Text = "正在进行数据分析，请稍后...";
            updateAll();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int len = fData.InputEnd - fData.InputStart;
            if (len > 5000)
            {
                string msg = "数据点数已经达到" + len.ToString() + "点，变换速度将非常慢，继续进行DFT变换？";
                if (MessageBox.Show(msg, "！！！警告！！！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    updateAll(true, true, true, true, true);
                }
            }
            else
            {
                updateAll(true, true, true, true, true);
            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (bMove == false)
            {
                bMove = true;
                button8.Text = "缩放";
            }
            else
            {
                bMove = false;
                button8.Text = "移动";
            }
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            
        }





        /// <summary>
        /// 保存文件
        /// </summary>
        void Save(Bitmap bp)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = @"Bitmap文件(*.bmp)|*.bmp|Jpeg文件(*.jpg)|*.jpg|所有合适文件(*.bmp,*.jpg)|*.bmp;*.jpg";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            if (DialogResult.OK == saveFileDialog.ShowDialog())
            {
                ImageFormat format = ImageFormat.Bmp;
                switch (Path.GetExtension(saveFileDialog.FileName).ToLower())
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                    default:
                        MessageBox.Show(this, "Unsupported image format was specified", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
                try
                {
                    bp.Save(saveFileDialog.FileName, format);
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "Failed writing image file", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }

        private void 实部图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save(fbitMapReal);
        }

        private void 虚部图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save(fbitMapImag);
        }

        private void fFT图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save(fbitMapFFT);
        }

        private void dFT图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save(fbitMapDFT);
        }

        private void 直方图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save(fbitMapHis);
        }

        private void 星座图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save(fbitMapConstellation);
        }

       



        




        private void button9_Click(object sender, EventArgs e)
        {
            //statusLabel.Text = "正在读取数据文件,请稍后...";
            //fData.dataRedy = false;
            //fData.readData(Convert.ToInt32(textBox2.Text));
            //statusLabel.Text = "正在进行数据分析，请稍后...";
            //updateAll();
        }




    }
}
