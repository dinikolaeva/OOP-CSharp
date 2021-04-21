using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    public class Box
    {
        private decimal length;
        private decimal height;
        private decimal width;

        public Box(decimal length, decimal width, decimal height)
        {
            this.Length = length;
            this.Width  = width;
            this.Height = height;
        }

        public decimal Length
        {
            get => this.length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                length = value;
            }

        }
        public decimal Width 
        {
            get => width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                width = value;
            }
        }
        public decimal Height
        {
            get => height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                height = value;
            }
        }

        public decimal GetSurfaceArea()
        {
            return 2 * this.Length * this.Width  + 2 * this.Length * this.Height + 2 * this.Width  * this.Height;
        }

        public decimal GetLateralSurfaceArea()
        {
            return 2 * this.Length * this.Height + 2 * this.Width  * this.Height;
        }

        public decimal GetVolume()
        {
            return this.Length * this.Width  * this.Height;
        }
    }
}
