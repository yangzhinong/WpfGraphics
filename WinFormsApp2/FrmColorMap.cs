﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2;
public partial class FrmColorMap : Form
{
    public FrmColorMap()
    {
        InitializeComponent();
        SetStyle(ControlStyles.ResizeRedraw,true);
        BackColor = Color.White;
        this.Width = 340;
        this.Height = 340;
    }

    private void FrmColorMap_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        int width = 30;
        int height = 128;
        int y = 10;

        ColorMap cm = new ColorMap();
        Font aFont = new Font("Arial", 20, FontStyle.Bold);
        g.DrawString("OPAQUE COLOR", aFont, Brushes.Black, 10, 60);
        DrawColorBar(g, 10, y, width, height, cm, "Spring");
        DrawColorBar(g, 10 + 40, y, width, height, cm, "Summer");
        DrawColorBar(g, 10 + 2 * 40, y, width, height, cm, "Autumn");
        DrawColorBar(g, 10 + 3 * 40, y, width, height, cm, "Winter");
        DrawColorBar(g, 10 + 4 * 40, y, width, height, cm, "Jet");
        DrawColorBar(g, 10 + 5 * 40, y, width, height, cm, "Gray");
        DrawColorBar(g, 10 + 6 * 40, y, width, height, cm, "Hot");
        DrawColorBar(g, 10 + 7 * 40, y, width, height, cm, "Cool");
        y = y + 150;
        // Create transparent color maps with alpha = 150:
        ColorMap cm1 = new ColorMap(64, 150);
        g.DrawString("TRANSPARENT COLOR", aFont, Brushes.Black, 10, 210);
        DrawColorBar(g, 10, y, width, height, cm1, "Spring");
        DrawColorBar(g, 10 + 40, y, width, height, cm1, "Summer");
        DrawColorBar(g, 10 + 2 * 40, y, width, height, cm1, "Autumn");
        DrawColorBar(g, 10 + 3 * 40, y, width, height, cm1, "Winter");
        DrawColorBar(g, 10 + 4 * 40, y, width, height, cm1, "Jet");
        DrawColorBar(g, 10 + 5 * 40, y, width, height, cm1, "Gray");
        DrawColorBar(g, 10 + 6 * 40, y, width, height, cm1, "Hot");
        DrawColorBar(g, 10 + 7 * 40, y, width, height, cm1, "Cool");
    }

    private void DrawColorBar(Graphics g, int x, int y,
                            int width, int height, ColorMap map, string str)
    {
        int[,] cmap = new int[64, 4];
        switch (str)
        {
            case "Jet":
                cmap = map.Jet();
                break;
            case "Hot":
                cmap = map.Hot();
                break;
            case "Gray":
                cmap = map.Gray();
                break;
            case "Cool":
                cmap = map.Cool();
                break;
            case "Summer":
                cmap = map.Summer();
                break;
            case "Autumn":
                cmap = map.Autumn();
                break;
            case "Spring":
                cmap = map.Spring();
                break;
            case "Winter":
                cmap = map.Winter();
                break;
        }

        int ymin = 0;
        int ymax = 32;
        int dy = height / (ymax - ymin);
        int m = 64;
        for (int i = 0; i < 32; i++)
        {
            int colorIndex = (int)((i - ymin) *
            m / (ymax - ymin));
            SolidBrush aBrush = new SolidBrush(Color.FromArgb(
            cmap[colorIndex, 0], cmap[colorIndex, 1],
            cmap[colorIndex, 2], cmap[colorIndex, 3]));
            g.FillRectangle(aBrush, x, y + i * dy, width, dy);
        }
    }
}
