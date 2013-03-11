using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BMHDTVPlotTool
{
    class CTxtFile:CFileBase
    {
        int fDataChars;

        public CTxtFile():base()
        {
            fDataChars = 0;
        }

        private void calcDataChars()
        {
            if (fDataWidth % 4 == 0)
                fDataChars = fDataWidth / 4;
            else
                fDataChars = fDataWidth / 4 + 1;
        }



        private double getNumFormChars(string s)
        {
            /*
            int sigh=1;
	        long intData=0;
	        long deciData=0;
            string intStr;
            string deciStr;



            if (fSigh)
            {
                intStr = s.Substring(1, fIntWidth);
                deciStr = s.Substring(1+fIntWidth,s.Length-1-fIntWidth-2);
                
               
            }
            else
            {
                intStr = s.Substring(0, fIntWidth);
                deciStr = s.Substring(1 + fIntWidth, s.Length  - fIntWidth - 2);
            }

            if (fIntWidth != 0)
                intData = Convert.ToInt32(intStr, 16);
            else
                intData = 0;

            if (fDeciWidth != 0)
                deciData = Convert.ToInt32(deciStr, 16);
            else
                deciData = 0;



            

	        return data_float;
             */
            return 1.0;
        }


        public void readFile(List<ComplexNumber> mInputNum)
        {
            int i=0;
            StreamReader objReader = new StreamReader(fFileName);
            string sLine = "";
            calcDataChars();
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                //getNumFormChars(sLine);
                ComplexNumber c = new ComplexNumber(0, 0);
                c.real = System.Convert.ToDouble(sLine);
                mInputNum.Add(c);
                i++;
                if (i == 10000)
                    break;
                //System.Console.WriteLine("{0}", sLine);
            }
            objReader.Close();

        }



    }
}
