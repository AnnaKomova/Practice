using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW5.Variant00
{
    public class Task1
    {
        public struct Number : INumber
        {
            private double _real;


            public double Real => _real;
            public double Abs => Math.Abs(_real);
            public int Sign => Math.Sign(_real);

            public Number(double real)
            {
                _real = real;
            }

            public void Sum(INumber other)
            {
                _real += other.Real;
            }
            public void Sub(INumber other)
            {
                _real -= other.Real;
            }
            public void Mul(INumber other)
            {
                _real *= other.Real;
            }
            public void Div(INumber other)
            {
                _real /= other.Real;
            }
            public void Neg()
            {
                _real *= -1;
            }
        }
    }
}
