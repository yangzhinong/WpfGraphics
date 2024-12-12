using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace WpfApp7.Chapter13
{
    /// <summary>
    /// Interaction logic for SimpleSurfaceTest.xaml
    /// </summary>
    public partial class SimpleSurfaceTest : Window
    {
        private SimpleSurface ss = new SimpleSurface();
        public SimpleSurfaceTest()
        {
            InitializeComponent();
            ss.IsHiddenLine = false;
            ss.Viewport3d = viewport;
            //AddSinc();
            //AddPeaks();
            AddRandomSurface();
        }

        private void AddSinc()
        {
            ss.Xmin = -8;
            ss.Xmax = 8;
            ss.Zmin = -8;
            ss.Zmax = 8;
            ss.Ymin = -1;
            ss.Ymax = 1;
            ss.CreateSurface(Sinc);
        }

        private Point3D Sinc(double x, double z)
        {
            double r = Math.Sqrt(x * x + z * z) + 0.00001;
            double y = Math.Sin(r) / r;
            return new Point3D(x, y, z);
        }

        private void AddPeaks()
        {
            ss.Xmin = -3;
            ss.Xmax = 3;
            ss.Zmin = -3;
            ss.Zmax = 3;
            ss.Ymin = -8;
            ss.Ymax = 8;
            ss.CreateSurface(Peaks);
        }

        private Point3D Peaks(double x, double z)
        {
            double y = 3 * Math.Pow((1 - x), 2) * Math.Exp(-x * x - (z + 1) * (z + 1)) -
                            10 * (0.2 * x - Math.Pow(x, 3)-Math.Pow(z, 5)) * 
                            Math.Exp(-x * x - z * z) -1 / 3 * Math.Exp(-(x + 1) * (x + 1) - z * z);
            return new Point3D(x, y, z);
        }

        private void AddRandomSurface()
        {
            ss.Xmin = -8;
            ss.Xmax = 8;
            ss.Zmin = -8;
            ss.Zmax = 8;
            ss.Ymin = -1;
            ss.Ymax = 1;
            ss.CreateSurface(RandomSurface);
        }
        private Random rand = new Random();
        private Point3D RandomSurface(double x, double z)
        {
            double r = Math.Sqrt(x * x + z * z) + 0.00001;
            double y = Math.Sin(r) / r +  0.2 * rand.NextDouble();
            return new Point3D(x, y, z);
        }
    }
}
