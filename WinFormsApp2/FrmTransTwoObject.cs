using System.Drawing.Drawing2D;

namespace WinFormsApp2;
public partial class FrmTransTwoObject : Form
{
    public FrmTransTwoObject()
    {
        InitializeComponent();
        this.BackColor = Color.White;
        panel1.Paint += panel1Paint;
    }

    private void panel1Paint(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        DrawAxes(g);
        ApplyTransformation(g);
    }

    private void DrawAxes(Graphics g)
    {
        Matrix m = new Matrix();
        m.Translate(panel1.Width / 2, panel1.Height / 2);

        g.Transform = m;
        g.DrawLine(Pens.Blue, -panel1.Width / 2, 0, panel1.Width / 2, 0);
        g.DrawLine(Pens.Blue, 0, -panel1.Height / 2, 0, panel1.Height / 2);

        g.DrawString("X", this.Font, Brushes.Blue, panel1.Width / 2 - 20, -20);
        g.DrawString("Y", this.Font, Brushes.Blue, 5, -panel1.Height / 2 + 5);

        //Draw Ticks
        int tick = 40;
        StringFormat sf = new StringFormat();
        sf.Alignment = StringAlignment.Far;
        for (int i = -200; i <= 200; i += tick)
        {
            g.DrawLine(Pens.Blue, i, -3, i, 3);
            g.DrawLine(Pens.Blue, -3, i, 3, i);

            SizeF sizeXTick = g.MeasureString(i.ToString(), this.Font);
            if (i != 0)
            {
                g.DrawString(i.ToString(), this.Font, Brushes.Blue, i + sizeXTick.Width / 2, 4f, sf);
                g.DrawString((-i).ToString(), this.Font, Brushes.Blue, -3f, i - sizeXTick.Height / 2, sf);
            }
            else
            {
                g.DrawString("0", this.Font, Brushes.Blue, new PointF(i - sizeXTick.Width / 3, 4f), sf);
            }
        }
    }

    private void ApplyTransformation(Graphics g)
    {
        Pen aPen = new Pen(Color.Black, 2);
        HatchBrush hb;

        if (cbHBrickHouse.Checked)
        {
            Matrix m = new Matrix();
            m.Translate(panel1.Width / 2, panel1.Height / 2);

            int dx = Convert.ToInt16(tbRedTranslationX.Text);
            int dy = -Convert.ToInt16(tbRedTranslationY.Text);
            m.Translate(dx, dy, MatrixOrder.Append);

            float angle = Convert.ToSingle(tbRedRotaionAngle.Text);
            m.RotateAt(angle, new PointF(panel1.Width / 2, panel1.Height / 2), MatrixOrder.Append);
            g.Transform = m;

            hb = new HatchBrush(HatchStyle.HorizontalBrick, Color.Red, Color.White);

            DrawHouse(g, hb, aPen);
        }
        if (cbDBrickHouse.Checked)
        {
            // Create a new transform matrix:
            Matrix m1 = new Matrix();
            // Bring origin to the center:
            m1.Translate(panel1.Width / 2, panel1.Height / 2);
            // Rotation:
            float angle = Convert.ToSingle(tbGreenRotationAngle.Text);
            m1.RotateAt(angle, new PointF(panel1.Width / 2,
            panel1.Height / 2), MatrixOrder.Append);
            // Translation:
            int dx = Convert.ToInt16(tbGreenTranslationX.Text);
            int dy = -Convert.ToInt16(tbGreenTranslationY.Text);
            m1.Translate(dx, dy, MatrixOrder.Append);
            g.Transform = m1;
            // Define diagonal-brick brush:
            hb = new HatchBrush(HatchStyle.DiagonalBrick, Color.Green, Color.White);
            // Draw house obect by calling DrawHouse method:
            DrawHouse(g, hb, aPen);

        }
    }

    private void DrawHouse(Graphics g, HatchBrush hb, Pen aPen)
    {
        Point[] pta = new Point[5];
        pta[0] = new Point(-40, 40);
        pta[1] = new Point(40, 40);
        pta[2] = new Point(40, -40);
        pta[3] = new Point(0, -80);
        pta[4] = new Point(-40, -40);
        g.FillPolygon(hb, pta);
        g.DrawPolygon(aPen, pta);
    }

    private void btnShow_Click(object sender, EventArgs e)
    {
        panel1.Invalidate();
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
        tbRedTranslationX.Text = "0";
        tbRedTranslationY.Text = "0";

        tbRedRotaionAngle.Text = "0";

        panel1.Invalidate();

    }
}
