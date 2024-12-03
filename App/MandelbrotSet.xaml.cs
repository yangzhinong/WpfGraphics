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
using System.Windows.Shapes;

namespace WpfApp7
{
    /// <summary>
    /// Interaction logic for MandelbrotSet.xaml
    /// </summary>
    public partial class MandelbrotSet : Window
    {
        private double Xmin = -2;
        private double Xmax = 1;
        private double Ymin = -1.5;
        private double Ymax = 1.5;
        private int NIterations = 200;
        private double MaxRadius = 2;
        private int width = 3 * 128;
        private int height = 3 * 128;
        private double zmax = 0;
        private Shape rubberBand = null;
        private Point startPoint = new Point();
        Point endPoint = new Point();

        public MandelbrotSet()
        {
            InitializeComponent();
            InitializeMandelbrot();
        }

        private void InitializeMandelbrot()
        {
            tbIterations.Text = "100";
            tbRadius.Text = "2";
            tbXmin.Text = "-2";
            tbXmax.Text = "1";
            tbYmin.Text = "-1.5";
            tbYmax.Text = "1.5";
            NIterations = 100;
            MaxRadius = 2;
            Xmin = -2;
            Xmax = 1;
            Ymin = -1;
            Ymax = 1;
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!canvas.IsMouseCaptured)
            {
                startPoint = e.GetPosition(canvas);
                canvas.CaptureMouse();
            }
        }

        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            endPoint = e.GetPosition(canvas);
            if (endPoint.X > startPoint.X)
            {
                Xmin = Xmin + (Xmax - Xmin) * startPoint.X / width;
                Xmax = Xmin + (Xmax - Xmin) * endPoint.X / width;
            }
            else if (endPoint.X < startPoint.X)
            {
                Xmax = Xmin + (Xmax - Xmin) * startPoint.X / width;
                Xmin = Xmin + (Xmax - Xmin) * endPoint.X / width;
            }
            if (endPoint.Y > startPoint.Y)
            {
                Ymin = Ymin + (Ymax - Ymin) * startPoint.Y / height;
                Ymax = Ymin + (Ymax - Ymin) * endPoint.Y / height;
            }
            else if (endPoint.Y < startPoint.Y)
            {
                Ymax = Ymin + (Ymax - Ymin) * startPoint.Y / height;
                Ymin = Ymin + (Ymax - Ymin) * endPoint.Y / height;
            }

            tbXmin.Text = Xmin.ToString();
            tbXmax.Text = Xmax.ToString();
            tbYmin.Text = Ymin.ToString();
            tbYmax.Text = Ymax.ToString();
            byte[] pixelData = DrawMandelbrotSet();

            BitmapSource bmpSource = BitmapSource.Create(width, height, 96, 96,
                                                PixelFormats.Gray8, null, pixelData, width);
            showImage.Source = bmpSource;
            if (rubberBand != null)
            {
                canvas.Children.Remove(rubberBand);
                rubberBand = null;
                canvas.ReleaseMouseCapture();
            }
        }

        private byte[] DrawMandelbrotSet()
        {
            int looper;
            double cx, cy, dcx, dcy, x, y, x2, y2;
            dcx = (Xmax - Xmin) / (width - 1);
            dcy = (Ymax - Ymin) / (height - 1);
            byte[] pixelData =
            new byte[width * height];
            cy = Ymin;
            for (int i = 0; i < height; i++)
            {
                int iIndex = i * height;
                cx = Xmin;
                for (int j = 0; j < height; j++)
                {
                    x = 0;
                    y = 0;
                    x2 = 0;
                    y2 = 0;
                    looper = 1;
                    while (looper < NIterations && x2 + y2 < MaxRadius * MaxRadius)
                    {
                        x2 = x * x;
                        y2 = y * y;
                        y = 2 * y * x + cy;
                        x = x2 - y2 + cx;
                        looper += 1;
                    }

                    int cindex;
                    if (looper < NIterations)
                    {
                        cindex = 150 + looper % 256;
                        if (cindex < 0)
                            cindex = 0;
                        if (cindex > 255)
                            cindex = 255;
                    }
                    else
                        cindex = 50;
                    pixelData[j + iIndex] =
                    (byte)cindex;
                    cx += dcx;
                    if (zmax < Math.Sqrt(x2 + y2))
                        zmax = Math.Sqrt(x2 + y2);
                }
                cy += dcy;
            }
            return pixelData;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (canvas.IsMouseCaptured)
            {
                endPoint = e.GetPosition(canvas);
                if (rubberBand == null)
                {
                    rubberBand = new Rectangle();
                    rubberBand.Stroke = Brushes.Red;
                    canvas.Children.Add(rubberBand);
                }
                double width1 = Math.Abs(startPoint.X - endPoint.X);
                double height1 = Math.Abs(startPoint.Y - endPoint.Y);
                double left1 = Math.Min(startPoint.X, endPoint.X);
                double top1 = Math.Min(startPoint.Y, endPoint.Y);
                rubberBand.Width = width1;
                rubberBand.Height = height1;
                Canvas.SetLeft(rubberBand, left1);
                Canvas.SetTop(rubberBand, top1);
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            AddMandelbrotSet();
        }

        private void AddMandelbrotSet()
        {
            Xmin = Double.Parse(tbXmin.Text);
            Xmax = Double.Parse(tbXmax.Text);
            Ymin = Double.Parse(tbYmin.Text);
            Ymax = Double.Parse(tbYmax.Text);
            NIterations = Int32.Parse(tbIterations.Text);
            MaxRadius = Double.Parse(tbRadius.Text);
            byte[] pixelData = DrawMandelbrotSet();
            BitmapSource bmpSource =
            BitmapSource.Create(width, height, 96, 96,
                                    PixelFormats.Gray8, null, pixelData, width);
            showImage.Source = bmpSource;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            InitializeMandelbrot();
            AddMandelbrotSet();
        }
    }
}
