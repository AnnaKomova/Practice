using CW5.Variant00;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW5.Variant00
{
    public class Task2
    {
        public class Number : INumber
        {
            protected double _real;

            public double Real => _real;
            public virtual double Abs => Math.Abs(_real);
            public int Sign => Math.Sign(_real);

            public Number(double real)
            {
                _real = real;
            }

            public virtual void Sum(INumber other)
            {
                if(other == null) { return; }
                _real += other.Real;
            }
            public virtual void Sub(INumber other)
            {
                if (other == null) { return; }
                _real -= other.Real;
            }
            public virtual void Mul(INumber other)
            {
                if (other == null) { return; }
                _real *= other.Real;
            }
            public virtual void Div(INumber other)
            {
                if (other == null) { return; }
                _real /= other.Real;
            }
            public virtual void Neg()
            {
                _real *= -1;
            }
        }

        public class ComplexNumber : Number, IComplexNumber
        {
            private double _imaginary;

            public double Imaginary => _imaginary;
            public int ISign => Math.Sign(_imaginary);

            public ComplexNumber(double real, double imaginary) : base(real)
            {
                _imaginary = imaginary;
            }

            public override void Sum(INumber other)
            {
                if (other is ComplexNumber)
                {
                    //_imaginary += other.Imaginary;  ..ошибка...
                    _real += other.Real;
                }

            }
            public override void Sub(INumber other)
            {
                //_real -= other.Real;
            }
            public override void Mul(INumber other)
            {
                //_real *= other.Real;
            }
            public override void Div(INumber other)
            {
                //_real /= other.Real;
            }
            public override void Neg()
            {
                //_real *= -1;
            }

        }
    }
    }
