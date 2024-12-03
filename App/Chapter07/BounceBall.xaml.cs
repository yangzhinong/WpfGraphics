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
    /// Interaction logic for BounceBall.xaml
    /// </summary>
    public partial class BounceBall : Window
    {
        private double Mass;
        private double Radius;
        private double CORx;
        private double CORy;
        private double Gravity;
        private double X0;
        private double Y0;
        private double V0x;
        private double V0y;
        private double W0;

        double time = 0;
        double dt = 0.05;
        double x = 0;
        double y = 0;
        double vx = 0;
        double vy = 0;
        double w = 0;
        double theta0 = 0;
        double theta = 0;
        double max = 100;
        public BounceBall()
        {
            InitializeComponent();
            BallInitialize();
        }

        private void BallInitialize()
        {
            tbM.Text = "2";
            tbR.Text = "5";
            tbCORx.Text = "0.8";
            tbCORy.Text = "0.8";
            tbG.Text = "9.81";
            tbX0.Text = "5";
            tbY0.Text = "5";
            tbV0x.Text = "50";
            tbV0y.Text = "50";
            tbW0.Text = "0";
            Canvas.SetLeft(ball, 0);
            Canvas.SetBottom(ball, 0);
            ball.Width = Utility.XNormalize( canvas1, 10, 0, max);
            ball.Height = canvas1.Height - Utility.YNormalize(canvas1, 10, 0, max);
        }

        private void SetInputParameters()
        {
            Mass = Double.Parse(tbM.Text);
            Radius = Double.Parse(tbR.Text);
            CORx = Double.Parse(tbCORx.Text);
            CORy = Double.Parse(tbCORy.Text);
            Gravity = Double.Parse(tbG.Text);
            X0 = Double.Parse(tbX0.Text);
            if (X0 < Radius)
                X0 = Radius;
            Y0 = Double.Parse(tbY0.Text);
            if (Y0 < Radius)
                Y0 = Radius;
            V0x = Double.Parse(tbV0x.Text);
            V0y = Double.Parse(tbV0y.Text);
            W0 = Double.Parse(tbW0.Text);
            ball.Width = Utility.XNormalize(
            canvas1, 2 * Radius, 0, max);
            ball.Height = canvas1.Height - Utility.YNormalize(canvas1, 2 * Radius, 0, max);
            Canvas.SetBottom(ball, 0);
            Canvas.SetLeft(ball, 0);
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            SetInputParameters();
            x = 0;
            y = 0;
            vx = 0;
            vy = 0;
            theta0 = 0;
            theta = 0;
            time = 0;
            CompositionTarget.Rendering += StartAnimation;
        }

        private void StartAnimation(object sender, EventArgs e)
        {
            // Calculate positions and velocities of the ball
            // for the case without collision:
            x = X0 + V0x * dt;
            y = Y0 + V0y * dt - 0.5 * Gravity * dt * dt;
            theta = theta0 + 180 * W0 * dt / Math.PI;
            vx = V0x;
            if (Y0 > Radius)
            {
                vy = V0y - Gravity * dt;
            }
            else
            {
                vy = V0y;
            }
            w = W0;
            // Reset the ball's position:
            Canvas.SetLeft(ball, Utility.XNormalize(
            canvas1, X0 - Radius, 0, max));
            Canvas.SetBottom(ball, canvas1.Height-Utility.YNormalize(canvas1,
            Y0 - Radius, 0, max));
            ballRotate.Angle = theta0;
            // Determine if the ball hits left or right wall:
            if ((V0x < 0 && X0 <= Radius) || (V0x > 0 && X0 >= max - Radius))
            {
                vx = -CORy * V0x;
                vy = ((1 - 2 * CORx / 5) * V0y + (2 / 5) * (1 + CORx) * Radius * W0) / (1 + 2 / 5);
                w = ((1 + CORx) * V0y + (2 / 5 - CORx) * Radius * W0) / Radius / (1 + 2 / 5);
            }
            // Determine if the ball hits the top or
            // bottom wall:
            if ((V0y < 0 && Y0 <= Radius) || (V0y > 0 &&Y0 >= max - Radius))
            {
                vy = -CORy * V0y;
                vx = ((1 - 2 * CORx / 5) * V0x + (2 / 5) *(1 + CORx) * Radius * W0) / (1 + 2 / 5);
                w = ((1 + CORx) * V0x + (2 / 5 - CORx) * Radius * W0) / Radius / (1 + 2 / 5);
            }
            // Reset the initial condition for next round
            // simulation:
            X0 = x;
            Y0 = y;
            theta0 = theta;
            V0x = vx;
            V0y = vy;
            W0 = w;
            time += dt;
            // Make sure to keep the ball inside the box:
            if (time > 0 && Y0 < Radius)
                Canvas.SetBottom(ball, 0);
            // Condition for stoping simulation:
            if (time > 100)
            {
                CompositionTarget.Rendering -= StartAnimation;
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            CompositionTarget.Rendering -= StartAnimation;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            BallInitialize();
            CompositionTarget.Rendering -= StartAnimation;
        }
    }
}
