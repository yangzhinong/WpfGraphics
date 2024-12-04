using System;
using System.Windows;
using System.Windows.Media;

namespace WpfApp7.Chapter08
{
    /// <summary>
    /// Interaction logic for LineChartWithLegend.xaml
    /// </summary>
    public partial class LineChartWithLegend : Window
    {
        private ChartStyleGridlines cs;
        private Legend lg = new Legend();
        private DataCollection dc = new DataCollection();
        private DataSeries ds = new DataSeries();
        public LineChartWithLegend()
        {
            InitializeComponent();
            AddChart();
            lg.LegendCanvas = legendCanvas;
            lg.IsLegend = true;
            lg.IsBorder = true;
            lg.AddLegend(cs, dc);
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
            cs.GridlinePattern = GridlinePatternEnum.Dot;
            cs.GridlineColor = Brushes.Black;
            cs.AddChartStyle(tbTitle, tbXLabel, tbYLabel);

            // Draw Sine curve:
            ds.LineColor = Brushes.Blue;
            ds.LineThickness = 1;
            ds.SeriesName = "Sine";
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
            ds.SeriesName = "Cosine";
            ds.LinePattern = LinePatternEnum.DashDot;
            ds.LineThickness = 2;
            for (int i = 0; i < 70; i++)
            {
                double x = i / 5.0;
                double y = Math.Cos(x);
                ds.LineSeries.Points.Add(new Point(x, y));
            }
            dc.DataList.Add(ds);
            //Draw sine^2 curve:
            ds = new DataSeries();
            ds.LineColor = Brushes.DarkGreen;
            ds.SeriesName = "Sine^2";
            ds.LinePattern = LinePatternEnum.Dot;
            ds.LineThickness = 2;
            for (int i = 0; i < 70; i++)
            {
                double x = i / 5.0;
                double y = Math.Sin(x) * Math.Sin(x);
                ds.LineSeries.Points.Add(new Point(x, y));
            }
            dc.DataList.Add(ds);
            dc.AddLines(chartCanvas, cs);
        }
    }
}
