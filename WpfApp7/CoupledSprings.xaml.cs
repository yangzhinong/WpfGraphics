using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp7
{
    /// <summary>
    /// Interaction logic for CoupledSprings.xaml
    /// </summary>
    public partial class CoupledSprings : Window
    {
        private double M1;
        private double K1;
        private double B1;
        private double M2;
        private double K2;
        private double B2;
        private double K3;
        private double B3;
        private double X01;
        private double X02;
        private double V01;
        private double V02;

        private double xb1 = 3.4;
        private double xb2 = 6.6;


        double[] xx = new double[4];
        double[] result = new double[4];

        double time = 0;
        double dt = 0.02;

        Polyline pl1 = new Polyline();
        Polyline pl2 = new Polyline();
        Polyline pl3 = new Polyline();
        Polyline pl4 = new Polyline();


        public CoupledSprings()
        {
            InitializeComponent();
            pl1.Stroke = Brushes.Blue;
            canvas2.Children.Add(pl1);
            pl2.Stroke = Brushes.Blue;
            canvas3.Children.Add(pl2);
            SpringsInitialize();
        }

        private void SpringsInitialize()
        {
            tbm1.Text = "0.2";
            tbk1.Text = "10";
            tbb1.Text = "0.0";
            tbm2.Text = "0.2";
            tbk2.Text = "1";
            tbb2.Text = "0.0";
            tbk3.Text = "10";
            tbb3.Text = "0.0";
            tbx01.Text = "1";
            tbv01.Text = "0";
            tbx02.Text = "0";
            tbv02.Text = "0";
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            // Get input parameters:
            M1 = Double.Parse(tbm1.Text);
            K1 = Double.Parse(tbk1.Text);
            B1 = Double.Parse(tbb1.Text);
            M2 = Double.Parse(tbm2.Text);
            K2 = Double.Parse(tbk2.Text);
            B2 = Double.Parse(tbb2.Text);
            K3 = Double.Parse(tbk3.Text);
            B3 = Double.Parse(tbb3.Text);
            X01 = Double.Parse(tbx01.Text);
            X02 = Double.Parse(tbx02.Text);
            V01 = Double.Parse(tbv01.Text);
            V02 = Double.Parse(tbv02.Text);

            // Add polylines for displaying
            // positions of m1 and m2:
            canvas2.Children.Clear();
            pl1 = new Polyline();
            pl1.Stroke = Brushes.Blue;
            canvas2.Children.Add(pl1);
            pl2 = new Polyline();
            pl2.Stroke = Brushes.Red;
            canvas2.Children.Add(pl2);

            // Add polylines for displaying
            // position phase diagram:
            canvas3.Children.Clear();
            path1.Fill = Brushes.Red;
            pl3 = new Polyline();
            pl3.Stroke = Brushes.DarkGreen;
            canvas3.Children.Add(pl3);
            canvas3.Children.Add(path1);

            // Add polylines for displaying
            // velocity phase diagram:
            canvas4.Children.Clear();
            path2.Fill = Brushes.Red;
            pl4 = new Polyline();
            pl4.Stroke = Brushes.DarkGreen;

            canvas4.Children.Add(pl4);
            canvas4.Children.Add(path2);
            time = 0;
            xx = new double[4] { X01, X02, V01, V02 };
            CompositionTarget.Rendering += StartAnimation;

        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            SpringsInitialize();
            canvas2.Children.Clear();
            canvas3.Children.Clear();
            canvas4.Children.Clear();
            CompositionTarget.Rendering -= StartAnimation;

        }

        private void StartAnimation(object sender, EventArgs e)
        {
            // Calculate positions of m1 and m2:
            ODESolver.Function[] f =
            new ODESolver.Function[4] { f1, f2, f3, f4 };
            result = ODESolver.RungeKutta4(f, xx, time, dt);

            AnimatingSprings();
            DisplayPositions();
            PositionPhase();
            VelocityPhase();

            xx = result;
            time += dt;
            if (time > 0 && Math.Abs(result[0]) < 0.01 &&
            Math.Abs(result[1]) < 0.01 &&
            Math.Abs(result[2]) < 0.005 &&
            Math.Abs(result[2]) < 0.005)
            {
                CompositionTarget.Rendering -= StartAnimation;
            }
        }
        private void AnimatingSprings()
        {
            Point pt1 = new Point(XNormalize(canvas1,  xb1 + result[0], 0, 10), 45);
            Point pt2 = new Point(XNormalize(canvas1,  xb2 + result[1], 0, 10), 45);
            mass1.Center = pt1;
            mass2.Center = pt2;
            // Animate spring1:
            int n = spring1.Points.Count;
            double delta = (pt1.X - 70) / (n - 5);
            spring1.Points[2] = new Point(
                                            spring1.Points[1].X + 0.5 * delta,
                                            spring1.Points[2].Y);
            spring1.Points[n - 1] = new Point(pt1.X - 50, spring1.Points[n - 1].Y);
            spring1.Points[n - 2] = new Point(pt1.X - 55, spring1.Points[n - 2].Y);
            spring1.Points[n - 3] = new Point(spring1.Points[n - 2].X - 0.5 * delta, spring1.Points[n - 3].Y);

            for (int i = 3; i < n - 3; i++)
            {
                spring1.Points[i] = new Point( 10 + (i - 2) * delta,
                spring1.Points[i].Y);
            }

            // Animate spring2:
            Canvas.SetLeft(spring2, pt1.X + 20);
            delta = (pt2.X - pt1.X - 60) / (n - 5);
            spring2.Points[2] = new Point(
                                    spring2.Points[1].X + 0.5 * delta,
                                    spring2.Points[2].Y);
            for (int i = 3; i < n - 3; i++)
            {
                spring2.Points[i] = new Point(10 + (i - 2) * delta, spring2.Points[i].Y);
            }
            spring2.Points[n - 1] = new Point(pt2.X - pt1.X - 40, spring2.Points[n - 1].Y);
            spring2.Points[n - 2] = new Point(pt2.X - pt1.X - 45, spring2.Points[n - 2].Y);
            spring2.Points[n - 3] = new Point(spring2.Points[n - 2].X - 0.5 * delta,
                                              spring2.Points[n - 3].Y);

            // Animate spring3:
            spring3.Points[0] = new Point(XNormalize(canvas1, result[1], 0, 10),
                                                spring3.Points[0].Y);
            spring3.Points[1] = new Point(spring3.Points[0].X + 5, spring3.Points[1].Y);
            delta = (spring3.Points[n - 1].X - spring3.Points[0].X - 20) / (n - 5);
            spring3.Points[2] = new Point(spring3.Points[1].X + 0.5 * delta, spring3.Points[2].Y);
            spring3.Points[n - 3] = new Point(spring3.Points[n - 2].X - 0.5 * delta, spring3.Points[n - 3].Y);
            for (int i = 3; i < n - 3; i++)
            {
                spring3.Points[i] = new Point(spring3.Points[2].X + (i - 2) * delta, spring3.Points[i].Y);
            }
        }

        private void DisplayPositions()
        {
            // Shaw positions of m1 and m2:
            if (time < 30)
            {
                pl1.Points.Add(new Point(
                    XNormalize(canvas2, time, 0, 30),
                            YNormalize(canvas2,
                            result[0], 0, 6) - 70));
                pl2.Points.Add(new Point(
                    XNormalize(canvas2, time, 0, 30),
                    YNormalize(canvas2,
                    result[1], 0, 6) - 30));
            }
        }

        private void VelocityPhase()
        {
            if (time < 30)
            {
                pl4.Points.Add(new Point(
                XNormalize(canvas4, result[2], -8, 8),
                YNormalize(canvas4, result[3], -8, 8)));
                redDot2.Center = new Point(
                XNormalize(canvas4, result[2], -8, 8),
                YNormalize(canvas4, result[3], -8, 8));
            }
        }
        private void PositionPhase()
        {
            if (time < 30)
            {
                pl3.Points.Add(new Point(
                XNormalize(canvas3, result[0], -1, 1),
                YNormalize(canvas3, result[1], -1, 1)));
                redDot1.Center = new Point(
                XNormalize(canvas3, result[0], -1, 1),
                YNormalize(canvas3, result[1], -1, 1));
            }
        }

        private double f1(double[] xx, double t)
        {
            return xx[2];
        }
        private double f2(double[] xx, double t)
        {
            return xx[3];
        }
        private double f3(double[] xx, double t)
        {
            return -(K1 + K2) * xx[0] / M1 + K2 * xx[1] / M1 - (B1 + B2) * xx[2] / M1 + B2 * xx[3] / M1;
        }

        private double f4(double[] xx, double t)
        {
            return -(K2 + K3) * xx[1] / M2 + K2 * xx[0] / M2 - (B2 + B3) * xx[3] / M2 + B2 * xx[2] / M2;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            CompositionTarget.Rendering -= StartAnimation;
        }

        private double XNormalize(Canvas canvas, double x,
                    double min, double max)
        {
            double result = (x - min) *
            canvas.Width / (max - min);
            return result;
        }
        private double YNormalize(Canvas canvas, double y,
                                double min, double max)
        {
            double result = canvas.Height - (y - min) *
            canvas.Height / (max - min);
            return result;
        }
    }
}
