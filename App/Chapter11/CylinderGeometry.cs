using System;
using System.Windows.Media.Media3D;

namespace Geometries
{
    public class CylinderGeometry
    {
        // Define private fields:
        private double rin = 1.0;
        private double rout = 1.0;
        private double height = 1.0;
        private int thetaDiv = 20;
        private Point3D center = new Point3D();
        // Define public properties:
        public double Rin { get=> rin; set=> rin=value; }

        public double Rout
        {
            get { return rout; }
            set { rout = value; }
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
            if (ThetaDiv < 2 || Rin == Rout)
                return null;
            double radius = Rin;
            if (Rin > Rout)
            {
                Rin = rout;
                Rout = radius;
            }
            double h = Height / 2;
            Point3D[,] pts = new Point3D[ThetaDiv, 4];

            for (int i = 0; i < ThetaDiv; i++)
            {
                pts[i, 0] = GetPosition(rout, i * 360 / (ThetaDiv - 1), h);
                pts[i, 1] = GetPosition(rout,                 i * 360 / (ThetaDiv - 1), -h);
                pts[i, 2] = GetPosition(rin,                i * 360 / (ThetaDiv - 1), -h);
                pts[i, 3] = GetPosition(rin,                 i * 360 / (ThetaDiv - 1), h);
            }
            for (int i = 0; i < ThetaDiv - 1; i++)
            {
                // Top surface:
                mesh.Positions.Add(pts[i, 0]);
                mesh.Positions.Add(pts[i + 1, 0]);
                mesh.Positions.Add(pts[i + 1, 3]);
                mesh.Positions.Add(pts[i, 3]);
                mesh.TriangleIndices.Add(16 * i);
                mesh.TriangleIndices.Add(16 * i + 1);
                mesh.TriangleIndices.Add(16 * i + 2);
                mesh.TriangleIndices.Add(16 * i + 2);
                mesh.TriangleIndices.Add(16 * i + 3);
                mesh.TriangleIndices.Add(16 * i);
                // Bottom surface:
                mesh.Positions.Add(pts[i, 1]);
                mesh.Positions.Add(pts[i, 2]);
                mesh.Positions.Add(pts[i + 1, 2]);
                mesh.Positions.Add(pts[i + 1, 1]);
                mesh.TriangleIndices.Add(16 * i + 4);
                mesh.TriangleIndices.Add(16 * i + 5);
                mesh.TriangleIndices.Add(16 * i + 6);
                mesh.TriangleIndices.Add(16 * i + 6);
                mesh.TriangleIndices.Add(16 * i + 7);
                mesh.TriangleIndices.Add(16 * i + 4);

                // Outer surface:
                mesh.Positions.Add(pts[i, 1]);
                mesh.Positions.Add(pts[i + 1, 1]);
                mesh.Positions.Add(pts[i + 1, 0]);
                mesh.Positions.Add(pts[i, 0]);
                mesh.TriangleIndices.Add(16 * i + 8);
                mesh.TriangleIndices.Add(16 * i + 9);
                mesh.TriangleIndices.Add(16 * i + 10);
                mesh.TriangleIndices.Add(16 * i + 10);
                mesh.TriangleIndices.Add(16 * i + 11);
                mesh.TriangleIndices.Add(16 * i + 8);
                // Inner surface:
                mesh.Positions.Add(pts[i, 3]);
                mesh.Positions.Add(pts[i + 1, 3]);
                mesh.Positions.Add(pts[i + 1, 2]);
                mesh.Positions.Add(pts[i, 2]);
                mesh.TriangleIndices.Add(16 * i + 12);

                mesh.TriangleIndices.Add(16 * i + 13);
                mesh.TriangleIndices.Add(16 * i + 14);
                mesh.TriangleIndices.Add(16 * i + 14);
                mesh.TriangleIndices.Add(16 * i + 15);
                mesh.TriangleIndices.Add(16 * i + 12);
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
