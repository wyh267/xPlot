using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;

namespace BMHDTVPlotTool
{
    /// <summary>
    /// 数据类 保存并封装所有的数据和数据处理操作
    /// </summary>
    class CData
    {

        delegate void updateProess(int value, string statusStr,bool zoomIn=false,bool finished=false);

        delegate void updateLabel(string formatStr);


        Form1 fForm;


        /// <summary>
        /// 输入数据列表
        /// </summary>
        public List<ComplexNumber> fInputNum;
        /// <summary>
        /// FFT数据列表
        /// </summary>
        public List<ComplexNumber> fFFTNum;
        /// <summary>
        /// DFT数据列表
        /// </summary>
        public List<ComplexNumber> fDFTNum;
        /// <summary>
        /// 直方图
        /// </summary>
        public List<int> fHis;
        /// <summary>
        /// 输入文件操作类
        /// </summary>
        CFileBase fInputFile;
        /// <summary>
        /// 输出文件操作类
        /// </summary>
        CFileBase fOutputFile;
        /// <summary>
        /// 实部虚部自动同步
        /// </summary>
        bool fRealImagSync;
        public bool RealImagSync
        {
            get { return fRealImagSync; }
            set { fRealImagSync = value; }
        }

        /// <summary>
        /// 自适应FFT点数
        /// </summary>
        bool fRightFFTPoints;
        public bool RightFFTPoints
        {
            get { return fRightFFTPoints; }
            set { fRightFFTPoints = value; }
        }

        /// <summary>
        /// 频域使用20*log10坐标
        /// </summary>
        bool fUsingLogXY;
        public bool UsingLogXY
        {
            get { return fUsingLogXY; }
            set { fUsingLogXY = value; }
        }

        /// <summary>
        /// 是否仅有实部数据
        /// </summary>
        bool fOnlyReal;
        public bool OnlyReal
        {
            get { return fOnlyReal; }
            set { fOnlyReal = value; }
        }


        public bool dataRedy;

        /// <summary>
        /// FFT点数，0为自适应
        /// </summary>
        int fFFTCount;
        public int FFTCount
        {
            get { return fFFTCount; }
            set { fFFTCount = value; }
        }


        /// <summary>
        /// 数据展示起始索引
        /// </summary>
        int fInputStart=0;
        public int InputStart
        {
            get { return fInputStart; }
            set { fInputStart = value; }
        }

        /// <summary>
        /// 数据展示结束索引
        /// </summary>
        int fInputEnd = 0;
        public int InputEnd 
        {
            get { return fInputEnd; }
            set { fInputEnd = value; }
        }

        updateProess update;
        updateLabel  updateFormat;

        public CData()
        {
            fInputNum = new List<ComplexNumber>();
            fFFTNum= new List<ComplexNumber>();
            fDFTNum = new List<ComplexNumber>();
            fHis = new List<int>();
            dataRedy = false;
            RightFFTPoints = true;
            fFFTCount = 0;
            
        }

        /// <summary>
        /// 设置输入CFile文件操作类
        /// </summary>
        /// <param name="mInput">从界面传过来的文件操作类</param>
        /// <returns>成功返回true</returns>
        public bool setInputFile(CFileBase mInput)
        {
            fInputFile = mInput;
            return true;
        }

        /// <summary>
        /// 设置输出CFile文件操作类
        /// </summary>
        /// <param name="mOutput">从界面传过来的文件操作类</param>
        /// <returns>成功返回true</returns>
        public bool setOutputFile(CFileBase mOutput)
        {
            fOutputFile = mOutput;
            return true;
        }
        
        public bool configureData(Form1 mForm)
        {
            fForm = mForm;
            update = new updateProess(fForm.updatePross);
            updateFormat = new updateLabel(fForm.updateFileFormatLabel);
            // 
            //up(true);
            return true;
        }

        


        public bool updateData()
        {

            return true;
        }



        /// <summary>
        /// 数据处理函数，依次进行FFT,DFT,直方图操作
        /// </summary>
        /// <returns>成功返回true 失败返回false</returns>
        public bool processData(bool bReal = true, bool bImage = true, bool bFFT = true, bool bDFT = false, bool bHis = true)
        {
            if (dataRedy == true)
            {
                //System.Console.WriteLine("fRealImagSync:{0} UsingLogXY:{1} ", fRealImagSync, UsingLogXY);
                if (bFFT == true)
                {
                    update(0, "进行FFT处理");
                    //Application.DoEvents();
                    //Thread.Sleep(1000);
                    FFT();
                }
                if (bDFT == true)
                {
                    update(0, "进行DFT处理");
                    DFT(1);
                }
                CalcHis();
                return true;
            }
            else
                return false;
        }




        private void CalcHis()
        {
            int max = 0;
            int min = 0;
            fHis.Clear();

            for (int i = fInputStart; i < fInputEnd; i++)
            {
                if (fInputNum[i].real > max)
                    max = (int)fInputNum[i].real;
                if (fInputNum[i].real < min)
                    min = (int)fInputNum[i].real;
                //if (fInputNum[i].imag > max)
                //    max = (int)fInputNum[i].imag;
                //if (fInputNum[i].imag < min)
                //    min = (int)fInputNum[i].imag;

            }


            max = System.Math.Abs(max) + System.Math.Abs(min)+1;

            for (int i = 0; i < max;i++ )
                fHis.Add(0);

            for (int i = fInputStart; i < fInputEnd; i++)
            {
                fHis[(int)(fInputNum[i].real + System.Math.Abs(min))]++;
                //fHis[(int)(fInputNum[i].imag + System.Math.Abs(min))]++;
            }


            
            

        }









        /// <summary>
        /// FFT辅助函数
        /// </summary>
        /// 
        private void BitReOrder()
        {
            int a, b, p = 0;
            int n  = fFFTNum.Count;
            ComplexNumber temp;
            for (int i = 1; i < n; i *= 2)//求总位数
            {
                p++;
            }
            for (int i = 0; i < n; i++)
            {
                a = i;
                b = 0;
                for (int j = 0; j < p; j++)
                {
                    b = (b << 1) + (a & 1);
                    a >>= 1;
                }
                if (b > i)
                {
                    temp = fFFTNum[i];
                    fFFTNum[i] = fFFTNum[b];
                    fFFTNum[b] = temp;
                    
                }
            }
        }

        /// <summary>
        /// FFT变换
        /// </summary>
        /// 
        private void FFT()
        {
            

            int fftLen;
            int len;
            int nLen = fInputEnd - fInputStart;
            if (fFFTCount == 0)
            {
                for (len = 0; len < 20; len++)
                {

                    if (System.Math.Pow((double)2, (double)len) > nLen)
                        break;
                }
                fftLen = (int)System.Math.Pow((double)2, (double)(len - 1));
            }
            else
            {
                fftLen = fFFTCount;
            }
            fFFTNum.Clear();
            
            
            for (int i = 0; i < fftLen; i++)
            {
                if (i >= nLen)
                    fFFTNum.Add(new ComplexNumber(0,0));
                else
                    fFFTNum.Add(fInputNum[i+fInputStart]);
                
            }
            
            BitReOrder();
            int n = fFFTNum.Count;
            double angle = -2 * Math.PI / n;
            ComplexNumber comp = new ComplexNumber(Math.Cos(angle), Math.Sin(angle));
            ComplexNumber[] Wcomplex = new ComplexNumber[n / 2];
            Wcomplex[0].real = 1;
            Wcomplex[0].imag = 0;
            for (int i = 1; i < n / 2; i++)//建立权向量索引表
            {
                Wcomplex[i] = Wcomplex[i - 1] * comp;
            }
            int wei = (int)Math.Log(n, 2);//求位数
            //ComplexNumber[] newW = new ComplexNumber[n / 2];
            List<ComplexNumber> newW = new List<ComplexNumber>(n / 2);

            for (int i = 0; i < n / 2; i++)
            {
                newW.Add(new ComplexNumber(0,0));
            }
            ComplexNumber temp;
            int t;
            for (int i = 0; i < wei; i++)
            {
                for (int l = 0; l < n / 2; )//每级权数组
                {
                    for (int k = 0; k < Math.Pow(2, i); k++)
                    {
                       // newW.Add( Wcomplex[(int)(k * Math.Pow(2, (wei - i - 1)))] );
                        newW[l] = Wcomplex[(int)(k * Math.Pow(2, (wei - i - 1)))];
                        l++;
                    }
                }
                int j = 0, a = 0;
                for (int m = 0; m < Math.Pow(2, (wei - i - 1)); m++)//每级分块
                {
                    for (int o = 0; o < (n / 2) / Math.Pow(2, (wei - i - 1)); o++)//每块蝶形运算次数
                    {
                        t = (int)(j + Math.Pow(2, i));
                        temp = fFFTNum[j] + fFFTNum[t] * newW[a];
                        fFFTNum[t] = fFFTNum[j] - fFFTNum[t]*newW[a];
                        fFFTNum[j] = temp;
                        a++; j++;
                    }
                    j = j - (int)((n / 2) / Math.Pow(2, (wei - i - 1))) + (int)Math.Pow(2, (i + 1));
                }

                update((int)((float)i/wei*100), "正在进行快速傅立叶变换(FFT)");

            }
            
            for (int i = 0; i < n; i++)
            {
                fFFTNum[i] = fFFTNum[i];
            }
            update(100, "快速傅立叶变换(FFT)完成");
        }




        /// <summary>
        /// DFT变换
        /// </summary>
        /// <param name="sign">是否逆变换，-1为逆变换</param>
        private void DFT(int sign)
        {
            int i, k;
            double c, d, q, w, s;
            int nLen = fInputEnd - fInputStart;
            ComplexNumber tmp = new ComplexNumber(0, 0);
            q = 6.28318530718 / nLen;
            fDFTNum = new List<ComplexNumber>();
            for (int t = 0; t < nLen; t++)
                fDFTNum.Add(new ComplexNumber(0, 0));

            for (k = 0; k < nLen; k++)
            {
                w = k * q;

                fDFTNum[k] = tmp;

                for (i = 0; i < nLen; i++)
                {
                    d = i * w;
                    c = System.Math.Cos(d);
                    s = System.Math.Sin(d) * sign;
                    ComplexNumber tp = new ComplexNumber(0, 0);
                    tp.real = c * fInputNum[i+fInputStart].real + s * fInputNum[i+fInputStart].imag;
                    tp.imag = c * fInputNum[i+fInputStart].imag - s * fInputNum[i+fInputStart].real;
                    fDFTNum[k] += tp;
                    // fDFTNum[k].real += c * fInputNum[i].real + s * fInputNum[i].imag;
                    // fDFTNum[k].imag += c * fInputNum[i].imag - s * fInputNum[i].real;
                }
                update((int)((float)k / nLen * 100), "正在进行离散傅立叶变换(DFT)");
            }
            if (sign == -1)
            {
                c = 1.0 / fInputNum.Count;
                for (k = 0; k < fInputNum.Count; k++)
                {
                    // mOut[k].real = c * mOut[k].real;
                    // mOut[k].imag = c * mOut[k].imag;
                    fDFTNum[k] = fInputNum[k] * c;
                }
            }

            update(100, "离散傅立叶变换(DFT)完成");
            
        }


       
        public bool readData(long mStartPos=0)
        {
            fInputNum.Clear();
            if (dataRedy == false)
            {
                fInputFile.checkFileFormat();
                string str = "";
                if(fInputFile.DataNum==1)
                    str = "位宽：" + fInputFile.DataWidth.ToString() + " 仅有实部";
                else
                    str = "位宽：" + fInputFile.DataWidth.ToString() + " 有虚部";

                if (fInputFile.Sigh == true)
                    str = str + " 数据有符号";
                else
                    str = str + " 数据无符号";
                
                updateFormat(str);

                fInputFile.readFile(fInputNum, mStartPos);
                dataRedy = true;
                fInputStart = 0;
                fInputEnd = fInputNum.Count;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 测试函数，生成数据
        /// </summary>
        /// <returns></returns>
        public bool createData()
        {
                
                int i;
                double ti = 0;
                double fTiStep = 0.01;
                ComplexNumber tmp;
                for (i = 0; i < 5000; i++)
                {
                    /*
                    tmp.real = 0;
                    if (i < 100 || (i>200 && i<300) || (i>400 && i<500) || (i >600 && i<700) || (i>800 && i <900))
                    {
                        tmp.real = 1;// System.Math.Sin(ti) + System.Math.Cos(5 * ti) + System.Math.Cos(9 * ti) + System.Math.Sin(2 * ti) + System.Math.Sin(7 * ti) + System.Math.Sin(6 * ti); ;
                    }
                    
                    tmp.imag = 0;// System.Math.Sin(ti) + System.Math.Cos(5 * ti) + System.Math.Cos(9 * ti) + System.Math.Sin(2 * ti) + System.Math.Sin(7 * ti) + System.Math.Sin(6 * ti); ;
                    ;
                     */
                    if (i % 2 == 0)
                    {
                        tmp.real = 5*System.Math.Sin(ti);
                        tmp.imag = -1;
                    }
                    else
                    {
                        tmp.real = -1;
                        tmp.imag = 5*System.Math.Sin(ti);
                    }
                    
                    fInputNum.Add(tmp);
                    ti += fTiStep;
                    //fFFT[i].real = fnum[i].real;
                    //fFFT[i].imag = 0;
                }
                /*
                for (i = 0; i < 4; i++)
                {
                    ti+=0.001;
                    fnum[i].real = i+1;//System.Math.Sin(ti) + System.Math.Cos(5 * ti) + System.Math.Cos(9 * ti); ;
                    fnum[i].imag = 0;
                    //fFFT[i].real = fnum[i].real;
                    //fFFT[i].imag = 0;
                }
                for (i = 4; i < 8; i++)
                {
                    ti += 0.001;
                    fnum[i].real = 8-i;//System.Math.Sin(ti) + System.Math.Cos(5 * ti) + System.Math.Cos(9 * ti); ;
                    fnum[i].imag = 0;
                    //fFFT[i].real = fnum[i].real;
                    //fFFT[i].imag = 0;
                }
                 */
                dataRedy = true;
                return true;
        }




    }
}
