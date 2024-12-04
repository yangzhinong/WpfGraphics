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

namespace WpfApp7.Chapter08
{
    /// <summary>
    /// Interaction logic for LineChartControlExample.xaml
    /// </summary>
    public partial class LineChartControlExample : Window
    {
        private DataSeriesLineChartControl ds;
        public LineChartControlExample()
        {
            InitializeComponent();
            AddChart();
        }

        private void AddChart()
        {
            // Draw Sine curve:
            ds = new DataSeriesLineChartControl();
            ds.LineColor = Brushes.Blue;
            ds.LineThickness = 3;
            for (int i = 0; i < 70; i++)
            {
                double x = i / 5.0;
                double y = Math.Sin(x);
                ds.LineSeries.Points.Add(new Point(x, y));
            }
            myLineChart.ControlDataCollection.
            DataList.Add(ds);
            // Draw cosine curve:
            ds = new DataSeriesLineChartControl();
            ds.LineColor = Brushes.Red;
            ds.LinePattern = LinePatternEnum.DashDot;
            ds.LineThickness = 3;
            for (int i = 0; i < 70; i++)
            {
                double x = i / 5.0;
                double y = Math.Cos(x);
                ds.LineSeries.Points.Add(new Point(x, y));
            }
            myLineChart.ControlDataCollection.DataList.Add(ds);
            myLineChart.ControlDataCollection.AddLines();
        }
    }
}
