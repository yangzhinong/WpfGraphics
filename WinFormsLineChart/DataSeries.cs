using System.Collections;

namespace WinFormsLineChart;
public class DataSeries
{
    private ArrayList pointList;
    private LineStyle lineStyle;
    private string seriesName = "Default Name";
    public DataSeries()
    {
        lineStyle = new LineStyle();
        pointList = new ArrayList();
        SymbolStyle= new SymbolStyle();
    }
    public LineStyle LineStyle
    {
        get { return lineStyle; }
        set { lineStyle = value; }
    }
    public string SeriesName
    {
        get { return seriesName; }
        set { seriesName = value; }
    }
    public ArrayList PointList
    {
        get { return pointList; }
        set { pointList = value; }
    }

    public SymbolStyle SymbolStyle { get; set; }

    public void AddPoint(PointF pt)
    {
        pointList.Add(pt);
    }

}
