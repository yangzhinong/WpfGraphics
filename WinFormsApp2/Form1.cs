namespace WinFormsApp2;

public partial class Form1 : Form
{
    private Rectangle PlotArea;
    private float xMin = 0f;
    private float xMax = 10f;
    private float yMin = 0f;
    private float yMax = 10f;

    private int offset = 30;
    public Form1()
    {
        InitializeComponent();
        this.SetStyle(ControlStyles.ResizeRedraw, true);
        this.BackColor = Color.White;
    }


    private PointF Point2D(PointF ptf)
    {
        PointF aPoint = new PointF();
        aPoint.X = (ptf.X - xMin) * drawingPanel.Width / (xMax - xMin);
        aPoint.Y = drawingPanel.Height - (ptf.Y - yMin) * drawingPanel.Height / (yMax - yMin);
        return aPoint;
    }

    private void drawingPanel_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        drawingPanel.Left = offset;
        drawingPanel.Top = offset;
        drawingPanel.Width = ClientRectangle.Width - 2 * offset;
        drawingPanel.Height = ClientRectangle.Height - 2 * offset;



        //g.DrawRectangle(Pens.Red, rect);

        //g.DrawRectangle(Pens.Black, PlotArea);

        var aPen = new Pen(Color.Green, 3);
        g.DrawLine(aPen, Point2D(new PointF(3, 2)), Point2D(new PointF(6, 7)));
        aPen.Dispose();
        g.Dispose();
    }

    private void Form1_SizeChanged(object sender, EventArgs e)
    {
        drawingPanel.Invalidate();
    }
}
