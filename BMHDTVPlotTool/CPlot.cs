using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMHDTVPlotTool
{
    /// <summary>
    /// 图像绘制类，封装绘图的操作
    /// </summary>
    class CPlot
    {

        /// <summary>
        /// 实部图像
        /// </summary>
        Bitmap fbitMapReal;

        /// <summary>
        /// 虚部图像
        /// </summary>
        Bitmap fbitMapImag;

        /// <summary>
        /// FFT图像
        /// </summary>
        Bitmap fbitMapFFT;

        /// <summary>
        /// DFT图像
        /// </summary>
        Bitmap fbitMapDFT;

        /// <summary>
        /// 直方图
        /// </summary>
        Bitmap fbitMapHis;

        Bitmap fbitMapConstellation;

        Form1 fForm;
        CData fData;


        //时域实数图像使用的变换变量
        double fmaxYReal;
        double fminYReal;
        double fScalyReal = 1;
        double fPyReal;
        double fScalxReal;


        //时域虚部图像使用的变换变量
        double fmaxYImage;
        double fminYImage;
        double fScalyImage = 1;
        double fPyImage;
        double fScalxImage;

        public CPlot()
        {
        }


        /// <summary>
        /// 配置CPlot的图像位图和数据
        /// </summary>
        /// <param name="mReal">实数位图</param>
        /// <param name="mImag">虚数位图</param>
        /// <param name="mFFT">FFT位图</param>
        /// <param name="mDFT">DFT位图</param>
        /// <param name="mHis">直方图位图</param>
        /// <param name="mData">数据</param>
        /// <returns></returns>
        public bool configureCPlot(Bitmap mReal, Bitmap mImag, Bitmap mFFT, Bitmap mDFT, Bitmap mHis,CData mData,Form1 mForm,Bitmap mConstellation)
        {
            fbitMapReal = mReal;
            fbitMapImag = mImag;
            fbitMapFFT = mFFT;
            fbitMapDFT = mDFT;
            fbitMapHis = mHis;
            fbitMapConstellation = mConstellation;
            fForm = mForm;
            fData = mData;
            return true;
        }





        public bool processPlot()
        {
            drawRealPic();
            drawImagPic();
            drawFFTPic();
            drawDFTPic();
            drawHisPic();
            drawConstellationPic();
            return true;
        }


        

        /// <summary>
        /// 画时域图
        /// </summary>
        /// <returns>成功返回true 失败返回false</returns>
        public bool drawRealPic(int mStart = 0, int mEnd = 0)
        {
            int nLen = 0;
            int nStart = 0;
            int nEnd = 0;

            nStart = fData.InputStart;
            nEnd = fData.InputEnd;
            nLen = fData.InputEnd - fData.InputStart;
            /*
            if (mEnd > mStart)
                nLen = mEnd - mStart;
            else
                nLen = fData.fInputNum.Count;

            if ((nLen + mStart) > fData.fInputNum.Count)
                nLen = fData.fInputNum.Count-mStart;
            */
            Graphics g = Graphics.FromImage(fbitMapReal);
            g.Clear(Color.WhiteSmoke);
            Pen p = new Pen(Color.Red, 0);
            Pen pxy = new Pen(Color.Gray, 0);


            /*坐标变换*/
            fmaxYReal = fData.fInputNum[nStart].real;
            fminYReal = fData.fInputNum[nStart].real;
            for (int i = nStart; i < nLen + nStart; i++)
            {
                if (fmaxYReal < fData.fInputNum[i].real)
                    fmaxYReal = fData.fInputNum[i].real;

                if (fminYReal > fData.fInputNum[i].real)
                    fminYReal = fData.fInputNum[i].real;
            }
            if (fmaxYReal < 0)
                fmaxYReal = 0;
            if (fminYReal > 0)
                fminYReal = 0;

            if (fmaxYReal == 0 && fminYReal == 0)
                fScalyReal = 1;
            else
                fScalyReal = 250 / (System.Math.Abs(fmaxYReal) + System.Math.Abs(fminYReal));
            fPyReal = System.Math.Abs(fmaxYReal * fScalyReal) - System.Math.Abs(fminYReal * fScalyReal);
            fScalxReal = (float)1000 / nLen;
            if (fmaxYReal == 0)
            {
                fPyReal = 1;
            }
            if (fminYReal == 0)
            {
                fPyReal = 249;
            }
            if (fmaxYReal != 0 && fminYReal != 0)
            {
                fPyReal = 125 + (fmaxYReal * fScalyReal + fminYReal * fScalyReal) / 2;
            }

            if (fmaxYReal == 0 && fminYReal == 0)
                fPyReal = 125;
            g.TranslateTransform(0, (float)fPyReal);
            g.ScaleTransform((float)(fScalxReal), (float)((0 - fScalyReal/**0.9*/)));
            /*坐标变换完成*/



            /*开始画图*/
            for (int i = nStart; i < nLen + nStart; i++)
            {
                g.DrawLine(p, new PointF((float)i - nStart, (float)0), new PointF(i - nStart, (float)fData.fInputNum[i].real));

                
            }
            /*画图完成*/

            //画横坐标
            g.DrawLine(pxy, new Point(0, 0), new Point((int)((1000) / (fScalxReal/**0.9*/)), 0));

            //坐标反变换
            g.ScaleTransform((float)(1 / fScalxReal), (float)((0 - 1 / fScalyReal/**0.9*/)));
            g.TranslateTransform(0, 0 - (float)fPyReal);






            /*画坐标轴*/
            //最大值
            g.DrawString(fmaxYReal.ToString(), new Font("黑体", 8), Brushes.Black, new Point(10, 10));
            g.DrawLine(pxy, new Point(0, 0), new Point(5, 0));

            g.DrawString((fmaxYReal / 2).ToString(), new Font("黑体", 8), Brushes.Black, new Point(10, (int)(fPyReal/2+10)));
            g.DrawLine(pxy, new Point(0, (int)(fPyReal/2 + 10)), new Point(5, (int)(fPyReal/2 + 10)));


            //最小值
            g.DrawString(fminYReal.ToString(), new Font("黑体", 8), Brushes.Black, new Point(10, 240));
            g.DrawLine(pxy, new Point(0, 249), new Point(5, 249));

            g.DrawString((fminYReal / 2).ToString(), new Font("黑体", 8), Brushes.Black, new Point(10, (int)((249-fPyReal) / 2 +fPyReal+ 10)));
            g.DrawLine(pxy, new Point(0, (int)((249-fPyReal) / 2 +fPyReal+ 10)), new Point(5, (int)((249-fPyReal) / 2 +fPyReal+ 10)));


            //零点
            if (fmaxYReal != 0 && fminYReal != 0)
                g.DrawString("0", new Font("黑体", 8), Brushes.Black, new Point(10, (int)(fPyReal + 10)));
            else
            {

                double y3 = (fmaxYReal - (System.Math.Abs(fmaxYReal) + System.Math.Abs(fminYReal)) / 4 * 2);
                g.DrawString(y3.ToString(), new Font("黑体", 8), Brushes.Black, new Point(10, (int)(250 + 10)));
                g.DrawLine(pxy, new Point(0, 125), new Point(5, 125));
            }

            //纵坐标
            g.DrawLine(pxy, new Point(0, 0), new Point(0, 250));
            /*坐标轴绘制完成*/

            

            g.Dispose();
            return true;
        }


        /// <summary>
        /// 画虚部图
        /// </summary>
        /// <returns>成功返回true 失败返回false</returns>
        public bool drawImagPic(int mStart = 0, int mEnd = 0)
        {
            int nLen = 0;
            int nStart = 0;
            int nEnd = 0;

            nStart = fData.InputStart;
            nEnd = fData.InputEnd;
            nLen = fData.InputEnd - fData.InputStart;
            /*
            if (mEnd > mStart)
                nLen = mEnd - mStart;
            else
                nLen = fData.fInputNum.Count;

            if ((nLen + mStart) > fData.fInputNum.Count)
                nLen = fData.fInputNum.Count - mStart;
            */

            Graphics g = Graphics.FromImage(fbitMapImag);
            g.Clear(Color.WhiteSmoke);
      

            Pen p = new Pen(Color.Blue, 0);
            Pen pxy = new Pen(Color.Gray, 0);

            /*坐标变换*/
            fmaxYImage = fData.fInputNum[nStart].imag;
            fminYImage = fData.fInputNum[nStart].imag;

            for (int i = nStart; i < nLen + nStart; i++)
            {
                if (fmaxYImage < fData.fInputNum[i].imag)
                    fmaxYImage = fData.fInputNum[i].imag;

                if (fminYImage > fData.fInputNum[i].imag)
                    fminYImage = fData.fInputNum[i].imag;
            }
            if (fmaxYImage < 0)
                fmaxYImage = 0;
            if (fminYImage > 0)
                fminYImage = 0;

            if (fmaxYImage == 0 && fminYImage == 0)
                fScalyImage = 1;
            else
                fScalyImage = 250 / (System.Math.Abs(fmaxYImage) + System.Math.Abs(fminYImage));
            fPyImage = System.Math.Abs(fmaxYImage * fScalyImage) - System.Math.Abs(fminYImage * fScalyImage);

            fScalxImage = (float)1000 / nLen;

            if (fmaxYImage == 0)
            {
                fPyImage = 1;
            }
            if (fminYImage == 0)
            {
                fPyImage = 249;
            }

            if (fmaxYImage != 0 && fminYImage != 0)
            {
                fPyImage = 125 + (fmaxYImage * fScalyImage + fminYImage * fScalyImage) / 2;
            }

            if (fmaxYImage == 0 && fminYImage == 0)
                fPyImage = 125;

            g.TranslateTransform(0, (float)fPyImage);
            g.ScaleTransform((float)(fScalxImage), (float)((0 - fScalyImage/**0.9*/)));
            /*坐标变换完成*/



            /*画图*/
            for (int i = nStart; i < nLen + nStart; i++)
            {

                g.DrawLine(p, new PointF((float)i - nStart, (float)0), new PointF(i - nStart, (float)fData.fInputNum[i].imag));
                
            }
           
            //横坐标
            g.DrawLine(pxy, new Point(0, 0), new Point((int)((1000) / (fScalxImage/**0.9*/)), 0));
            //坐标反变换
            g.ScaleTransform((float)(1 / fScalxImage), (float)((0 - 1 / fScalyImage/**0.9*/)));
            g.TranslateTransform(0, 0 - (float)fPyImage);




            /*画坐标轴*/
           
            //最大值
            g.DrawString(fmaxYImage.ToString(), new Font("黑体", 8), Brushes.Black, new Point(10, 10));
            g.DrawLine(pxy,new Point(0, 0), new Point(5, 0));


            g.DrawString((fmaxYReal / 2).ToString(), new Font("黑体", 8), Brushes.Black, new Point(10, (int)(fPyReal / 2 + 10)));
            g.DrawLine(pxy, new Point(0, (int)(fPyReal / 2 + 10)), new Point(5, (int)(fPyReal / 2 + 10)));


            //最小值
            g.DrawString(fminYReal.ToString(), new Font("黑体", 8), Brushes.Black, new Point(10, 240));
            g.DrawLine(pxy, new Point(0, 249), new Point(5, 249));

            g.DrawString((fminYReal / 2).ToString(), new Font("黑体", 8), Brushes.Black, new Point(10, (int)((249 - fPyReal) / 2 + fPyReal + 10)));
            g.DrawLine(pxy, new Point(0, (int)((249 - fPyReal) / 2 + fPyReal + 10)), new Point(5, (int)((249 - fPyReal) / 2 + fPyReal + 10)));



            //最小值
            g.DrawString(fminYImage.ToString(), new Font("黑体", 8), Brushes.Black, new Point(10, 240));
            g.DrawLine(pxy, new Point(0, 249), new Point(5, 249));

            //零点
            if (fmaxYImage != 0 && fminYImage != 0)
                g.DrawString("0", new Font("黑体", 8), Brushes.Black, new Point(10, (int)(fPyImage + 10)));
            else
            {

                double y3 = (fmaxYImage - (System.Math.Abs(fmaxYImage) + System.Math.Abs(fminYImage)) / 4 * 2);
                g.DrawString(y3.ToString(), new Font("黑体", 8), Brushes.Black, new Point(10, (int)(250 + 10)));
                g.DrawLine(pxy, new Point(0, 125), new Point(5, 125));
            }

            //纵坐标
            g.DrawLine(pxy, new Point(0, 0), new Point(0, 250));
            /*坐标轴绘制完成*/


            g.Dispose();
            return true;
        }



        /// <summary>
        /// 画FFT图
        /// </summary>
        /// <returns>成功返回true 失败返回false</returns>
        public bool drawFFTPic()
        {
            Graphics g = Graphics.FromImage(fbitMapFFT);
            g.Clear(Color.WhiteSmoke);
            double scal;
            double fftscalx = (float)1000 / fData.fFFTNum.Count;
            double cm = 0;


            Pen p = new Pen(Color.Green, 0.2F);
            Pen pp = new Pen(Color.Gray, 0);

            
            
            
            //模最大值
            for (int i = 0; i < fData.fFFTNum.Count; i++)
            {
                if (Math.Sqrt(fData.fFFTNum[(i)].real * fData.fFFTNum[(i)].real + fData.fFFTNum[(i)].imag * fData.fFFTNum[(i)].imag) > cm &&
                   (fData.fFFTNum[(i)].real != 0 || fData.fFFTNum[(i)].imag != 0 ))
                    
                {
                    cm =Math.Sqrt(fData.fFFTNum[(i)].real * fData.fFFTNum[(i)].real + fData.fFFTNum[(i)].imag * fData.fFFTNum[(i)].imag);
                }
            }

            //如果模最大值为零，不用作图
            if (cm == 0)
            {
                g.Dispose();
                return false;
            }
            scal = 500 / cm;
            if (scal == 0)
                scal = 0.01;
                   
            g.TranslateTransform(0, 500);
            g.ScaleTransform((float)fftscalx, (float)((0 - scal)));
            /*坐标变换完成*/


            //开始画图
            for (int i = 0; i < fData.fFFTNum.Count; i++)
            {
                float mo = (float)(Math.Sqrt(fData.fFFTNum[(i)].real * fData.fFFTNum[(i)].real + fData.fFFTNum[(i)].imag * fData.fFFTNum[(i)].imag));
                
                g.DrawLine(p, new PointF(i, 0), new PointF(i, mo));
                

            }
            
            
            g.ScaleTransform((float)(1 / fftscalx), (float)((0 - 1 / scal/**0.9*/)));
            g.TranslateTransform(0, -500);



            //画横坐标
            g.DrawLine(pp, new Point(0, 499), new Point(1000, 499));
            //横坐标最大值
            g.DrawString("2π", new Font("黑体", 8), Brushes.Black, new Point(980, 480));


            //画纵轴
            g.DrawLine(pp, new Point(0, 0), new Point(0, 500));
            //纵坐标最大值
            g.DrawString(cm.ToString(), new Font("黑体", 8), Brushes.Black, new Point(10, 10));

            g.DrawString((cm*0.8).ToString(), new Font("黑体", 8), Brushes.Black, new Point(10, 100+10));
            g.DrawLine(pp, new Point(0, 100), new Point(5, 100));

            g.DrawString((cm*0.6).ToString(), new Font("黑体", 8), Brushes.Black, new Point(10, 200+10));
            g.DrawLine(pp, new Point(0, 200), new Point(5, 200));

            g.DrawString((cm*0.4).ToString(), new Font("黑体", 8), Brushes.Black, new Point(10, 300+10));
            g.DrawLine(pp, new Point(0, 300), new Point(5, 300));

            g.DrawString((cm * 0.2).ToString(), new Font("黑体", 8), Brushes.Black, new Point(10, 400+10));
            g.DrawLine(pp, new Point(0, 400), new Point(5, 400));

            //纵坐标最小值
            g.DrawString("坐标原点", new Font("黑体", 8), Brushes.Black, new Point(10, 480));

            g.Dispose();
            return true;
        }

        /// <summary>
        /// 画DFT图
        /// </summary>
        /// <returns>成功返回true 失败返回false</returns>
        public bool drawDFTPic()
        {
            Graphics g = Graphics.FromImage(fbitMapDFT);
            g.Clear(Color.WhiteSmoke);
            double scal;
            double fftscalx = (float)1000 / fData.fDFTNum.Count;
            double cm = 0;
            Pen p = new Pen(Color.Pink, 0.2F);
            Pen pp = new Pen(Color.Gray, 0);


            

            for (int i = 0; i < fData.fDFTNum.Count; i++)
            {
                double tmp=20*Math.Log10(Math.Sqrt(fData.fDFTNum[(i)].real * fData.fDFTNum[(i)].real + fData.fDFTNum[(i)].imag * fData.fDFTNum[(i)].imag));
                if ( tmp > cm
                    &&
                   tmp>0)
                {
                    cm = 20*Math.Log10(Math.Sqrt(fData.fDFTNum[(i)].real * fData.fDFTNum[(i)].real + fData.fDFTNum[(i)].imag * fData.fDFTNum[(i)].imag));
                }
            }

            //如果模最大值为零，不用作图
            if (cm == 0)
            {
                g.Dispose();
                return false;
            }
            scal = 500 / cm;
            g.TranslateTransform(0, 500);
            g.ScaleTransform((float)fftscalx, (float)((0 - scal)));


            for (int i = 0; i < fData.fDFTNum.Count; i++)
            {
                float mo = 20 * (float)Math.Log10((Math.Sqrt(fData.fDFTNum[(i)].real * fData.fDFTNum[(i)].real + fData.fDFTNum[(i)].imag * fData.fDFTNum[(i)].imag)));
                if (mo<0)
                    mo = 0;
                g.DrawLine(p, new PointF(i, 0), new PointF(i, mo));
                //g.FillEllipse(new SolidBrush(Color.Red), i, mo, 1,1);

            }

            

            g.ScaleTransform((float)(1 / fftscalx), (float)((0 - 1 / scal/**0.9*/)));
            g.TranslateTransform(0, -500);


            g.DrawLine(pp, new Point(0, 499), new Point(1000, 499));
            //横坐标最大值
            g.DrawString("2π", new Font("黑体", 8), Brushes.Black, new Point(980, 480));








            g.DrawLine(pp, new Point(0, 0), new Point(0, 500));
            g.DrawString(cm.ToString(), new Font("黑体", 8), Brushes.Black, new Point(10, 10));

            g.DrawString((cm * 0.8).ToString(), new Font("黑体", 8), Brushes.Black, new Point(10, 100 + 10));
            g.DrawLine(pp, new Point(0, 100), new Point(5, 100));

            g.DrawString((cm * 0.6).ToString(), new Font("黑体", 8), Brushes.Black, new Point(10, 200 + 10));
            g.DrawLine(pp, new Point(0, 200), new Point(5, 200));

            g.DrawString((cm * 0.4).ToString(), new Font("黑体", 8), Brushes.Black, new Point(10, 300 + 10));
            g.DrawLine(pp, new Point(0, 300), new Point(5, 300));

            g.DrawString((cm * 0.2).ToString(), new Font("黑体", 8), Brushes.Black, new Point(10, 400 + 10));
            g.DrawLine(pp, new Point(0, 400), new Point(5, 400));



            //纵坐标最小值
            g.DrawString("坐标原点", new Font("黑体", 8), Brushes.Black, new Point(10, 480));

            g.Dispose();
            return true;
        }

        /// <summary>
        /// 画直方图
        /// </summary>
        /// <returns>成功返回true 失败返回false</returns>
        public bool drawHisPic()
        {
            Graphics g = Graphics.FromImage(fbitMapHis);
            g.Clear(Color.WhiteSmoke);
            Pen pp = new Pen(Color.Gray, 0);
            Pen p = new Pen(Color.Red, 0.2F);
            int cm = 0;
            for (int i = 0; i < fData.fHis.Count; i++)
                if (fData.fHis[i] > cm)
                    cm = fData.fHis[i];

            g.TranslateTransform(500, 500);
            g.ScaleTransform((float)(1000.0F / (fData.fHis.Count)), (float)((0 - (500 / (float)(cm))/**0.9*/)));

            for (int i = 0; i < fData.fHis.Count; i++)
                g.DrawLine(p, new PointF(i - fData.fHis.Count / 2, 0), new PointF(i - fData.fHis.Count/2, fData.fHis[i]));


            g.DrawLine(pp, new Point(0 - fData.fHis.Count / 2, 0), new Point(fData.fHis.Count/2, 0));
            g.DrawLine(pp, new Point(0 , 0), new Point(0,cm));
                g.Dispose();
            return true;
        }


        /// <summary>
        /// 画星座图
        /// </summary>
        /// <returns></returns>
        public bool drawConstellationPic()
        {
            int nLen = 0;
            int nStart = 0;
            int nEnd = 0;

            nStart = fData.InputStart;
            nEnd = fData.InputEnd;
            nLen = fData.InputEnd - fData.InputStart;

            Graphics g = Graphics.FromImage(fbitMapConstellation);
            g.Clear(Color.WhiteSmoke);
            double cmReal = 0;
            double cmImage = 0;
            Pen p = new Pen(Color.Gray, 0.2F);

            for (int i = nStart; i < nStart + nLen; i++)
            {
                if (System.Math.Abs(fData.fInputNum[i].real) > cmReal)
                    cmReal = System.Math.Abs(fData.fInputNum[i].real);
                if (System.Math.Abs(fData.fInputNum[i].imag) > cmImage)
                    cmImage = System.Math.Abs(fData.fInputNum[i].imag);
            }

            if (cmReal != 0 && cmImage != 0)
            {
                g.TranslateTransform(500, 250);
                g.ScaleTransform((float)(1000 / (2 * cmReal)), (float)((0 - (500 / (2 * cmImage))/**0.9*/)));



                for (int i = 0; i < nLen; i++)
                {


                    g.FillRectangle(new SolidBrush(Color.Red), (float)fData.fInputNum[i + nStart].real, (float)fData.fInputNum[i + nStart].imag, 5, 5);

                }

                g.DrawLine(p, new PointF((float)(0 - cmReal), (float)0), new PointF((float)cmReal, 0));
                g.DrawLine(p, new PointF(0, (float)(0 - cmImage)), new PointF(0, (float)cmImage));
            }
            
            g.Dispose();
           
            
            return true;
        }




    }
}
