using System.Drawing.Drawing2D;

namespace WinFormsLineChart;

public partial class Form1 : Form
{
    private DataCollection dc;
    private ChartStyle cs;
    private Legend lg;

    public Form1()
    {
        InitializeComponent();
        this.SetStyle(ControlStyles.ResizeRedraw, true);
        dc = new DataCollection();
        cs = new ChartStyle(this);
        lg = new Legend();
        lg.IsLegendVisible = true;

        cs.XLimMin = 0f;
        cs.XLimMax = 6f;
        cs.YLimMin = -1.1f;
        cs.YLimMax = 1.1f;

        cs.YTick = 0.2f;
        cs.YTickDisplayFormat = "{0:0.0}";
        
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        cs.ChartArea = this.ClientRectangle;
        AddData(g);
        SetPlotArea(g);
        cs.AddChartStyle(g);
        dc.AddLines(g, cs);
        lg.AddLegend(g, dc, cs);
        g.Dispose();
    }
    public void AddData(Graphics g)
    {
        // Override ChartStyle properties:
        cs.XLimMin = 0f;
        cs.XLimMax = 6f;
        cs.YLimMin = -1.5f;
        cs.YLimMax = 1.5f;
        cs.XTick = 1.0f;
        cs.YTick = 0.5f;
        cs.XLabel = "This is X axis";
        cs.YLabel = "This is Y axis";
        cs.Title = "Sine and Cosine Chart";

        dc.DataSeriesList.Clear();
        // Add Sine data with 7 data points:
        DataSeries ds1 = new DataSeries();

        ds1.LineStyle.LineColor = Color.Red;
        ds1.LineStyle.Thickness = 2f;
        ds1.LineStyle.Pattern = DashStyle.Dash;
        ds1.LineStyle.PlotMethod = LineStyle.PlotLinesMethodEnum.Splines;
        ds1.SeriesName = "Sine";
        ds1.SymbolStyle.SymbolType =  SymbolStyle.SymbolTypeEnum.Diamond;
        ds1.SymbolStyle.BorderColor = Color.Red;
        ds1.SymbolStyle.FillColor = Color.Yellow;
        ds1.SymbolStyle.BorderThickness = 1f;
        for (int i = 0; i < 7; i++)
        {
            ds1.AddPoint(new PointF(i / 1.0f,
            (float)Math.Sin(i / 1.0f)));
        }
        dc.Add(ds1);

        // Add Cosine data with 7 data points:
        DataSeries ds2 = new DataSeries();
        ds2.LineStyle.LineColor = Color.Blue;
        ds2.LineStyle.Thickness = 1f;
        ds2.LineStyle.Pattern = DashStyle.Solid;
        ds2.LineStyle.PlotMethod =
        LineStyle.PlotLinesMethodEnum.Splines;
        ds2.SeriesName = "Cosine";
        ds2.SymbolStyle.SymbolType =
        SymbolStyle.SymbolTypeEnum.Triangle;
        ds2.SymbolStyle.BorderColor = Color.Blue;
        for (int i = 0; i < 7; i++)
        {
            ds2.AddPoint(new PointF(i / 1.0f,
            (float)Math.Cos(i / 1.0f)));
        }
        dc.Add(ds2);

    }
    private void SetPlotArea(Graphics g)
    {
        // Set PlotArea:
        int xOffset = cs.ChartArea.Width / 10;
        int yOffset = cs.ChartArea.Height / 10;
        // Define the plot area:
        int plotX = cs.ChartArea.X + xOffset;
        int plotY = cs.ChartArea.Y + yOffset;
        int plotWidth = cs.ChartArea.Width - 2 * xOffset;
        int plotHeight = cs.ChartArea.Height - 2 * yOffset;
        cs.PlotArea = new Rectangle(plotX, plotY, plotWidth, plotHeight);
    }
}
