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
    /// Interaction logic for Pendulum.xaml
    /// </summary>
    public partial class Pendulum : Window
    {
        private double PendulumMass = 1;
        private double PendulumLength = 1;
        private double DampingCoefficient = 0.5;
        private double Theta0 = 45;
        private double Alpha0 = 0;

        double[] xx = new double[2];

        double time = 0;
        double dt = 0.03;
        Polyline p1 = new Polyline();

        double xMin = 0;
        double yMin = -100;
        double xMax = 50;
        double yMax = 100;

        public Pendulum()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            PendulumMass = double.Parse(tbMass.Text);
            PendulumLength = double.Parse(tbLength.Text);
            DampingCoefficient = double.Parse(tbDamping.Text);

            Theta0 = double.Parse(tbTheta0.Text);
            Theta0 = Math.PI * Theta0 / 180;
            Alpha0 = double.Parse(tbAlpha0.Text);
            Alpha0 = Math.PI * Alpha0 / 180;

            if (canvasRight.Children.Count > 4)
                canvasRight.Children.Remove(p1);

            p1= new Polyline();
            p1.Stroke = Brushes.Red;
            canvasRight.Children.Add(p1);

            time = 0;
            xx = new double[2] { Theta0, Alpha0 };
            CompositionTarget.Rendering += StartAnimation;

        }

        private void StartAnimation(object sender, EventArgs e)
        {
            Move1();
            //Move2();
        }
        private void Move1()
        {
            ODESolver.Function[] f = new ODESolver.Function[2] { f1, f2 };

            double[] result = ODESolver.RungeKutta4(f, xx, time, dt);

            Point pt = new Point(140 + 130 * Math.Sin(result[0]),
                20 + 130 * Math.Cos(result[0]));
            ball.Center = pt;
            line1.X2 = pt.X;
            line1.Y2 = pt.Y;

            if (time < xMax)
                p1.Points.Add(new Point(XNormalize(time) + 10,
                    YNormalize(180 * result[0] / Math.PI)));

            xx = result;
            time += dt;

            if (time > 0 && Math.Abs(result[0]) < 0.01 && Math.Abs(result[1]) < 0.001)
            {
                tbDisplay.Text = "Stopped";
                CompositionTarget.Rendering -= StartAnimation;
            }
        }
        private double[] yy = new double[1];
        private void Move2()
        {
            ODESolver.Function[] f = new ODESolver.Function[] {  f11,f12 };

            double[] result = ODESolver.RungeKutta4(f, xx, time, dt);

            Point pt = new Point(10, 20 + result[0]);
            b.Center = pt;
           
        

            xx = result;
            time += dt;

            //if (time > 0 && Math.Abs(result[0]) < 0.01 && Math.Abs(result[1]) < 0.001)
            //{
            //    tbDisplay.Text = "Stopped";
            //    CompositionTarget.Rendering -= StartAnimation;
            //}
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            line1.X2 = 140;
            line1.Y2 = 150;
            ball.Center = new Point(140, 150);
            tbDisplay.Text = "Stopped";
            CompositionTarget.Rendering -= StartAnimation;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            PendulumInitialize();

        }

        private void PendulumInitialize()
        {
            tbMass.Text = "1";
            tbLength.Text = "1";
            tbDamping.Text = "0.1";
            tbTheta0.Text = "45";
            tbAlpha0.Text = "0";
            line1.X2 = 140;
            line1.Y2 = 150;
            ball.Center = new Point(140, 150);
        }

        private double f11(double[] xx, double t)
        {
            return xx[1];
        }

        private double f12(double[] xx, double t)
        {
            double m = PendulumMass;
            double L = PendulumLength;
            double g = 9.81;
            double b = DampingCoefficient;
            return g;
        }

        private double f1(double[] xx, double t)
        {
            return xx[1];
        }
        private double f2(double[] xx, double t)
        {
            double m = PendulumMass;
            double L = PendulumLength;
            double g = 9.81;
            double b = DampingCoefficient;
            return -g * Math.Sin(xx[0]) / L - b * xx[1] / m;
        }

        private double XNormalize(double x)
        {
            double result = (x - xMin) *
            canvasRight.Width / (xMax - xMin);
            return result;
        }
        private double YNormalize(double y)
        {
            double result = canvasRight.Height - (y - yMin) *
            canvasRight.Height / (yMax - yMin);
            return result;
        }
    }
}
