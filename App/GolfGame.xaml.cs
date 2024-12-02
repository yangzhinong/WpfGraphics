using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp7
{
    /// <summary>
    /// Interaction logic for GolfGame.xaml
    /// </summary>
    public partial class GolfGame : Window
    {
        double xMin = 0;
        double yMin = 0;
        double xMax = 100;
        double yMax = 100;

        double X0 = 20;
        double Y0 = 20;
        double V0x = 10;
        double V0y = 10;
        double BallMass = 0.05;
        double BallArea = 0.0014;
        double DragCoefficient = 0.25;
        double AirDensity = 1.2;
        double DistanceToHole = 100;

        double[] xx = new double[4];

        double time = 0;
        double dt = 0.1;
        double gravity = 9.81;
        double ym = 0;
        Polyline pl = new Polyline();

        public GolfGame()
        {
            InitializeComponent();
            pl.Stroke = Brushes.Blue;
            canvas1.Children.Add(pl);
            GolfGameInitialize();
        }

        private void GolfGameInitialize()
        {
            tbV0x.Text = "20";
            tbV0y.Text = "40";
            tbDistance.Text = "100";
            tbMass.Text = "0.05";
            tbArea.Text = "0.0014";
            tbDrag.Text = "0.25";
            tbDensity.Text = "1.2";

            tbXMax.Text = "X distance of this par:";
            tbYMax.Text = "Highest Y of this par:";
            tbResult.Text = "Let's start playing...";
            xMin = X0 - 0.1 * DistanceToHole;
            yMin = X0 - 0.2 * DistanceToHole;
            xMax = X0 + 1.1 * DistanceToHole;
            yMax = X0 + 0.7 * DistanceToHole;
            Canvas.SetLeft(golfBall, XNormalize(X0));
            Canvas.SetTop(golfBall, YNormalize(Y0));
            Canvas.SetLeft(golfHole, XNormalize(X0 + DistanceToHole) - 10);

            Canvas.SetTop(golfHole, YNormalize(Y0) - 2);
            Canvas.SetLeft(golfFlag, XNormalize(X0 + DistanceToHole) - 2);
            Canvas.SetTop(golfFlag, YNormalize(Y0) + 4);
        }

        private double YNormalize(double y)
        {
            return Utility.YNormalize(canvas1, y, yMin, yMax);
        }

        private double XNormalize(double x)
        {
            return Utility.XNormalize(canvas1, x, xMin, xMax);
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            time = 0;
            dt = 0.1;

            // Add trace curve:
            if (canvas1.Children.Count > 3)
                canvas1.Children.Remove(pl);
            pl = new Polyline();
            pl.Stroke = Brushes.LightCoral;
            canvas1.Children.Add(pl);


            // Get input parameters:
            V0x = Double.Parse(tbV0x.Text);
            V0y = Double.Parse(tbV0y.Text);
            DistanceToHole = Double.Parse(tbDistance.Text);
            BallMass = Double.Parse(tbMass.Text);
            BallArea = Double.Parse(tbArea.Text);
            DragCoefficient = Double.Parse(tbDrag.Text);
            AirDensity = Double.Parse(tbDensity.Text);

            // Set the axis limits:
            xMin = X0 - 0.1 * DistanceToHole;
            yMin = X0 - 0.2 * DistanceToHole;
            xMax = X0 + 1.1 * DistanceToHole;
            yMax = X0 + 0.7 * DistanceToHole;

            // Set the golf court:
            Canvas.SetLeft(golfHole,
            XNormalize(X0 + DistanceToHole) - 10);
            Canvas.SetTop(golfHole, YNormalize(Y0) - 2);
            Canvas.SetLeft(golfFlag, XNormalize(X0 + DistanceToHole) - 2);
            Canvas.SetTop(golfFlag, YNormalize(Y0) + 4);
            tbXMax.Text = "X distance of this par:";
            tbYMax.Text = "Highest Y of this par:";
            tbResult.Text = "Let's start playing...";

            xx = new double[4] { X0, Y0, V0x, V0y };
            CompositionTarget.Rendering += StartAnimation;


        }

        private void StartAnimation(object sender, EventArgs e)
        {
            ODESolver.Function[] f = new ODESolver.Function[4] { f1, f2, f3, f4 };
            double[] result = ODESolver.RungeKutta4(f, xx, time, dt);

            xx = result;
            double x = result[0];
            double y = result[1];

            if (y > ym)
                ym = y;

            if (y >= Y0)
            {
                Canvas.SetLeft(golfBall, XNormalize(x));
                Canvas.SetTop(golfBall, YNormalize(y));
                pl.Points.Add(new Point(XNormalize(x) + 5, YNormalize(y) + 5));
            }
            if (x > X0 && y <= Y0)
            {
                double xm = Math.Round(x - X0);
                ym = Math.Round(ym - Y0);
                tbXMax.Text = "X distance of this par: " + xm.ToString() + " m";
                tbYMax.Text = "Highest Y of this par: " + ym.ToString() + " m";
                if (xm > DistanceToHole - 10 && xm < DistanceToHole + 10)
                    tbResult.Text = "Congratulations! You win.";
                else
                    tbResult.Text = "You missed. Try again.";
                CompositionTarget.Rendering -= StartAnimation;
            }
            time += dt;
        }
        private double f1(double[] xx, double t)
        {
            return xx[2]; //速度关于时间在X轴的函数值
        }

        private double f2(double[] xx, double t)
        {
            return xx[3]; //速度关于时间在Y轴的函数值
        }

        private double f3(double[] xx, double t)
        {
            double A = BallArea;
            double rho = AirDensity;
            double cd = DragCoefficient;
            double m = BallMass;
            double fd = 0.5 * rho * A * cd * (xx[2] * xx[2] + xx[3] * xx[3]);
            return -fd * xx[2] / m / Math.Sqrt(xx[2] * xx[2] + xx[3] * xx[3] + 1.0e-10); //加速度x方向关于速度与时间的微分方程
        }

        private double f4(double[] xx, double t)
        {
            double A = BallArea;
            double rho = AirDensity;
            double cd = DragCoefficient;
            double m = BallMass;
            double fd = 0.5 * rho * A * cd * (xx[2] * xx[2] + xx[3] * xx[3]);
            return -gravity - fd * xx[3] / m / Math.Sqrt(xx[2] * xx[2] + xx[3] * xx[3] + 1.0e-10); //加速度y方向关于速度与时间的微分方程
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            GolfGameInitialize();
            if (canvas1.Children.Count > 3)
                canvas1.Children.Remove(pl);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
