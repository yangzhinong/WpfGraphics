using System;
using System.Windows.Media.Media3D;

namespace Geometries
{
    public class TorusGeometry
    {
        // Define private fields:
        private double r1 = 1.0;
        private double r2 = 0.3;
        private int uDiv = 20;
        private int vDiv = 20;
        private Point3D center = new Point3D();
        // Define public properties:
        public double R1
        {
            get { return r1; }
            set { r1 = value; }
        }
        public double R2
        {
            get { return r2; }
            set { r2 = value; }
        }

        public int UDiv
        {
            get { return uDiv; }
            set { uDiv = value; }
        }
        public int VDiv
        {
            get { return vDiv; }
            set { vDiv = value; }
        }
        public Point3D Center
        {
            get { return center; }
            set { center = value; }
        }
        // Get-only property generates MeshGeometry3D object:
        public MeshGeometry3D Mesh3D
        {
            get { return GetMesh3D(); }
        }

        private MeshGeometry3D GetMesh3D()
        {
            if (UDiv < 2 || VDiv < 2)
                return null;
            MeshGeometry3D mesh = new MeshGeometry3D();
            Point3D[,] pts = new Point3D[UDiv, VDiv];
            for (int i = 0; i <= UDiv; i++)
            {
                for (int j = 0; j <= VDiv; j++)
                {
                    mesh.Positions.Add(
                    GetPosition(i * 360 / (UDiv - 1),
                    j * 360 / (VDiv - 1)));
                }
            }

            for (int i = 0; i < UDiv; i++)
            {
                for (int j = 0; j < VDiv; j++)
                {
                    int y0 = j;
                    int y1 = j + 1;
                    int x0 = i * (VDiv + 1);
                    int x1 = (i + 1) * (VDiv + 1);
                    mesh.TriangleIndices.Add(x0 + y0);
                    mesh.TriangleIndices.Add(x0 + y1);
                    mesh.TriangleIndices.Add(x1 + y0);

                    mesh.TriangleIndices.Add(x1 + y0);
                    mesh.TriangleIndices.Add(x0 + y1);
                    mesh.TriangleIndices.Add(x1 + y1);
                }
            }
            mesh.Freeze();
            return mesh;
        }

        private Point3D GetPosition(double u, double v)
        {
            Point3D pt = new Point3D();
            double snu = Math.Sin(u * Math.PI / 180);
            double cnu = Math.Cos(u * Math.PI / 180);
            double snv = Math.Sin(v * Math.PI / 180);
            double cnv = Math.Cos(v * Math.PI / 180);
            pt.X = (R1 + R2 * cnv) * cnu;
            pt.Y = R2 * snv;
            pt.Z = (R1 + R2 * cnv) * snu;
            pt += (Vector3D)Center;
            return pt;
        }

    }
}
