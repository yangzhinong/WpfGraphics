using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp7.Chapter08
{
    public class ChartStyleLineChartControl
    {
        private double Xmin;
        private double Xmax;
        private double Ymin;
        private double Ymax;
        private string Title;
        private string XLabel;
        private string YLabel;
        private double XTick;
        private double YTick;
        private bool IsXGrid;
        private bool IsYGrid;
        private Brush GridlineColor;
        private GridlinePatternEnum GridlinePattern;

        private double leftOffset = 20;
        private double bottomOffset = 15;
        private double rightOffset = 10;
        private Line gridline = new Line();
        private LineChartControl lcc;
        private Canvas TextCanvas;
        private Canvas ChartCanvas;

        public ChartStyleLineChartControl(LineChartControl lcc)
        {
            this.lcc = lcc;
            TextCanvas = lcc.textCanvas;
            ChartCanvas = lcc.chartCanvas;
            UpdateChartStyle();
        }
        public void UpdateChartStyle()
        {
            Xmin = lcc.Xmin;
            Xmax = lcc.Xmax;
            Ymin = lcc.Ymin;
            Ymax = lcc.Ymax;
            XTick = lcc.XTick;
            YTick = lcc.YTick;
            Title = lcc.Title;
            XLabel = lcc.XLabel;
            YLabel = lcc.YLabel;
            IsXGrid = lcc.IsXGrid;
            IsYGrid = lcc.IsYGrid;
            GridlineColor = lcc.GridlineColor;
            GridlinePattern = lcc.GridlinePattern;
        }

        public void AddChartStyle()
        {
            UpdateChartStyle();
            Point pt = new Point();
            Line tick = new Line();
            double offset = 0;
            double dx, dy;
            TextBlock tb = new TextBlock();
            // determine right offset:
            tb.Text = Xmax.ToString();
            tb.Measure(new Size(Double.PositiveInfinity,
            Double.PositiveInfinity));
            Size size = tb.DesiredSize;
            rightOffset = size.Width / 2 + 2;
            // Determine left offset:
            for (dy = Ymin; dy <= Ymax; dy += YTick)
            {
                pt = NormalizePoint(new Point(Xmin, dy));
                tb = new TextBlock();
                tb.Text = dy.ToString();
                tb.TextAlignment = TextAlignment.Right;
                tb.Measure(new Size(Double.PositiveInfinity,
                Double.PositiveInfinity));
                size = tb.DesiredSize;
                if (offset < size.Width)
                    offset = size.Width;
            }
            leftOffset = offset + 5;

            Canvas.SetLeft(ChartCanvas, leftOffset);
            Canvas.SetBottom(ChartCanvas, bottomOffset);
            ChartCanvas.Width = TextCanvas.Width - leftOffset - rightOffset;
            ChartCanvas.Height = TextCanvas.Height - bottomOffset - size.Height / 2;
            Rectangle chartRect = new Rectangle();
            chartRect.Stroke = Brushes.Black;
            chartRect.Width = ChartCanvas.Width;
            chartRect.Height = ChartCanvas.Height;
            ChartCanvas.Children.Add(chartRect);
            // Create vertical gridlines:
            if (IsYGrid == true)
            {
                for (dx = Xmin + XTick; dx < Xmax;dx += XTick)
                {
                    gridline = new Line();
                    AddLinePattern();
                    gridline.X1 = NormalizePoint(new Point(dx, Ymin)).X;
                    gridline.Y1 = NormalizePoint(new Point(dx, Ymin)).Y;
                    gridline.X2 = NormalizePoint(
                    new Point(dx, Ymax)).X;
                    gridline.Y2 = NormalizePoint(
                    new Point(dx, Ymax)).Y;
                    ChartCanvas.Children.Add(gridline);
                }
            }
            // Create horizontal gridlines:
            if (IsXGrid == true)
            {
                for (dy = Ymin + YTick; dy < Ymax;
                dy += YTick)
                {
                    gridline = new Line();
                    AddLinePattern();
                    gridline.X1 = NormalizePoint(
                    new Point(Xmin, dy)).X;
                    gridline.Y1 = NormalizePoint(
                    new Point(Xmin, dy)).Y;
                    gridline.X2 = NormalizePoint(
                    new Point(Xmax, dy)).X;
                    gridline.Y2 = NormalizePoint(
                    new Point(Xmax, dy)).Y;
                    ChartCanvas.Children.Add(gridline);
                }
            }

            // Create x-axis tick marks:
            for (dx = Xmin; dx <= Xmax; dx += XTick)
            {
                pt = NormalizePoint(new Point(dx, Ymin));
                tick = new Line();
                tick.Stroke = Brushes.Black;
                tick.X1 = pt.X;
                tick.Y1 = pt.Y;
                tick.X2 = pt.X;
                tick.Y2 = pt.Y - 5;
                ChartCanvas.Children.Add(tick);
                tb = new TextBlock();
                tb.Text = dx.ToString();
                tb.Measure(new Size(Double.PositiveInfinity,
                Double.PositiveInfinity));
                size = tb.DesiredSize;
                TextCanvas.Children.Add(tb);
                Canvas.SetLeft(tb, leftOffset + pt.X - size.Width / 2);
                Canvas.SetTop(tb, pt.Y + 2 + size.Height / 2);
            }

            // Create y-axis tick marks:
            for (dy = Ymin; dy <= Ymax; dy += YTick)
            {
                pt = NormalizePoint(new Point(Xmin, dy));
                tick = new Line();
                tick.Stroke = Brushes.Black;
                tick.X1 = pt.X;
                tick.Y1 = pt.Y;
                tick.X2 = pt.X + 5;
                tick.Y2 = pt.Y;
                ChartCanvas.Children.Add(tick);
                tb = new TextBlock();
                tb.Text = dy.ToString();
                tb.Measure(new Size(Double.PositiveInfinity,
                Double.PositiveInfinity));
                size = tb.DesiredSize;
                TextCanvas.Children.Add(tb);
                Canvas.SetRight(tb, ChartCanvas.Width + 10);
                Canvas.SetTop(tb, pt.Y);
            }



        }

        public void AddLinePattern()
        {
            gridline.Stroke = GridlineColor;
            gridline.StrokeThickness = 1;
            switch (GridlinePattern)
            {
                case GridlinePatternEnum.Dash:
                    gridline.StrokeDashArray =
                    new DoubleCollection(
                    new double[2] { 4, 3 });
                    break;
                case GridlinePatternEnum.Dot:
                    gridline.StrokeDashArray =
                    new DoubleCollection(
                    new double[2] { 1, 2 });
                    break;
                case GridlinePatternEnum.DashDot:
                    gridline.StrokeDashArray =
                    new DoubleCollection(
                    new double[4] { 4, 2, 1, 2 });
                    break;
            }
        }
        public Point NormalizePoint(Point pt)
        {
            if (ChartCanvas.Width.ToString() == "NaN")
                ChartCanvas.Width = 270;
            if (ChartCanvas.Height.ToString() == "NaN")
                ChartCanvas.Height = 250;
            Point result = new Point();
            result.X = (pt.X - Xmin) * ChartCanvas.Width / (Xmax - Xmin);
            result.Y = ChartCanvas.Height - (pt.Y - Ymin) *
            ChartCanvas.Height / (Ymax - Ymin);
            return result;
        }
        public enum GridlinePatternEnum
        {
            Solid = 1,
            Dash = 2,
            Dot = 3,
            DashDot = 4
        }
    }
}
