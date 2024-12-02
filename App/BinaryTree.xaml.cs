using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp7
{
    /// <summary>
    /// Interaction logic for BinaryTree.xaml
    /// </summary>
    public partial class BinaryTree : Window
    {
        private int II = 0;
        private int i = 0;
        private double lengthScale = 0.75;
        private double deltaTheta = Math.PI / 5;

        public BinaryTree()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            canvas1.Children.Clear();
            tbLabel.Text = "";
            i = 0;
            II = 1;
            CompositionTarget.Rendering += StartAnimation;
        }

        private void StartAnimation(object sender, EventArgs e)
        {
            i += 1;
            if (i % 60 == 0)
            {
                DrawBinaryTree(canvas1, II,
                                new Point(canvas1.Width / 2, 0.83 * canvas1.Height),
                                0.2 * canvas1.Width, -Math.PI / 2);

                string str = "Binary Tree - Depth = " + II.ToString();
                tbLabel.Text = str;
                II += 1;
                if (II > 10)
                {
                    tbLabel.Text = "Binary Tree - Depth = 10.    Finished";
                    CompositionTarget.Rendering -= StartAnimation;
                }
            }
        }

        private void DrawBinaryTree(Canvas canvas, int depth, Point pt, double length, double theta)
        {
            double x1 = pt.X + length * Math.Cos(theta);
            double y1 = pt.Y + length * Math.Sin(theta);
            Line line = new Line();
            line.Stroke = Brushes.Blue;
            line.X1 = pt.X;
            line.Y1 = pt.Y;
            line.X2 = x1;
            line.Y2 = y1;
            canvas.Children.Add(line);

            if (depth > 1)
            {
                DrawBinaryTree(canvas, depth - 1,new Point(x1, y1), length * lengthScale, theta + deltaTheta);
                DrawBinaryTree(canvas, depth - 1,new Point(x1, y1), length * lengthScale, theta - deltaTheta);
            }
            else
                return;
        }
    }
}
