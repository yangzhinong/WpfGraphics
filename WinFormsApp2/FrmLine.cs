using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2;
public partial class FrmLine : Form
{
    public FrmLine()
    {
        InitializeComponent();
        this.BackColor = Color.White;
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        Pen aPen = new Pen(Color.Blue, 4);

        aPen.StartCap = LineCap.DiamondAnchor;
        aPen.EndCap = LineCap.ArrowAnchor;
        aPen.DashStyle = DashStyle.DashDot;
        aPen.DashOffset = 50;
        g.DrawLine(aPen, 50, 30, 200, 30);

        Point point1 = new Point(50, 200);
        Point point2 = new Point(100, 75);
        Point point3 = new Point(150, 60);
        Point point4 = new Point(200, 160);
        Point point5 = new Point(250, 250);

        Point[] points = { point1, point2, point3, point4, point5 };

        g.DrawCurve(aPen, points);
        aPen.Dispose();
        g.Dispose();

    }
}
