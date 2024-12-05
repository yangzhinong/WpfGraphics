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

namespace WpfApp7.Chapter09
{
    /// <summary>
    /// Interaction logic for OrthographicProjection.xaml
    /// </summary>
    public partial class OrthographicProjection : Window
    {
        public OrthographicProjection()
        {
            InitializeComponent();
            SetMatrixCamera();
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            SetMatrixCamera();
        }

        private void SetMatrixCamera()
        {
            Point3D cameraPosition =Point3D.Parse(tbCameraPosition.Text);
            Vector3D lookDirection = Vector3D.Parse(tbLookDirection.Text);
            Vector3D upDirection =  Vector3D.Parse(tbUpDirection.Text);
            double w = Double.Parse(tbWidth.Text);
            double zn = Double.Parse(tbNearPlane.Text);
            double zf = Double.Parse(tbFarPlane.Text);

            myCameraMatrix.ViewMatrix =Utility.SetViewMatrix(cameraPosition,lookDirection, upDirection);
            myCameraMatrix.ProjectionMatrix = Utility.SetOrthographic(w, w, zn, zf);
        }
    }
}
