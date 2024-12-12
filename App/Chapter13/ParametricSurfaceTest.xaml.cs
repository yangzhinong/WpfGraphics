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
using WpfApp7.Chapter10;

namespace WpfApp7.Chapter13
{
    /// <summary>
    /// Interaction logic for ParametricSurfaceTest.xaml
    /// </summary>
    public partial class ParametricSurfaceTest : Window
    {
        private ParametricSurface ps = new ParametricSurface();
        public ParametricSurfaceTest()
        {
            InitializeComponent();
            ps.IsHiddenLine = false;
            ps.Viewport3d = viewport;
            //AddHelicoid();
            //AddSphere();
            //AddTorus();
            //AddHyperboloid();
            AddEllipticCylinder();
        }
        private void AddHelicoid()
        {
            ps.Umin = 0.5;
            ps.Umax = 1;
            ps.Vmin = -3 * Math.PI;
            ps.Vmax = 3 * Math.PI;
            ps.Nv = 100;
            ps.Nu = 10;
            ps.Ymin = ps.Vmin;
            ps.Ymax = ps.Vmax;
            ps.CreateSurface(Helicoid);
        }

        private Point3D Helicoid(double u, double v)
        {
            double x = u * Math.Cos(v);
            double z = u * Math.Sin(v);
            double y =  v;
            return new Point3D(x, y, z);
        }

        private void AddSphere()
        {
            ps.Umin = 0;
            ps.Umax = 2 * Math.PI;
            ps.Vmin = -0.5 * Math.PI;
            ps.Vmax = 0.5 * Math.PI;
            ps.Nu = 20;
            ps.Nv = 20;
            ps.CreateSurface(Sphere);
        }

        private Point3D Sphere(double u, double v)
        {
            double x = Math.Cos(v) * Math.Cos(u);
            double z = Math.Cos(v) * Math.Sin(u);
            double y = Math.Sin(v);
            return new Point3D(x, y, z);
        }
        private void AddTorus()
        {
            ps.Umin = 0;
            ps.Umax = 2 * Math.PI;
            ps.Vmin = 0;
            ps.Vmax = 2 * Math.PI;
            ps.Nu = 50;
            ps.Nv = 20;
            ps.CreateSurface(Torus);
        }

        private Point3D Torus(double u, double v)
        {
            double x = (1 + 0.3 * Math.Cos(v)) * Math.Cos(u);
            double z = (1 + 0.3 * Math.Cos(v)) * Math.Sin(u);
            double y = 0.3 * Math.Sin(v);
            return new Point3D(x, y, z);
        }

        private void AddHyperboloid()
        {
            ps.Umin = -2 * Math.PI;
            ps.Umax = 2 * Math.PI;
            ps.Vmin = -2 * Math.PI;
            ps.Vmax = 2 * Math.PI;
            ps.Nu = 50;
            ps.Nv = 50;
            ps.CreateSurface(Hyperboloid);
        }

        /// <summary>
        /// 双曲面
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        private Point3D Hyperboloid(double u, double v)
        {
            const double a = 1.0d, b = 1.0d, c = 1.0d;
            double x = a * Math.Cos(u) * Math.Cosh(v);
            double y = b * Math.Sinh(v);
            double z = c * Math.Sin(u) * Math.Cosh(v);
            return new Point3D(x, y, z);
        }

        private void AddEllipticCylinder()
        {
            ps.Umin = 0;
            ps.Umax = 2 * Math.PI;
            ps.Vmin = -1;
            ps.Vmax = 1;
            ps.Nu = 30;
            ps.Nv = 10;
            ps.CreateSurface(EllipticCylinder);
        }
        /// <summary>
        /// 椭圆柱面
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        private Point3D EllipticCylinder(double u, double v)
        {
            const double a = 1.5d, b = 1.0d;
            double x = a * Math.Cos(u);
            double y = v;
            double z = b * Math.Sin(u);
            return new Point3D(x, y, z);
        }

    }
}
