using System;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

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

        public static Matrix3D Matrix3DRound(Matrix3D m, int v)
        {
            double f(double x) => Math.Round(x, v);
            return new Matrix3D(f(m.M11), f(m.M12), f(m.M13), f(m.M14),
                            f(m.M21), f(m.M22), f(m.M23), f(m.M24),
                            f(m.M31), f(m.M32), f(m.M33), f(m.M34),
                            f(m.OffsetX), f(m.OffsetY), f(m.OffsetZ), f(m.M44));
        }

        public static void Print(Matrix3D m, string name)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Matrix3D {name}: ");
            sb.AppendLine($"\t{m.M11}, \t{m.M12}, \t{m.M13}, \t{m.M14}");
            sb.AppendLine($"\t{m.M21}, \t{m.M22}, \t{m.M23}, \t{m.M24}");
            sb.AppendLine($"\t{m.M31}, \t{m.M32}, \t{m.M33}, \t{m.M34}");
            sb.AppendLine($"\t{m.OffsetX}, \t{m.OffsetY}, \t{m.OffsetZ}, \t{m.M44}");

            Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// 设置视图矩阵
        /// </summary>
        /// <param name="cameraPosition">相机位置</param>
        /// <param name="lookDirection">看方向的向量</param>
        /// <param name="upDirection">相机正上方的向量</param>
        /// <returns></returns>
        public static Matrix3D SetViewMatrix(Point3D cameraPosition, Vector3D lookDirection, Vector3D upDirection)
        {
            // Normalize vectors
            lookDirection.Normalize();
            upDirection.Normalize();

            // Define vectors, XScale, YScale, and ZScale:
            //相当于是求的两个向量的夹角的余弦值
            double denom = Math.Sqrt(1 - Math.Pow(Vector3D.DotProduct(lookDirection, upDirection), 2));
            Vector3D XScale = Vector3D.CrossProduct(lookDirection, upDirection) / denom;
            Vector3D YScale = (upDirection - (Vector3D.DotProduct(upDirection, lookDirection)) * lookDirection) / denom;
            Vector3D ZScale = lookDirection;

            Matrix3D M = new Matrix3D();

            M.M11 = XScale.X;
            M.M21 = XScale.Y;
            M.M31 = XScale.Z;
            M.M12 = YScale.X;
            M.M22 = YScale.Y;
            M.M32 = YScale.Z;
            M.M13 = ZScale.X;
            M.M23 = ZScale.Y;
            M.M33 = ZScale.Z;

            // Translate the camera position to the origin:
            Matrix3D translateMatrix = new Matrix3D();
            translateMatrix.Translate(new Vector3D(-cameraPosition.X,-cameraPosition.Y, -cameraPosition.Z));
            // Define reflect matrix about the Z axis:
            Matrix3D reflectMatrix = new Matrix3D();
            reflectMatrix.M33 = -1;

            Matrix3D viewMatrix = translateMatrix * M * reflectMatrix;


            return viewMatrix;
        }

        /// <summary>
        /// 返回非对称视锥体的通用透视矩阵，
        /// 该矩阵以近平面的四条边以及到近平面和远平面的距离作为输入参数
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="near"></param>
        /// <param name="far"></param>
        /// <returns></returns>

        public static Matrix3D SetPerspectiveOffCenter(
                    double left, double right, double bottom,
                    double top, double near, double far)
        {
            Matrix3D perspectiveMatrix = new Matrix3D();
            perspectiveMatrix.M11 = 2 * near / (right - left);
            perspectiveMatrix.M22 = 2 * near / (top - bottom);
            perspectiveMatrix.M31 = (right + left) / (right - left);
            perspectiveMatrix.M32 = (top + bottom) / (top - bottom);
            perspectiveMatrix.M33 = far / (near - far);
            perspectiveMatrix.M34 = -1.0;
            perspectiveMatrix.OffsetZ = near * far / (near - far);
            perspectiveMatrix.M44 = 0;
            return perspectiveMatrix;
        }
        /// <summary>
        /// 返回对称视锥体，四个输入参数：近平面的宽度和高度，以及到近平面和远平面的距离
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="near"></param>
        /// <param name="far"></param>
        /// <returns></returns>
        public static Matrix3D SetPerspective(
                double width, double height,double near, double far)
        {
            Matrix3D perspectiveMatrix = new Matrix3D();
            perspectiveMatrix.M11 = 2 * near / width;
            perspectiveMatrix.M22 = 2 * near / height;
            perspectiveMatrix.M33 = far / (near - far);
            perspectiveMatrix.M34 = -1.0;
            perspectiveMatrix.OffsetZ = near * far / (near - far);
            perspectiveMatrix.M44 = 0;
            return perspectiveMatrix;
        }
        /// <summary>
        /// 返回对称视锥体，但使用视野和纵横比作为参数，
        /// 而不是宽度和高度。
        /// 通过将纵横比设置为 1，您可以将透视矩阵方法的结果与直接使用 PerspectiveCamera 类获得的结果进行比较
        /// </summary>
        /// <param name="fov"></param>
        /// <param name="aspectRatio"></param>
        /// <param name="near"></param>
        /// <param name="far"></param>
        /// <returns></returns>
        public static Matrix3D SetPerspectiveFov(double fov,
                        double aspectRatio, double near, double far)
        {
            Matrix3D perspectiveMatrix = new Matrix3D();
            double yscale = 1.0 / Math.Tan(fov * Math.PI / 180 / 2);
            double xscale = yscale / aspectRatio;
            perspectiveMatrix.M11 = xscale;
            perspectiveMatrix.M22 = yscale;
            perspectiveMatrix.M33 = far / (near - far);
            perspectiveMatrix.M34 = -1.0;
            perspectiveMatrix.OffsetZ = near * far / (near - far);
            perspectiveMatrix.M44 = 0;
            return perspectiveMatrix;
        }

        /// <summary>
        /// 正交变换
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="near"></param>
        /// <param name="far"></param>
        /// <returns></returns>
        public static Matrix3D SetOrthographicOffCenter(
                    double left, double right, double bottom,
                    double top, double near, double far)
        {
            Matrix3D orthographicMatrix = new Matrix3D();
            orthographicMatrix.M11 = 2 / (right - left);
            orthographicMatrix.M22 = 2 / (top - bottom);
            orthographicMatrix.M33 = 1 / (near - far);
            orthographicMatrix.OffsetX = (left + right) / (left - right);
            orthographicMatrix.OffsetY =  (bottom + top) / (bottom - top);
            orthographicMatrix.OffsetZ = near / (near - far);
            return orthographicMatrix;
        }

        public static Matrix3D SetOrthographic(double width,
                    double height, double near, double far)
        {
            Matrix3D orthographicMatrix = new Matrix3D();
            orthographicMatrix.M11 = 2 / width;
            orthographicMatrix.M22 = 2 / height;
            orthographicMatrix.M33 = 1 / (near - far);
            orthographicMatrix.OffsetZ = near / (near - far);
            return orthographicMatrix;
        }


    }
}
