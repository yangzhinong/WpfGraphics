using System;
using System.Windows.Media.Media3D;

namespace Geometries
{
    public class ConeGeometry
    {
        // Define private fields:
        private double rtop = 1.0;
        private double rbottom = 1.0;
        private double height = 1.0;
        private int thetaDiv = 20;
        private Point3D center = new Point3D();
        // Define public properties:
        public double Rtop
        {
            get { return rtop; }
            set { rtop = value; }
        }
        public double Rbottom
        {
            get { return rbottom; }
            set { rbottom = value; }
        }
        public double Height
        {
            get { return height; }
            set { height = value; }
        }
        public int ThetaDiv
        {
            get { return thetaDiv; }
            set { thetaDiv = value; }
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
            MeshGeometry3D mesh = new MeshGeometry3D();
            if (ThetaDiv < 2)
                return null;
            double h = Height / 2;
            Point3D pt = new Point3D(0, h, 0);
            pt += (Vector3D)Center;
            Point3D pb = new Point3D(0, -h, 0);
            pb += (Vector3D)Center;
            Point3D[] pts = new Point3D[ThetaDiv];
            Point3D[] pbs = new Point3D[ThetaDiv];
            for (int i = 0; i < ThetaDiv; i++)
            {
                pts[i] = GetPosition(Rtop,
                i * 360 / (ThetaDiv - 1), h);
                pbs[i] = GetPosition(Rbottom,
                i * 360 / (ThetaDiv - 1), -h);
            }
            for (int i = 0; i < ThetaDiv - 1; i++)
            {
                // Top surface:
                mesh.Positions.Add(pt);
                mesh.Positions.Add(pts[i]);
                mesh.Positions.Add(pts[i + 1]);
                mesh.TriangleIndices.Add(10 * i);
                mesh.TriangleIndices.Add(10 * i + 1);
                mesh.TriangleIndices.Add(10 * i + 2);
                // Bottom surface:
                mesh.Positions.Add(pb);
                mesh.Positions.Add(pbs[i + 1]);
                mesh.Positions.Add(pbs[i]);
                mesh.TriangleIndices.Add(10 * i + 3);
                mesh.TriangleIndices.Add(10 * i + 4);

                mesh.TriangleIndices.Add(10 * i + 5);
                // Outer surface:
                mesh.Positions.Add(pts[i]);
                mesh.Positions.Add(pbs[i]);
                mesh.Positions.Add(pbs[i + 1]);
                mesh.Positions.Add(pts[i + 1]);
                mesh.TriangleIndices.Add(10 * i + 6);
                mesh.TriangleIndices.Add(10 * i + 7);
                mesh.TriangleIndices.Add(10 * i + 8);
                mesh.TriangleIndices.Add(10 * i + 8);
                mesh.TriangleIndices.Add(10 * i + 9);
                mesh.TriangleIndices.Add(10 * i + 6);
            }

            mesh.Freeze();
            return mesh;
        }

        private Point3D GetPosition(double radius,double theta, double y)
        {
            Point3D pt = new Point3D();
            double sn = Math.Sin(theta * Math.PI / 180);
            double cn = Math.Cos(theta * Math.PI / 180);
            pt.X = radius * cn;
            pt.Y = y;
            pt.Z = -radius * sn;
            pt += (Vector3D)Center;
            return pt;
        }
    }
}
