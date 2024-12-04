using System.Collections.Generic;

namespace WpfApp7.Chapter08
{
    public class DataCollectionLineChartControl
    {
        private List<DataSeriesLineChartControl> dataList;
        private LineChartControl lcc;
        private ChartStyleLineChartControl cs;
        public DataCollectionLineChartControl(
        LineChartControl lcc)
        {
            dataList = new List<DataSeriesLineChartControl>();
            this.lcc = lcc;
            this.cs = lcc.ControlChartStyle;
        }
        public List<DataSeriesLineChartControl> DataList
        {
            get { return dataList; }
            set { dataList = value; }
        }

        public void AddLines()
        {
            lcc.ControlChartStyle.AddChartStyle();
            int j = 0;
            foreach (DataSeriesLineChartControl ds
            in DataList)
            {
                if (ds.SeriesName == "Default Name")
                {
                    ds.SeriesName = "DataSeries" +
                    j.ToString();
                }
                ds.AddLinePattern();
                for (int i = 0; i <
                ds.LineSeries.Points.Count; i++)
                {
                    ds.LineSeries.Points[i] =
                    cs.NormalizePoint(
                    ds.LineSeries.Points[i]);
                }
                lcc.chartCanvas.Children.Add(ds.LineSeries);
                j++;
            }
        }
    }
}