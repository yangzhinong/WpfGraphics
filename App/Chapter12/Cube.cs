using Geometries;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Shapes
{
    public class Cube : UIElement3D
    {
        protected override void OnUpdateModel()
        {
            GeometryModel3D model = new GeometryModel3D();
            CubeGeometry geometry = new CubeGeometry();

            geometry.Width = Width;
            geometry.Height = Height;
            geometry.Length = Length;
            geometry.Center = Center;
            model.Geometry = geometry.Mesh3D;
            model.Material= Material;

            Model = model;
        }

        public Model3D Model
        {
            get { return (Model3D)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        // The Model property for the cube:
        private static readonly DependencyProperty
        ModelProperty = DependencyProperty.Register("Model", typeof(Model3D), typeof(Cube),
                        new PropertyMetadata(ModelPropertyChanged));
        private static void ModelPropertyChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
        {
            Cube cube = (Cube)d;
            cube.Visual3DModel = (Model3D)e.NewValue;
        }


        public double Length
        {
            get { return (double)GetValue(LengthProperty); }
            set { SetValue(LengthProperty, value); }
        }

        public static readonly DependencyProperty LengthProperty =
            DependencyProperty.Register("Length", typeof(double), typeof(Cube),
                new PropertyMetadata(1.0d, PropertyChanged));




        public double Width
        {
            get { return (double)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }

        public static readonly DependencyProperty WidthProperty =
            DependencyProperty.Register("Width", typeof(double), typeof(Cube),
                new PropertyMetadata(1.0d, PropertyChanged));



        public double Height
        {
            get { return (double)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }

        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.Register("Height", typeof(double), typeof(Cube), new PropertyMetadata(1.0d, PropertyChanged));





        public Point3D Center
        {
            get { return (Point3D)GetValue(CenterProperty); }
            set { SetValue(CenterProperty, value); }
        }

        public static readonly DependencyProperty CenterProperty =
            DependencyProperty.Register("Center", typeof(Point3D), typeof(Cube),
                new PropertyMetadata(new Point3D(0, 0, 0), PropertyChanged));



        public Material Material
        {
            get { return (Material)GetValue(MaterialProperty); }
            set { SetValue(MaterialProperty, value); }
        }

        public static readonly DependencyProperty MaterialProperty =
            DependencyProperty.Register("Material", typeof(Material), typeof(Cube),
                new PropertyMetadata(new DiffuseMaterial(Brushes.Blue), PropertyChanged));

        private static void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as Cube)?.InvalidateModel();
        }
    }
}
