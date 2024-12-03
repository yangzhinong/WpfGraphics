using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp7.Chapter08
{
    /// <summary>
    /// 定义数据集（多条折线图）
    /// </summary>
    public class DataCollection
    {
        private List<DataSeries> dataList;
        public DataCollection()
        {
            dataList = new List<DataSeries>();
        }

        public List<DataSeries> DataList { get => dataList; set => dataList = value; }

        /// <summary>
        /// 关联 数据集 和 画布，图表样式
        /// </summary>
        /// <param name="canvas">画布</param>
        /// <param name="cs">图表样式</param>
        public void AddLines(Canvas canvas, ChartStyle cs)
        {
            int j = 0;
            foreach(DataSeries ds in dataList)
            {
                if (ds.SeriesName == "Default Name")
                {
                    ds.SeriesName = "DataSeries" + j.ToString();
                }
                ds.AddLinePattern();
                for(int i = 0; i< ds.LineSeries.Points.Count; i++)
                {
                    ds.LineSeries.Points[i] = cs.NormalizePoint(ds.LineSeries.Points[i]);
                }
                canvas.Children.Add(ds.LineSeries);
                j++;
            }
        }
    }

    public enum LinePatternEnum
    {
        Solid = 1,
        Dash =2,
        Dot =3,
        DashDot=4,
        None=5
    }

    /// <summary>
    /// 定义数据点集，颜色，线宽，线型
    /// </summary>
    public class DataSeries
    {
        public DataSeries()
        {
            LineColor = Brushes.Black;
            LineSeries= new Polyline();
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
                    LineSeries.StrokeDashArray = new DoubleCollection() { 4, 2,1,2 };
                    break;
                case LinePatternEnum.None:
                    LineSeries.Stroke = Brushes.Transparent;
                    break;

            }
        }
    }
}
