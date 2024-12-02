using System.Windows.Controls;

namespace WpfApp7
{
    public class Utility
    {
        public static double XNormalize(Canvas canvas, double x, double xMin, double xMax)
        {
            double result = (x - xMin) *
            canvas.Width / (xMax - xMin);
            return result;
        }
        public static double YNormalize(Canvas canvas, double y, double yMin, double yMax)
        {
            double result = canvas.Height - (y - yMin) *
            canvas.Height / (yMax - yMin);
            return result;
        }
    }
}
