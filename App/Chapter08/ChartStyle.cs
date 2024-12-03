using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp7.Chapter08
{
    /// <summary>
    /// 图表样式（X轴范围，Y轴范围，画布）
    /// </summary>
    public class ChartStyle
    {
        private double xmin = 0;
        private double xmax = 1;
        private double ymin = 0;
        private double ymax = 1;

        private Canvas chartCanvas;

        public Canvas ChartCanvas { get => chartCanvas; set => chartCanvas = value; }
        public double Xmin { get=> xmin; set => xmin = value; }
        public double Xmax { get=> xmax; set => xmax = value; }
        public double Ymin { get => ymin; set => ymin = value; }
        public double Ymax { get => ymax; set => ymax = value; }

        public ChartStyle()
        {
            
        }
        public ChartStyle(Canvas chartCanvas)
        {
            this.chartCanvas = chartCanvas;
        }
        /// <summary>
        /// 画布长宽改变
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void ResizeCanvas(double width, double height)
        {
            ChartCanvas.Width = width;
            ChartCanvas.Height = height;
        }

        /// <summary>
        /// 映身数据点到画布设备点
        /// </summary>
        /// <param name="pt">数据点</param>
        /// <returns>返回设备点</returns>
        public Point NormalizePoint(Point pt)
        {
            if (ChartCanvas.Width.ToString() == "NaN")
                ChartCanvas.Width = 270;
            if (ChartCanvas.Height.ToString() == "NaN")
                ChartCanvas.Height = 250;
            Point result = new Point();
            result.X = (pt.X - Xmin) * ChartCanvas.Width / (Xmax - Xmin);
            result.Y = chartCanvas.Height - (pt.Y - Ymin) * ChartCanvas.Height / (Ymax - Ymin);
            return result;
        }
    }
}
