using System;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileName.GetFileExtension("example"));
            Console.WriteLine(FileName.GetFileExtension("example.pdf"));
            Console.WriteLine(FileName.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileName.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileName.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileName.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}", Calculations2D.CalculateDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", Calculations3D.CalculateDistance3D(5, 2, -1, 3, -6, 4));

            Dimensions.Width = 3;
            Dimensions.Height = 4;
            Dimensions.Depth = 5;
            Console.WriteLine("Volume = {0:f2}", Calculations3D.CalculateVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", Calculations3D.CalculateDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", Calculations2D.CalculateDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", Calculations2D.CalculateDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", Calculations2D.CalculateDiagonalYZ());
        }
    }
}
