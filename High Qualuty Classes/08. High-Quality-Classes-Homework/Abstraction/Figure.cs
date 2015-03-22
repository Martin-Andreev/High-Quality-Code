namespace Abstraction
{
    using System;

    public abstract class Figure : IFigure
    {
        protected double width;
        protected double height;
        protected double radius;

        protected Figure(double radius)
        {
            this.Radius = radius;
        }

        protected Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public virtual double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Width cannot be negative number!");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Height cannot be negative number!");
                }

                this.height = value;
            }
        }

        public virtual double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Radius cannot be negative number!");
                }

                this.radius = value;
            }
        }

        public abstract double CalcPerimeter();

        public abstract double CalcSurface();
    }
}
