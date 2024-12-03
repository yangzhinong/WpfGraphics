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
    /// Interaction logic for LineChartExample.xaml
    /// </summary>
    public partial class LineChartExample : Window
    {
        private ChartStyle cs;
        private DataCollection dc = new DataCollection();
        private DataSeries ds = new DataSeries();
        public LineChartExample()
        {
            InitializeComponent();
            AddChart();
        }

        private void AddChart()
        {
            cs = new ChartStyle(chartCanvas);
            cs.Xmin = 0;
            cs.Xmax = 7;
            cs.Ymin = -1.1;
            cs.Ymax = 1.1;

            ds = new DataSeries();
            ds.LineColor = Brushes.Blue;
            ds.LineThickness = 3;
            for (int i=0; i<70; i++)
            {
                double x = i / 5.0d;
                double y = Math.Sin(x);
                ds.LineSeries.Points.Add(new Point(x, y));
            }
            dc.DataList.Add(ds);
            ds = new DataSeries();
            ds.LineColor = Brushes.Red;
            ds.LinePattern = LinePatternEnum.DashDot;
            ds.LineThickness = 1;
            for (int i = 0; i < 70; i++)
            {
                double x = i / 5.0;
                double y = Math.Cos(x);
                ds.LineSeries.Points.Add(new Point(x, y));
            }
            dc.DataList.Add(ds);

            dc.AddLines(chartCanvas, cs);
            

        }
    }
}
