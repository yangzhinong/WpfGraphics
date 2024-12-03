using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp7.Chapter08
{
    /// <summary>
    /// Interaction logic for SimpleLineChart.xaml
    /// </summary>
    public partial class SimpleLineChart : Window
    {
        private double xmin = 0;
        private double xmax = Math.PI*2;
        private double ymin = -1.1;
        private double ymax = 1.1;
        private Polyline pl;
        public SimpleLineChart()
        {
            InitializeComponent();
            AddChart();
        }

        private void AddChart()
        {
            pl = new Polyline();
            pl.Stroke = Brushes.Black;
            for (int i = 0; i < 70; i++)
            {
                double x = i / 5.0d;
                double y = Math.Sin(x);
                pl.Points.Add(NormalizePoint(new Point(x, y)));
            }
            chartCanvas.Children.Add(pl);

            // Draw cosing curve;
            pl = new Polyline();
            pl.Stroke= Brushes.Black;
            pl.StrokeDashArray = new DoubleCollection() { 4, 3 };
            for (int i = 0; i < 70; i++)
            {
                double x = i / 5.0d;
                double y = Math.Cos(x);
                pl.Points.Add(NormalizePoint(new Point(x, y)));
            }
            chartCanvas.Children.Add(pl);
        }

        private Point NormalizePoint(Point pt)
        {
            Point result = new Point
            {
                X = (pt.X - xmin) * chartCanvas.Width / (xmax - xmin),
                Y = chartCanvas.Height - (pt.Y - ymin) * chartCanvas.Height / (ymax - ymin)
            };
            return result;
        }
    }
}
