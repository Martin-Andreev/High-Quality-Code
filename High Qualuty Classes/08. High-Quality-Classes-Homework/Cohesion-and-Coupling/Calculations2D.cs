using System;

namespace CohesionAndCoupling
{
    public static class Calculations2D
    {
        public static double CalculateDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public static double CalculateDiagonalXY()
        {
            double distance = Calculations2D.CalculateDistance2D(0, 0, Dimensions.Width, Dimensions.Height);
            return distance;
        }

        public static double CalculateDiagonalXZ()
        {
            double distance = Calculations2D.CalculateDistance2D(0, 0, Dimensions.Width, Dimensions.Depth);
            return distance;
        }

        public static double CalculateDiagonalYZ()
        {
            double distance = Calculations2D.CalculateDistance2D(0, 0, Dimensions.Height, Dimensions.Depth);
            return distance;
        }
    }
}