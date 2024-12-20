namespace WinFormsLineChart;

public partial class Form1bak : Form
{
    // Define the drawing area
    private Rectangle PlotArea;
    // Unit defined in world coordinate system:
    private float xMin = 0f;
    private float xMax = 6;
    private float yMin = -1.1f;
    private float yMax = 1.1f;
    private int nPoints = 61;
    // Unit in pixel:
    private int offset = 30;

    public Form1bak()
    {
        InitializeComponent();
        this.BackColor = Color.White;
        this.SetStyle(ControlStyles.ResizeRedraw, true);

    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g= e.Graphics;

        Rectangle ChartArea = ClientRectangle;
        PlotArea = new Rectangle(ChartArea.Location, ChartArea.Size);

        PlotArea.Inflate(-offset, -offset);

        g.DrawRectangle(Pens.Black, PlotArea);


        PointF[] pt1 = new PointF[nPoints];
        PointF[] pt2 = new PointF[nPoints];

        for (int i = 0; i < nPoints; i++)
        {
            pt1[i] = new PointF(i / 5.0f, (float)Math.Sin(i / 5.0f));
            pt2[i] = new PointF(i / 5.0f, (float)Math.Cos(i / 5.0f));
        }

        for (int i = 1; i < nPoints; i++)
        {
            g.DrawLine(Pens.Blue, Point2D(pt1[i - 1]),Point2D(pt1[i]));
            g.DrawLine(Pens.Red, Point2D(pt2[i - 1]),Point2D(pt2[i]));
        }
    }

    private PointF Point2D(PointF ptf)
    {
        PointF aPoint = new PointF();
        if (ptf.X <xMin || ptf.X>xMax ||
            ptf.Y <yMin || ptf.Y>yMax)
        {
            ptf.X = Single.NaN;
            ptf.Y = Single.NaN;
        }

        aPoint.X= PlotArea.X + (ptf.X-xMin) * PlotArea.Width/(xMax-xMin);

        aPoint.Y = PlotArea.Bottom - (ptf.Y-yMin) * PlotArea.Height/(yMax-yMin);

        return aPoint;
    }
}
