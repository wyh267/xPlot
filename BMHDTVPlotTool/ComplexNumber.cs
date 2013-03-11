using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMHDTVPlotTool
{
    /// <summary>
    /// 复数结构
    /// 包含标准的复数四则运算
    /// </summary>
    public struct ComplexNumber
    {
        public ComplexNumber(double _real, double _imag)
        {
            this.real = _real;
            this.imag = _imag;
        }
        public double imag;
        public double real;
        public static ComplexNumber operator +(ComplexNumber comp1, ComplexNumber comp2)
        {
            return new ComplexNumber((comp1.real + comp2.real), (comp1.imag + comp2.imag));
        }
        public static ComplexNumber operator -(ComplexNumber comp1, ComplexNumber comp2)
        {
            return new ComplexNumber((comp1.real - comp2.real), (comp1.imag - comp2.imag));
        }
        public static ComplexNumber operator *(ComplexNumber comp1, ComplexNumber comp2)
        {
            return new ComplexNumber((comp1.real * comp2.real - comp1.imag * comp2.imag), (comp1.real * comp2.imag + comp1.imag * comp2.real));
        }
        public static ComplexNumber operator /(ComplexNumber comp1, int num)
        {
            return new ComplexNumber((comp1.real / num), (comp1.imag / num));
        }
        public static ComplexNumber operator *(ComplexNumber comp1, int num)
        {
            return new ComplexNumber((comp1.real * num), (comp1.imag * num));
        }
        public static ComplexNumber operator *(ComplexNumber comp1, double num)
        {
            return new ComplexNumber((comp1.real * num), (comp1.imag * num));
        }
    }
}
