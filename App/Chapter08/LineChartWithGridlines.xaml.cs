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
    /// Interaction logic for LineChartWithGridlines.xaml
    /// </summary>
    public partial class LineChartWithGridlines : Window
    {
        private ChartStyleGridlines cs;
        private DataCollection dc = new DataCollection();
        private DataSeries ds = new DataSeries();

        public LineChartWithGridlines()
        {
            InitializeComponent();
            AddChart();
        }

        private void AddChart()
        {
            cs = new ChartStyleGridlines();
            cs.ChartCanvas = chartCanvas;
            cs.TextCanvas = textCanvas;
            cs.Title = "Sine and Cosine Chart";
            cs.Xmin = 0;
            cs.Xmax = 7;
            cs.Ymin = -1.5;
            cs.Ymax = 1.5;
            cs.YTick = 0.5;
            cs.GridlinePattern =GridlinePatternEnum.Dot;
            cs.GridlineColor = Brushes.Black;
            
            cs.AddChartStyle(tbTitle, tbXLabel, tbYLabel);

            // Draw Sine curve:
            ds.LineColor = Brushes.Blue;
            ds.LineThickness = 3;
            for (int i = 0; i < 70; i++)
            {
                double x = i / 5.0;
                double y = Math.Sin(x);
                ds.LineSeries.Points.Add(new Point(x, y));
            }
            dc.DataList.Add(ds);

            // Draw cosine curve:
            ds = new DataSeries();
            ds.LineColor = Brushes.Red;
            ds.LinePattern =LinePatternEnum.DashDot;
            ds.LineThickness = 3;
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
