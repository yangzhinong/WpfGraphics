using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp7.Chapter08
{
    public class DataSeriesLineChartControl
    {
        public DataSeriesLineChartControl()
        {
            LineColor = Brushes.Black;
            LineSeries = new Polyline();
            LineThickness = 1;
            SeriesName = "Default Name";
        }

        public Brush LineColor { get; set; }
        public Polyline LineSeries { get; set; }
        public double LineThickness { get; set; }

        public LinePatternEnum LinePattern { get; set; }
        public string SeriesName { get; set; }

        public void AddLinePattern()
        {
            LineSeries.Stroke = LineColor;
            LineSeries.StrokeThickness = LineThickness;
            switch (LinePattern)
            {
                case LinePatternEnum.Dash:
                    LineSeries.StrokeDashArray = new DoubleCollection() { 4, 3 };
                    break;
                case LinePatternEnum.Dot:
                    LineSeries.StrokeDashArray = new DoubleCollection() { 1, 2 };
                    break;
                case LinePatternEnum.DashDot:
                    LineSeries.StrokeDashArray = new DoubleCollection() { 4, 2, 1, 2 };
                    break;
                case LinePatternEnum.None:
                    LineSeries.Stroke = Brushes.Transparent;
                    break;

            }
        }
    }
}