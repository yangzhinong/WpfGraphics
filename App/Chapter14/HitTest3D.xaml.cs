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

namespace WpfApp7.Chapter14
{
    /// <summary>
    /// Interaction logic for HitTest3D.xaml
    /// </summary>
    public partial class HitTest3D : Window
    {
        public HitTest3D()
        {
            InitializeComponent();
        }

        private void viewport3d_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePoint = e.GetPosition(viewport3d);
            HitTestResult result = VisualTreeHelper.HitTest(viewport3d, mousePoint);

            var mesh = result as RayMeshGeometry3DHitTestResult;
            if (mesh != null)
            {
                double x = Math.Round(mesh.PointHit.X, 4);
                double y = Math.Round(mesh.PointHit.Y, 4);
                double z = Math.Round(mesh.PointHit.Z, 4);
                Point3D pt = new Point3D(x, y, z);
                string text = "(" + pt.ToString() + ")";
                if (mesh.MeshHit == torusMesh.Geometry)
                    text = "Torus - Mesh Point = " + text;
                else if (mesh.MeshHit == sphereMesh.Geometry)
                    text = "Sphere - Mesh Point = " + text;
                textBlock.Text = text;
            }
        }
    }
}
