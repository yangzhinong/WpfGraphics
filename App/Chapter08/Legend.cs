using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp7.Chapter08
{
    public class Legend
    {
        public bool IsLegend { get; set; }
        public bool IsBorder { get;set; }
        public Canvas LegendCanvas { get; set; }

        public Legend()
        {
            IsLegend = false;
            IsBorder = true;
        }

        public void AddLegend(ChartStyleGridlines cs,DataCollection dc)
        {
            TextBlock tb = new TextBlock();
            if (dc.DataList.Count < 1 || !IsLegend)
                return;
            int n = 0;
            string[] legendLabels = new string[dc.DataList.Count];
            foreach (DataSeries ds in dc.DataList)
            {
                legendLabels[n] = ds.SeriesName;
                n++;
            }
            double legendWidth = 0;
            Size size = new Size(0, 0);
            for (int i = 0; i < legendLabels.Length; i++)
            {
                tb = new TextBlock();
                tb.Text = legendLabels[i];
                tb.Measure(new Size(Double.PositiveInfinity,Double.PositiveInfinity));
                size = tb.DesiredSize;
                if (legendWidth < size.Width)
                    legendWidth = size.Width;
            }
            legendWidth += 50;
            LegendCanvas.Width = legendWidth + 5;
            double legendHeight = 17 * dc.DataList.Count;
            double sx = 6;
            double sy = 2;
            double textHeight = size.Height;
            double lineLength = 34;
            Rectangle legendRect = new Rectangle();
            legendRect.SnapsToDevicePixels = true;
            legendRect.Stroke = Brushes.Black;
            legendRect.Width = legendWidth;
            legendRect.Height = legendHeight;

            if (IsLegend && IsBorder)
                LegendCanvas.Children.Add(legendRect);
            n = 1;
            foreach (DataSeries ds in dc.DataList)
            {
                double xSymbol = sx + lineLength / 2;
                double xText = 2 * sx + lineLength;
                double yText = n * sy + (2 * n - 1) * textHeight / 2;
                Line line = new Line();
                AddLinePattern(line, ds);
                line.X1 = sx;
                line.Y1 = yText;
                line.X2 = sx + lineLength;
                line.Y2 = yText;
                LegendCanvas.Children.Add(line);
                tb = new TextBlock();
                tb.Text = ds.SeriesName;
                LegendCanvas.Children.Add(tb);
                Canvas.SetTop(tb, yText - size.Height / 2);
                Canvas.SetLeft(tb, xText);
                n++;
            }

        }
        private void AddLinePattern(Line line, DataSeries ds)
        {
            line.Stroke = ds.LineColor;
            line.StrokeThickness = ds.LineThickness;
            switch (ds.LinePattern)
            {
                case LinePatternEnum.Dash:
                    line.StrokeDashArray =
                    new DoubleCollection(
                    new double[2] { 4, 3 });
                    break;
                case LinePatternEnum.Dot:
                    line.StrokeDashArray =
                    new DoubleCollection(
                    new double[2] { 1, 2 });
                    break;
                case LinePatternEnum.DashDot:
                    line.StrokeDashArray =
                    new DoubleCollection(
                    new double[4] { 4, 2, 1, 2 });
                    break;
                case LinePatternEnum.None:
                    line.Stroke = Brushes.Transparent;
                    break;
            }
        }
    }
}
