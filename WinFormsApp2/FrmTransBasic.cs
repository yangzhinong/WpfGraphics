﻿using System;
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
public partial class FrmTransBasic : Form
{
    public FrmTransBasic()
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
        Matrix m = new Matrix();
        m.Translate(panel1.Width / 2, panel1.Height / 2);
        if (rbTranslation.Checked)
        {
            int dx = Convert.ToInt16(tbTranslationX.Text);
            int dy = Convert.ToInt16(tbTranslationY.Text);
            m.Translate(dx, dy);
        }
        else if (rbScale.Checked)
        {
            float sx = Convert.ToSingle(tbScaleX.Text);
            float sy = Convert.ToSingle(tbScaleY.Text);
            m.Scale(sx, sy);

        }
        else if (rbRotation.Checked)
        {
            float angle = Convert.ToSingle(tbRotaionAngle.Text);
            float x = Convert.ToSingle(tbRotateAtX.Text);
            float y = Convert.ToSingle(tbRotateAtY.Text);
            g.FillEllipse(Brushes.Black, x - 4, y - 4, 8, 8);
            m.RotateAt(angle, new PointF(x, y));
        }
        else if (rbShear.Checked)
        {
            float alpha = Convert.ToSingle(tbShearX.Text);
            float beta = Convert.ToSingle(tbShearY.Text);
            m.Shear(alpha, beta);
        }
        g.Transform = m;
        DrawHouse(g, Color.Black);
    }

    private void DrawHouse(Graphics g, Color color)
    {
        HatchBrush hb = new HatchBrush(HatchStyle.HorizontalBrick, color, Color.White);
        Pen aPen = new Pen(color, 2);
        Point[] pta = new Point[5];
        pta[0] = new Point(-40, 40);
        pta[1] = new Point(40, 40);
        pta[2] = new Point(40, -40);
        pta[3] = new Point(0, -80);
        pta[4] = new Point(-40, -40);
        g.FillPolygon(hb, pta);
        g.DrawPolygon(aPen, pta);
        hb.Dispose();
        aPen.Dispose();
    }

    private void btnShow_Click(object sender, EventArgs e)
    {
        panel1.Invalidate();
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
        tbTranslationX.Text = "0";
        tbTranslationY.Text = "0";
        tbScaleX.Text = "1";
        tbScaleY.Text = "1";
        tbRotaionAngle.Text = "0";
        tbRotateAtX.Text = "0";
        tbRotateAtY.Text = "0"; 
        tbShearX.Text = "0";
        tbShearY.Text = "0";
        panel1.Invalidate();

    }
}
