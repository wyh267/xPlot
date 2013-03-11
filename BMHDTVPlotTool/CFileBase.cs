using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BMHDTVPlotTool
{
    /// <summary>
    /// 文件操作基类，封装必要的文件类型和方法
    /// </summary>
    class CFileBase
    {

        /// <summary>
        /// 文件名
        /// </summary>
        protected string fFileName;
        public string FileName
        {
            get { return fFileName; }
            set { fFileName = value; }
        }

        /// <summary>
        /// 数据宽度
        /// </summary>
        protected int fDataWidth;
        public int DataWidth
        {
            get { return fDataWidth; }
            set { fDataWidth = value; }
        }

        /// <summary>
        /// 整数部分宽度
        /// </summary>
        protected int fIntWidth;
        public int IntWidth
        {
            get { return fIntWidth; }
            set { fIntWidth = value; }
        }

        /// <summary>
        /// 小数部分宽度
        /// </summary>
        protected int fDeciWidth;
        public int DeciWidth
        {
            get { return fDeciWidth; }
            set { fDeciWidth = value; }
        }

        /// <summary>
        /// 数据是否有符号
        /// </summary>
        protected bool fSigh;
        public bool Sigh
        {
            get { return fSigh; }
            set { fSigh = value; }
        }

        /// <summary>
        /// 能够处理的最多数
        /// </summary>
        int fMaxNumCount;
        public int MaxNumCount
        {
            get { return fMaxNumCount; }
            set { fMaxNumCount = value; }
        }


        /// <summary>
        /// 文件读取位置
        /// </summary>
        long fFilePos;
        public long FilePos
        {
            get { return fFilePos; }
            set { fFilePos = value; }
        }


        /// <summary>
        /// 是否有虚部
        /// </summary>
        int fDataNum;
        public int DataNum
        {
            get { return fDataNum; }
            set { fDataNum = value; }
        }


        public CFileBase()
        {
            fMaxNumCount = 10000;
            fFilePos = 0;
        }





        public bool checkFileFormat()
        {
            fDataNum = System.Convert.ToInt32(fFileName.Substring(fFileName.Length - 3, 1));
            fDataWidth = System.Convert.ToInt32(fFileName.Substring(fFileName.Length - 2, 2));

            if (fDataWidth == 16)
                fSigh = true;
            else
                fSigh = false;

            System.Console.WriteLine("数据个数：{0},数据长度:{1}", fDataNum, fDataWidth);

            return true;

        }






        public void readFile(List<ComplexNumber> mInputNum, long mStartPos=0)
        {
            long offset=0;
            FileStream fs = new FileStream(fFileName, FileMode.Open);



            if (mStartPos != 0)
            {
                if (fDataWidth == 8 && fDataNum == 1)
                    fFilePos = mStartPos;
                if (fDataWidth == 12 && fDataNum == 1)
                    fFilePos = mStartPos * 3 / 2;
                if (fDataWidth == 12 && fDataNum == 2)
                    fFilePos = mStartPos * 3;
                if (fDataWidth == 16 && fDataNum == 2)
                    fFilePos = mStartPos * 4;
                if (fDataWidth == 16 && fDataNum == 1)
                    fFilePos = mStartPos * 2;
            }
            offset = fs.Seek(fFilePos, SeekOrigin.Begin);
            if (offset > fs.Length-5)
                return;

            BinaryReader br = new BinaryReader(fs);
            ComplexNumber c=new ComplexNumber(0,0);



            



            if (fDataWidth == 8 && fDataNum == 1)
            {
                for (long i = 0; i < fMaxNumCount ; i++)
                {
                    c.real = (double)(br.ReadByte()-128);
                    c.imag = 0;
                    mInputNum.Add(c);
                    fFilePos += 1;
                }
            }





            //位宽12，没有虚部
            if (fDataWidth == 12 && fDataNum == 1)
            {
                for (long i = 0; i < fMaxNumCount/2; i++)
                {
                    byte[] rd= br.ReadBytes(3);
                    int real=(int)rd[1] & 0x0f;
                    c.real = ((real << 8) | (rd[0])) -2048;
                    c.imag = 0;
                    mInputNum.Add(c);

                    real = (int)rd[1] & 0xf0;
                    c.real = ((real >> 4) | (((int)rd[2])<<4))-2048;
                    c.imag = 0;
                    mInputNum.Add(c);
                    fFilePos += 3;

                }

                ////判断是否有符号
                //int mLow = 0;
                //int mMid = 0;
                //int mHigh = 0;

                //for (int i = 0; i < mInputNum.Count; i++)
                //{
                //    if (mInputNum[i].real < 1365)
                //        mLow++;

                //    if (mInputNum[i].real > 1365 && mInputNum[i].real < 2730)
                //        mMid++;

                //    if (mInputNum[i].real > 2730)
                //        mHigh++;

                //}

                ////if (mMid <= mLow || mMid <= mHigh)
                //{
                //    for (int i = 0; i < mInputNum.Count; i++)
                //    {
                //        double tmpR = mInputNum[i].real;
                //        double tmpI = mInputNum[i].imag;
                //        //if (mInputNum[i].real > 2048)
                //            tmpR = mInputNum[i].real-2048;
                //        //if (mInputNum[i].imag > 2047)
                //        //    tmpI = 2048 - mInputNum[i].imag;
                //        mInputNum[i] = new ComplexNumber(tmpR, tmpI);
                //    }
                //}



            }


            //位宽12，有虚部，无符号
            if (fDataWidth == 12 && fDataNum == 2)
            {
                for (long i = 0; i < fMaxNumCount; i++)
                {
                    byte[] rd = br.ReadBytes(3);
                    int real = (int)rd[1] & 0x0f;
                    c.real = ((real << 8) | (rd[0]))-2048;

                    real = (int)rd[1] & 0xf0;
                    c.imag = ((real >> 4) | (((int)rd[2])<<4))-2048;

                    mInputNum.Add(c);
                    fFilePos += 3;

                }


                ////判断是否有符号
                //int mLow = 0;
                //int mMid = 0;
                //int mHigh = 0;

                //for (int i = 0; i < mInputNum.Count; i++)
                //{
                //    if (mInputNum[i].real < 1365)
                //        mLow++;

                //    if (mInputNum[i].real > 1365 && mInputNum[i].real < 2730)
                //        mMid++;

                //    if (mInputNum[i].real > 2730)
                //        mHigh++;

                //}

                //if (mMid <= mLow || mMid <= mHigh)
                //{
                //    for (int i = 0; i < mInputNum.Count; i++)
                //    {
                //        double tmpR = mInputNum[i].real;
                //        double tmpI = mInputNum[i].imag;
                //        //if (mInputNum[i].real > 2047)
                //            tmpR = 2048 - mInputNum[i].real;
                //        //if (mInputNum[i].imag > 2047)
                //            tmpI = 2048 - mInputNum[i].imag;
                //        mInputNum[i] = new ComplexNumber(tmpR, tmpI);
                //    }
                //}

            }

            //位宽16，有虚部，有符号
            if (fDataWidth == 16 && fDataNum == 2)
            {
                for (long i = 0; i < fMaxNumCount; i++)
                {
                    c.real = br.ReadInt16();
                    c.imag = br.ReadInt16();
                    fFilePos += 4;
                    // long pos = fs.Seek(offset, SeekOrigin.Current);
                    mInputNum.Add(c);

                }
            }


            //位宽16，没有虚部，有符号
            if (fDataWidth == 16 && fDataNum == 1)
            {
                for (long i = 0; i < fMaxNumCount; i++)
                {
                    int tmp = br.ReadInt16();
                    //if (tmp >= 2047)
                    tmp = tmp -2048;


                    c.real = tmp;
                    c.imag = 0;
                    fFilePos += 2;
                    // long pos = fs.Seek(offset, SeekOrigin.Current);
                    mInputNum.Add(c);

                }
            }




/*

            nNumChars = (fDataWidth * fDataNum) / 8;

            offset = fs.Length / fMaxNumCount;
            if (offset % 4 != 0)
                offset = offset + (offset % 4);


            for (long i = 0; i < fMaxNumCount; i++)
                {
                    c.real = br.ReadInt16();
                    c.imag = br.ReadInt16();
                    fFilePos += 4;
                   // long pos = fs.Seek(offset, SeekOrigin.Current);
                    mInputNum.Add(c);
                   // if (pos >= fs.Length)
                   //     break;
                    

                }
 * */
            br.Close();
            fs.Close();

        }



    }
}
