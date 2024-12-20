using System.Drawing.Drawing2D;

namespace WinFormsLineChart;

public partial class Form1 : Form
{
    private DataCollection dc;
    private ChartStyle cs;

    public Form1()
    {
        InitializeComponent();
        this.SetStyle(ControlStyles.ResizeRedraw, true);
        dc = new DataCollection();
        cs = new ChartStyle(this);
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
        AddData();
        SetPlotArea(g);
        cs.AddChartStyle(g);
        dc.AddLines(g, cs);
        g.Dispose();
    }
    public void AddData()
    {
        dc.DataSeriesList.Clear();
        // Add Sine data with 20 data points:
        DataSeries ds1 = new();
        ds1.LineStyle.LineColor = Color.Red;
        ds1.LineStyle.Thickness = 2f;
        ds1.LineStyle.Pattern = DashStyle.Dash;
        for (int i = 0; i < 20; i++)
        {
            ds1.AddPoint(new PointF(i / 5.0f, (float)Math.Sin(i / 5.0f)));
        }
        dc.Add(ds1);
        // Add Cosine data with 40 data points:
        DataSeries ds2 = new();
        ds2.LineStyle.LineColor = Color.Blue;
        ds2.LineStyle.Thickness = 1f;
        ds2.LineStyle.Pattern = DashStyle.Solid;
        for (int i = 0; i < 40; i++)
        {
            ds2.AddPoint(new PointF(i / 5.0f,(float)Math.Cos(i / 5.0f)));
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
